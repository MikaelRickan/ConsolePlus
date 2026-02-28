using ConsolePlus.Core;
using ConsolePlus.Output;

namespace ConsolePlus.Components;

public class StatusMessage : IDisposable
{
    private readonly int _cursorTop;
    private bool _disposed;
    private StatusType _currentStatus = StatusType.None;
    private bool _clearOnDispose = false;

    public StatusMessage()
    {
        _cursorTop = Console.CursorTop;
    }

    public StatusMessage ClearOnDispose(bool clear)
    {
        _clearOnDispose = clear;
        return this;
    }

    public void Show(string message, StatusType status = StatusType.Info)
    {
        Clear();
        _currentStatus = status;
        
        var (icon, color) = GetStatusIconAndColor(status);
        
        Console.SetCursorPosition(0, _cursorTop);
        
        var originalColor = Console.ForegroundColor;
        Console.ForegroundColor = color;
        Console.Write($"{icon} {message}");
        Console.ForegroundColor = originalColor;
        
        var clearLength = Console.WindowWidth - icon.Length - message.Length - 2;
        if (clearLength > 0)
        {
            Console.Write(new string(' ', clearLength));
        }
        
        Console.SetCursorPosition(0, _cursorTop);
    }

    public void Success(string message) => Show(message, StatusType.Success);
    public void Error(string message) => Show(message, StatusType.Error);
    public void Warning(string message) => Show(message, StatusType.Warning);
    public void Info(string message) => Show(message, StatusType.Info);
    public void Pending(string message) => Show(message, StatusType.Pending);

    public void Clear()
    {
        Console.SetCursorPosition(0, _cursorTop);
        Console.Write(new string(' ', Console.WindowWidth));
        Console.SetCursorPosition(0, _cursorTop);
    }

    private static (string icon, ConsoleColor color) GetStatusIconAndColor(StatusType status)
    {
        return status switch
        {
            StatusType.Success => ("✓", Theme.Current.Colors.Success),
            StatusType.Error => ("✗", Theme.Current.Colors.Error),
            StatusType.Warning => ("⚠", Theme.Current.Colors.Warning),
            StatusType.Info => ("ℹ", Theme.Current.Colors.Info),
            StatusType.Pending => ("●", Theme.Current.Colors.Info),
            _ => (" ", Theme.Current.Colors.Foreground)
        };
    }

    public void Dispose()
    {
        if (_disposed) return;
        if (_clearOnDispose) Clear();
        _disposed = true;
    }
}

public enum StatusType
{
    None,
    Success,
    Error,
    Warning,
    Info,
    Pending
}

public static class Status
{
    public static void Show(string message, StatusType status = StatusType.Info)
    {
        using var statusMsg = new StatusMessage();
        statusMsg.Show(message, status);
    }

    public static void Success(string message) => Show(message, StatusType.Success);
    public static void Error(string message) => Show(message, StatusType.Error);
    public static void Warning(string message) => Show(message, StatusType.Warning);
    public static void Info(string message) => Show(message, StatusType.Info);
    public static void Pending(string message) => Show(message, StatusType.Pending);
}
