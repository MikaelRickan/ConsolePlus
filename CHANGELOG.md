# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [1.0.0] - 2026-03-01

### Added
- **Core Improvements**
  - New `Color` struct with Hex, RGB, and 256-color support.
  - Powerful `Markup` engine for tag-based styling: `[bold red]Text[/]`.
  - Automatic Windows VT (Virtual Terminal) initialization and UTF-8 emoji support.
  - Fluent API for chained styling: `"Hello".Bold().Red().WriteLine()`.
- **Interactive Prompt Suite**
  - `Prompt.Confirm`, `Prompt.Select`, `Prompt.MultiSelect`, `Prompt.Ask`, and `Prompt.Secret`.
  - `Prompt.Menu<T>` for structured, interactive navigation.
- **Advanced UI Components**
  - `Card` component with rounded corners, titles, subtitles, and footers.
  - `ListView` for beautiful bulleted and numbered lists.
  - `Panel` with fluid width support and automatic text wrapping.
  - `Table` overhauled with rounded borders and responsive column scaling.
  - `LiveArea` for flicker-free, managed console regions.
- **Visual Effects & Animations**
  - `Typewriter` effect with full Markup tag support.
  - `Gradient` rendering for smooth horizontal color transitions.
  - `Notification` helper for styled status messages.
  - Native ANSI effects: `blink`, `reverse`, `dim`, etc.
- **Premium Demos**
  - **Enterprise Dashboard**: A real-time cloud monitor simulation.
  - **Retro Snake Game**: A fully playable, flicker-free console game.
  - **Theme Gallery**: Visual showcase of all built-in color palettes.

### Changed
- **Architecture**: Replaced `ColoredOutput`, `StyledOutput`, and `FormattedOutput` with unified `Markup` and `SyntaxHighlighter` systems.
- **Responsiveness**: Optimized all components to be "content-aware" and terminal-responsive (fluid layouts).
- **Initialization**: Simplified library initialization to a single `ConsoleHelper.Setup()` call.
- **Table System**: Transitioned from fixed border tuples to a dynamic, scalable rendering engine.

## [0.1.0] - 2026-02-28
- Initial internal beta release.
