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
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public const string Bold = "\x1B[1m";
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public const string Dim = "\x1B[2m";
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public const string Italic = "\x1B[3m";
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public const string Underline = "\x1B[4m";
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public const string Blink = "\x1B[5m";
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public const string Reverse = "\x1B[7m";
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public const string Hidden = "\x1B[8m";
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public const string Strikethrough = "\x1B[9m";
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member

    // Reset text styles
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public const string BoldOff = "\x1B[22m";
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public const string ItalicOff = "\x1B[23m";
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public const string UnderlineOff = "\x1B[24m";
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public const string BlinkOff = "\x1B[25m";
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public const string ReverseOff = "\x1B[27m";
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public const string HiddenOff = "\x1B[28m";
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public const string StrikethroughOff = "\x1B[29m";
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member

    // Standard foreground colors (30-37)
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public const string ForegroundBlack = "\x1B[30m";
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public const string ForegroundRed = "\x1B[31m";
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public const string ForegroundGreen = "\x1B[32m";
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public const string ForegroundYellow = "\x1B[33m";
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public const string ForegroundBlue = "\x1B[34m";
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public const string ForegroundMagenta = "\x1B[35m";
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public const string ForegroundCyan = "\x1B[36m";
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public const string ForegroundWhite = "\x1B[37m";
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member

    // Standard background colors (40-47)
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public const string BackgroundBlack = "\x1B[40m";
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public const string BackgroundRed = "\x1B[41m";
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public const string BackgroundGreen = "\x1B[42m";
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public const string BackgroundYellow = "\x1B[43m";
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public const string BackgroundBlue = "\x1B[44m";
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public const string BackgroundMagenta = "\x1B[45m";
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public const string BackgroundCyan = "\x1B[46m";
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public const string BackgroundWhite = "\x1B[47m";
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member

    // Bright foreground colors (90-97)
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public const string ForegroundBrightBlack = "\x1B[90m";
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public const string ForegroundBrightRed = "\x1B[91m";
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public const string ForegroundBrightGreen = "\x1B[92m";
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public const string ForegroundBrightYellow = "\x1B[93m";
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public const string ForegroundBrightBlue = "\x1B[94m";
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public const string ForegroundBrightMagenta = "\x1B[95m";
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public const string ForegroundBrightCyan = "\x1B[96m";
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public const string ForegroundBrightWhite = "\x1B[97m";
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member

    // Bright background colors (100-107)
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public const string BackgroundBrightBlack = "\x1B[100m";
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public const string BackgroundBrightRed = "\x1B[101m";
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public const string BackgroundBrightGreen = "\x1B[102m";
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public const string BackgroundBrightYellow = "\x1B[103m";
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public const string BackgroundBrightBlue = "\x1B[104m";
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public const string BackgroundBrightMagenta = "\x1B[105m";
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public const string BackgroundBrightCyan = "\x1B[106m";
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public const string BackgroundBrightWhite = "\x1B[107m";
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member

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

    /// <summary>
    /// Hides the console cursor.
    /// </summary>
    public const string HideCursor = "\x1B[?25l";

    /// <summary>
    /// Shows the console cursor.
    /// </summary>
    public const string ShowCursor = "\x1B[?25h";
}

