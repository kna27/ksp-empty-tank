using UnityEngine;
using KSP.UI.Screens;
using System.IO;

namespace EmptyTank
{

    using MonoBehavior = MonoBehaviour;

    [KSPAddon(KSPAddon.Startup.EditorAny, false)]
    public class AppLauncher : MonoBehavior
    {
        /// <summary>
        /// Toolbar button will be visible in VAB and SPH
        /// </summary>
        private const ApplicationLauncher.AppScenes VisibleInScenes =
            ApplicationLauncher.AppScenes.VAB |
            ApplicationLauncher.AppScenes.SPH;
        /// <summary>
        /// Path to the icon for the toolbar button
        /// </summary>
        private static string appIconPath = @"/GameData/EmptyTank/icon.png";
        private static Texture2D appIcon;

        private ApplicationLauncherButton launcher;

        public void Start()
        {
            // Get base of app icon path
            appIconPath = Application.platform == RuntimePlatform.OSXPlayer ? Directory.GetParent(Directory.GetParent(Application.dataPath).ToString()).ToString() : Directory.GetParent(Application.dataPath).ToString();
            appIconPath += @"/GameData/EmptyTank/icon.png";
            // Create a Texture2D using icon.png
            appIcon ??= new Texture2D(32, 32);
            appIcon.LoadImage(File.ReadAllBytes(appIconPath));
            
            GameEvents.onGUIApplicationLauncherReady.Add(AddLauncher);
            GameEvents.onGUIApplicationLauncherDestroyed.Add(RemoveLauncher);
        }

        public void OnDisable()
        {
            GameEvents.onGUIApplicationLauncherReady.Remove(AddLauncher);
            GameEvents.onGUIApplicationLauncherDestroyed.Remove(RemoveLauncher);
            RemoveLauncher();
        }

        public Vector3 GetAnchor()
        {
            return launcher?.GetAnchor() ?? Vector3.right;
        }

        private void AddLauncher()
        {
            if (ApplicationLauncher.Ready && launcher == null)
            {
                launcher = ApplicationLauncher.Instance.AddModApplication(
                    OnToggleOn, OnToggleOff,
                    null, null,
                    null, null,
                    VisibleInScenes, appIcon
                );
            }
        }

        private void RemoveLauncher()
        {
            if (launcher == null) return;
            ApplicationLauncher.Instance.RemoveModApplication(launcher);
            launcher = null;
        }

        private static void OnToggleOn()
        {
            EmptyTank.EmptyTanks();
        }

        private static void OnToggleOff()
        {
            EmptyTank.FillTanks();
        }
    }
}
