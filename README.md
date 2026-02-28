# ConsolePlus

A modern .NET 8 library that enhances console output with colors, styling, and beautiful formatting for .NET developers.

## Project Overview

**ConsolePlus** is a lightweight, developer-friendly library that transforms ordinary console applications into visually appealing experiences. Built for .NET 8, it provides intuitive APIs for colored output, styled text, progress bars, tables, spinners, and more.

## Quick Start

```bash
dotnet add package ConsolePlus
```

Or reference the project directly.

## Architecture

```
ConsolePlus/
├── src/
│   ├── ConsolePlus/           # Main library
│   │   ├── Core/
│   │   │   ├── AnsiEscapeCodes.cs   # ANSI escape sequence constants
│   │   │   ├── ColorPalette.cs      # Predefined color palettes
│   │   │   ├── ConsoleWriter.cs     # Core writing functionality
│   │   │   ├── Theme.cs            # Theme management
│   │   │   └── TextStyle.cs        # Text styling enum
│   │   ├── Output/
│   │   │   ├── ColoredOutput.cs    # Colored text output helpers
│   │   │   ├── StyledOutput.cs     # Bold, italic, underline styles
│   │   │   └── FormattedOutput.cs # JSON, XML, Markdown formatting
│   │   ├── Components/
│   │   │   ├── ProgressBar.cs      # Progress bar component
│   │   │   ├── Table.cs            # Table component
│   │   │   ├── Spinner.cs          # Loading spinner
│   │   │   └── StatusMessage.cs    # Status messages
│   │   └── Utilities/
│   │       └── ConsoleExtensions.cs # String extension methods
│   └── ConsolePlus.Sample/        # Sample/demo application
└── ConsolePlus.csproj
```

## Features

### 1. Colored Output
- Success, Error, Warning, Info, Debug messages
- Foreground and background colors
- 256-color support (ANSI)
- RGB color support
- Predefined color palettes (6 themes)
- Custom color themes

### 2. Styled Text
- Bold text
- Italic text
- Underline text
- Strikethrough
- Dimmed text
- Combined styles

### 3. Progress Bars
- Linear progress bars
- Customizable fill characters
- Percentage display
- Custom colors
- Message display
- Animated updates

### 4. Tables
- Auto-sizing columns
- Multiple border styles (Simple, Double, Rounded, Compact)
- Header styling
- Row alternation
- Column colors

### 5. Spinners
- 9 different spinner styles
- Success/Error callbacks
- Custom colors
- Async operation support

### 6. Status Messages
- In-place status updates
- Success, Error, Warning, Info, Pending states

### 7. Formatted Output
- Pretty-printed JSON with syntax highlighting
- Syntax-highlighted XML
- Markdown rendering

### 8. Themes
- Built-in themes: Default, Dark, Light, Minimal, Solarized, Nord, Dracula, Christmas, Ocean
- Theme-aware colored output
- Custom theme support

## Usage Examples

### Basic Colored Output
```csharp
using ConsolePlus.Output;

// Simple colored messages
ColoredOutput.Success("Operation completed!");
ColoredOutput.Error("Something went wrong!");
ColoredOutput.Warning("Please be careful!");
ColoredOutput.Info("Information here");
ColoredOutput.Debug("Debug message");
```

### String Extensions
```csharp
using ConsolePlus.Extensions;

"Success!".WriteSuccess();
"Error!".WriteError();
"Warning!".WriteWarning();
```

### RGB and 256-Color
```csharp
"Red text".WriteRgb(255, 100, 100);
"Color 196".Write256(196);
```

### Styled Text
```csharp
using ConsolePlus.Output;

StyledOutput.Bold("Bold text");
StyledOutput.Italic("Italic text");
StyledOutput.Underline("Underlined text");
StyledOutput.Strikethrough("Strikethrough text");
```

### Progress Bar
```csharp
using ConsolePlus.Components;

using (var progress = new ProgressBar())
{
    progress.Start();
    for (int i = 0; i <= 100; i += 10)
    {
        progress.Update(i);
        Thread.Sleep(100);
    }
}

// With custom options
using (var progress2 = new ProgressBar()
    .WithMessage("Downloading...")
    .WithFillColor(ConsoleColor.Cyan)
    .WithFillCharacter('='))
{
    progress2.Start();
    for (int i = 0; i <= 100; i += 5)
    {
        progress2.Update(i);
    }
}
```

### Table
```csharp
using ConsolePlus.Components;

var table = new Table();
table.AddHeader("Name", "Age", "City", "Status");
table.AddRow("Alice", "30", "New York", "Active");
table.AddRow("Bob", "25", "London", "Inactive");
table.WithBorderStyle(TableBorderStyle.Double)
     .WithHeaderColor(ConsoleColor.Cyan)
     .WithAlternateRowColors(true)
     .Render();
```

### Spinner
```csharp
using ConsolePlus.Components;

using (var spinner = new Spinner("Loading..."))
{
    spinner.Start();
    Thread.Sleep(2000);
    spinner.Success("Loaded successfully!");
}

// Different styles
using (var spinner2 = new Spinner("Processing...", SpinnerStyle.Circle))
{
    spinner2.Start();
    spinner2.Error("Failed!");
}
```

### Status Messages
```csharp
using ConsolePlus.Components;

// Using the class
using (var status = new StatusMessage())
{
    status.Pending("Processing...");
    status.Success("Done!");
}

// Or static helper
Status.Success("All good!");
Status.Error("Failed!");
Status.Warning("Warning!");
Status.Info("Info");
```

### JSON/XML Formatting
```csharp
using ConsolePlus.Output;

var json = @"{
    ""name"": ""John"",
    ""age"": 30,
    ""active"": true
}";
FormattedOutput.WriteJson(json);

var xml = @"<person><name>John</name><age>30</age></person>";
FormattedOutput.WriteXml(xml);
```

### Markdown Rendering
```csharp
using ConsolePlus.Output;

var md = @"# Hello
## Subtitle

This is **bold** and *italic* text.
";
FormattedOutput.WriteMarkdown(md);
```

### Themes
```csharp
using ConsolePlus.Core;

// Apply built-in theme
Theme.Apply("dracula");
ColoredOutput.Success("Success with Dracula colors!");

// Reset to default
Theme.Apply(Theme.Default);

// Create custom theme
var customTheme = new Theme
{
    Name = "MyTheme",
    Colors = new ColorPalette
    {
        Success = ConsoleColor.Green,
        Error = ConsoleColor.Red,
        Warning = ConsoleColor.Yellow,
        Info = ConsoleColor.Cyan
    }
};
Theme.Apply(customTheme);
```

## Running the Demo

```bash
dotnet run --project src/ConsolePlus.Sample/ConsolePlus.Sample.csproj
```

## Requirements

- .NET 8.0 or later
- For best results: Windows Terminal with a Nerd Font (for full emoji/symbol support)

## Version

0.1.0 - Initial release

## License

MIT License
