using ConsolePlus.Components;
using ConsolePlus.Core;
using ConsolePlus.Output;
using ConsolePlus.Extensions;

Console.WriteLine("╔════════════════════════════════════════════════════════════╗");
Console.WriteLine("║                    ConsolePlus Demo!                        ║");
Console.WriteLine("║         A modern .NET library for beautiful console        ║");
Console.WriteLine("║                        output                              ║");
Console.WriteLine("╚════════════════════════════════════════════════════════════╝");
Console.WriteLine();

Console.WriteLine("═══════════════════════════════════════════════════════════════");
Console.WriteLine("│                    COLORED OUTPUT                           │");
Console.WriteLine("═══════════════════════════════════════════════════════════════");
ColoredOutput.Success("Operation completed successfully!");
ColoredOutput.Error("An error occurred!");
ColoredOutput.Warning("This is a warning message!");
ColoredOutput.Info("Here's some information.");
ColoredOutput.Debug("Debug message for developers.");
Console.WriteLine();

Console.WriteLine("═══════════════════════════════════════════════════════════════");
Console.WriteLine("│                  STRING EXTENSIONS                          │");
Console.WriteLine("═══════════════════════════════════════════════════════════════");
"Success message via extension".WriteSuccess();
"Error message via extension".WriteError();
"Warning message via extension".WriteWarning();
"Info message via extension".WriteInfo();
Console.WriteLine();

Console.WriteLine("═══════════════════════════════════════════════════════════════");
Console.WriteLine("│                      RGB COLORS                            │");
Console.WriteLine("═══════════════════════════════════════════════════════════════");
"Red text (RGB)".WriteRgb(255, 100, 100);
"Green text (RGB)".WriteRgb(100, 255, 100);
"Blue text (RGB)".WriteRgb(100, 100, 255);
"Pink text (RGB)".WriteRgb(255, 100, 200);
"Orange text (RGB)".WriteRgb(255, 165, 0);
Console.WriteLine();

Console.WriteLine("═══════════════════════════════════════════════════════════════");
Console.WriteLine("│                    256-COLOR MODE                          │");
Console.WriteLine("═══════════════════════════════════════════════════════════════");
Console.Write("Color 196 (orange-red): "); "███████".Write256(196);
Console.Write("Color 46 (bright green): "); "███████".Write256(46);
Console.Write("Color 51 (bright cyan): "); "███████".Write256(51);
Console.Write("Color 201 (pink): "); "███████".Write256(201);
Console.Write("Color 226 (yellow): "); "███████".Write256(226);
Console.WriteLine();

Console.WriteLine("═══════════════════════════════════════════════════════════════");
Console.WriteLine("│                      STYLED TEXT                           │");
Console.WriteLine("═══════════════════════════════════════════════════════════════");
StyledOutput.Bold("Bold text");
StyledOutput.Italic("Italic text");
StyledOutput.Underline("Underlined text");
StyledOutput.Dim("Dim text");
StyledOutput.Strikethrough("Strikethrough text");
StyledOutput.Bold("Bold and italic combined");
Console.WriteLine();

Console.WriteLine("═══════════════════════════════════════════════════════════════");
Console.WriteLine("│                    PROGRESS BAR                            │");
Console.WriteLine("═══════════════════════════════════════════════════════════════");
Console.WriteLine("Default progress bar:");
using (var progress = new ProgressBar())
{
    progress.Start();
    for (int i = 0; i <= 100; i += 10)
    {
        progress.Update(i);
        Thread.Sleep(80);
    }
}
Console.WriteLine();

Console.WriteLine("Progress bar with message and custom colors:");
using (var progress2 = new ProgressBar()
    .WithMessage("Downloading files...")
    .WithFillColor(ConsoleColor.Cyan)
    .WithBackgroundColor(ConsoleColor.DarkGray))
{
    progress2.Start();
    for (int i = 0; i <= 100; i += 5)
    {
        progress2.Update(i);
        Thread.Sleep(40);
    }
}
Console.WriteLine();

