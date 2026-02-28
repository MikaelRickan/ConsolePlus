using System;
using System.Text;

namespace ConsolePlus.Core;

/// <summary>
/// Core console writer with color and style support.
/// </summary>
public class ConsoleWriter
{
    private readonly StringBuilder _buffer = new();
    private Color _foregroundColor = ConsoleColor.Gray;
    private Color _backgroundColor = ConsoleColor.Black;
    private TextStyle _textStyle = TextStyle.None;

    /// <summary>
    /// Gets or sets the current foreground color.
    /// </summary>
    public Color ForegroundColor
    {
        get => _foregroundColor;
        set => _foregroundColor = value;
    }

    /// <summary>
    /// Gets or sets the current background color.
    /// </summary>
    public Color BackgroundColor
    {
        get => _backgroundColor;
        set => _backgroundColor = value;
    }

    /// <summary>
    /// Gets or sets the current text style.
    /// </summary>
    public TextStyle TextStyle
    {
        get => _textStyle;
        set => _textStyle = value;
    }

    /// <summary>
    /// Writes text with the current color and style.
    /// </summary>
    public void Write(string text)
    {
        ApplyColorAndStyle();
        Console.Write(text);
        ResetColorAndStyle();
    }

    /// <summary>
    /// Writes text with the current color and style, followed by a new line.
    /// </summary>
    public void WriteLine(string text)
    {
        Write(text);
        Console.WriteLine();
    }

    /// <summary>
    /// Writes text with specific colors.
    /// </summary>
    public void Write(string text, Color foreground, Color? background = null)
    {
        var fg = foreground.ToForegroundAnsi();
        var bg = background?.ToBackgroundAnsi() ?? "";
        Console.Write($"{fg}{bg}{text}{AnsiEscapeCodes.Reset}");
    }

    private void ApplyColorAndStyle()
    {
        Console.Write(_foregroundColor.ToForegroundAnsi());
        Console.Write(_backgroundColor.ToBackgroundAnsi());
        
        if (_textStyle.HasFlag(TextStyle.Bold)) Console.Write(AnsiEscapeCodes.Bold);
        if (_textStyle.HasFlag(TextStyle.Dim)) Console.Write(AnsiEscapeCodes.Dim);
        if (_textStyle.HasFlag(TextStyle.Italic)) Console.Write(AnsiEscapeCodes.Italic);
        if (_textStyle.HasFlag(TextStyle.Underline)) Console.Write(AnsiEscapeCodes.Underline);
        if (_textStyle.HasFlag(TextStyle.Strikethrough)) Console.Write(AnsiEscapeCodes.Strikethrough);
    }

    private void ResetColorAndStyle()
    {
        Console.Write(AnsiEscapeCodes.Reset);
    }

    /// <summary>
    /// Creates a new ConsoleWriter with the specified foreground color.
    /// </summary>
    public static ConsoleWriter WithColor(Color foreground) => new() { _foregroundColor = foreground };

    /// <summary>
    /// Creates a new ConsoleWriter with the specified colors.
    /// </summary>
    public static ConsoleWriter WithColors(Color foreground, Color background) 
        => new() { _foregroundColor = foreground, _backgroundColor = background };

    /// <summary>
    /// Creates a new ConsoleWriter with the specified text style.
    /// </summary>
    public static ConsoleWriter WithStyle(TextStyle style) => new() { _textStyle = style };
}

/// <summary>
/// Text styling options.
/// </summary>
[Flags]
public enum TextStyle
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    None = 0,
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    Bold = 1,
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    Dim = 2,
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    Italic = 4,
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    Underline = 8,
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    Blink = 16,
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    Reverse = 32,
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    Hidden = 64,
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    Strikethrough = 128
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}

