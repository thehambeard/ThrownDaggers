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
            if (GUILayout.Button("Test"))
            {
                var item = ResourcesLibrary.TryGetBlueprint<BlueprintItemWeapon>("CE459D19-CB5F-4991-9363-F36E0ACF7882");
                Main.Mod.Debug(item?.AssetGuidThreadSafe);
                Game.Instance.Player.Inventory.Add(item);
            }
            if (GUILayout.Button("Test Babble"))
            {
                var item = ResourcesLibrary.TryGetBlueprint<BlueprintItemWeapon>("F760A339-C44D-49C3-9388-DAB7A9EDFEA6");
                Main.Mod.Debug(item?.AssetGuidThreadSafe);
                Game.Instance.Player.Inventory.Add(item);
            }
        }
    }
}
