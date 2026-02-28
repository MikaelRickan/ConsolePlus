using ConsolePlus.Core;
using ConsolePlus.Components;

namespace ConsolePlus.Prompts;

/// <summary>
/// Provides interactive console prompts.
/// </summary>
public static class Prompt
{
    /// <summary>
    /// Asks for a yes/no confirmation.
    /// </summary>
    public static bool Confirm(string message, bool defaultValue = true)
    {
        var suffix = defaultValue ? "[cyan](Y/n)[/]" : "[cyan](y/N)[/]";
        Markup.Write($"{message} {suffix} ");
        
        while (true)
        {
            var key = Console.ReadKey(true);
            if (key.Key == ConsoleKey.Enter) return defaultValue;
            if (key.Key == ConsoleKey.Y) { Console.WriteLine("Yes"); return true; }
            if (key.Key == ConsoleKey.N) { Console.WriteLine("No"); return false; }
        }
    }

    /// <summary>
    /// Asks for free text input.
    /// </summary>
    public static string Ask(string message, string? defaultValue = null)
    {
        var suffix = defaultValue != null ? $" [dim]({defaultValue})[/]" : "";
        Markup.Write($"{message}{suffix} ");
        
        var input = Console.ReadLine();
        return string.IsNullOrEmpty(input) ? defaultValue ?? "" : input;
    }

    /// <summary>
    /// Asks the user to select multiple options from a list.
    /// </summary>
    public static List<T> MultiSelect<T>(string message, IEnumerable<T> options) where T : notnull
    {
        var optionsList = options.ToList();
        var selectedIndexes = new HashSet<int>();
        var currentIndex = 0;
        
        Console.Write(AnsiEscapeCodes.HideCursor);
        Markup.WriteLine($"{message} [dim](Space to toggle, Enter to confirm)[/]");

        try
        {
            while (true)
            {
                for (int i = 0; i < optionsList.Count; i++)
                {
                    var isSelected = selectedIndexes.Contains(i);
                    var isCurrent = i == currentIndex;
                    
                    var checkbox = isSelected ? "[green]☑[/]" : "☐";
                    var pointer = isCurrent ? "[cyan]>[/]" : " ";
                    
                    if (isCurrent)
                    {
                        Markup.WriteLine($"  {pointer} {checkbox} [bold cyan]{optionsList[i]}[/]");
                    }
                    else
                    {
                        Markup.WriteLine($"    {checkbox} {optionsList[i]}");
                    }
                }

                var key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Enter)
                {
                    return selectedIndexes.Select(i => optionsList[i]).ToList();
                }

                if (key.Key == ConsoleKey.Spacebar)
                {
                    if (selectedIndexes.Contains(currentIndex)) selectedIndexes.Remove(currentIndex);
                    else selectedIndexes.Add(currentIndex);
                }
                else if (key.Key == ConsoleKey.UpArrow)
                {
                    currentIndex = (currentIndex == 0) ? optionsList.Count - 1 : currentIndex - 1;
                }
                else if (key.Key == ConsoleKey.DownArrow)
                {
                    currentIndex = (currentIndex == optionsList.Count - 1) ? 0 : currentIndex + 1;
                }

                // Clear
                for (int i = 0; i < optionsList.Count; i++)
                {
                    Console.Write(AnsiEscapeCodes.CursorUp);
                    Console.Write(AnsiEscapeCodes.ClearLine);
                }
                Console.Write(AnsiEscapeCodes.CarriageReturn);
            }
        }
        finally
        {
            Console.Write(AnsiEscapeCodes.ShowCursor);
        }
    }

    /// <summary>
    /// Asks the user to select an option from a list.
    /// </summary>
    public static T Select<T>(string message, IEnumerable<T> options) where T : notnull
    {
        var optionsList = options.ToList();
        var selectedIndex = 0;
        
        Console.Write(AnsiEscapeCodes.HideCursor);
        Markup.WriteLine($"{message}");

        try
        {
            while (true)
            {
                for (int i = 0; i < optionsList.Count; i++)
                {
                    if (i == selectedIndex)
                    {
                        Markup.WriteLine($"  [cyan]>[/] [bold cyan]{optionsList[i]}[/]");
                    }
                    else
                    {
                        Markup.WriteLine($"    {optionsList[i]}");
                    }
                }

                var key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Enter)
                {
                    return optionsList[selectedIndex];
                }

                if (key.Key == ConsoleKey.UpArrow)
                {
                    selectedIndex = (selectedIndex == 0) ? optionsList.Count - 1 : selectedIndex - 1;
                }
                else if (key.Key == ConsoleKey.DownArrow)
                {
                    selectedIndex = (selectedIndex == optionsList.Count - 1) ? 0 : selectedIndex + 1;
                }

                // Clear
                for (int i = 0; i < optionsList.Count; i++)
                {
                    Console.Write(AnsiEscapeCodes.CursorUp);
                    Console.Write(AnsiEscapeCodes.ClearLine);
                }
                Console.Write(AnsiEscapeCodes.CarriageReturn);
            }
        }
        finally
        {
            Console.Write(AnsiEscapeCodes.ShowCursor);
        }
    }

    /// <summary>
    /// Asks for sensitive input, masking the characters.
    /// </summary>
    public static string Secret(string message, char mask = '*')
    {
        Markup.Write($"{message} ");
        var input = new System.Text.StringBuilder();
        
        while (true)
        {
            var key = Console.ReadKey(true);
            if (key.Key == ConsoleKey.Enter)
            {
                Console.WriteLine();
                return input.ToString();
            }
            
            if (key.Key == ConsoleKey.Backspace)
            {
                if (input.Length > 0)
                {
                    input.Remove(input.Length - 1, 1);
                    Console.Write("\b \b");
                }
            }
            else if (!char.IsControl(key.KeyChar))
            {
                input.Append(key.KeyChar);
                Console.Write(mask);
            }
        }
    }

    /// <summary>
    /// Displays a full-screen or boxed menu with a title.
    /// </summary>
    public static T Menu<T>(string title, IEnumerable<T> options) where T : notnull
    {
        Rule.Render(title, Color.Cyan);
        var result = Select("Use arrows to navigate, Enter to select:", options);
        Rule.Render(character: '─');
        return result;
    }
}
