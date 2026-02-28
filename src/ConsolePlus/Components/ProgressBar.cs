using ConsolePlus.Core;

namespace ConsolePlus.Components;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
public class ProgressBar : IDisposable
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
{
    private readonly int _width;
    private char _fillCharacter;
    private char _emptyCharacter;
    private bool _showPercentage;
    private bool _showMessage;
    private ConsoleColor _fillColor;
    private ConsoleColor _backgroundColor;
    private string _message = "";
    private int _currentProgress;
    private int _totalProgress = 100;
    private bool _disposed;
    private int _cursorTop;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public ProgressBar(int width = 40, int total = 100)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    {
        _width = width;
        _totalProgress = total;
        _fillCharacter = '█';
        _emptyCharacter = '░';
        _showPercentage = true;
        _showMessage = false;
        _fillColor = ConsoleColor.Green;
        _backgroundColor = ConsoleColor.DarkGray;
    }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public ProgressBar WithFillColor(ConsoleColor color)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    {
        _fillColor = color;
        return this;
    }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public ProgressBar WithBackgroundColor(ConsoleColor color)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    {
        _backgroundColor = color;
        return this;
    }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public ProgressBar WithMessage(string message)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    {
        _message = message;
        _showMessage = true;
        return this;
    }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public ProgressBar WithFillCharacter(char character)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    {
        _fillCharacter = character;
        return this;
    }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public ProgressBar WithEmptyCharacter(char character)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    {
        _emptyCharacter = character;
        return this;
    }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public ProgressBar ShowPercentage(bool show)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    {
        _showPercentage = show;
        return this;
    }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public void Start()
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    {
        _cursorTop = Console.CursorTop;
        Render(0);
    }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public void Update(int value)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    {
        _currentProgress = Math.Clamp(value, 0, _totalProgress);
        Render(_currentProgress);
    }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public void Increment(int amount = 1)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    {
        Update(_currentProgress + amount);
    }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public void Complete()
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    {
        Update(_totalProgress);
    }

    private void Render(int progress)
    {
        var percentage = (double)progress / _totalProgress;
        var filledWidth = (int)(_width * percentage);
        var emptyWidth = _width - filledWidth;

        Console.SetCursorPosition(0, _cursorTop);

        var fill = new string(_fillCharacter, filledWidth);
        var empty = new string(_emptyCharacter, emptyWidth);

        var originalForeground = Console.ForegroundColor;
        var originalBackground = Console.BackgroundColor;

        Console.ForegroundColor = _fillColor;
        Console.Write(fill);

        Console.ForegroundColor = _backgroundColor;
        Console.Write(empty);

        Console.ResetColor();

        if (_showPercentage)
        {
            var percentText = $" {percentage * 100:F0}%";
            Console.Write(percentText);
        }

        if (_showMessage && !string.IsNullOrEmpty(_message))
        {
            Console.Write($" {_message}");
        }

        var clearLength = _width + 20 - Console.CursorLeft;
        if (clearLength > 0)
        {
            Console.Write(new string(' ', clearLength));
        }

        Console.SetCursorPosition(0, _cursorTop);
    }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public void Dispose()
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    {
        if (_disposed) return;
        
        Console.SetCursorPosition(0, _cursorTop);
        Console.Write(new string(' ', Console.WindowWidth));
        Console.SetCursorPosition(0, _cursorTop);
        
        _disposed = true;
    }
}
