using System;
using System.Linq;
using System.Collections.Generic;
using ConsolePlus.Core;

namespace ConsolePlus.Components;

/// <summary>
/// A modern, beautiful card display with rounded corners and automatic scaling.
/// </summary>
public class Card
{
    private string _title = "";
    private string _subtitle = "";
    private string _content = "";
    private string _footer = "";
    private Color _borderColor = Color.FromHex("#444444");
    private Color _titleColor = Color.Cyan;
    private int _width = 0; // 0 = Auto, -1 = Fluid
    private int _padding = 2;

    public Card(string content)
    {
        _content = content;
    }

    public Card WithTitle(string title, Color? color = null)
    {
        _title = title;
        if (color.HasValue) _titleColor = color.Value;
        return this;
    }

    public Card WithSubtitle(string subtitle)
    {
        _subtitle = subtitle;
        return this;
    }

    public Card WithFooter(string footer)
    {
        _footer = footer;
        return this;
    }

    public Card WithBorderColor(Color color)
    {
        _borderColor = color;
        return this;
    }

    public Card Fluid()
    {
        _width = -1;
        return this;
    }

    public Card WithWidth(int width)
    {
        _width = width;
        return this;
    }

    public void Render()
    {
        int maxWidth = Console.WindowWidth - 4;
        int targetInnerWidth;

        if (_width == -1)
        {
            targetInnerWidth = maxWidth;
        }
        else if (_width > 0)
        {
            targetInnerWidth = Math.Min(_width, maxWidth);
        }
        else
        {
            // Auto-calculate
            var tempLines = _content.Split('\n');
            int contentMax = (tempLines.Length > 0 ? tempLines.Max(l => Markup.GetVisibleLength(l)) : 0) + (_padding * 2);
            int titleMax = Markup.GetVisibleLength(_title) + 6;
            int subMax = Markup.GetVisibleLength(_subtitle) + 4;
            int footMax = Markup.GetVisibleLength(_footer) + 4;
            targetInnerWidth = Math.Max(contentMax, Math.Max(titleMax, Math.Max(subMax, footMax)));
            targetInnerWidth = Math.Min(targetInnerWidth, maxWidth);
        }

        // Apply wrapping
        string wrapped = Markup.WrapText(_content, targetInnerWidth - (_padding * 2));
        var lines = wrapped.Replace("\r", "").Split('\n');

        // 1. Top Border
        Console.Write(_borderColor.ToForegroundAnsi() + "╭");
        if (!string.IsNullOrEmpty(_title))
        {
            int remaining = targetInnerWidth - Markup.GetVisibleLength(_title) - 2;
            int left = remaining / 2;
            int right = remaining - left;
            Console.Write(new string('─', left) + " " + _titleColor.ToForegroundAnsi() + AnsiEscapeCodes.Bold + _title + AnsiEscapeCodes.Reset + _borderColor.ToForegroundAnsi() + " " + new string('─', right));
        }
        else
        {
            Console.Write(new string('─', targetInnerWidth));
        }
        Console.WriteLine("╮" + AnsiEscapeCodes.Reset);

        // 2. Subtitle
        if (!string.IsNullOrEmpty(_subtitle))
        {
            WriteCenteredLine(Markup.WrapText(_subtitle, targetInnerWidth - 4), targetInnerWidth, "italic dim");
            Console.WriteLine(_borderColor.ToForegroundAnsi() + "├" + new string('─', targetInnerWidth) + "┤" + AnsiEscapeCodes.Reset);
        }

        // 3. Content
        WritePadding(targetInnerWidth);
        foreach (var line in lines)
        {
            var clean = line.TrimEnd();
            if (string.IsNullOrEmpty(clean) && line == lines.Last()) continue;

            Console.Write(_borderColor.ToForegroundAnsi() + "│" + AnsiEscapeCodes.Reset);
            int cLen = Markup.GetVisibleLength(clean);
            int leftPad = _padding;
            int rightPad = targetInnerWidth - cLen - leftPad;

            Console.Write(new string(' ', leftPad));
            Markup.Write(clean);
            Console.Write(new string(' ', Math.Max(0, rightPad)));
            Console.WriteLine(_borderColor.ToForegroundAnsi() + "│" + AnsiEscapeCodes.Reset);
        }
        WritePadding(targetInnerWidth);

        // 4. Footer
        if (!string.IsNullOrEmpty(_footer))
        {
            Console.WriteLine(_borderColor.ToForegroundAnsi() + "├" + new string('─', targetInnerWidth) + "┤" + AnsiEscapeCodes.Reset);
            WriteCenteredLine(Markup.WrapText(_footer, targetInnerWidth - 4), targetInnerWidth, "dim");
        }

        // 5. Bottom
        Console.WriteLine(_borderColor.ToForegroundAnsi() + "╰" + new string('─', targetInnerWidth) + "╯" + AnsiEscapeCodes.Reset);
    }

    private void WritePadding(int width)
    {
        Console.WriteLine(_borderColor.ToForegroundAnsi() + "│" + new string(' ', width) + "│" + AnsiEscapeCodes.Reset);
    }

    private void WriteCenteredLine(string text, int width, string style)
    {
        var lines = text.Replace("\r", "").Split('\n');
        foreach (var line in lines)
        {
            Console.Write(_borderColor.ToForegroundAnsi() + "│" + AnsiEscapeCodes.Reset);
            int vLen = Markup.GetVisibleLength(line);
            int left = (width - vLen) / 2;
            int right = width - vLen - left;
            Console.Write(new string(' ', left));
            Markup.Write($"[{style}]{line}[/]");
            Console.Write(new string(' ', right));
            Console.WriteLine(_borderColor.ToForegroundAnsi() + "│" + AnsiEscapeCodes.Reset);
        }
    }
}
