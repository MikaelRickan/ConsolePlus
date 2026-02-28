namespace ConsolePlus.Core;

/// <summary>
/// Provides ANSI escape code constants for console styling and colors.
/// </summary>
public static class AnsiEscapeCodes
{
    /// <summary>
    /// ESC character.
    /// </summary>
    public const char Escape = '\x1B';

    /// <summary>
    /// CSI (Control Sequence Introducer).
    /// </summary>
    public const string CSI = "\x1B[";

    /// <summary>
    /// Reset all attributes.
    /// </summary>
    public const string Reset = "\x1B[0m";

    // Text Styles
    public const string Bold = "\x1B[1m";
    public const string Dim = "\x1B[2m";
    public const string Italic = "\x1B[3m";
    public const string Underline = "\x1B[4m";
    public const string Blink = "\x1B[5m";
    public const string Reverse = "\x1B[7m";
    public const string Hidden = "\x1B[8m";
    public const string Strikethrough = "\x1B[9m";

    // Reset text styles
    public const string BoldOff = "\x1B[22m";
    public const string ItalicOff = "\x1B[23m";
    public const string UnderlineOff = "\x1B[24m";
    public const string BlinkOff = "\x1B[25m";
    public const string ReverseOff = "\x1B[27m";
    public const string HiddenOff = "\x1B[28m";
    public const string StrikethroughOff = "\x1B[29m";

    // Standard foreground colors (30-37)
    public const string ForegroundBlack = "\x1B[30m";
    public const string ForegroundRed = "\x1B[31m";
    public const string ForegroundGreen = "\x1B[32m";
    public const string ForegroundYellow = "\x1B[33m";
    public const string ForegroundBlue = "\x1B[34m";
    public const string ForegroundMagenta = "\x1B[35m";
    public const string ForegroundCyan = "\x1B[36m";
    public const string ForegroundWhite = "\x1B[37m";

    // Standard background colors (40-47)
    public const string BackgroundBlack = "\x1B[40m";
    public const string BackgroundRed = "\x1B[41m";
    public const string BackgroundGreen = "\x1B[42m";
    public const string BackgroundYellow = "\x1B[43m";
    public const string BackgroundBlue = "\x1B[44m";
    public const string BackgroundMagenta = "\x1B[45m";
    public const string BackgroundCyan = "\x1B[46m";
    public const string BackgroundWhite = "\x1B[47m";

    // Bright foreground colors (90-97)
    public const string ForegroundBrightBlack = "\x1B[90m";
    public const string ForegroundBrightRed = "\x1B[91m";
    public const string ForegroundBrightGreen = "\x1B[92m";
    public const string ForegroundBrightYellow = "\x1B[93m";
    public const string ForegroundBrightBlue = "\x1B[94m";
    public const string ForegroundBrightMagenta = "\x1B[95m";
    public const string ForegroundBrightCyan = "\x1B[96m";
    public const string ForegroundBrightWhite = "\x1B[97m";

    // Bright background colors (100-107)
    public const string BackgroundBrightBlack = "\x1B[100m";
    public const string BackgroundBrightRed = "\x1B[101m";
    public const string BackgroundBrightGreen = "\x1B[102m";
    public const string BackgroundBrightYellow = "\x1B[103m";
    public const string BackgroundBrightBlue = "\x1B[104m";
    public const string BackgroundBrightMagenta = "\x1B[105m";
    public const string BackgroundBrightCyan = "\x1B[106m";
    public const string BackgroundBrightWhite = "\x1B[107m";

    /// <summary>
    /// Creates a 256-color foreground escape code.
    /// </summary>
    public static string Foreground256(int color) => $"\x1B[38;5;{color}m";

    /// <summary>
    /// Creates a 256-color background escape code.
    /// </summary>
    public static string Background256(int color) => $"\x1B[48;5;{color}m";

    /// <summary>
    /// Creates an RGB foreground escape code.
    /// </summary>
    public static string ForegroundRgb(byte r, byte g, byte b) => $"\x1B[38;2;{r};{g};{b}m";

    /// <summary>
    /// Creates an RGB background escape code.
    /// </summary>
    public static string BackgroundRgb(byte r, byte g, byte b) => $"\x1B[48;2;{r};{g};{b}m";

    /// <summary>
    /// Clears the current line.
    /// </summary>
    public const string ClearLine = "\x1B[2K";

    /// <summary>
    /// Moves cursor up one line.
    /// </summary>
    public const string CursorUp = "\x1B[1A";

    /// <summary>
    /// Moves cursor down one line.
    /// </summary>
    public const string CursorDown = "\x1B[1B";

    /// <summary>
    /// Moves cursor to beginning of line.
    /// </summary>
    public const string CarriageReturn = "\r";
}

