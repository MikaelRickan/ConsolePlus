using ConsolePlus.Core;

namespace ConsolePlus.Sample;

public static class SnakeDemo
{
    public static void Run()
    {
        Console.Clear();
        ConsoleHelper.SetTitle("ConsolePlus | Snake Game 🐍");
        Console.CursorVisible = false;

        // Dynamic sizing based on window, but with a safe max
        int width = Math.Min(Console.WindowWidth - 4, 40);
        int height = Math.Min(Console.WindowHeight - 6, 20);
        
        var snake = new List<(int x, int y)> { (width / 2, height / 2), (width / 2 - 1, height / 2), (width / 2 - 2, height / 2) };
        var direction = (x: 1, y: 0);
        var food = (x: width * 3 / 4, y: height / 2);
        var score = 0;
        var random = new Random();

        // Header
        Markup.WriteLine($"[bold cyan]SNAKE GAME[/] - Use [bold]Arrow Keys[/] to move. [dim]Score: {score}[/]");
        
        // Starting coordinates for the board
        int startX = 1;
        int startY = 2;

        // Draw static border
        SafeSetCursor(0, startY - 1);
        Console.Write("╭" + new string('─', width) + "╮");
        for (int i = 0; i < height; i++)
        {
            SafeSetCursor(0, startY + i);
            Console.Write("│" + new string(' ', width) + "│");
        }
        SafeSetCursor(0, startY + height);
        Console.Write("╰" + new string('─', width) + "╯");

        while (true)
        {
            if (Console.KeyAvailable)
            {
                var key = Console.ReadKey(true).Key;
                direction = key switch
                {
                    ConsoleKey.UpArrow when direction.y == 0 => (0, -1),
                    ConsoleKey.DownArrow when direction.y == 0 => (0, 1),
                    ConsoleKey.LeftArrow when direction.x == 0 => (-1, 0),
                    ConsoleKey.RightArrow when direction.x == 0 => (1, 0),
                    ConsoleKey.Escape => (0, 0),
                    _ => direction
                };
                if (key == ConsoleKey.Escape) break;
            }

            var head = (x: snake[0].x + direction.x, y: snake[0].y + direction.y);

            // Collision checks
            if (head.x < 1 || head.x > width || head.y < 0 || head.y >= height || snake.Contains(head))
            {
                SafeSetCursor(0, startY + height + 1);
                Markup.WriteLine("[bold red]GAME OVER![/] Final Score: [yellow]" + score + "[/]");
                break;
            }

            snake.Insert(0, head);

            if (head == food)
            {
                score += 10;
                // Update score in header
                SafeSetCursor(0, 0);
                Markup.Write($"[bold cyan]SNAKE GAME[/] - Use [bold]Arrow Keys[/] to move. [dim]Score: {score}[/]");
                
                // New food
                food = (random.Next(1, width), random.Next(0, height));
            }
            else
            {
                var tail = snake.Last();
                SafeSetCursor(startX + tail.x - 1, startY + tail.y);
                Console.Write(" ");
                snake.RemoveAt(snake.Count - 1);
            }

            // Draw food
            SafeSetCursor(startX + food.x - 1, startY + food.y);
            Markup.Write("[red][/]");

            // Draw head
            SafeSetCursor(startX + head.x - 1, startY + head.y);
            Markup.Write("[green]■[/]");

            Thread.Sleep(100);
        }

        Console.CursorVisible = true;
    }

    private static void SafeSetCursor(int x, int y)
    {
        try
        {
            // Clamp values to buffer size
            int safeX = Math.Max(0, Math.Min(x, Console.BufferWidth - 1));
            int safeY = Math.Max(0, Math.Min(y, Console.BufferHeight - 1));
            Console.SetCursorPosition(safeX, safeY);
        }
        catch { /* Ignore if still failing in weird environments */ }
    }
}
