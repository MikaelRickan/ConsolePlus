namespace ConsolePlus.Components;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
public class Spinner : IDisposable
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
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

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public Spinner(string message, SpinnerStyle style = SpinnerStyle.Dots, ConsoleColor color = ConsoleColor.Cyan, int delayMs = 80)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    {
        _message = message;
        _style = style;
        _color = color;
        _delayMs = delayMs;
        _cursorTop = Console.CursorTop;
    }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public void Start()
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    {
        _cts = new CancellationTokenSource();
        _animationTask = Task.Run(Animate);
    }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public void Success(string message)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    {
        Stop();
        var originalColor = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"✓ {message}");
        Console.ForegroundColor = originalColor;
    }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public void Error(string message)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    {
        Stop();
        var originalColor = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"✗ {message}");
        Console.ForegroundColor = originalColor;
    }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public void Stop()
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
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

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public void Dispose()
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    {
        if (_disposed) return;
        Stop();
        _cts?.Dispose();
        _disposed = true;
    }
}

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
public enum SpinnerStyle
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    Dots,
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    Circle,
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    Square,
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    Rectangle,
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    Bar,
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    Triangle,
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    SquareRotation,
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    Vertical,
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    Arrow
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}
