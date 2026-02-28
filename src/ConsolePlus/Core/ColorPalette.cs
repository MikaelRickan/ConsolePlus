namespace ConsolePlus.Core;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
public class ColorPalette
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public ConsoleColor Primary { get; init; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public ConsoleColor Secondary { get; init; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public ConsoleColor Accent { get; init; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public ConsoleColor Background { get; init; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public ConsoleColor Foreground { get; init; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public ConsoleColor Success { get; init; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public ConsoleColor Warning { get; init; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public ConsoleColor Error { get; init; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public ConsoleColor Info { get; init; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    /// <summary>
    /// Gets a palette by name.
    /// </summary>
    public static ColorPalette GetByName(string name)
    {
        return name.ToLower() switch
        {
            "solarized" => Solarized,
            "nord" => Nord,
            "dracula" => Dracula,
            "christmas" => Christmas,
            "ocean" => Ocean,
            _ => Default
        };
    }

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
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
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
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
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
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
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
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
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
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
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
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}
