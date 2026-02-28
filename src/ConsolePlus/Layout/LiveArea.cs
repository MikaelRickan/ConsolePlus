using System;
using ConsolePlus.Core;

namespace ConsolePlus.Layout;

/// <summary>
/// Manages a persistent area of the console for live updates.
/// </summary>
public class LiveArea : IDisposable
{
    private int _startTop;
    private int _lineCount;
    private bool _started;

    public void Start()
    {
        _startTop = Console.CursorTop;
        _started = true;
    }

    /// <summary>
    /// Re-renders the content in the live area.
    /// </summary>
    public void Update(string content)
    {
        if (!_started) Start();

        var lines = content.Replace("\r", "").Split('\n');
        
        // Clear previous lines by moving back to start
        Console.SetCursorPosition(0, _startTop);
        for (int i = 0; i < Math.Max(_lineCount, lines.Length); i++)
        {
             Console.Write(AnsiEscapeCodes.ClearLine);
             Console.WriteLine();
        }
        Console.SetCursorPosition(0, _startTop);

        foreach (var line in lines)
        {
            Markup.WriteLine(line);
        }

        _lineCount = lines.Length;
    }

    public void Dispose()
    {
        Console.SetCursorPosition(0, _startTop + _lineCount);
    }
}
