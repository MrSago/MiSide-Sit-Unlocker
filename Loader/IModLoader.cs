namespace Mod.Loader;

public interface IModLoader
{
    string ModDirectoryDestination { get; }
    string UnhollowedModulesDirectory { get; }

    event Action? Update;
    event Action<int, string>? SceneWasLoaded;
    event Action<int, string>? SceneWasInitialized;

    Action<object> OnLogMessage { get; }
    Action<object> OnLogWarning { get; }
    Action<object> OnLogError { get; }
}
