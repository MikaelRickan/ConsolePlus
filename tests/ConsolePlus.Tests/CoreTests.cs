using System;
using ConsolePlus.Core;
using Xunit;

namespace ConsolePlus.Tests;

public class CoreTests
{
    [Fact]
    public void Color_FromHex_CorrectRgb()
    {
        var color = Color.FromHex("#FF5500");
        var ansi = color.ToForegroundAnsi();
        Assert.Contains("255", ansi);
        Assert.Contains("85", ansi);
        Assert.Contains("0", ansi);
    }

    [Fact]
    public void Markup_RemoveMarkup_ReturnsCleanString()
    {
        var input = "[bold red]Hello[/] [blue]World[/] 🚀";
        var clean = Markup.RemoveMarkup(input);
        Assert.Equal("Hello World 🚀", clean);
    }

    [Fact]
    public void Markup_GetVisibleLength_IgnoresTags()
    {
        var input = "[bold red]Hello[/]";
        Assert.Equal(5, Markup.GetVisibleLength(input));
    }

    [Fact]
    public void ConsoleWriter_WithColor_SetsState()
    {
        var writer = ConsoleWriter.WithColor(ConsoleColor.Red);
        Assert.Equal(new Color(ConsoleColor.Red).ToForegroundAnsi(), writer.ForegroundColor.ToForegroundAnsi());
    }
}
