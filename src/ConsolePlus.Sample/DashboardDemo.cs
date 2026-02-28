using ConsolePlus.Core;
using ConsolePlus.Layout;
using ConsolePlus.Components;

namespace ConsolePlus.Sample;

public static class DashboardDemo
{
    public static void Run()
    {
        Console.Clear();
        ConsoleHelper.SetTitle("ConsolePlus | Cloud Dashboard ☁️");
        
        using (var live = new LiveArea())
        {
            var random = new Random();
            var logs = new List<string> { 
                "[dim]System initialized.[/]", 
                "[green]✓[/] Connectivity established." 
            };

            const int TotalWidth = 70;
            const int InnerWidth = TotalWidth - 2;

            for (int i = 0; i < 15; i++)
            {
                var cpu = random.Next(5, 95);
                var ram = random.Next(20, 80);
                var disk = random.Next(10, 40);

                if (i % 3 == 0) {
                    var events = new[] { 
                        "[cyan]ℹ[/] Scaling group updated.", 
                        "[green]✓[/] Database backup finished.", 
                        "[yellow]⚠[/] Latency spike in US-EAST." 
                    };
                    logs.Add($"[dim]{DateTime.Now:HH:mm:ss}[/] {events[random.Next(events.Length)]}");
                    if (logs.Count > 6) logs.RemoveAt(0);
                }

                var output = new System.Text.StringBuilder();
                
                // 1. Top Border
                output.AppendLine("[bold #5555FF]╭─ CLOUD INFRASTRUCTURE MONITOR " + new string('─', InnerWidth - 30) + "╮[/]");
                output.AppendLine("│" + new string(' ', InnerWidth) + "│");
                
                // 2. Stats Row
                output.Append("│  ");
                output.Append(FormatMiniCard("CPU", cpu, "#55FFFF"));
                output.Append("   ");
                output.Append(FormatMiniCard("RAM", ram, "#55FF55"));
                output.Append("   ");
                output.Append(FormatMiniCard("NET", disk, "#FFFF55"));
                output.AppendLine("  │");
                
                output.AppendLine("│" + new string(' ', InnerWidth) + "│");
                
                // 3. Middle Separator
                output.AppendLine("[bold #5555FF]├─ RECENT SYSTEM EVENTS " + new string('─', InnerWidth - 23) + "┤[/]");
                
                // 4. Log Section
                foreach (var log in logs)
                {
                    var visibleLen = Markup.GetVisibleLength(log);
                    var padding = InnerWidth - visibleLen - 4;
                    output.AppendLine($"│  {log}{new string(' ', Math.Max(0, padding))}  │");
                }
                
                // Fill remaining log space
                for (int j = 0; j < 6 - logs.Count; j++)
                    output.AppendLine("│" + new string(' ', InnerWidth) + "│");

                // 5. Bottom Border
                output.AppendLine("[bold #5555FF]╰" + new string('─', InnerWidth) + "╯[/]");
                
                // Status Line
                var statusLine = $"  [dim]Global Status: [/][bold green]HEALTHY[/] [dim]| Nodes: 12 Active[/]";
                output.AppendLine(statusLine);

                live.Update(output.ToString());
                Thread.Sleep(400);
            }
        }
        
        Console.WriteLine("\n[dim]Dashboard sequence finished.[/]");
    }

    private static string FormatMiniCard(string label, int value, string color)
    {
        // Total width per card: 3 + 1 + 10 + 1 + 4 = 19
        var bar = new string('█', value / 10) + new string('░', 10 - (value / 10));
        return $"[bold]{label}:[/] [{color}]{bar}[/] [bold]{value,2}%[/]";
    }
}
