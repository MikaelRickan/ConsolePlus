using ConsolePlus.Core;

namespace ConsolePlus.Components;

public class ProgressBar : IDisposable
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

    public ProgressBar(int width = 40, int total = 100)
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

    public ProgressBar WithFillColor(ConsoleColor color)
    {
        _fillColor = color;
        return this;
    }

    public ProgressBar WithBackgroundColor(ConsoleColor color)
    {
        _backgroundColor = color;
        return this;
    }

    public ProgressBar WithMessage(string message)
    {
        _message = message;
        _showMessage = true;
        return this;
    }

    public ProgressBar WithFillCharacter(char character)
    {
        _fillCharacter = character;
        return this;
    }

    public ProgressBar WithEmptyCharacter(char character)
    {
        _emptyCharacter = character;
        return this;
    }

    public ProgressBar ShowPercentage(bool show)
    {
        _showPercentage = show;
        return this;
    }

    public void Start()
    {
        _cursorTop = Console.CursorTop;
        Render(0);
    }

    public void Update(int value)
    {
        _currentProgress = Math.Clamp(value, 0, _totalProgress);
        Render(_currentProgress);
    }

    public void Increment(int amount = 1)
    {
        Update(_currentProgress + amount);
    }

    public void Complete()
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

    public void Dispose()
    {
        if (_disposed) return;
        
        Console.SetCursorPosition(0, _cursorTop);
        Console.Write(new string(' ', Console.WindowWidth));
        Console.SetCursorPosition(0, _cursorTop);
        
        _disposed = true;
    }
}
