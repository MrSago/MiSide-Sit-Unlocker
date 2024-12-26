#if BIE
using System;
using HarmonyLib;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Mod.Loader.BepInEx;

[HarmonyPatch]
public static class BepInExPatches
{
    [HarmonyPatch(typeof(SceneManager), "Internal_SceneLoaded")]
    [HarmonyPostfix]
    private static void SceneLoadedPostfix(Scene scene)
    {
        BepInExPlugin.Instance?.OnSceneWasLoaded(scene.buildIndex, scene.name);
        BepInExPlugin.Instance?.OnSceneWasInitialized(scene.buildIndex, scene.name);
    }
}

#endif
