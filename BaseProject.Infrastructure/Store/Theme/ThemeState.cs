using System.Text.Json.Serialization;
using Fluxor;
using Fluxor.Persist.Storage;
using MudBlazor;

namespace BaseProject.Infrastructure.Store.Theme;

[PersistState]
[FeatureState]
public class ThemeState
{
    public ThemeState(bool isDarkMode)
    {
        IsDarkMode = isDarkMode;
    }
    
    private ThemeState()
    {
        IsDarkMode = false;;
    }

    public bool IsDarkMode { get; }

    [property: JsonIgnore]
    public MudTheme CurrentTheme => new MudTheme()
    {
        LayoutProperties = new()
        {
            DrawerWidthRight = "300px",
            DrawerWidthLeft = "250px"
        },
        Palette = GetLightPalette(),
        PaletteDark = GetDarkPalette()
    };
    
    private Palette GetLightPalette()
    {
        return new Palette
        {
            Primary = "#009688",
            PrimaryContrastText = "#fff",
            PrimaryDarken = "#00695C",
            PrimaryLighten = "#4DB6AC",
            Secondary = "#E91E63",
            SecondaryContrastText = "#fff",
            SecondaryDarken = "#AD1457",
            SecondaryLighten = "#F06292",
            Tertiary = "#673AB7",
            TertiaryContrastText = "#fff",
            TertiaryDarken = "#4527A0",
            TertiaryLighten = "#9575CD",
            TextPrimary = "#212121",
            TextSecondary = "#757575",
            TextDisabled = "#BDBDBD",
            AppbarText = "#FAFAFA",
            AppbarBackground = "#009688",
            DrawerText = "#212121",
            Background = "#F5F5F5",
        };
    }
    
    private Palette GetDarkPalette()
    {
        return new Palette
        {
            Primary = "#009688",
            PrimaryContrastText = "#fff",
            PrimaryDarken = "#00695C",
            PrimaryLighten = "#4DB6AC",
            Secondary = "#E91E63",
            SecondaryContrastText = "#fff",
            SecondaryDarken = "#AD1457",
            SecondaryLighten = "#F06292",
            Tertiary = "#673AB7",
            TertiaryContrastText = "#fff",
            TertiaryDarken = "#4527A0",
            TertiaryLighten = "#9575CD",
            TextPrimary = "#9E9E9E",
            TextSecondary = "#BDBDBD",
            TextDisabled = "#E0E0E0",
            AppbarText = "#FAFAFA",
            AppbarBackground = "#009688",
        };
    }
}