namespace ConsolePlus.Core;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
public class Theme
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public string Name { get; init; } = "Default";
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public ColorPalette Colors { get; init; } = ColorPalette.Default;
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public bool UseAnsiColors { get; init; } = true;
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public bool EnableAnimations { get; init; } = true;
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public static Theme Default => new() { Name = "Default" };
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public static Theme Dark => new() { Name = "Dark", Colors = ColorPalette.Default };
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public static Theme Light => new() { Name = "Light", Colors = ColorPalette.Solarized };
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public static Theme Minimal => new() 
    { 
        Name = "Minimal", 
        Colors = ColorPalette.Default,
        EnableAnimations = false 
    };
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public static Theme Solarized => new() { Name = "Solarized", Colors = ColorPalette.Solarized };
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public static Theme Nord => new() { Name = "Nord", Colors = ColorPalette.Nord };
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public static Theme Dracula => new() { Name = "Dracula", Colors = ColorPalette.Dracula };
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public static Theme Christmas => new() { Name = "Christmas", Colors = ColorPalette.Christmas };
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public static Theme Ocean => new() { Name = "Ocean", Colors = ColorPalette.Ocean };
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public static Theme Current { get; private set; } = Default;
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public static void Apply(Theme theme)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    {
        Current = theme;
    }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public static void Apply(string themeName)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
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
