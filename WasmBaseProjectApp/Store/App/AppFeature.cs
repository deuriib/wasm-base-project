using Fluxor;
using System.Reflection;

namespace WasmBaseProjectApp.Store.App
{
    public class AppFeature : Feature<AppState>
    {
        public override string GetName() => "App";

        protected override AppState GetInitialState()
        {
            var assembly = Assembly.GetExecutingAssembly().GetName();
            return new AppState(
                appName: assembly?.Name!,
                appVersion: $"{assembly?.Version?.Major}.{assembly?.Version?.Minor}.{assembly?.Version?.Revision}"
                );
        }
    }
}
