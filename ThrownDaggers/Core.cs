using Kingmaker.PubSubSystem;
using ModMaker;
using System;
using System.Reflection;
using static ThrownDaggers.Main;
namespace ThrownDaggers
{
    class Core :
        IModEventHandler
    {
        public int Priority => 200;

        public void ResetSettings()
        {
            Mod.Debug(MethodBase.GetCurrentMethod());
            Mod.ResetSettings();
            Mod.Settings.lastModVersion = Mod.Version.ToString();
            Mod.Settings.RangedStars = true;
            Mod.Settings.RangedDaggers = true;
        }

        public void HandleModEnable()
        {
            Mod.Debug(MethodBase.GetCurrentMethod());
            if (!Version.TryParse(Mod.Settings.lastModVersion, out Version version) || version < new Version(0, 0, 0))
                ResetSettings();
            else
            {
                Mod.Settings.lastModVersion = Mod.Version.ToString();
            }

            EventBus.Subscribe(this);
        }

        public void HandleModDisable()
        {
            Mod.Debug(MethodBase.GetCurrentMethod());
            EventBus.Unsubscribe(this);
        }
    }
}