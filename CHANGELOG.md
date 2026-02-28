# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [0.1.0] - 2026-02-28

### Added
- **Core Components**
  - `AnsiEscapeCodes` - Full ANSI escape sequence constants (colors, styles, cursor control)
  - `TextStyle` enum - Text styling options (Bold, Italic, Underline, etc.)
  - `ConsoleWriter` - Core writing functionality with color/style support

- **Color Support**
  - `ColorPalette` - 6 predefined color palettes (Default, Solarized, Nord, Dracula, Christmas, Ocean)
  - `Theme` - Theme management with 9 built-in themes
  - 256-color mode support
  - RGB color mode support

- **Output Classes**
  - `ColoredOutput` - Success, Error, Warning, Info, Debug messages with theme support
  - `StyledOutput` - Bold, Italic, Underline, Strikethrough, Dim text styling
  - `FormattedOutput` - JSON, XML, and Markdown formatting with syntax highlighting

- **Components**
  - `ProgressBar` - Customizable progress bars with fill characters, colors, messages
  - `Table` - Tables with 4 border styles, header colors, row alternation, column colors
  - `Spinner` - 9 spinner styles with success/error callbacks
  - `StatusMessage` - In-place status updates with various states

- **Extensions**
  - `ConsoleExtensions` - String extension methods for colored output

- **Sample Application**
  - `ConsolePlus.Sample` - Demo application showcasing all features

### Fixed
- Duplicate class definitions in source files
- Table rendering bug with border characters
- ProgressBar stub methods now work correctly
- JSON value display issue
- XML formatting improvements

### Changed
- Theme integration - ColoredOutput now uses Theme.Current.Colors for consistent theming
- Improved demo application with comprehensive feature showcase
