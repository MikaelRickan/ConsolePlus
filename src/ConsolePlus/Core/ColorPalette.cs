namespace ConsolePlus.Core;

public class ColorPalette
{
    public ConsoleColor Primary { get; init; }
    public ConsoleColor Secondary { get; init; }
    public ConsoleColor Accent { get; init; }
    public ConsoleColor Background { get; init; }
    public ConsoleColor Foreground { get; init; }
    public ConsoleColor Success { get; init; }
    public ConsoleColor Warning { get; init; }
    public ConsoleColor Error { get; init; }
    public ConsoleColor Info { get; init; }

    public static ColorPalette Default => new()
    {
        Primary = ConsoleColor.White,
        Secondary = ConsoleColor.Gray,
        Accent = ConsoleColor.Cyan,
        Background = ConsoleColor.Black,
        Foreground = ConsoleColor.Gray,
        Success = ConsoleColor.Green,
        Warning = ConsoleColor.Yellow,
        Error = ConsoleColor.Red,
        Info = ConsoleColor.Cyan
    };

    public static ColorPalette Solarized => new()
    {
        Primary = ConsoleColor.White,
        Secondary = ConsoleColor.Gray,
        Accent = ConsoleColor.Cyan,
        Background = ConsoleColor.Black,
        Foreground = ConsoleColor.DarkGray,
        Success = ConsoleColor.Green,
        Warning = ConsoleColor.Yellow,
        Error = ConsoleColor.Red,
        Info = ConsoleColor.Blue
    };

    public static ColorPalette Nord => new()
    {
        Primary = ConsoleColor.White,
        Secondary = ConsoleColor.DarkGray,
        Accent = ConsoleColor.Cyan,
        Background = ConsoleColor.Black,
        Foreground = ConsoleColor.Gray,
        Success = ConsoleColor.Green,
        Warning = ConsoleColor.Yellow,
        Error = ConsoleColor.Red,
        Info = ConsoleColor.Blue
    };

    public static ColorPalette Dracula => new()
    {
        Primary = ConsoleColor.White,
        Secondary = ConsoleColor.DarkGray,
        Accent = ConsoleColor.Magenta,
        Background = ConsoleColor.Black,
        Foreground = ConsoleColor.Gray,
        Success = ConsoleColor.Green,
        Warning = ConsoleColor.Yellow,
        Error = ConsoleColor.Red,
        Info = ConsoleColor.Cyan
    };

    public static ColorPalette Christmas => new()
    {
        Primary = ConsoleColor.White,
        Secondary = ConsoleColor.DarkGreen,
        Accent = ConsoleColor.Red,
        Background = ConsoleColor.Black,
        Foreground = ConsoleColor.Green,
        Success = ConsoleColor.Green,
        Warning = ConsoleColor.Yellow,
        Error = ConsoleColor.Red,
        Info = ConsoleColor.Cyan
    };

    public static ColorPalette Ocean => new()
    {
        Primary = ConsoleColor.White,
        Secondary = ConsoleColor.Blue,
        Accent = ConsoleColor.Cyan,
        Background = ConsoleColor.Black,
        Foreground = ConsoleColor.Blue,
        Success = ConsoleColor.Green,
        Warning = ConsoleColor.Yellow,
        Error = ConsoleColor.Red,
        Info = ConsoleColor.Cyan
    };
}
