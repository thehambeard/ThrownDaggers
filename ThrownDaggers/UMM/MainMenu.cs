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
                var item = ResourcesLibrary.TryGetBlueprint<BlueprintItemWeapon>("11F0CC28-ECDE-4679-B113-78BDAC498D5C");
                Main.Mod.Debug(item?.AssetGuidThreadSafe);
                Game.Instance.Player.Inventory.Add(item);
            }
        }
    }
}
