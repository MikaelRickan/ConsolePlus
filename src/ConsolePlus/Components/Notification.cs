using ConsolePlus.Core;

namespace ConsolePlus.Components;

/// <summary>
/// Provides simple notification messages.
/// </summary>
public static class Notification
{
    public static void Show(string message, string type = "info")
    {
        var (symbol, color) = type.ToLower() switch
        {
            "success" => ("✓", "green"),
            "error" => ("✗", "red"),
            "warning" => ("⚠", "yellow"),
            _ => ("ℹ", "cyan")
        };

        Markup.WriteLine($"[{color}]{symbol}[/] {message}");
    }

    public static void Success(string message) => Show(message, "success");
    public static void Error(string message) => Show(message, "error");
    public static void Info(string message) => Show(message, "info");
    public static void Warning(string message) => Show(message, "warning");
}
