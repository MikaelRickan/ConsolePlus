using System;
using System.Collections.Generic;
using System.Linq;
using ConsolePlus.Core;

namespace ConsolePlus.Components;

/// <summary>
/// A modern table component with rounded borders, markup support, and automatic scaling.
/// </summary>
public class Table
{
    private string[] _headers = Array.Empty<string>();
    private readonly List<string[]> _rows = new();
    private Color _borderColor = Color.FromHex("#444444");
    private Color _headerColor = Color.Cyan;
    private bool _widthFluid = false;

    public void AddHeader(params string[] headers)
    {
        _headers = headers;
    }

    public void AddRow(params string[] row)
    {
        _rows.Add(row);
    }

    public Table Fluid()
    {
        _widthFluid = true;
        return this;
    }

    public Table WithBorderColor(Color color)
    {
        _borderColor = color;
        return this;
    }

    public Table WithHeaderColor(Color color)
    {
        _headerColor = color;
        return this;
    }

    public void Render()
    {
        if (_headers.Length == 0 && _rows.Count == 0) return;

        int columnCount = Math.Max(_headers.Length, _rows.Count > 0 ? _rows.Max(r => r.Length) : 0);
        int[] columnWidths = new int[columnCount];
        int maxWidth = Console.WindowWidth - (columnCount + 1); // Account for borders

        // 1. Calculate ideal widths
        for (int i = 0; i < columnCount; i++)
        {
            int max = i < _headers.Length ? Markup.GetVisibleLength(_headers[i]) : 0;
            foreach (var row in _rows)
            {
                if (i < row.Length)
                    max = Math.Max(max, Markup.GetVisibleLength(row[i]));
            }
            columnWidths[i] = max + 2; // +2 for cell padding
        }

        // 2. Scale down if necessary
        int totalWidth = columnWidths.Sum();
        if (totalWidth > maxWidth || _widthFluid)
        {
            // Simple proportional scaling
            double ratio = (double)maxWidth / totalWidth;
            if (_widthFluid) ratio = (double)maxWidth / totalWidth;
            
            for (int i = 0; i < columnCount; i++)
            {
                columnWidths[i] = Math.Max(5, (int)(columnWidths[i] * ratio));
            }
            
            // Adjust last column for rounding errors
            int newTotal = columnWidths.Sum();
            columnWidths[columnCount - 1] += (maxWidth - newTotal);
        }

        // 3. Render
        RenderBorder("╭", "┬", "╮", columnWidths);
        
        if (_headers.Length > 0)
        {
            RenderRow(_headers, columnWidths, _headerColor, true);
            RenderBorder("├", "┼", "┤", columnWidths);
        }

        foreach (var row in _rows)
        {
            RenderRow(row, columnWidths);
        }

        RenderBorder("╰", "┴", "╯", columnWidths);
    }

    private void RenderBorder(string left, string mid, string right, int[] widths)
    {
        Console.Write(_borderColor.ToForegroundAnsi() + left);
        for (int i = 0; i < widths.Length; i++)
        {
            Console.Write(new string('─', widths[i]));
            if (i < widths.Length - 1) Console.Write(mid);
        }
        Console.WriteLine(right + AnsiEscapeCodes.Reset);
    }

    private void RenderRow(string[] row, int[] widths, Color? color = null, bool bold = false)
    {
        // Handle wrapping in cells by splitting into sub-rows
        var cellLines = new List<string[]>();
        int maxLines = 1;

        for (int i = 0; i < widths.Length; i++)
        {
            var text = i < row.Length ? row[i] : "";
            var wrapped = Markup.WrapText(text, widths[i] - 2);
            var lines = wrapped.Replace("\r", "").Split('\n');
            cellLines.Add(lines);
            maxLines = Math.Max(maxLines, lines.Length);
        }

        for (int lineIndex = 0; lineIndex < maxLines; lineIndex++)
        {
            Console.Write(_borderColor.ToForegroundAnsi() + "│" + AnsiEscapeCodes.Reset);
            for (int i = 0; i < widths.Length; i++)
            {
                var line = lineIndex < cellLines[i].Length ? cellLines[i][lineIndex].Trim() : "";
                WriteCell(line, widths[i], color, bold);
                Console.Write(_borderColor.ToForegroundAnsi() + "│" + AnsiEscapeCodes.Reset);
            }
            Console.WriteLine();
        }
    }

    private void WriteCell(string text, int width, Color? color, bool bold)
    {
        Console.Write(" ");
        if (color.HasValue) Console.Write(color.Value.ToForegroundAnsi());
        if (bold) Console.Write(AnsiEscapeCodes.Bold);
        
        Markup.Write(text);
        
        Console.Write(AnsiEscapeCodes.Reset);
        int padding = width - Markup.GetVisibleLength(text) - 1;
        if (padding > 0) Console.Write(new string(' ', padding));
    }
}
