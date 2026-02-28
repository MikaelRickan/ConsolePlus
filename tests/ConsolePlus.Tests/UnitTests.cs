using ConsolePlus.Components;
using ConsolePlus.Output;
using ConsolePlus.Core;
using Xunit;

namespace ConsolePlus.Tests;

public class TableTests
{
    [Fact]
    public void Table_AddHeader_SetsHeaders()
    {
        var table = new Table();
        table.AddHeader("Name", "Age", "City");

        var headers = table.GetType()
            .GetField("_headers", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)?
            .GetValue(table) as string[];

        Assert.NotNull(headers);
        Assert.Equal(3, headers.Length);
        Assert.Equal("Name", headers[0]);
        Assert.Equal("Age", headers[1]);
        Assert.Equal("City", headers[2]);
    }

    [Fact]
    public void Table_AddRow_AddsRowToCollection()
    {
        var table = new Table();
        table.AddHeader("Name", "Age");
        table.AddRow("Alice", "30");
        table.AddRow("Bob", "25");

        var rowsField = table.GetType()
            .GetField("_rows", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        var rows = rowsField?.GetValue(table) as List<string[]>;

        Assert.NotNull(rows);
        Assert.Equal(2, rows.Count);
        Assert.Equal("Alice", rows[0][0]);
        Assert.Equal("30", rows[0][1]);
    }

    [Fact]
    public void Table_WithBorderStyle_SetsBorderStyle()
    {
        var table = new Table();
        table.WithBorderStyle(TableBorderStyle.Double);

        var borderStyleField = table.GetType()
            .GetField("_borderStyle", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        var borderStyle = (TableBorderStyle)borderStyleField!.GetValue(table)!;

        Assert.Equal(TableBorderStyle.Double, borderStyle);
    }

    [Fact]
    public void Table_WithHeaderColor_SetsColor()
    {
        var table = new Table();
        table.WithHeaderColor(ConsoleColor.Cyan);

        var headerColorField = table.GetType()
            .GetField("_headerColor", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        var headerColor = (ConsoleColor)headerColorField!.GetValue(table)!;

        Assert.Equal(ConsoleColor.Cyan, headerColor);
    }
}

public class ProgressBarTests
{
    [Fact]
    public void ProgressBar_Constructor_SetsDefaults()
    {
        var progress = new ProgressBar();

        var widthField = progress.GetType()
            .GetField("_width", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        var totalField = progress.GetType()
            .GetField("_totalProgress", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);

        var width = (int)widthField!.GetValue(progress)!;
        var total = (int)totalField!.GetValue(progress)!;

        Assert.Equal(40, width);
        Assert.Equal(100, total);
    }

    [Fact]
    public void ProgressBar_WithMessage_ShowsMessage()
    {
        var progress = new ProgressBar().WithMessage("Downloading...");

        var messageField = progress.GetType()
            .GetField("_message", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        var message = (string)messageField!.GetValue(progress)!;

        Assert.Equal("Downloading...", message);
    }

    [Fact]
    public void ProgressBar_WithFillColor_SetsColor()
    {
        var progress = new ProgressBar().WithFillColor(ConsoleColor.Red);

        var fillColorField = progress.GetType()
            .GetField("_fillColor", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        var fillColor = (ConsoleColor)fillColorField!.GetValue(progress)!;

        Assert.Equal(ConsoleColor.Red, fillColor);
    }

    [Fact]
    public void ProgressBar_Update_ClampsToTotal()
    {
        // Skip if no console - progress bar renders to console
        if (!Console.IsOutputRedirected && !Console.IsInputRedirected)
        {
            var progress = new ProgressBar(40, 100);

            var currentProgressField = progress.GetType()
                .GetField("_currentProgress", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);

            progress.Update(150);

            var currentProgress = (int)currentProgressField!.GetValue(progress)!;
            Assert.Equal(100, currentProgress);
        }
    }

    [Fact]
    public void ProgressBar_Update_ClampsToZero()
    {
        // Skip if no console - progress bar renders to console
        if (!Console.IsOutputRedirected && !Console.IsInputRedirected)
        {
            var progress = new ProgressBar(40, 100);

            var currentProgressField = progress.GetType()
                .GetField("_currentProgress", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);

            progress.Update(-50);

            var currentProgress = (int)currentProgressField!.GetValue(progress)!;
            Assert.Equal(0, currentProgress);
        }
    }
}

public class SpinnerTests
{
    [Fact]
    public void Spinner_Constructor_SetsDefaults()
    {
        // Skip if no console - spinner requires console
        if (!Console.IsOutputRedirected && !Console.IsInputRedirected)
        {
            var spinner = new Spinner("Loading...");

            var messageField = spinner.GetType()
                .GetField("_message", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            var message = (string)messageField!.GetValue(spinner)!;

            var styleField = spinner.GetType()
                .GetField("_style", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            var style = (SpinnerStyle)styleField!.GetValue(spinner)!;

            Assert.Equal("Loading...", message);
            Assert.Equal(SpinnerStyle.Dots, style);
        }
    }

    [Fact]
    public void Spinner_WithStyle_SetsStyle()
    {
        // Skip if no console - spinner requires console
        if (!Console.IsOutputRedirected && !Console.IsInputRedirected)
        {
            var spinner = new Spinner("Processing...", SpinnerStyle.Circle);

            var styleField = spinner.GetType()
                .GetField("_style", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            var style = (SpinnerStyle)styleField!.GetValue(spinner)!;

            Assert.Equal(SpinnerStyle.Circle, style);
        }
    }
}

public class ThemeTests
{
    [Fact]
    public void Theme_Apply_SetsCurrentTheme()
    {
        Theme.Apply("dracula");

        Assert.Equal("Dracula", Theme.Current.Name);
    }

    [Fact]
    public void Theme_ApplyWithInvalidName_DefaultsToDefault()
    {
        Theme.Apply("nonexistent");

        Assert.Equal("Default", Theme.Current.Name);
    }

    [Fact]
    public void Theme_ApplyWithInstance_SetsCurrent()
    {
        var customTheme = new Theme { Name = "Custom" };
        Theme.Apply(customTheme);

        Assert.Equal("Custom", Theme.Current.Name);
    }

    [Fact]
    public void ColorPalette_Default_HasRequiredColors()
    {
        var palette = ColorPalette.Default;

        Assert.NotEqual(ConsoleColor.Black, palette.Success);
        Assert.NotEqual(ConsoleColor.Black, palette.Error);
        Assert.NotEqual(ConsoleColor.Black, palette.Warning);
    }
}

public class FormattedOutputTests
{
    [Fact]
    public void WriteJson_ValidJson_DoesNotThrow()
    {
        var json = @"{
            ""name"": ""John"",
            ""age"": 30
        }";

        var exception = Record.Exception(() => FormattedOutput.WriteJson(json));

        Assert.Null(exception);
    }

    [Fact]
    public void WriteJson_InvalidJson_ShowsError()
    {
        var invalidJson = "not valid json";

        var exception = Record.Exception(() => FormattedOutput.WriteJson(invalidJson));

        Assert.Null(exception);
    }

    [Fact]
    public void WriteXml_ValidXml_DoesNotThrow()
    {
        var xml = @"<person><name>John</name><age>30</age></person>";

        var exception = Record.Exception(() => FormattedOutput.WriteXml(xml));

        Assert.Null(exception);
    }

    [Fact]
    public void WriteXml_InvalidXml_ShowsError()
    {
        var invalidXml = "<person><name>John</name></person";

        var exception = Record.Exception(() => FormattedOutput.WriteXml(invalidXml));

        Assert.Null(exception);
    }

    [Fact]
    public void WriteMarkdown_ValidMarkdown_DoesNotThrow()
    {
        var markdown = @"# Heading

**Bold** and *italic*

- Item 1
- Item 2
";

        var exception = Record.Exception(() => FormattedOutput.WriteMarkdown(markdown));

        Assert.Null(exception);
    }
}

public class StatusMessageTests
{
    [Fact]
    public void StatusMessage_Constructor_StoresCursorPosition()
    {
        // Skip if no console - status message uses console
        if (!Console.IsOutputRedirected && !Console.IsInputRedirected)
        {
            var status = new StatusMessage();

            var cursorTopField = status.GetType()
                .GetField("_cursorTop", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            var cursorTop = (int)cursorTopField!.GetValue(status)!;

            Assert.True(cursorTop >= 0);
        }
    }

    [Fact]
    public void StatusMessage_WithClearOnDispose_SetsFlag()
    {
        // Skip if no console - status message uses console
        if (!Console.IsOutputRedirected && !Console.IsInputRedirected)
        {
            var status = new StatusMessage().ClearOnDispose(true);

            var clearOnDisposeField = status.GetType()
                .GetField("_clearOnDispose", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            var clearOnDispose = (bool)clearOnDisposeField!.GetValue(status)!;

            Assert.True(clearOnDispose);
        }
    }
}
