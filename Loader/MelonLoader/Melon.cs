#if ML
using MelonLoader;
using MelonLoader.Utils;

[assembly: MelonPlatformDomain(MelonPlatformDomainAttribute.CompatibleDomains.IL2CPP)]
[assembly: MelonInfo(
    typeof(Mod.Loader.MelonLoader.Melon),
    Mod.Properties.BuildInfo.NAME,
    Mod.Properties.BuildInfo.VERSION,
    Mod.Properties.BuildInfo.AUTHOR,
    Mod.Properties.BuildInfo.DOWNLOADLINK
)]
[assembly: MelonGame("AIHASTO", "MiSideFull")]
[assembly: MelonColor(255, 196, 21, 169)]
[assembly: MelonAuthorColor(255, 80, 20, 146)]

namespace Mod.Loader.MelonLoader;

public class Melon : MelonMod, IModLoader
{
    public string ModDirectoryDestination => MelonEnvironment.ModsDirectory;
    public string UnhollowedModulesDirectory =>
        Path.Combine(
            Path.GetDirectoryName(ModDirectoryDestination) ?? "",
            Path.Combine("MelonLoader", "Il2CppAssemblies")
        );

    public event Action? Update;
    public event Action<int, string>? SceneWasLoaded;
    public event Action<int, string>? SceneWasInitialized;

    public Action<object> OnLogMessage => MelonLogger.Msg;
    public Action<object> OnLogWarning => MelonLogger.Warning;
    public Action<object> OnLogError => MelonLogger.Error;

    public override void OnUpdate() => Update?.Invoke();

    public override void OnSceneWasLoaded(int buildIndex, string sceneName) =>
        SceneWasLoaded?.Invoke(buildIndex, sceneName);

    public override void OnSceneWasInitialized(int buildIndex, string sceneName) =>
        SceneWasInitialized?.Invoke(buildIndex, sceneName);

    public override void OnLateInitializeMelon()
    {
        ModCore.Init(this);
    }
}

#endif
