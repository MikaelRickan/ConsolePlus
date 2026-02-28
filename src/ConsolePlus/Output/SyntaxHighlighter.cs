using System.Text.RegularExpressions;
using ConsolePlus.Core;

namespace ConsolePlus.Output;

/// <summary>
/// Provides basic syntax highlighting for common formats.
/// </summary>
public static class SyntaxHighlighter
{
    /// <summary>
    /// Highlights JSON syntax.
    /// </summary>
    public static void HighlightJson(string json)
    {
        // Key highlighting
        var result = Regex.Replace(json, @"""([^""]+)""\s*:", m => $"[#569CD6]\"{m.Groups[1].Value}\"[/][#D4D4D4]:[/]");
        
        // String value highlighting
        result = Regex.Replace(result, @":\s*""([^""]+)""", m => $": [#CE9178]\"{m.Groups[1].Value}\"[/]");
        
        // Number highlighting
        result = Regex.Replace(result, @":\s*(\d+(\.\d+)?)", m => $": [#B5CEA8]{m.Groups[1].Value}[/]");
        
        // Boolean and Null highlighting
        result = Regex.Replace(result, @":\s*(true|false|null)", m => $": [#569CD6]{m.Groups[1].Value}[/]");

        Markup.WriteLine(result);
    }

    /// <summary>
    /// Highlights C# syntax (basic).
    /// </summary>
    public static void HighlightCSharp(string code)
    {
        var keywords = new[] { "public", "private", "protected", "class", "void", "string", "int", "bool", "new", "using", "namespace", "static", "return", "if", "else", "foreach", "in", "var" };
        var keywordPattern = $@"\b({string.Join("|", keywords)})\b";

        // Keywords
        var result = Regex.Replace(code, keywordPattern, m => $"[#569CD6]{m.Value}[/]");
        
        // Strings
        result = Regex.Replace(result, @"""([^""]*)""", m => $"[#CE9178]\"{m.Groups[1].Value}\"[/]");
        
        // Types (PascalCase heuristic)
        result = Regex.Replace(result, @"\b([A-Z][a-zA-Z0-9]+)\b", m => $"[#4EC9B0]{m.Value}[/]");
        
        // Comments
        result = Regex.Replace(result, @"//.*", m => $"[#6A9955]{m.Value}[/]");

        Markup.WriteLine(result);
    }

    /// <summary>
    /// Highlights Markdown syntax.
    /// </summary>
    public static void HighlightMarkdown(string markdown)
    {
        var lines = markdown.Replace("\r", "").Split('\n');
        foreach (var line in lines)
        {
            if (line.StartsWith("# ")) Markup.WriteLine($"[bold #569CD6]{line}[/]");
            else if (line.StartsWith("## ")) Markup.WriteLine($"[bold cyan]{line}[/]");
            else if (line.StartsWith("### ")) Markup.WriteLine($"[bold white]{line}[/]");
            else if (line.StartsWith("- ") || line.StartsWith("* ")) Markup.WriteLine($"[cyan]•[/] {line.Substring(2)}");
            else
            {
                // Basic inline bold/italic
                var result = Regex.Replace(line, @"\*\*([^*]+)\*\*", m => $"[bold]{m.Groups[1].Value}[/]");
                result = Regex.Replace(result, @"\*([^*]+)\*", m => $"[italic]{m.Groups[1].Value}[/]");
                Markup.WriteLine(result);
            }
        }
    }
}
