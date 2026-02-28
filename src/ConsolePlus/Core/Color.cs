using System;

namespace ConsolePlus.Core;

/// <summary>
/// Represents a color in the console, supporting standard ConsoleColor, 8-bit (256 colors), and 24-bit (RGB) colors.
/// </summary>
public readonly struct Color
{
    private readonly byte? _r;
    private readonly byte? _g;
    private readonly byte? _b;
    private readonly byte? _index;
    private readonly ConsoleColor? _consoleColor;

    public Color(ConsoleColor color)
    {
        _consoleColor = color;
        _index = null;
        _r = _g = _b = null;
    }

    public Color(byte index)
    {
        _index = index;
        _consoleColor = null;
        _r = _g = _b = null;
    }

    public Color(byte r, byte g, byte b)
    {
        _r = r;
        _g = g;
        _b = b;
        _index = null;
        _consoleColor = null;
    }

    public string ToForegroundAnsi()
    {
        if (_r.HasValue) return AnsiEscapeCodes.ForegroundRgb(_r.Value, _g!.Value, _b!.Value);
        if (_index.HasValue) return AnsiEscapeCodes.Foreground256(_index.Value);
        if (_consoleColor.HasValue) return FromConsoleColor(_consoleColor.Value, true);
        return "";
    }

    public string ToBackgroundAnsi()
    {
        if (_r.HasValue) return AnsiEscapeCodes.BackgroundRgb(_r.Value, _g!.Value, _b!.Value);
        if (_index.HasValue) return AnsiEscapeCodes.Background256(_index.Value);
        if (_consoleColor.HasValue) return FromConsoleColor(_consoleColor.Value, false);
        return "";
    }

    private static string FromConsoleColor(ConsoleColor color, bool foreground)
    {
        return color switch
        {
            ConsoleColor.Black => foreground ? AnsiEscapeCodes.ForegroundBlack : AnsiEscapeCodes.BackgroundBlack,
            ConsoleColor.DarkRed => foreground ? AnsiEscapeCodes.ForegroundRed : AnsiEscapeCodes.BackgroundRed,
            ConsoleColor.DarkGreen => foreground ? AnsiEscapeCodes.ForegroundGreen : AnsiEscapeCodes.BackgroundGreen,
            ConsoleColor.DarkYellow => foreground ? AnsiEscapeCodes.ForegroundYellow : AnsiEscapeCodes.BackgroundYellow,
            ConsoleColor.DarkBlue => foreground ? AnsiEscapeCodes.ForegroundBlue : AnsiEscapeCodes.BackgroundBlue,
            ConsoleColor.DarkMagenta => foreground ? AnsiEscapeCodes.ForegroundMagenta : AnsiEscapeCodes.BackgroundMagenta,
            ConsoleColor.DarkCyan => foreground ? AnsiEscapeCodes.ForegroundCyan : AnsiEscapeCodes.BackgroundCyan,
            ConsoleColor.Gray => foreground ? AnsiEscapeCodes.ForegroundWhite : AnsiEscapeCodes.BackgroundWhite,
            ConsoleColor.DarkGray => foreground ? AnsiEscapeCodes.ForegroundBrightBlack : AnsiEscapeCodes.BackgroundBrightBlack,
            ConsoleColor.Red => foreground ? AnsiEscapeCodes.ForegroundBrightRed : AnsiEscapeCodes.BackgroundBrightRed,
            ConsoleColor.Green => foreground ? AnsiEscapeCodes.ForegroundBrightGreen : AnsiEscapeCodes.BackgroundBrightGreen,
            ConsoleColor.Yellow => foreground ? AnsiEscapeCodes.ForegroundBrightYellow : AnsiEscapeCodes.BackgroundBrightYellow,
            ConsoleColor.Blue => foreground ? AnsiEscapeCodes.ForegroundBrightBlue : AnsiEscapeCodes.BackgroundBrightBlue,
            ConsoleColor.Magenta => foreground ? AnsiEscapeCodes.ForegroundBrightMagenta : AnsiEscapeCodes.BackgroundBrightMagenta,
            ConsoleColor.Cyan => foreground ? AnsiEscapeCodes.ForegroundBrightCyan : AnsiEscapeCodes.BackgroundBrightCyan,
            ConsoleColor.White => foreground ? AnsiEscapeCodes.ForegroundBrightWhite : AnsiEscapeCodes.BackgroundBrightWhite,
            _ => ""
        };
    }

    public static implicit operator Color(ConsoleColor color) => new(color);
    
    // Common colors
    public static Color Red => new(ConsoleColor.Red);
    public static Color Green => new(ConsoleColor.Green);
    public static Color Blue => new(ConsoleColor.Blue);
    public static Color Yellow => new(ConsoleColor.Yellow);
    public static Color Cyan => new(ConsoleColor.Cyan);
    public static Color Magenta => new(ConsoleColor.Magenta);
    public static Color White => new(ConsoleColor.White);
    public static Color Black => new(ConsoleColor.Black);
    public static Color Gray => new(ConsoleColor.Gray);

    public static Color FromRgb(byte r, byte g, byte b) => new(r, g, b);
    public static Color FromIndex(byte index) => new(index);
    public static Color FromHex(string hex)
    {
        hex = hex.TrimStart('#');
        if (hex.Length != 6) throw new ArgumentException("Invalid hex color");
        byte r = Convert.ToByte(hex.Substring(0, 2), 16);
        byte g = Convert.ToByte(hex.Substring(2, 2), 16);
        byte b = Convert.ToByte(hex.Substring(4, 2), 16);
        return new Color(r, g, b);
    }
}
