namespace ConsolePlus.Core;

public class Theme
{
    public string Name { get; init; } = "Default";
    public ColorPalette Colors { get; init; } = ColorPalette.Default;
    public bool UseAnsiColors { get; init; } = true;
    public bool EnableAnimations { get; init; } = true;

    public static Theme Default => new() { Name = "Default" };
    public static Theme Dark => new() { Name = "Dark", Colors = ColorPalette.Default };
    public static Theme Light => new() { Name = "Light", Colors = ColorPalette.Solarized };
    public static Theme Minimal => new() 
    { 
        Name = "Minimal", 
        Colors = ColorPalette.Default,
        EnableAnimations = false 
    };
    public static Theme Solarized => new() { Name = "Solarized", Colors = ColorPalette.Solarized };
    public static Theme Nord => new() { Name = "Nord", Colors = ColorPalette.Nord };
    public static Theme Dracula => new() { Name = "Dracula", Colors = ColorPalette.Dracula };

    public static Theme Christmas => new() { Name = "Christmas", Colors = ColorPalette.Christmas };
    public static Theme Ocean => new() { Name = "Ocean", Colors = ColorPalette.Ocean };

    public static Theme Current { get; private set; } = Default;

    public static void Apply(Theme theme)
    {
        Current = theme;
    }

    public static void Apply(string themeName)
    {
        Current = themeName.ToLower() switch
        {
            "dark" => Dark,
            "light" => Light,
            "minimal" => Minimal,
            "solarized" => Solarized,
            "nord" => Nord,
            "dracula" => Dracula,
            "christmas" => Christmas,
            "ocean" => Ocean,
            _ => Default
        };
    }
}
