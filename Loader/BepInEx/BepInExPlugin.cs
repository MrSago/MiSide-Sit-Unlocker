#if BIE
using BepInEx;
using BepInEx.IL2CPP;
using BepInEx.Logging;
using BepInEx.Unity.IL2CPP;
using HarmonyLib;
using Mod.Properties;
using UnityEngine;

namespace Mod.Loader.BepInEx;

[BepInPlugin(BuildInfo.PACKAGE, BuildInfo.NAME, BuildInfo.VERSION)]
public class BepInExPlugin : BasePlugin, IModLoader
{
    public static BepInExPlugin Instance = null!;

    private static readonly Harmony _harmony = new(BuildInfo.GUID);
    public Harmony HarmonyInstance => _harmony;

    public string ModDirectoryDestination =>
        Path.Combine(Paths.PluginPath, ModCore.MOD_DIRECTORY_NAME);
    public string UnhollowedModulesDirectory => Path.Combine(Paths.BepInExRootPath, "interop");

    public event Action? Update;
    public event Action<int, string>? SceneWasLoaded;
    public event Action<int, string>? SceneWasInitialized;

    public Action<object> OnLogMessage => Log.LogMessage;
    public Action<object> OnLogWarning => Log.LogWarning;
    public Action<object> OnLogError => Log.LogError;

    public void OnUpdate() => Update?.Invoke();

    public void OnSceneWasLoaded(int buildIndex, string sceneName) =>
        SceneWasLoaded?.Invoke(buildIndex, sceneName);

    public void OnSceneWasInitialized(int buildIndex, string sceneName) =>
        SceneWasInitialized?.Invoke(buildIndex, sceneName);

    public override void Load()
    {
        Instance = this;
        HarmonyInstance.PatchAll(typeof(BepInExPatches));
        IL2CPPChainloader.AddUnityComponent(typeof(BepInExEventProxy));
        ModCore.Init(this);
    }

    private class BepInExEventProxy : MonoBehaviour
    {
        private void Update() => Instance?.OnUpdate();
    }
}

#endif
