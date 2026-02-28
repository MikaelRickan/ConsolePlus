# ConsolePlus 🚀

A modern, high-performance .NET library for building beautiful, interactive, and visually appealing console applications. Inspired by tools like **Gemini CLI**, **Claude Code**, and **Kilo Code**.

## ✨ Key Features

- **True Color (RGB) Support**: Use Hex codes and 24-bit colors for a premium look.
- **Rich Markup Engine**: Simple tag-based styling: `[bold red]Error:[/] [#55FF55]Success[/] 🚀`.
- **Interactive Prompts**: 
  - `Prompt.Confirm`, `Prompt.Select`, `Prompt.MultiSelect`, `Prompt.Ask`, and `Prompt.Secret`.
- **Advanced Layouts**: 
  - **Cards**: Modern rounded-corner displays with titles and footers.
  - **Columns**: Render multiple content blocks side-by-side.
  - **Panels**: Grouped content with custom borders and padding.
  - **Tables**: Modern, markup-aware tables with rounded corners.
- **Visual Effects**: 
  - **Typewriter**: Character-by-character rendering with markup support.
  - **Gradients**: Smooth color transitions between hex values.
  - **LiveArea**: Managed "sticky" console regions for real-time updates.
- **Smart Initialization**: Automatic Windows VT (Virtual Terminal) processing and UTF-8 emoji support.

## 🚀 Quick Start

### Installation
(Coming soon to NuGet)

### Setup
```csharp
using ConsolePlus.Core;

// Initialize for modern features (VT, UTF-8, Colors)
ConsoleHelper.Setup();
```

### Basic Styling
```csharp
using ConsolePlus.Extensions;

// Fluent API
"Hello World".Bold().Cyan().WriteLine();

// Markup Engine
Markup.WriteLine("[bold #FF5555]Critical:[/] System failure detected! ✗");
```

### Interactive Prompts
```csharp
var choice = Prompt.Select("Choose your starter:", new[] { "Bulbasaur", "Charmander", "Squirtle" });
var isReady = Prompt.Confirm("Ready to begin?");
```

### Advanced Components
```csharp
new Card("Welcome to the next gen console.")
    .WithTitle("ConsolePlus V2")
    .WithBorderColor(Color.FromHex("#5555FF"))
    .Render();
```

## 🛠 Project Structure

- **Core**: Color management, ANSI codes, and the Markup engine.
- **Components**: UI elements like Cards, Panels, Tables, and Lists.
- **Prompts**: Interactive input handlers.
- **Layout**: Tools for side-by-side and persistent rendering.
- **Animations**: Effects like Typewriter and Gradients.

## 🧪 Testing

ConsolePlus is backed by a robust test suite. Run tests with:
```bash
dotnet test
```

## 📄 License

This project is licensed under the MIT License.
