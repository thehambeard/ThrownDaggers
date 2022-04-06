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
    class ThrowRegularDaggers
    {
        public static void Configure()
        {
            var daggerType = Resources.GetBlueprint<BlueprintWeaponType>("07cc1a7fceaee5b42b3e43da960fe76d");
            var dartType = Resources.GetBlueprint<BlueprintWeaponType>("f415ae950523a7843a74d7780dd551af");
            var strength = Resources.GetBlueprint<BlueprintWeaponEnchantment>("c4d213911e9616949937e1520c80aaf3");

            daggerType.m_AttackRange = new Kingmaker.Utility.Feet(20);
            daggerType.m_AttackType = Kingmaker.RuleSystem.AttackType.Ranged;
            daggerType.m_VisualParameters = dartType.m_VisualParameters;
            daggerType.m_FighterGroupFlags = WeaponFighterGroupFlags.Thrown;
            if (Main.Mod.Settings.StrengthDaggers) daggerType.m_Enchantments = daggerType.m_Enchantments.Append(strength.ToReference<BlueprintWeaponEnchantmentReference>()).ToArray();
        }
    }
}
