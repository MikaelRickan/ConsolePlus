# ConsolePlus Developer Guide

Welcome to the ConsolePlus developer guide! This document provides information on how to contribute to the project and maintain the codebase.

## 🛠 Prerequisites

- .NET 8.0 SDK or later.
- A terminal with True Color support (Windows Terminal, VS Code Terminal, iTerm2, etc.).

## 🚀 Getting Started

### Building the Project
To build the entire solution, run the following command from the root directory:
```bash
dotnet build src/ConsolePlus.sln
```

### Running the Sample Application
To see the library in action, run the sample project:
```bash
dotnet run --project src/ConsolePlus.Sample/ConsolePlus.Sample.csproj
```

### Running Tests
We use xUnit for testing. Run all tests with:
```bash
dotnet test src/ConsolePlus.sln
```

## 📂 Project Structure

- `src/ConsolePlus/`: The core library containing all components, layouts, and engine logic.
  - `Animations/`: Effects like Typewriter and Gradients.
  - `Components/`: UI elements (Cards, Panels, Tables, etc.).
  - `Core/`: The foundation (Color, Markup, ANSI codes).
  - `Layout/`: Positioning and multi-column rendering.
  - `Prompts/`: Interactive input handlers.
- `src/ConsolePlus.Sample/`: A comprehensive demo application showcasing all features.
- `src/ConsolePlus.Tests/`: Unit and integration tests.
- `docs/`: Documentation and guides.

## 🎨 Coding Standards

### XML Documentation
All public classes and methods **must** have XML documentation comments. This ensures a great developer experience for users of the library.
```csharp
/// <summary>
/// Renders a beautiful card to the console.
/// </summary>
public void Render() { ... }
```

### Modern C# Features
We use .NET 8, so feel free to use modern C# features like file-scoped namespaces, primary constructors, and enhanced interpolation.

### Adding New Components
When adding a new component:
1. Create a new class in `src/ConsolePlus/Components/`.
2. Follow the fluent builder pattern (e.g., `.WithTitle()`, `.WithColor()`).
3. Ensure the component is content-aware and handles terminal resizing where possible.
4. Add a demonstration of the component in `src/ConsolePlus.Sample/Program.cs`.
5. Add unit tests in `src/ConsolePlus.Tests/`.

## 🧪 Testing Guidelines
- Aim for high coverage of the `Core` logic (Markup engine, Color parsing).
- For UI components, test the logical state and output generation where feasible.
