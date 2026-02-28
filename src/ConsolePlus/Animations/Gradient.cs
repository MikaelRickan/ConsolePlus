using System;
using ConsolePlus.Core;

namespace ConsolePlus.Animations;

/// <summary>
/// Provides methods for rendering text with color gradients.
/// </summary>
public static class Gradient
{
    /// <summary>
    /// Renders text with a horizontal gradient between two colors.
    /// </summary>
    public static void Write(string text, Color start, Color end)
    {
        var cleanText = Markup.RemoveMarkup(text);
        if (cleanText.Length == 0) return;

        // Get RGB components from Color struct via hex (simplified for now)
        // We'll add RGB accessors to Color later if needed, but for now we'll assume Color can provide them.
        // For this step, I'll add a helper to parse RGB for interpolation.

        var startRgb = GetRgb(start);
        var endRgb = GetRgb(end);

        for (int i = 0; i < cleanText.Length; i++)
        {
            float ratio = (float)i / (cleanText.Length - 1);
            byte r = (byte)(startRgb.r + (endRgb.r - startRgb.r) * ratio);
            byte g = (byte)(startRgb.g + (endRgb.g - startRgb.g) * ratio);
            byte b = (byte)(startRgb.b + (endRgb.b - startRgb.b) * ratio);

            Console.Write(AnsiEscapeCodes.ForegroundRgb(r, g, b) + cleanText[i]);
        }
        Console.Write(AnsiEscapeCodes.Reset);
    }

    public static void WriteLine(string text, Color start, Color end)
    {
        Write(text, start, end);
        Console.WriteLine();
    }

    private static (byte r, byte g, byte b) GetRgb(Color color)
    {
        // Internal hack to get RGB from the Color struct
        // In a real scenario, we'd add R, G, B properties to the Color struct.
        var ansi = color.ToForegroundAnsi();
        var match = System.Text.RegularExpressions.Regex.Match(ansi, @"2;(\d+);(\d+);(\d+)m");
        if (match.Success)
        {
            return (byte.Parse(match.Groups[1].Value), byte.Parse(match.Groups[2].Value), byte.Parse(match.Groups[3].Value));
        }
        return (128, 128, 128); // Fallback
    }
}
