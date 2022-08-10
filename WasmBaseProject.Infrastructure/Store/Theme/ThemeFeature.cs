using Fluxor;

namespace WasmBaseProject.Infrastructure.Store.Theme
{
    public class ThemeFeature : Feature<ThemeState>
    {
        public override string GetName() => "Theme";

        protected override ThemeState GetInitialState()
            => new ThemeState(isDarkMode: false);
    }
}
