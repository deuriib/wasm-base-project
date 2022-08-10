using System.Reflection;
using Fluxor;

namespace WasmBaseProject.Infrastructure.Store.App
{
    public class AppFeature : Feature<AppState>
    {
        public override string GetName() => "App";

        protected override AppState GetInitialState()
        {
            return new AppState(
                AppName: "WasmBaseProject",
                AppVersion: $"1.0.0"
                );
        }
    }
}