Console.WriteLine("Custom fill characters:");
using (var progress3 = new ProgressBar()
    .WithFillCharacter('=')
    .WithEmptyCharacter('-')
    .WithMessage("Loading"))
{
    progress3.Start();
    for (int i = 0; i <= 100; i += 10)
    {
        progress3.Update(i);
        Thread.Sleep(60);
    }
}
Console.WriteLine();

Console.WriteLine("═══════════════════════════════════════════════════════════════");
Console.WriteLine("│                         TABLE                               │");
Console.WriteLine("═══════════════════════════════════════════════════════════════");
Console.WriteLine("Table with Double border:");
var table = new Table();
table.AddHeader("Name", "Age", "City", "Status");
table.AddRow("Alice", "30", "New York", "Active");
table.AddRow("Bob", "25", "London", "Active");
table.AddRow("Charlie", "35", "Paris", "Inactive");
table.AddRow("Diana", "28", "Tokyo", "Active");
table.WithBorderStyle(TableBorderStyle.Double)
     .WithHeaderColor(ConsoleColor.Cyan)
     .WithAlternateRowColors(true)
     .Render();
Console.WriteLine();

Console.WriteLine("Table with Simple border:");
var table2 = new Table();
table2.AddHeader("Product", "Price", "Qty");
table2.AddRow("Laptop", "$999", "5");
table2.AddRow("Phone", "$599", "10");
table2.AddRow("Tablet", "$399", "8");
table2.WithBorderStyle(TableBorderStyle.Simple)
     .WithBorderColor(ConsoleColor.Yellow)
     .Render();
Console.WriteLine();

Console.WriteLine("Table with Rounded border and column colors:");
var table3 = new Table();
table3.AddHeader("ID", "Name", "Role");
table3.AddRow("1", "John", "Admin");
table3.AddRow("2", "Jane", "User");
table3.AddRow("3", "Bob", "User");
table3.WithBorderStyle(TableBorderStyle.Rounded)
     .WithColumnColors(ConsoleColor.Yellow, ConsoleColor.Green, ConsoleColor.Cyan)
     .Render();
Console.WriteLine();

Console.WriteLine("═══════════════════════════════════════════════════════════════");
Console.WriteLine("│                       SPINNER                               │");
Console.WriteLine("═══════════════════════════════════════════════════════════════");
Console.WriteLine("Default spinner:");
using (var spinner = new Spinner("Loading data..."))
{
    spinner.Start();
    Thread.Sleep(2000);
    spinner.Success("Data loaded!");
}
Console.WriteLine();

Console.WriteLine("Circle spinner:");
using (var spinner2 = new Spinner("Processing...", SpinnerStyle.Circle, ConsoleColor.Yellow))
{
    spinner2.Start();
    Thread.Sleep(1500);
    spinner2.Error("Processing failed!");
}
Console.WriteLine();

Console.WriteLine("═══════════════════════════════════════════════════════════════");
Console.WriteLine("│                    STATUS MESSAGE                          │");
Console.WriteLine("═══════════════════════════════════════════════════════════════");
Console.WriteLine("Using StatusMessage class:");
using (var status = new StatusMessage())
{
    status.Pending("Processing request...");
    Thread.Sleep(500);
    status.Success("Request completed!");
    Thread.Sleep(500);
}
Console.WriteLine();

Console.WriteLine("Using Status helper (static):");
Status.Success("Everything is great!");
Thread.Sleep(300);
Status.Error("Something went wrong!");
Thread.Sleep(300);
Status.Warning("Please be careful!");
Thread.Sleep(300);
Status.Info("Just so you know...");
Thread.Sleep(300);
Status.Pending("Waiting for response...");
Console.WriteLine();

Console.WriteLine("═══════════════════════════════════════════════════════════════");
Console.WriteLine("│                    JSON FORMATTING                         │");
Console.WriteLine("═══════════════════════════════════════════════════════════════");
var json = @"{
    ""name"": ""John Doe"",
    ""age"": 30,
    ""email"": ""john@example.com"",
    ""address"": {
        ""city"": ""New York"",
        ""country"": ""USA""
    },
    ""active"": true,
    ""balance"": 150.50,
    ""tags"": [""developer"", ""designer""],
    ""metadata"": null
}";
FormattedOutput.WriteJson(json);
Console.WriteLine();

