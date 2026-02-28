using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace ConsolePlus.Core;

/// <summary>
/// Provides a simple markup language for styled console output.
/// Usage: [color]text[/] or [style]text[/]. Nested tags are supported.
/// Example: [bold red]Hello[/] [blue]World[/] 🚀
/// </summary>
public static class Markup
{
    private static readonly Regex TagRegex = new(@"\[(/?[a-zA-Z0-9#\s,/_ -]+)\]", RegexOptions.Compiled);

    /// <summary>
    /// Removes all markup tags from the specified text.
    /// </summary>
    public static string RemoveMarkup(string text)
    {
        if (string.IsNullOrEmpty(text)) return "";
        return TagRegex.Replace(text, "");
    }

    /// <summary>
    /// Gets the length of the text without markup tags.
    /// </summary>
    public static int GetVisibleLength(string text)
    {
        return RemoveMarkup(text).Length;
    }

    /// <summary>
    /// Wraps text to a specific width while preserving markup tags.
    /// </summary>
    public static string WrapText(string text, int maxWidth)
    {
        if (maxWidth <= 0) return text;
        var words = text.Split(' ');
        var result = new StringBuilder();
        var currentLine = new StringBuilder();
        int currentLineLength = 0;

        foreach (var word in words)
        {
            // Handle existing newlines in words
            if (word.Contains('\n'))
            {
                var parts = word.Split('\n');
                for (int i = 0; i < parts.Length; i++)
                {
                    ProcessWord(parts[i]);
                    if (i < parts.Length - 1) NewLine();
                }
                continue;
            }

            ProcessWord(word);
        }

        void ProcessWord(string word)
        {
            int wordLen = GetVisibleLength(word);
            if (currentLineLength + wordLen + (currentLineLength > 0 ? 1 : 0) > maxWidth)
            {
                NewLine();
            }

            if (currentLine.Length > 0)
            {
                currentLine.Append(' ');
                currentLineLength++;
            }

            currentLine.Append(word);
            currentLineLength += wordLen;
        }

        void NewLine()
        {
            result.AppendLine(currentLine.ToString());
            currentLine.Clear();
            currentLineLength = 0;
        }

        result.Append(currentLine);
        return result.ToString();
    }

    // --- Status Helpers ---

    public static void Success(string message) => WriteLine($"[green]✓[/] {message}");
    public static void Error(string message) => WriteLine($"[red]✗[/] {message}");
    public static void Warning(string message) => WriteLine($"[yellow]⚠[/] {message}");
    public static void Info(string message) => WriteLine($"[cyan]ℹ[/] {message}");

    public static void Write(string text)
    {
        Render(text, false);
    }

    public static void WriteLine(string text)
    {
        Render(text, true);
    }

    private static void Render(string text, bool newline)
    {
        var segments = TagRegex.Split(text);
        var matches = TagRegex.Matches(text);
        
        var styleStack = new Stack<string>();
        
        for (int i = 0; i < segments.Length; i++)
        {
            if (i % 2 == 1) // This is a tag
            {
                var tag = segments[i];
                if (tag.StartsWith("/"))
                {
                    if (styleStack.Count > 0) styleStack.Pop();
                    ApplyStyles(styleStack);
                }
                else
                {
                    styleStack.Push(tag);
                    ApplyStyles(styleStack);
                }
            }
            else // This is text
            {
                if (!string.IsNullOrEmpty(segments[i]))
                {
                    Console.Write(segments[i]);
                }
            }
        }

        Console.Write(AnsiEscapeCodes.Reset);
        if (newline) Console.WriteLine();
    }

    private static void ApplyStyles(IEnumerable<string> styles)
    {
        Console.Write(AnsiEscapeCodes.Reset);
        foreach (var styleGroup in styles)
        {
            var parts = styleGroup.Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var part in parts)
            {
                ApplyPart(part.ToLower());
            }
        }
    }

    private static void ApplyPart(string part)
    {
        // Check for hex colors
        if (part.StartsWith("#"))
        {
            try { Console.Write(Color.FromHex(part).ToForegroundAnsi()); return; } catch { }
        }

        // Check for styles
        switch (part)
        {
            case "bold": Console.Write(AnsiEscapeCodes.Bold); return;
            case "dim": Console.Write(AnsiEscapeCodes.Dim); return;
            case "italic": Console.Write(AnsiEscapeCodes.Italic); return;
            case "underline": Console.Write(AnsiEscapeCodes.Underline); return;
            case "strikethrough": Console.Write(AnsiEscapeCodes.Strikethrough); return;
            case "blink": Console.Write(AnsiEscapeCodes.Blink); return;
            case "reverse": Console.Write(AnsiEscapeCodes.Reverse); return;
        }

        // Check for standard colors
        if (Enum.TryParse<ConsoleColor>(part, true, out var consoleColor))
        {
            Console.Write(new Color(consoleColor).ToForegroundAnsi());
            return;
        }

        // Check for background colors (bg-red)
        if (part.StartsWith("bg-"))
        {
            var bgColorPart = part.Substring(3);
            if (bgColorPart.StartsWith("#"))
            {
                 try { Console.Write(Color.FromHex(bgColorPart).ToBackgroundAnsi()); return; } catch { }
            }
            if (Enum.TryParse<ConsoleColor>(bgColorPart, true, out var consoleBgColor))
            {
                Console.Write(new Color(consoleBgColor).ToBackgroundAnsi());
                return;
            }
        }
    }
}
