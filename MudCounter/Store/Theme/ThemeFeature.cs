using Fluxor;
using MudBlazor;

namespace MudCounter.Store.Theme
{
    public class ThemeFeature : Feature<ThemeState>
    {
        public override string GetName() => "Theme";

        protected override ThemeState GetInitialState()
            => new ThemeState(isDarkMode: false);
    }
}
