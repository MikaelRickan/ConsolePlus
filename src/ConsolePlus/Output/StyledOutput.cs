using ConsolePlus.Core;

namespace ConsolePlus.Output;

public static class StyledOutput
{
    public static void Write(string text, TextStyle style, ConsoleColor? color = null)
    {
        var ansiStyle = GetAnsiStyle(style);
        
        if (color.HasValue)
        {
            var ansiColor = GetAnsiColor(color.Value);
            Console.Write($"{ansiStyle}{ansiColor}{text}{AnsiEscapeCodes.Reset}");
        }
        else
        {
            Console.Write($"{ansiStyle}{text}{AnsiEscapeCodes.Reset}");
        }
    }

    public static void WriteLine(string text, TextStyle style, ConsoleColor? color = null)
    {
        Write(text, style, color);
        Console.WriteLine();
    }

    public static void Bold(string text, ConsoleColor? color = null)
    {
        WriteLine(text, TextStyle.Bold, color);
    }

    public static void Italic(string text, ConsoleColor? color = null)
    {
        WriteLine(text, TextStyle.Italic, color);
    }

    public static void Underline(string text, ConsoleColor? color = null)
    {
        WriteLine(text, TextStyle.Underline, color);
    }

    public static void Dim(string text, ConsoleColor? color = null)
    {
        WriteLine(text, TextStyle.Dim, color);
    }

    public static void Strikethrough(string text, ConsoleColor? color = null)
    {
        WriteLine(text, TextStyle.Strikethrough, color);
    }

    public static void Blink(string text, ConsoleColor? color = null)
    {
        WriteLine(text, TextStyle.Blink, color);
    }

    public static void Reverse(string text, ConsoleColor? color = null)
    {
        WriteLine(text, TextStyle.Reverse, color);
    }

    public static void Hidden(string text)
    {
        WriteLine(text, TextStyle.Hidden);
    }

    private static string GetAnsiStyle(TextStyle style)
    {
        var codes = new List<string>();
        
        if (style.HasFlag(TextStyle.Bold)) codes.Add(AnsiEscapeCodes.Bold);
        if (style.HasFlag(TextStyle.Dim)) codes.Add(AnsiEscapeCodes.Dim);
        if (style.HasFlag(TextStyle.Italic)) codes.Add(AnsiEscapeCodes.Italic);
        if (style.HasFlag(TextStyle.Underline)) codes.Add(AnsiEscapeCodes.Underline);
        if (style.HasFlag(TextStyle.Blink)) codes.Add(AnsiEscapeCodes.Blink);
        if (style.HasFlag(TextStyle.Reverse)) codes.Add(AnsiEscapeCodes.Reverse);
        if (style.HasFlag(TextStyle.Hidden)) codes.Add(AnsiEscapeCodes.Hidden);
        if (style.HasFlag(TextStyle.Strikethrough)) codes.Add(AnsiEscapeCodes.Strikethrough);

        return codes.Count > 0 ? string.Join("", codes) : "";
    }

    private static string GetAnsiColor(ConsoleColor color)
    {
        return color switch
        {
            ConsoleColor.Black => AnsiEscapeCodes.ForegroundBlack,
            ConsoleColor.DarkRed => AnsiEscapeCodes.ForegroundRed,
            ConsoleColor.DarkGreen => AnsiEscapeCodes.ForegroundGreen,
            ConsoleColor.DarkYellow => AnsiEscapeCodes.ForegroundYellow,
            ConsoleColor.DarkBlue => AnsiEscapeCodes.ForegroundBlue,
            ConsoleColor.DarkMagenta => AnsiEscapeCodes.ForegroundMagenta,
            ConsoleColor.DarkCyan => AnsiEscapeCodes.ForegroundCyan,
            ConsoleColor.Gray => AnsiEscapeCodes.ForegroundWhite,
            ConsoleColor.DarkGray => AnsiEscapeCodes.ForegroundBrightBlack,
            ConsoleColor.Red => AnsiEscapeCodes.ForegroundBrightRed,
            ConsoleColor.Green => AnsiEscapeCodes.ForegroundBrightGreen,
            ConsoleColor.Yellow => AnsiEscapeCodes.ForegroundBrightYellow,
            ConsoleColor.Blue => AnsiEscapeCodes.ForegroundBrightBlue,
            ConsoleColor.Magenta => AnsiEscapeCodes.ForegroundBrightMagenta,
            ConsoleColor.Cyan => AnsiEscapeCodes.ForegroundBrightCyan,
            ConsoleColor.White => AnsiEscapeCodes.ForegroundBrightWhite,
            _ => AnsiEscapeCodes.ForegroundWhite
        };
    }
}