Console.WriteLine("═══════════════════════════════════════════════════════════════");
Console.WriteLine("│                    XML FORMATTING                          │");
Console.WriteLine("═══════════════════════════════════════════════════════════════");
var xml = @"<person>
    <name>John Doe</name>
    <age>30</age>
    <email>john@example.com</email>
    <address city=""New York"" country=""USA"" />
    <active>true</active>
    <roles>
        <role>Admin</role>
        <role>User</role>
    </roles>
</person>";
FormattedOutput.WriteXml(xml);
Console.WriteLine();

Console.WriteLine("═══════════════════════════════════════════════════════════════");
Console.WriteLine("│                   MARKDOWN FORMATTING                      │");
Console.WriteLine("═══════════════════════════════════════════════════════════════");
var markdown = @"# Heading 1
## Heading 2
### Heading 3

This is **bold text** and *italic text* and ***bold italic***.

- List item 1
- List item 2
- List item 3

1. First item
2. Second item
3. Third item

> This is a blockquote

```
// This is a code block
function hello() {
    console.log('Hello, World!');
}
```

---
";
FormattedOutput.WriteMarkdown(markdown);

Console.WriteLine("═══════════════════════════════════════════════════════════════");
Console.WriteLine("│                   COLOR PALETTES                           │");
Console.WriteLine("═══════════════════════════════════════════════════════════════");
ShowColorPalette("Default", ColorPalette.Default);
ShowColorPalette("Solarized", ColorPalette.Solarized);
ShowColorPalette("Nord", ColorPalette.Nord);
ShowColorPalette("Dracula", ColorPalette.Dracula);
ShowColorPalette("Christmas", ColorPalette.Christmas);
ShowColorPalette("Ocean", ColorPalette.Ocean);

void ShowColorPalette(string name, ColorPalette palette)
{
    Console.WriteLine($"\n{name}:");
    ShowColorSample("  Primary", palette.Primary);
    ShowColorSample("  Secondary", palette.Secondary);
    ShowColorSample("  Accent", palette.Accent);
    ShowColorSample("  Success", palette.Success);
    ShowColorSample("  Warning", palette.Warning);
    ShowColorSample("  Error", palette.Error);
    ShowColorSample("  Info", palette.Info);
}

void ShowColorSample(string label, ConsoleColor color)
{
    var original = Console.ForegroundColor;
    Console.ForegroundColor = color;
    Console.WriteLine($"{label,-12} ████████████████████");
    Console.ForegroundColor = original;
}

Console.WriteLine("═══════════════════════════════════════════════════════════════");
Console.WriteLine("│                       THEMES                               │");
Console.WriteLine("═══════════════════════════════════════════════════════════════");
Console.WriteLine("Applying Dracula theme:");
Theme.Apply("dracula");
ColoredOutput.Success("Success message with Dracula theme");
ColoredOutput.Error("Error message with Dracula theme");
ColoredOutput.Warning("Warning message with Dracula theme");
ColoredOutput.Info("Info message with Dracula theme");

Console.WriteLine("\nApplying Nord theme:");
Theme.Apply("nord");
ColoredOutput.Success("Success message with Nord theme");
ColoredOutput.Error("Error message with Nord theme");
ColoredOutput.Warning("Warning message with Nord theme");
ColoredOutput.Info("Info message with Nord theme");

Console.WriteLine("\nApplying Christmas theme:");
Theme.Apply("christmas");
ColoredOutput.Success("Success message with Christmas theme");
ColoredOutput.Error("Error message with Christmas theme");
ColoredOutput.Warning("Warning message with Christmas theme");
ColoredOutput.Info("Info message with Christmas theme");

Console.WriteLine("\nResetting to Default theme:");
Theme.Apply(Theme.Default);
ColoredOutput.Success("Back to default theme");

Console.WriteLine();
Console.WriteLine("═══════════════════════════════════════════════════════════════");
Console.WriteLine("╔════════════════════════════════════════════════════════════╗");
Console.WriteLine("║                   Demo Complete!                           ║");
Console.WriteLine("║              Thank you for using ConsolePlus!             ║");
Console.WriteLine("╚════════════════════════════════════════════════════════════╝");
