using ConsolePlus.Core;
using ConsolePlus.Components;

namespace ConsolePlus.Extensions;

/// <summary>
/// Provides extension methods for easier console output.
/// </summary>
public static class ConsoleExtensions
{
    public static void WriteSuccess(this string message) => Markup.Success(message);
    public static void WriteError(this string message) => Markup.Error(message);
    public static void WriteWarning(this string message) => Markup.Warning(message);
    public static void WriteInfo(this string message) => Markup.Info(message);
    public static void WriteDebug(this string message) => Markup.WriteLine($"[dim]DEBUG:[/] {message}");

    public static void WriteRgb(this string text, byte r, byte g, byte b) 
        => Markup.Write($"[#{r:X2}{g:X2}{b:X2}]{text}[/]");

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

    // --- Fluent API ---

    private static string Wrap(string text, string tag) => $"[{tag}]{text}[/]";

    /// <summary>Applies bold style.</summary>
    public static string Bold(this string text) => Wrap(text, "bold");
    /// <summary>Applies italic style.</summary>
    public static string Italic(this string text) => Wrap(text, "italic");
    /// <summary>Applies underline style.</summary>
    public static string Underline(this string text) => Wrap(text, "underline");
    /// <summary>Applies strikethrough style.</summary>
    public static string Strikethrough(this string text) => Wrap(text, "strikethrough");
    /// <summary>Applies dim style.</summary>
    public static string Dim(this string text) => Wrap(text, "dim");
    
    /// <summary>Applies red color.</summary>
    public static string Red(this string text) => Wrap(text, "red");
    /// <summary>Applies green color.</summary>
    public static string Green(this string text) => Wrap(text, "green");
    /// <summary>Applies blue color.</summary>
    public static string Blue(this string text) => Wrap(text, "blue");
    /// <summary>Applies yellow color.</summary>
    public static string Yellow(this string text) => Wrap(text, "yellow");
    /// <summary>Applies cyan color.</summary>
    public static string Cyan(this string text) => Wrap(text, "cyan");
    /// <summary>Applies magenta color.</summary>
    public static string Magenta(this string text) => Wrap(text, "magenta");
    
    /// <summary>Applies hex color.</summary>
    public static string Hex(this string text, string hex) => Wrap(text, hex.StartsWith("#") ? hex : $"#{hex}");
    /// <summary>Applies hex background color.</summary>
    public static string BgHex(this string text, string hex) => Wrap(text, hex.StartsWith("#") ? $"bg-{hex}" : $"bg-#{hex}");

    /// <summary>Writes the styled string to console.</summary>
    public static void Write(this string text) => Markup.Write(text);
    /// <summary>Writes the styled string to console with newline.</summary>
    public static void WriteLine(this string text) => Markup.WriteLine(text);
}
