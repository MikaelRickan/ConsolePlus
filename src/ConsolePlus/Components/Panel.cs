using System;
using System.Linq;
using ConsolePlus.Core;

namespace ConsolePlus.Components;

/// <summary>
/// A bordered panel for content with automatic wrapping and scaling.
/// </summary>
public class Panel
{
    private string _title = "";
    private Color _titleColor = Color.Cyan;
    private Color _borderColor = Color.Gray;
    private int _padding = 1;
    private string _content = "";
    private int _width = 0; // 0 = Auto, -1 = Fluid

    public Panel(string content)
    {
        _content = content;
    }

    public Panel WithTitle(string title, Color? color = null)
    {
        _title = title;
        if (color.HasValue) _titleColor = color.Value;
        return this;
    }

    public Panel WithBorderColor(Color color)
    {
        _borderColor = color;
        return this;
    }

    public Panel WithPadding(int padding)
    {
        _padding = padding;
        return this;
    }

    public Panel Fluid()
    {
        _width = -1;
        return this;
    }

    public Panel WithWidth(int width)
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
            var tempLines = _content.Split('\n');
            int contentMax = tempLines.Max(l => Markup.GetVisibleLength(l)) + (_padding * 2);
            int titleMax = Markup.GetVisibleLength(_title) + 4;
            targetInnerWidth = Math.Max(contentMax, titleMax);
            targetInnerWidth = Math.Min(targetInnerWidth, maxWidth);
        }

        string wrapped = Markup.WrapText(_content, targetInnerWidth - (_padding * 2));
        var lines = wrapped.Replace("\r", "").Split('\n');

        // Top
        Console.Write(_borderColor.ToForegroundAnsi() + "┌");
        if (string.IsNullOrEmpty(_title))
        {
            Console.Write(new string('─', targetInnerWidth));
        }
        else
        {
            Console.Write(" ");
            Markup.Write(_title);
            Console.Write(_borderColor.ToForegroundAnsi());
            int tLen = Markup.GetVisibleLength(_title);
            Console.Write(new string('─', Math.Max(0, targetInnerWidth - tLen - 1)));
        }
        Console.WriteLine("┐" + AnsiEscapeCodes.Reset);

        // Content
        foreach (var line in lines)
        {
            var cleanLine = line.TrimEnd();
            if (string.IsNullOrEmpty(cleanLine) && line == lines.Last()) continue;
            
            Console.Write(_borderColor.ToForegroundAnsi() + "│" + AnsiEscapeCodes.Reset);
            int cLen = Markup.GetVisibleLength(cleanLine);
            int leftPad = _padding;
            int rightPad = targetInnerWidth - cLen - leftPad;

            Console.Write(new string(' ', leftPad));
            Markup.Write(cleanLine);
            Console.Write(new string(' ', Math.Max(0, rightPad)));
            Console.WriteLine(_borderColor.ToForegroundAnsi() + "│" + AnsiEscapeCodes.Reset);
        }

        // Bottom
        Console.WriteLine(_borderColor.ToForegroundAnsi() + "└" + new string('─', targetInnerWidth) + "┘" + AnsiEscapeCodes.Reset);
    }
}
