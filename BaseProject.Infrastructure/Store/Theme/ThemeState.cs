using System.Text.Json.Serialization;
using Fluxor;
using Fluxor.Persist.Storage;
using MudBlazor;

namespace BaseProject.Infrastructure.Store.Theme;

[PersistState]
[FeatureState]
public sealed record ThemeState(bool IsDarkMode)
{

    private ThemeState(): this(false)
    {
    }

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
            Primary = Colors.Teal.Default,
            PrimaryDarken = Colors.Teal.Darken1,
            PrimaryLighten = Colors.Teal.Lighten1,
            AppbarBackground = Colors.Teal.Default,
            Background = Colors.Grey.Lighten4,
        };
    }

    private Palette GetDarkPalette()
    {
        return new Palette
        {
            Primary = Colors.Teal.Default,
            PrimaryDarken = Colors.Teal.Darken1,
            PrimaryLighten = Colors.Teal.Lighten1,
            AppbarBackground = Colors.Teal.Default,
            Background = Colors.Grey.Darken4,
            BackgroundGrey = Colors.Grey.Darken1,
            TextPrimary = Colors.Grey.Lighten4,
            TextSecondary = Colors.Grey.Lighten3,
            TextDisabled = Colors.Grey.Lighten1,
            ActionDisabled = Colors.Grey.Darken2,
            ActionDisabledBackground = Colors.Grey.Darken4,
            DrawerBackground = Colors.Grey.Darken2,
            DrawerText = Colors.Grey.Lighten2,
            DrawerIcon = Colors.Grey.Lighten2,
            Surface = Colors.Grey.Darken3,
        };
    }
}