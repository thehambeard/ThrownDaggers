using JetBrains.Annotations;
using Kingmaker.Blueprints;

namespace ThrownDaggers.Utilities
{
    static class Resources
    {
        public static T GetBlueprint<T>(string id) where T : SimpleBlueprint
        {
            var assetId = BlueprintGuid.Parse(id);
            return GetBlueprint<T>(assetId);
        }
        public static T GetBlueprint<T>(BlueprintGuid id) where T : SimpleBlueprint
        {
            SimpleBlueprint asset = ResourcesLibrary.TryGetBlueprint(id);
            T value = asset as T;
            if (value == null) { Main.Mod.Error($"COULD NOT LOAD: {id} - {typeof(T)}"); }
            return value;
        }
        public static void AddBlueprint([NotNull] SimpleBlueprint blueprint)
        {
            AddBlueprint(blueprint, blueprint.AssetGuid);
        }
        public static void AddBlueprint([NotNull] SimpleBlueprint blueprint, string assetId)
        {
            var Id = BlueprintGuid.Parse(assetId);
            AddBlueprint(blueprint, Id);
        }
        public static void AddBlueprint([NotNull] SimpleBlueprint blueprint, BlueprintGuid assetId)
        {
            var loadedBlueprint = ResourcesLibrary.TryGetBlueprint(assetId);
            if (loadedBlueprint == null)
            {
                ResourcesLibrary.BlueprintsCache.AddCachedBlueprint(assetId, blueprint);
                blueprint.OnEnable();
            }
            else
            {
                Main.Mod.Error($"Failed to Add: {blueprint.name}");
                Main.Mod.Error($"Asset ID: {assetId} already in use by: {loadedBlueprint.name}");
            }
        }
    }
}