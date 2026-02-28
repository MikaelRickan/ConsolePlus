using ConsolePlus.Core;
using ConsolePlus.Components;
using ConsolePlus.Extensions;
using ConsolePlus.Prompts;
using ConsolePlus.Layout;
using ConsolePlus.Animations;
using ConsolePlus.Output;

namespace ConsolePlus.Sample;

public class Program
{
    public static void Main(string[] args)
    {
        // Initialize for modern terminal features
        ConsoleHelper.Setup();

        while (true)
        {
            Console.Clear();
            ConsoleHelper.SetTitle("ConsolePlus v2.0 | Main Menu 🚀");
            
            var choice = Prompt.Menu<string>("ConsolePlus v2.0 Demo", new[] { 
                "Visual Components", 
                "Card Displays",
                "Lists & Tables",
                "Progress & Status",
                "Interactive Prompts", 
                "Themes & Palettes",
                "Enterprise Dashboard",
                "Retro Snake Game",
                "Layouts & Side-by-Side",
                "Animations & FX",
                "Syntax Highlighting",
                "Exit" 
            });

            if (choice == "Exit") break;

            Console.Clear();
            Rule.Render(choice, Color.Yellow);
            Console.WriteLine();

            switch (choice)
            {
                case "Enterprise Dashboard":
                    DashboardDemo.Run();
                    break;

                case "Retro Snake Game":
                    SnakeDemo.Run();
                    break;
                case "Themes & Palettes":
                    Markup.WriteLine("[bold cyan]Theme Showcase Gallery:[/]");
                    Console.WriteLine();

                    // Display theme cards
                    var themeNames = new[] { "Default", "Dracula", "Nord", "Solarized", "Ocean" };
                    foreach (var tName in themeNames)
                    {
                        var palette = ColorPalette.GetByName(tName.ToLower());
                        new Card($"[bold]{tName} Palette[/]\n" +
                                 $"Primary:   [#{(byte)palette.Primary:X2}]██[/]  Secondary: [#{(byte)palette.Secondary:X2}]██[/]\n" +
                                 $"Success:   [#{(byte)palette.Success:X2}]██[/]  Error:     [#{(byte)palette.Error:X2}]██[/]\n" +
                                 $"Accent:    [#{(byte)palette.Accent:X2}]██[/]  Warning:   [#{(byte)palette.Warning:X2}]██[/]")
                            .WithTitle($"{tName} Theme", new Color(palette.Accent))
                            .WithBorderColor(new Color(palette.Primary))
                            .WithWidth(45)
                            .Render();
                        Console.WriteLine();
                    }

                    Console.WriteLine();
                    Markup.WriteLine("[bold cyan]True Color (RGB) Precision:[/]");
                    Gradient.WriteLine("  ██████████████████████████████████████████████████", Color.FromHex("#FF0000"), Color.FromHex("#00FF00"));
                    Gradient.WriteLine("  Vibrant 24-bit gradients allow for infinite brand expression.", Color.Cyan, Color.Magenta);
                    
                    Console.WriteLine();
                    var themeChoice = Prompt.Select("Apply a theme to the entire session?", themeNames);
                    Theme.Apply(themeChoice.ToLower());
                    Notification.Success($"The '{themeChoice}' theme has been applied globally!");
                    break;
                case "Visual Components":
                    Notification.Success("Components loaded successfully!");
                    Console.WriteLine();
                    
                    Markup.WriteLine("[bold cyan]Fluid Panel (Full Width):[/]");
                    new Panel("This panel automatically expands to fill the available terminal width. It will also [bold yellow]wrap text[/] if the content is too long for the screen. [italic]Try resizing your terminal and running this again![/]")
                        .WithTitle("Fluid Layout")
                        .Fluid()
                        .Render();
                    
                    Console.WriteLine();
                    Markup.WriteLine("[bold cyan]Auto-Sizing Panel:[/]");
                    new Panel("This panel only takes up as much space as it needs.")
                        .WithTitle("Compact")
                        .WithBorderColor(Color.Green)
                        .Render();
                    break;

                case "Card Displays":
                    new Card("This is a modern [bold cyan]Card[/] component.\nIt features [italic]rounded corners[/] and\nintegrated titles.")
                        .WithTitle("SYSTEM INFO")
                        .WithSubtitle("v2.0.4-beta")
                        .WithFooter("Press any key to continue")
                        .WithBorderColor(Color.FromHex("#5555FF"))
                        .Render();
                    
                    Console.WriteLine();
                    
                    new Card("[green]✓[/] API: [bold]Online[/]\n[green]✓[/] DB:  [bold]Online[/]\n[red]✗[/] S3:  [bold]Offline[/]")
                        .WithTitle("Services")
                        .WithBorderColor(Color.FromHex("#00FF00"))
                        .WithWidth(30)
                        .Render();
                    break;

                case "Lists & Tables":
                    Markup.WriteLine("[bold cyan]Fluid Table (Responsive Columns):[/]");
                    var table = new Table();
                    table.AddHeader("ID", "Feature Name", "Detailed Description of the Capability");
                    table.AddRow("V2", "Fluid Scaling", "Tables now automatically calculate column widths and wrap text within cells if the content is very long.");
                    table.AddRow("V2", "Markup Support", "You can use [bold red]colors[/] and [italic]styles[/] directly inside table cells without breaking the layout.");
                    table.Fluid().Render();

                    Console.WriteLine();
                    Markup.WriteLine("[bold cyan]Ordered List:[/]");
                    new ListView(new[] { "Automatic wrapping works here too!", "Just provide a long string and see it scale to your terminal width without breaking the bullet alignment." })
                        .Ordered()
                        .Render();
                    break;

                case "Progress & Status":
                    Markup.WriteLine("[bold cyan]Spinner:[/]");
                    using (var spinner = new Spinner("Authenticating...", SpinnerStyle.Dots, ConsoleColor.Magenta))
                    {
                        spinner.Start();
                        Thread.Sleep(2000);
                        spinner.Success("Authentication successful!");
                    }

                    Console.WriteLine();
                    Markup.WriteLine("[bold cyan]Progress Bar:[/]");
                    using (var progress = new ProgressBar(width: 40)
                        .WithMessage("Downloading models...")
                        .WithFillColor(ConsoleColor.Cyan)
                        .WithBackgroundColor(ConsoleColor.DarkGray))
                    {
                        progress.Start();
                        for (int i = 0; i <= 100; i += 5)
                        {
                            progress.Update(i);
                            Thread.Sleep(50);
                        }
                    }

                    Console.WriteLine();
                    Markup.WriteLine("[bold cyan]Status Messages:[/]");
                    using (var status = new StatusMessage())
                    {
                        status.Pending("Connecting to server...");
                        Thread.Sleep(1000);
                        status.Success("Connected!");
                        Thread.Sleep(500);
                        status.Pending("Fetching data...");
                        Thread.Sleep(1000);
                        status.Error("Failed to fetch data (timeout).");
                    }
                    break;

                case "Interactive Prompts":
                    var name = Prompt.Ask("What is your name?", "Developer");
                    var colors = Prompt.MultiSelect("Pick your favorite colors:", new[] { "Red", "Green", "Blue", "Yellow" });
                    Notification.Info($"Welcome, {name}!");
                    break;

                case "Layouts & Side-by-Side":
                    var left = "[bold green]Left Column[/]\nThis is some content.";
                    var middle = "[bold yellow]Middle Column[/]\nMore content here.";
                    var right = "[bold red]Right Column[/]\nAnd finally third.";
                    new Columns(left, middle, right).Render();
                    break;

                case "Animations & FX":
                    Gradient.WriteLine("BEAUTIFUL GRADIENT TEXT", Color.FromHex("#FF0000"), Color.FromHex("#0000FF"));
                    Console.WriteLine();
                    
                    Typewriter.Write("[italic cyan]AI is thinking about the meaning of life...[/]");
                    Console.WriteLine();
                    
                    Markup.WriteLine("Native ANSI effects: [blink red]Blinking Alert[/] or [reverse]Reversed Text[/].");
                    Console.WriteLine();

                    Markup.Write("Simulating a loading pulse: ");
                    for (int i = 0; i < 10; i++)
                    {
                        var color = i % 2 == 0 ? new Color(ConsoleColor.Cyan).ToForegroundAnsi() : new Color(ConsoleColor.DarkCyan).ToForegroundAnsi();
                        Console.Write($"\rSimulating a loading pulse: {color}██████████{AnsiEscapeCodes.Reset}");
                        Thread.Sleep(200);
                    }
                    Markup.WriteLine("\r[green]✓[/] Processing complete!                   ");
                    break;

                case "Syntax Highlighting":
                    Markup.WriteLine("[bold cyan]JSON Example:[/]");
                    var json = @"{
  ""name"": ""ConsolePlus"",
  ""version"": ""2.0.0"",
  ""isAwesome"": true,
  ""features"": 15
}";
                    SyntaxHighlighter.HighlightJson(json);
                    
                    Console.WriteLine();
                    Markup.WriteLine("[bold cyan]C# Example:[/]");
                    var code = @"using System;

public class Program 
{
    public static void Main() 
    {
        var message = ""Hello World"";
        Console.WriteLine(message);
    }
}";
                    SyntaxHighlighter.HighlightCSharp(code);
                    break;
            }

            Console.WriteLine();
            Markup.Write("\n[dim]Press any key to return to menu...[/]");
            Console.ReadKey(true);
        }

        Console.Clear();
        Markup.WriteLine("[bold #55FFFF]Thank you for trying ConsolePlus![/] ✨");
        Rule.Render(character: '─');
    }

    private static void ShowPalette(string name, ColorPalette palette)
    {
        Markup.Write($"  [bold]{name,-10}[/] ");
        var colors = new[] { palette.Primary, palette.Secondary, palette.Accent, palette.Success, palette.Warning, palette.Error, palette.Info };
        foreach (var color in colors)
        {
            Console.Write(new Color(color).ToForegroundAnsi() + "██" + AnsiEscapeCodes.Reset + " ");
        }
        Console.WriteLine();
    }
}
