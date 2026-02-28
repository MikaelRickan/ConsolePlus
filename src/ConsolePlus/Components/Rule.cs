using System;
using ConsolePlus.Core;

namespace ConsolePlus.Components;

/// <summary>
/// A horizontal line with optional text.
/// </summary>
public static class Rule
{
    public static void Render(string text = "", Color? color = null, char character = '─')
    {
        color ??= ConsoleColor.Gray;
        var width = Console.WindowWidth - 1;
        
        if (string.IsNullOrEmpty(text))
        {
            Console.Write(color.Value.ToForegroundAnsi());
            Console.WriteLine(new string(character, width));
            Console.Write(AnsiEscapeCodes.Reset);
            return;
        }

        var visibleTextLength = Markup.GetVisibleLength(text);
        var textLength = visibleTextLength + 2; // +2 for spaces
        var leftWidth = (width - textLength) / 2;
        var rightWidth = width - textLength - leftWidth;

        Console.Write(color.Value.ToForegroundAnsi());
        Console.Write(new string(character, leftWidth));
        Console.Write(AnsiEscapeCodes.Reset);
        
        Console.Write(" ");
        Markup.Write(text);
        Console.Write(" ");
        
        Console.Write(color.Value.ToForegroundAnsi());
        Console.Write(new string(character, rightWidth));
        Console.WriteLine(AnsiEscapeCodes.Reset);
    }
}
