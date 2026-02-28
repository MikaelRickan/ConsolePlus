using ConsolePlus.Core;

namespace ConsolePlus.Output;

public static class ColoredOutput
{
    private static ConsoleColor GetColor(ConsoleColor fallback) => Theme.Current.Colors.Foreground;

    /// <summary>
    /// Writes text in the specified foreground color.
    /// </summary>
    public static void Write(string text, ConsoleColor color)
    {
        var originalColor = Console.ForegroundColor;
        Console.ForegroundColor = color;
        Console.Write(text);
        Console.ForegroundColor = originalColor;
    }

    /// <summary>
    /// Writes a line in the specified foreground color.
    /// </summary>
    public static void WriteLine(string text, ConsoleColor color)
    {
        Write(text, color);
        Console.WriteLine();
    }

    /// <summary>
    /// Writes text with the specified foreground and background colors.
    /// </summary>
    public static void Write(string text, ConsoleColor foreground, ConsoleColor background)
    {
        var originalForeground = Console.ForegroundColor;
        var originalBackground = Console.BackgroundColor;

        Console.ForegroundColor = foreground;
        Console.BackgroundColor = background;
        Console.Write(text);

        Console.ForegroundColor = originalForeground;
        Console.BackgroundColor = originalBackground;
    }

    /// <summary>
    /// Writes a line with the specified foreground and background colors.
    /// </summary>
    public static void WriteLine(string text, ConsoleColor foreground, ConsoleColor background)
    {
        Write(text, foreground, background);
        Console.WriteLine();
    }

    /// <summary>
    /// Writes text using ANSI 256-color mode.
    /// </summary>
    public static void Write256(string text, int foregroundColor, int? backgroundColor = null)
    {
        var fg = AnsiEscapeCodes.Foreground256(foregroundColor);
        var bg = backgroundColor.HasValue ? AnsiEscapeCodes.Background256(backgroundColor.Value) : "";
        
        Console.Write($"{fg}{bg}{text}{AnsiEscapeCodes.Reset}");
    }

    /// <summary>
    /// Writes text using ANSI RGB color mode.
    /// </summary>
    public static void WriteRgb(string text, byte fgR, byte fgG, byte fgB, byte? bgR = null, byte? bgG = null, byte? bgB = null)
    {
        var fg = AnsiEscapeCodes.ForegroundRgb(fgR, fgG, fgB);
        var bg = "";
        
        if (bgR.HasValue && bgG.HasValue && bgB.HasValue)
            bg = AnsiEscapeCodes.BackgroundRgb(bgR.Value, bgG.Value, bgB.Value);
        
        Console.Write($"{fg}{bg}{text}{AnsiEscapeCodes.Reset}");
    }

    /// <summary>
    /// Writes success message in green.
    /// </summary>
    public static void Success(string message) => WriteLine($"✓ {message}", Theme.Current.Colors.Success);

    /// <summary>
    /// Writes error message in red.
    /// </summary>
    public static void Error(string message) => WriteLine($"✗ {message}", Theme.Current.Colors.Error);

    /// <summary>
    /// Writes warning message in yellow.
    /// </summary>
    public static void Warning(string message) => WriteLine($"⚠ {message}", Theme.Current.Colors.Warning);

    /// <summary>
    /// Writes info message in cyan.
    /// </summary>
    public static void Info(string message) => WriteLine($"ℹ {message}", Theme.Current.Colors.Info);

    /// <summary>
    /// Writes debug message in gray.
    /// </summary>
    public static void Debug(string message) => WriteLine($"Debug: {message}", ConsoleColor.DarkGray);
}

