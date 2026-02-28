using ConsolePlus.Core;
using ConsolePlus.Output;

namespace ConsolePlus.Components;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
public class StatusMessage : IDisposable
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
{
    private readonly int _cursorTop;
    private bool _disposed;
    private StatusType _currentStatus = StatusType.None;
    private bool _clearOnDispose = false;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public StatusMessage()
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    {
        _cursorTop = Console.CursorTop;
    }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public StatusMessage ClearOnDispose(bool clear)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    {
        _clearOnDispose = clear;
        return this;
    }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public void Show(string message, StatusType status = StatusType.Info)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
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

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public void Success(string message) => Show(message, StatusType.Success);
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public void Error(string message) => Show(message, StatusType.Error);
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public void Warning(string message) => Show(message, StatusType.Warning);
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public void Info(string message) => Show(message, StatusType.Info);
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public void Pending(string message) => Show(message, StatusType.Pending);
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public void Clear()
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
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

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public void Dispose()
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    {
        if (_disposed) return;
        if (_clearOnDispose) Clear();
        _disposed = true;
    }
}

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
public enum StatusType
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    None,
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    Success,
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    Error,
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    Warning,
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    Info,
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    Pending
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
public static class Status
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public static void Show(string message, StatusType status = StatusType.Info)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    {
        using var statusMsg = new StatusMessage();
        statusMsg.Show(message, status);
    }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public static void Success(string message) => Show(message, StatusType.Success);
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public static void Error(string message) => Show(message, StatusType.Error);
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public static void Warning(string message) => Show(message, StatusType.Warning);
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public static void Info(string message) => Show(message, StatusType.Info);
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public static void Pending(string message) => Show(message, StatusType.Pending);
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}
