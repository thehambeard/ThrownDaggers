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
                var item = ResourcesLibrary.TryGetBlueprint<BlueprintItemWeapon>("6F8785FD-3B7B-4A8B-B8E4-65444B60E60C");
                Main.Mod.Debug(item?.AssetGuidThreadSafe);
                Game.Instance.Player.Inventory.Add(item);
            }
        }
    }
}
