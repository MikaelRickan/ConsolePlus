using ConsolePlus.Core;
using ConsolePlus.Output;
using ConsolePlus.Components;

namespace ConsolePlus.Extensions;

public static class ConsoleExtensions
{
    public static void WriteColored(this string text, ConsoleColor color)
    {
        ColoredOutput.Write(text, color);
    }

    public static void WriteLineColored(this string text, ConsoleColor color)
    {
        ColoredOutput.WriteLine(text, color);
    }

    public static void WriteColored(this string text, ConsoleColor foreground, ConsoleColor background)
    {
        ColoredOutput.Write(text, foreground, background);
    }

    public static void WriteLineColored(this string text, ConsoleColor foreground, ConsoleColor background)
    {
        ColoredOutput.WriteLine(text, foreground, background);
    }

    public static void WriteSuccess(this string message)
    {
        ColoredOutput.Success(message);
    }

    public static void WriteError(this string message)
    {
        ColoredOutput.Error(message);
    }

    public static void WriteWarning(this string message)
    {
        ColoredOutput.Warning(message);
    }

    public static void WriteInfo(this string message)
    {
        ColoredOutput.Info(message);
    }

    public static void WriteDebug(this string message)
    {
        ColoredOutput.Debug(message);
    }

    public static void ClearCurrentLine()
    {
        Console.Write(AnsiEscapeCodes.CarriageReturn);
        Console.Write(AnsiEscapeCodes.ClearLine);
    }

    public static void ClearLines(int count)
    {
        for (int i = 0; i < count; i++)
        {
            Console.Write(AnsiEscapeCodes.CarriageReturn);
            Console.Write(AnsiEscapeCodes.ClearLine);
            if (i < count - 1)
                Console.Write(AnsiEscapeCodes.CursorUp);
        }
    }

    public static void WriteRgb(this string text, byte r, byte g, byte b)
    {
        ColoredOutput.WriteRgb(text, r, g, b);
    }

    public static void Write256(this string text, int color)
    {
        ColoredOutput.Write256(text, color);
    }
}
