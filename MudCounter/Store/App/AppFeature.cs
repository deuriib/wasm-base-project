using Fluxor;

namespace MudCounter.Store.App
{
    public class AppFeature : Feature<AppState>
    {
        public override string GetName() => "App";
        
        protected override AppState GetInitialState()
            => new AppState(appName: "MudCounter", appVersion: "0.0.1");
    }
}
