using System.Text;

namespace ConsolePlus.Core;

/// <summary>
/// Core console writer with color and style support.
/// </summary>
public class ConsoleWriter
{
    private readonly StringBuilder _buffer = new();
    private ConsoleColor _foregroundColor = ConsoleColor.Gray;
    private ConsoleColor _backgroundColor = ConsoleColor.Black;
    private TextStyle _textStyle = TextStyle.None;

    /// <summary>
    /// Gets or sets the current foreground color.
    /// </summary>
    public ConsoleColor ForegroundColor
    {
        get => _foregroundColor;
        set => _foregroundColor = value;
    }

    /// <summary>
    /// Gets or sets the current background color.
    /// </summary>
    public ConsoleColor BackgroundColor
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
    public void Write(string text, ConsoleColor foreground, ConsoleColor? background = null)
    {
        var previousForeground = Console.ForegroundColor;
        var previousBackground = Console.BackgroundColor;

        Console.ForegroundColor = foreground;
        if (background.HasValue)
            Console.BackgroundColor = background.Value;

        Console.Write(text);

        Console.ForegroundColor = previousForeground;
        Console.BackgroundColor = previousBackground;
    }

    /// <summary>
    /// Writes text with ANSI colors.
    /// </summary>
    public void WriteAnsi(string text, string foregroundAnsi, string? backgroundAnsi = null)
    {
        var reset = AnsiEscapeCodes.Reset;
        var fg = foregroundAnsi ?? "";
        var bg = backgroundAnsi ?? "";
        
        Console.Write($"{fg}{bg}{text}{reset}");
    }

    /// <summary>
    /// Writes a line with ANSI colors.
    /// </summary>
    public void WriteLineAnsi(string text, string foregroundAnsi, string? backgroundAnsi = null)
    {
        WriteAnsi(text, foregroundAnsi, backgroundAnsi);
        Console.WriteLine();
    }

    private void ApplyColorAndStyle()
    {
        Console.ForegroundColor = _foregroundColor;
        Console.BackgroundColor = _backgroundColor;
    }

    private void ResetColorAndStyle()
    {
        Console.ResetColor();
    }

    /// <summary>
    /// Creates a new ConsoleWriter with the specified foreground color.
    /// </summary>
    public static ConsoleWriter WithColor(ConsoleColor foreground) => new() { _foregroundColor = foreground };

    /// <summary>
    /// Creates a new ConsoleWriter with the specified colors.
    /// </summary>
    public static ConsoleWriter WithColors(ConsoleColor foreground, ConsoleColor background) 
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
    None = 0,
    Bold = 1,
    Dim = 2,
    Italic = 4,
    Underline = 8,
    Blink = 16,
    Reverse = 32,
    Hidden = 64,
    Strikethrough = 128
}

