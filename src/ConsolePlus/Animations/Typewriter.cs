using System;
using System.Threading;
using ConsolePlus.Core;

namespace ConsolePlus.Animations;

/// <summary>
/// Renders text with a typewriter effect.
/// </summary>
public static class Typewriter
{
    public static void Write(string text, int delayMs = 30)
    {
        var segments = System.Text.RegularExpressions.Regex.Split(text, @"(\[[/?[a-zA-Z0-9#\s,/_ -]+\])");
        
        foreach (var segment in segments)
        {
            if (segment.StartsWith("[") && segment.EndsWith("]"))
            {
                // It's a tag, render it immediately (no delay)
                Markup.Write(segment);
            }
            else
            {
                // It's text, render character by character
                foreach (var c in segment)
                {
                    Console.Write(c);
                    if (!char.IsWhiteSpace(c)) Thread.Sleep(delayMs);
                }
            }
        }
        Console.WriteLine();
    }
}
