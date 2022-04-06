using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Items.Ecnchantments;
using Kingmaker.Blueprints.Items.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThrownDaggers.Utilities;

namespace ThrownDaggers.Blueprints
{
    class ThrowingStars
    {
        public static void Configure()
        {
            var starknifeType = Resources.GetBlueprint<BlueprintWeaponType>("5a939137fc039084580725b2b0845c3f");
            var dartType = Resources.GetBlueprint<BlueprintWeaponType>("f415ae950523a7843a74d7780dd551af");
            var strength = Resources.GetBlueprint<BlueprintWeaponEnchantment>("c4d213911e9616949937e1520c80aaf3");

            starknifeType.m_AttackRange = new Kingmaker.Utility.Feet(20);
            starknifeType.m_AttackType = Kingmaker.RuleSystem.AttackType.Ranged;
            starknifeType.m_VisualParameters = dartType.m_VisualParameters;
            starknifeType.m_FighterGroupFlags = WeaponFighterGroupFlags.Thrown;
            if (Main.Mod.Settings.StrengthStars) starknifeType.m_Enchantments = starknifeType.m_Enchantments.Append(strength.ToReference<BlueprintWeaponEnchantmentReference>()).ToArray();
        }
    }
}
