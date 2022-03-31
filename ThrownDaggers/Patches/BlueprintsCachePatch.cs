using HarmonyLib;
using Kingmaker.Blueprints.JsonSystem;
using System;

namespace ThrownDaggers.Patches
{
    class BlueprintsCachePatch
    {
        [HarmonyPatch(typeof(BlueprintsCache))]
        static class BlueprintsCaches_Patch
        {
            private static bool Initialized = false;

            [HarmonyPriority(Priority.First)]
            [HarmonyPatch(nameof(BlueprintsCache.Init)), HarmonyPostfix]
            static void Postfix()
            {
                Main.Mod.Debug("Patching!");
                try
                {
                    if (Initialized)
                    {
                        Main.Mod.Debug("Already initialized blueprints cache.");
                        return;
                    }
                    Initialized = true;

                    Blueprints.ThrowingDaggers.Configure();
                    Loot.Ground.Configure();
                    Loot.Vendor.Configure();
                    if (Main.Mod.Settings.RangedStars) Blueprints.ThrowingStars.Configure();
                    if (Main.Mod.Settings.RangedDaggers) Blueprints.ThrowRegularDaggers.Configure();
                }
                catch (Exception e)
                {
                    Main.Mod.Error(e);
                }
            }
        }

    }
}
