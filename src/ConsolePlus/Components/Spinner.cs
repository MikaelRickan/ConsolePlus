namespace ConsolePlus.Components;

public class Spinner : IDisposable
{
    private readonly string _message;
    private readonly SpinnerStyle _style;
    private readonly ConsoleColor _color;
    private readonly int _delayMs;
    private readonly int _cursorTop;
    private int _frameIndex;
    private bool _disposed;
    private CancellationTokenSource? _cts;
    private Task? _animationTask;

    private static readonly string[][] Frames = new[]
    {
        new[] { "⠋", "⠙", "⠹", "⠸", "⠼", "⠴", "⠦", "⠧", "⠇", "⠏" },
        new[] { "◐", "◑", "◒", "◓" },
        new[] { "▖", "▗", "▘", "▝" },
        new[] { "▌", "▀", "▐", "▄" },
        new[] { "■", "□" },
        new[] { "◢", "◣", "◤", "◥" },
        new[] { "◰", "◳", "◲", "◱" },
        new[] { "▇", "▆", "▅", "▄", "▃", "▂" },
        new[] { "←", "↑", "→", "↓" },
    };

    public Spinner(string message, SpinnerStyle style = SpinnerStyle.Dots, ConsoleColor color = ConsoleColor.Cyan, int delayMs = 80)
    {
        _message = message;
        _style = style;
        _color = color;
        _delayMs = delayMs;
        _cursorTop = Console.CursorTop;
    }

    public void Start()
    {
        _cts = new CancellationTokenSource();
        _animationTask = Task.Run(Animate);
    }

    public void Success(string message)
    {
        Stop();
        var originalColor = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"✓ {message}");
        Console.ForegroundColor = originalColor;
    }

    public void Error(string message)
    {
        Stop();
        var originalColor = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"✗ {message}");
        Console.ForegroundColor = originalColor;
    }

    public void Stop()
    {
        _cts?.Cancel();
        try
        {
            _animationTask?.Wait(TimeSpan.FromMilliseconds(100));
        }
        catch (AggregateException) { }

        Console.SetCursorPosition(0, _cursorTop);
        Console.Write(new string(' ', Console.WindowWidth));
        Console.SetCursorPosition(0, _cursorTop);
    }

    private void Animate()
    {
        var frames = Frames[(int)_style];
        var originalColor = Console.ForegroundColor;

        while (!_cts!.Token.IsCancellationRequested)
        {
            var frame = frames[_frameIndex % frames.Length];
            
            Console.SetCursorPosition(0, _cursorTop);
            
            Console.ForegroundColor = _color;
            Console.Write($"{frame} {_message}");
            
            var clearLength = 50 - Console.CursorLeft;
            if (clearLength > 0)
                Console.Write(new string(' ', clearLength));

            Console.SetCursorPosition(0, _cursorTop);

            _frameIndex++;
            Thread.Sleep(_delayMs);
        }

        Console.ForegroundColor = originalColor;
    }

    public void Dispose()
    {
        if (_disposed) return;
        Stop();
        _cts?.Dispose();
        _disposed = true;
    }
}

public enum SpinnerStyle
{
    Dots,
    Circle,
    Square,
    Rectangle,
    Bar,
    Triangle,
    SquareRotation,
    Vertical,
    Arrow
}
