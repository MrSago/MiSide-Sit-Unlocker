using Mod.Loader;
using Mod.Properties;
using UnityEngine;

namespace Mod;

public static class ModCore
{
    public const string MOD_DIRECTORY_NAME = "SitUnlocker";

    public static IModLoader Loader { get; private set; } = null!;

    public static void Init(IModLoader loader)
    {
        if (Loader is not null)
        {
            throw new Exception($"{BuildInfo.NAME} is already initialized");
        }

        Loader = loader;

        SitUnlocker.Init();
    }

    #region LOGGING

    public static void Log(object message) => Log(message, LogType.Log);

    public static void LogWarning(object message) => Log(message, LogType.Warning);

    public static void LogError(object message) => Log(message, LogType.Error);

    private static void Log(object message, LogType logType)
    {
        string log = message?.ToString() ?? "";

        switch (logType)
        {
            case LogType.Log:
            case LogType.Assert:
                Loader.OnLogMessage(log);
                break;

            case LogType.Warning:
                Loader.OnLogWarning(log);
                break;

            case LogType.Error:
            case LogType.Exception:
                Loader.OnLogError(log);
                break;

            default:
                break;
        }
    }

    #endregion
}
