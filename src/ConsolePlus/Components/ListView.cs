using System;
using System.Collections.Generic;
using ConsolePlus.Core;

namespace ConsolePlus.Components;

/// <summary>
/// Renders structured lists with bullets or numbers.
/// </summary>
public class ListView
{
    private readonly List<string> _items = new();
    private string _bullet = "•";
    private Color _bulletColor = Color.Cyan;
    private bool _ordered = false;

    public ListView(IEnumerable<string> items)
    {
        _items.AddRange(items);
    }

    public ListView WithBullet(string bullet, Color? color = null)
    {
        _bullet = bullet;
        if (color.HasValue) _bulletColor = color.Value;
        return this;
    }

    public ListView Ordered(bool ordered = true)
    {
        _ordered = ordered;
        return this;
    }

    public void Render()
    {
        for (int i = 0; i < _items.Count; i++)
        {
            var prefix = _ordered ? $"{i + 1}." : _bullet;
            
            Console.Write("  " + _bulletColor.ToForegroundAnsi() + AnsiEscapeCodes.Bold + prefix + AnsiEscapeCodes.Reset + " ");
            Markup.WriteLine(_items[i]);
        }
    }
}
