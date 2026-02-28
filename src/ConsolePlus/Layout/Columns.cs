using System;
using System.Collections.Generic;
using System.Linq;
using ConsolePlus.Core;

namespace ConsolePlus.Layout;

/// <summary>
/// Renders multiple content blocks side-by-side.
/// </summary>
public class Columns
{
    private readonly List<string> _items = new();
    private int _spacing = 2;

    public Columns(params string[] items)
    {
        _items.AddRange(items);
    }

    public Columns WithSpacing(int spacing)
    {
        _spacing = spacing;
        return this;
    }

    public void Render()
    {
        if (_items.Count == 0) return;

        var totalWidth = Console.WindowWidth - 1;
        var columnWidth = totalWidth / _items.Count;

        var allLines = _items.Select(item => item.Replace("\r", "").Split('\n').ToList()).ToList();
        var maxLines = allLines.Max(l => l.Count);

        for (int lineIndex = 0; lineIndex < maxLines; lineIndex++)
        {
            for (int colIndex = 0; colIndex < _items.Count; colIndex++)
            {
                var columnLines = allLines[colIndex];
                var line = lineIndex < columnLines.Count ? columnLines[lineIndex] : "";
                
                var visibleLength = Markup.GetVisibleLength(line);
                Markup.Write(line);
                
                if (colIndex < _items.Count - 1)
                {
                    var padding = columnWidth - visibleLength;
                    if (padding > 0) Console.Write(new string(' ', padding));
                }
            }
            Console.WriteLine();
        }
    }
}
