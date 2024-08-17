using System.Text.Json.Serialization;
using Fluxor;
using Fluxor.Persist.Storage;
using MudBlazor;

namespace BaseProject.Infrastructure.Store.Theme;

[PersistState]
[FeatureState]
public sealed record ThemeState(bool IsDarkMode)
{
    public ThemeState() : this(false)
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
        PaletteLight = new()
        {
            Primary = Colors.Teal.Default,
            PrimaryDarken = Colors.Teal.Darken1,
            PrimaryLighten = Colors.Teal.Lighten1,
            AppbarBackground = Colors.Teal.Default,
            Background = Colors.Gray.Lighten4,
        },
        PaletteDark = new()
        {
            Primary = Colors.Teal.Default,
            PrimaryDarken = Colors.Teal.Darken1,
            PrimaryLighten = Colors.Teal.Lighten1,
            AppbarBackground = Colors.Teal.Default,
            Background = Colors.Gray.Darken4,
            BackgroundGray = Colors.Gray.Darken1,
            TextPrimary = Colors.Gray.Lighten4,
            TextSecondary = Colors.Gray.Lighten3,
            TextDisabled = Colors.Gray.Lighten1,
            ActionDisabled = Colors.Gray.Darken2,
            ActionDisabledBackground = Colors.Gray.Darken4,
            DrawerBackground = Colors.Gray.Darken2,
            DrawerText = Colors.Gray.Lighten2,
            DrawerIcon = Colors.Gray.Lighten2,
            Surface = Colors.Gray.Darken3,
        }
    };
}
