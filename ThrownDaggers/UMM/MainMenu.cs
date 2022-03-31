using Kingmaker;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Items.Weapons;
using ModMaker;
using UnityEngine;
using UnityModManagerNet;

namespace ThrownDaggers.UMM
{
    class MainMenu : IMenuTopPage
    {
        public string Name => "Main Menu";

        public int Priority => 100;

        public void OnGUI(UnityModManager.ModEntry modEntry)
        {
#if DEBUG
            if (GUILayout.Button("Test"))
            {
                var item = ResourcesLibrary.TryGetBlueprint<BlueprintItemWeapon>("CE459D19-CB5F-4991-9363-F36E0ACF7882");
                Main.Mod.Debug(item?.AssetGuidThreadSafe);
                Game.Instance.Player.Inventory.Add(item);
            }
#endif
        }
    }
}
