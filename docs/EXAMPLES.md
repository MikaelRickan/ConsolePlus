# ConsolePlus Examples & Showcase

ConsolePlus provides a wide range of components and features to build modern console applications. This document showcases the most common use cases.

## 🚀 Basic Initialization

To enable modern terminal features like True Color, UTF-8 emoji support, and Virtual Terminal processing (on Windows), call `Setup()` at the start of your application.

```csharp
using ConsolePlus.Core;

// Initialize the console environment
ConsoleHelper.Setup();
```

## 📝 The Markup Engine

Our markup engine allows for easy text styling with a familiar tag-based syntax.

```csharp
using ConsolePlus.Core;

Markup.WriteLine("[bold red]Critical Error:[/] Could not connect to the database.");
Markup.WriteLine("[#55FF55]Success:[/] Operation completed successfully! ✨");
Markup.WriteLine("[italic dim]Press any key to continue...[/]");
```

## 📦 UI Components

ConsolePlus includes high-level UI components that are content-aware and easy to use.

### Panels and Cards

```csharp
using ConsolePlus.Components;
using ConsolePlus.Core;

// A simple panel with a title
new Panel("Welcome to the next-generation console library.")
    .WithTitle("Greetings", Color.Cyan)
    .WithBorderColor(Color.Blue)
    .Render();

// A modern card with a title, subtitle, and footer
new Card("The quick brown fox jumps over the lazy dog.")
    .WithTitle("ANIMALS")
    .WithSubtitle("Fact of the day")
    .WithFooter("Source: Nature Magazine")
    .WithBorderColor(Color.Green)
    .Render();
```

### Tables

```csharp
using ConsolePlus.Components;

var table = new Table();
table.AddHeader("ID", "Name", "Status");
table.AddRow("001", "Worker-A", "[green]Online[/]");
table.AddRow("002", "Worker-B", "[yellow]Busy[/]");
table.AddRow("003", "Worker-C", "[red]Offline[/]");
table.Fluid().Render();
```

## ⌨️ Interactive Prompts

ConsolePlus offers a full suite of interactive prompts for user input.

```csharp
using ConsolePlus.Prompts;

// Simple selection
var choice = Prompt.Select("Choose a starter:", new[] { "Bulbasaur", "Charmander", "Squirtle" });

// Multi-selection (Space to toggle)
var items = Prompt.MultiSelect("Select features to enable:", new[] { "Logging", "Analytics", "Sync" });

// Confirmation (y/N)
bool proceed = Prompt.Confirm("Are you sure you want to delete the file?");

// Free-text input with validation
string name = Prompt.Ask("What is your name?", "DefaultUser");
```

## 🎬 Visual Effects

### Gradients and Typewriter

```csharp
using ConsolePlus.Animations;
using ConsolePlus.Core;

// Gradient text
Gradient.WriteLine("BEAUTIFUL GRADIENT HEADER", Color.FromHex("#FF0000"), Color.FromHex("#0000FF"));

// Typewriter effect
Typewriter.Write("[italic cyan]Searching for files...[/]");
```

## 🔍 More Examples

For a complete demonstration of all components, layouts, and effects, check out the sample project:

- [Main Demo (Program.cs)](../src/ConsolePlus.Sample/Program.cs)
- [Enterprise Dashboard Demo (DashboardDemo.cs)](../src/ConsolePlus.Sample/DashboardDemo.cs)
- [Retro Snake Game Demo (SnakeDemo.cs)](../src/ConsolePlus.Sample/SnakeDemo.cs)
