# ConsolePlus V2 Roadmap & Instructions

This document tracks the implementation of advanced features for the ConsolePlus library.

## 🚀 Overall Roadmap

### Phase 1: DX & Core Foundation (The "Glue")
- [x] **Terminal Capabilities Auto-detection**: Detect 24-bit color support.
- [x] **Fluent API**: Extension methods for chaining styles: `"text".Bold().Red().Write()`.
- [x] **Standardized Setup**: `ConsolePlus.Setup()` for one-line initialization.

### Phase 2: Interactive Prompts (The "Interaction")
- [x] **Input Handling**: Centralized keyboard listener.
- [x] **Prompt.Confirm**: Simple [y/N] choice.
- [x] **Prompt.Ask**: Free text input with validation.
- [x] **Prompt.Select**: Arrow-key navigable list.
- [x] **Prompt.MultiSelect**: Toggleable list with Space.

### Phase 3: Layout & Advanced Rendering (The "Structure")
- [x] **Columns & Grid**: Side-by-side content rendering.
- [x] **LiveArea**: A persistent "sticky" bottom section for status updates.
- [x] **Syntax Highlighting**: Basic colorization for C# and JSON.

### Phase 4: Animations & FX (The "Polish")
- [x] **Typewriter**: AI-style character-by-character rendering.
- [x] **Gradients**: Smooth color transitions for text.
- [x] **Notifications**: Toast-like temporary messages.

---

## 🛠 Project Organization

All new features should be implemented in their respective folders under `src/ConsolePlus/`:
- `src/ConsolePlus/Prompts/` - Interactive components.
- `src/ConsolePlus/Layout/` - Grid, Columns, LiveArea.
- `src/ConsolePlus/Animations/` - Typewriter, Effects.
- `src/ConsolePlus/Core/` - Foundation updates.

## 📝 Instructions for the Agent

1. **Surgical Updates**: Always use `replace` for existing files and `write_file` for new ones.
2. **Build First**: After every implementation step, run `dotnet build src/ConsolePlus.sln` to ensure no regressions.
3. **Verify via Sample**: Update `Program.New.cs` to demonstrate the latest feature.
4. **Update Progress**: Mark tasks as complete in this `GEMINI.md` file immediately after verification.
5. **Documentation**: Ensure all new public classes/methods have XML documentation comments.
6. **No Reversions**: Do not revert architectural changes (like the `Color` struct) without explicit user consent.

## ✅ Progress Log

- **[Completed]** True Color (RGB) support.
- **[Completed]** Markup Engine (V2 with Status Helpers).
- **[Completed]** Panel, Rule, Card, ListView & Table components.
- **[Completed]** Windows VT Initialization & Dynamic Titles.
- **[Completed]** Full Interactive Prompt Suite.
- **[Completed]** Layout System (Columns & LiveArea).
- **[Completed]** Animations & FX (Typewriter & Gradients).
- **[Completed]** Codebase Cleanup (Removed obsolete files).
- **[Completed]** Documentation Update (README & Changelog).
- **[Completed]** Content-Aware Components (Fluid Layouts & Wrapping).
- **[Completed]** Premium Demos (Dashboard & Snake).
- **[Final]** Version 1.0.0 Released.
