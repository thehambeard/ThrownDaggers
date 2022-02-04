﻿using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Items.Ecnchantments;
using Kingmaker.Blueprints.Items.Weapons;
using Kingmaker.Designers.Mechanics.EquipmentEnchants;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.UnitLogic.Mechanics.Actions;
using Kingmaker.UnitLogic.Mechanics.Components;
using System;
using System.Linq;
using ThrownDaggers.Extensions;
using ThrownDaggers.Utilities;

namespace ThrownDaggers.Blueprints
{
    class ThrowingDaggers
    {
        public static void Configure()
        {
            //Enchantments
            var corrosive = Resources.GetBlueprint<BlueprintWeaponEnchantment>("633b38ff1d11de64a91d490c683ab1c8");
            var flaming = Resources.GetBlueprint<BlueprintWeaponEnchantment>("30f90becaaac51f41bf56641966c4121");
            var flamingBurst = Resources.GetBlueprint<BlueprintWeaponEnchantment>("3f032a3cd54e57649a0cdad0434bf221");
            var frost = Resources.GetBlueprint<BlueprintWeaponEnchantment>("421e54078b7719d40915ce0672511d0b");
            var keen = Resources.GetBlueprint<BlueprintWeaponEnchantment>("102a9c8c9b7a75e4fb5844e79deaf4c0");
            var shock = Resources.GetBlueprint<BlueprintWeaponEnchantment>("102a9c8c9b7a75e4fb5844e79deaf4c0");
            var necrotic = Resources.GetBlueprint<BlueprintWeaponEnchantment>("bad4134798e182c4487819dce9b43003");
            var holy = Resources.GetBlueprint<BlueprintWeaponEnchantment>("28a9964d81fedae44bae3ca45710c140");
            var unholy = Resources.GetBlueprint<BlueprintWeaponEnchantment>("d05753b8df780fc4bb55b318f06af453");
            var coldiron = Resources.GetBlueprint<BlueprintWeaponEnchantment>("e5990dc76d2a613409916071c898eee8");
            var brilliant = Resources.GetBlueprint<BlueprintWeaponEnchantment>("66e9e299c9002ea4bb65b6f300e43770");
            var bleed = Resources.GetBlueprint<BlueprintWeaponEnchantment>("ac0108944bfaa7e48aa74f407e3944e3");
            var speed = Resources.GetBlueprint<BlueprintWeaponEnchantment>("f1c0c50108025d546b2554674ea1c006");
            var axiomatic = Resources.GetBlueprint<BlueprintWeaponEnchantment>("0ca43051edefcad4b9b2240aa36dc8d4");
            var chaotic = Resources.GetBlueprint<BlueprintWeaponEnchantment>("0ca43051edefcad4b9b2240aa36dc8d4");
            var anarchic = Resources.GetBlueprint<BlueprintWeaponEnchantment>("57315bc1e1f62a741be0efde688087e9");
            var strength = Resources.GetBlueprint<BlueprintWeaponEnchantment>("c4d213911e9616949937e1520c80aaf3");

            var dex2 = Helpers.CreateBlueprint<BlueprintWeaponEnchantment>("WeaponDex2", "BCABF724-4283-4ECF-B870-5ACA5DFFC114", bp =>
            {
                bp.m_IdentifyDC = 5;
                bp.m_EnchantmentCost = 1;
                bp.m_EnchantName = Helpers.CreateString("WEAPONDEX2", "Dexterity");
                bp.m_Description = Helpers.CreateString("WEAPONDEX2_DESC", "Grants its wielder a +2 enhancement {g|Encyclopedia:Bonus}bonus{/g} to {g|Encyclopedia:Dexterity}Dexterity{/g}. Bonuses of the same type usually don't stack.");
                bp.Components = new BlueprintComponent[0];
                bp.AddComponent<AddStatBonusEquipment>(comp =>
                {
                    comp.name = "AddStatBonusEquipment1";
                    comp.Descriptor = Kingmaker.Enums.ModifierDescriptor.Enhancement;
                    comp.Stat = Kingmaker.EntitySystem.Stats.StatType.Dexterity;
                    comp.Value = 2;
                    bp.m_Overrides.Add(comp.name);
                });
            });

            var shadowFangEnch = Helpers.CreateCopy<BlueprintWeaponEnchantment>(Resources.GetBlueprint<BlueprintWeaponEnchantment>("09d1b5ef72af22e4aaa6b9b3d75ba4a1"), bp =>
            {
                bp.name = "ShadowFangItemEnchantment";
                bp.AssetGuid = new BlueprintGuid(new Guid("7885DCDE-C221-42A0-9809-3C4270F06F16"));
                var comp = bp.GetComponent<AddInitiatorAttackWithWeaponTrigger>();
                var action = comp.Action.GetAction<ContextActionDealDamage>();
                action.AbilityType = Kingmaker.EntitySystem.Stats.StatType.Strength;
                
            });
            Resources.AddBlueprint(shadowFangEnch);

            //Weapon Type
            var dartType = Resources.GetBlueprint<BlueprintWeaponType>("f415ae950523a7843a74d7780dd551af");
            var throwingDaggerType = Helpers.CreateCopy<BlueprintWeaponType>(Resources.GetBlueprint<BlueprintWeaponType>("07cc1a7fceaee5b42b3e43da960fe76d"), bp =>
            {
                bp.AssetGuid = new BlueprintGuid(new Guid("CD982E48-AC45-4BCB-94EB-6A8CF3A2D86E"));
                bp.m_AttackRange = new Kingmaker.Utility.Feet(30);
                bp.m_AttackType = Kingmaker.RuleSystem.AttackType.Ranged;
                bp.m_VisualParameters = dartType.m_VisualParameters;
                bp.m_DefaultNameText = Helpers.CreateString("THROWING_DAGGER_DEFAULT_TEXT", "Throwing Dagger");
                bp.m_TypeNameText = Helpers.CreateString("THROWING_DAGGER_TYPE_TEXT", "Throwing Dagger");
                bp.m_Enchantments = bp.m_Enchantments = bp.m_Enchantments.Append(strength.ToReference<BlueprintWeaponEnchantmentReference>()).ToArray();

            });
            Resources.AddBlueprint(throwingDaggerType);

            //FEATS
            var weaponfocusdagger = Resources.GetBlueprint<BlueprintFeature>("316f75ce57559fe45a723d14399236dd");
            weaponfocusdagger.AddComponent<WeaponFocus>(bp =>
            {
                bp.AttackBonus = 1;
                bp.m_WeaponType = throwingDaggerType.ToReference<BlueprintWeaponTypeReference>();
                bp.Descriptor = Kingmaker.Enums.ModifierDescriptor.UntypedStackable;
            });

            var weaponfocusGreaterDagger = Resources.GetBlueprint<BlueprintFeature>("691d087c97011724888a3e55fa9e71ea");
            weaponfocusGreaterDagger.AddComponent<WeaponFocus>(bp =>
            {
                bp.AttackBonus = 1;
                bp.m_WeaponType = throwingDaggerType.ToReference<BlueprintWeaponTypeReference>();
                bp.Descriptor = Kingmaker.Enums.ModifierDescriptor.UntypedStackable;
            });

            var weaponSpecializationDagger = Resources.GetBlueprint<BlueprintFeature>("578a6db7e82d48d40b2c570b99b8abfb");
            weaponSpecializationDagger.AddComponent<WeaponTypeDamageBonus>(bp =>
            {
                bp.DamageBonus = 2;
                bp.m_WeaponType = throwingDaggerType.ToReference<BlueprintWeaponTypeReference>();
            });

            var weaponSpecializationGreaterDagger = Resources.GetBlueprint<BlueprintFeature>("aaf0a5dc7abef3247a401bc070298a75");
            weaponSpecializationGreaterDagger.AddComponent<WeaponTypeDamageBonus>(bp =>
            {
                bp.DamageBonus = 2;
                bp.m_WeaponType = throwingDaggerType.ToReference<BlueprintWeaponTypeReference>();
            });

            var improvedCritical = Resources.GetBlueprint<BlueprintFeature>("abac140ed92133f4e841266fe6a740c8");
            improvedCritical.AddComponent<WeaponTypeCriticalEdgeIncrease>(bp =>
           {
               bp.m_WeaponType = throwingDaggerType.ToReference<BlueprintWeaponTypeReference>();
           });

            //Item Blueprints
            var standardThrowingDagger = Helpers.CreateCopy<BlueprintItemWeapon>(Resources.GetBlueprint<BlueprintItemWeapon>("aa514dbf4c3d61f4e9c0738bd4d373cb"), bp =>
            {
                bp.name = "StandardThrowingDagger";
                bp.AssetGuid = new BlueprintGuid(new Guid("97B6A7AA-C762-40AB-BC25-82B3D4018816"));
                bp.m_Type = throwingDaggerType.ToReference<BlueprintWeaponTypeReference>();

            });
            Resources.AddBlueprint(standardThrowingDagger);

            var MasterworkThrowingDagger = Helpers.CreateCopy<BlueprintItemWeapon>(Resources.GetBlueprint<BlueprintItemWeapon>("dfc92affae244554e8745a9ee9b7c520"), bp =>
            {
                bp.name = "MasterWorkThrowingDagger";
                bp.AssetGuid = new BlueprintGuid(new Guid("763DDAD0-AE58-487D-BDD4-28F2D7FB4D82"));
                bp.m_Type = throwingDaggerType.ToReference<BlueprintWeaponTypeReference>();
                bp.m_DisplayNameText = Helpers.CreateString("MASTERWORK_TD_DISPLAY_NAME", "Masterwork Throwing Dagger");
            });
            Resources.AddBlueprint(MasterworkThrowingDagger);

            var ColdIronMasterwork = Helpers.CreateCopy<BlueprintItemWeapon>(Resources.GetBlueprint<BlueprintItemWeapon>("e55e8179b23f16e40999320d6e7d1664"), bp =>
            {
                bp.name = "ColdIronMasterworkThrowingDagger";
                bp.AssetGuid = new BlueprintGuid(new Guid("A1AB772D-47C2-48BE-8E31-DC05EDD00B12"));
                bp.m_Type = throwingDaggerType.ToReference<BlueprintWeaponTypeReference>();
                bp.m_DisplayNameText = Helpers.CreateString("COLDIRONMASTERWORK_TD_DISPLAY_NAME", "Cold Iron Masterwork Throwing Dagger");
                bp.m_Cost = 1200;
            });
            Resources.AddBlueprint(ColdIronMasterwork);

            var ColdIron = Helpers.CreateCopy<BlueprintItemWeapon>(Resources.GetBlueprint<BlueprintItemWeapon>("b103b6468f2eff042903377b6ed940b2"), bp =>
            {
                bp.name = "ColdIronThrowingDagger";
                bp.AssetGuid = new BlueprintGuid(new Guid("49A0EE1D-3684-4C36-9207-7B7F1E16533F"));
                bp.m_Type = throwingDaggerType.ToReference<BlueprintWeaponTypeReference>();
                bp.m_DisplayNameText = Helpers.CreateString("COLDIRON_TD_DISPLAY_NAME", "Cold Iron Throwing Dagger");
            });
            Resources.AddBlueprint(ColdIron);

            var plus1 = Helpers.CreateCopy<BlueprintItemWeapon>(Resources.GetBlueprint<BlueprintItemWeapon>("2a45458f776442e43bba57de65f9b738"), bp =>
            {
                bp.name = "ThrowingDaggerPlus1";
                bp.AssetGuid = new BlueprintGuid(new Guid("F977EB30-9C34-4956-9BF3-A81355FC5505"));
                bp.m_Type = throwingDaggerType.ToReference<BlueprintWeaponTypeReference>();
            });
            Resources.AddBlueprint(plus1);

            var plus2 = Helpers.CreateCopy<BlueprintItemWeapon>(Resources.GetBlueprint<BlueprintItemWeapon>("4607f83de16245844acb4596fc797147"), bp =>
            {
                bp.name = "ThrowingDaggerPlus2";
                bp.AssetGuid = new BlueprintGuid(new Guid("0F056291-4B76-41AA-AB8A-63322AC6AC41"));
                bp.m_Type = throwingDaggerType.ToReference<BlueprintWeaponTypeReference>();
            });
            Resources.AddBlueprint(plus2);

            var plus3 = Helpers.CreateCopy<BlueprintItemWeapon>(Resources.GetBlueprint<BlueprintItemWeapon>("4c08dc9c56fd3ea4da4c6825105f0498"), bp =>
            {
                bp.name = "ThrowingDaggerPlus3";
                bp.AssetGuid = new BlueprintGuid(new Guid("F3188454-7EEF-4DA6-80FA-D4032BE94336"));
                bp.m_Type = throwingDaggerType.ToReference<BlueprintWeaponTypeReference>();
            });
            Resources.AddBlueprint(plus3);

            var plus4 = Helpers.CreateCopy<BlueprintItemWeapon>(Resources.GetBlueprint<BlueprintItemWeapon>("c5df3da9ea298214fa1b9de35800c8c3"), bp =>
            {
                bp.name = "ThrowingDaggerPlus4";
                bp.AssetGuid = new BlueprintGuid(new Guid("D720EE24-3F42-4742-8339-32C091A61A59"));
                bp.m_Type = throwingDaggerType.ToReference<BlueprintWeaponTypeReference>();
            });
            Resources.AddBlueprint(plus4);

            var plus5 = Helpers.CreateCopy<BlueprintItemWeapon>(Resources.GetBlueprint<BlueprintItemWeapon>("801183fdc4e6d524f84cb209abb6e2f8"), bp =>
            {
                bp.name = "ThrowingDaggerPlus5";
                bp.AssetGuid = new BlueprintGuid(new Guid("D570D3C5-1F71-46D6-909F-53A96822B5CA"));
                bp.m_Type = throwingDaggerType.ToReference<BlueprintWeaponTypeReference>();
            });
            Resources.AddBlueprint(plus5);

            var coldironplus1 = Helpers.CreateCopy<BlueprintItemWeapon>(plus1, bp =>
            {
                bp.name = "ColdIronThrowingDaggerPlus1";
                bp.AssetGuid = new BlueprintGuid(new Guid("FB810AE7-39D3-426A-9DDA-C552FDEB9DED"));
                bp.m_Enchantments = bp.m_Enchantments = bp.m_Enchantments.Append(coldiron.ToReference<BlueprintWeaponEnchantmentReference>()).ToArray();
                bp.m_DisplayNameText = Helpers.CreateString("COLD_IRON_TD_PLUS1", "Cold Iron Throwing Dagger +1");
            });
            Resources.AddBlueprint(coldironplus1);

            var flamingplus1 = Helpers.CreateCopy<BlueprintItemWeapon>(plus1, bp =>
            {
                bp.name = "FlamingThrowingDaggerPlus1";
                bp.AssetGuid = new BlueprintGuid(new Guid("D3D4E155-C5B0-46D4-B73E-CE2D33F49823"));
                bp.m_Enchantments = bp.m_Enchantments.Append(flaming.ToReference<BlueprintWeaponEnchantmentReference>()).ToArray();
                bp.m_Cost = 8300;
                bp.CR = 5;
            });
            Resources.AddBlueprint(flamingplus1);

            var frostplus1 = Helpers.CreateCopy<BlueprintItemWeapon>(plus1, bp =>
            {
                bp.name = "ForstThrowingDaggerPlus1";
                bp.AssetGuid = new BlueprintGuid(new Guid("6A28AD07-5656-4203-B680-311CAB3FBCE9"));
                bp.m_Enchantments = bp.m_Enchantments.Append(frost.ToReference<BlueprintWeaponEnchantmentReference>()).ToArray();
                bp.m_Cost = 8300;
                bp.CR = 5;
            });
            Resources.AddBlueprint(frostplus1);

            var shockplus1 = Helpers.CreateCopy<BlueprintItemWeapon>(plus1, bp =>
            {
                bp.name = "ShockThrowingDaggerPlus1";
                bp.AssetGuid = new BlueprintGuid(new Guid("00D83239-34AE-4E57-B17B-48A2D945CC33"));
                bp.m_Enchantments = bp.m_Enchantments.Append(shock.ToReference<BlueprintWeaponEnchantmentReference>()).ToArray();
                bp.m_Cost = 8300;
                bp.CR = 5;
            });
            Resources.AddBlueprint(shockplus1);

            var acidplus1 = Helpers.CreateCopy<BlueprintItemWeapon>(plus1, bp =>
            {
                bp.name = "CorrosiveThrowingDaggerPlus1";
                bp.AssetGuid = new BlueprintGuid(new Guid("1114B483-18FC-49D4-B116-173E9338B443"));
                bp.m_Enchantments = bp.m_Enchantments.Append(corrosive.ToReference<BlueprintWeaponEnchantmentReference>()).ToArray();
                bp.m_Cost = 8300;
                bp.CR = 5;
            });
            Resources.AddBlueprint(acidplus1);

            var holyplus1 = Helpers.CreateCopy<BlueprintItemWeapon>(plus1, bp =>
            {
                bp.name = "holyThrowingDaggerPlus1";
                bp.AssetGuid = new BlueprintGuid(new Guid("DA09AA28-EF8F-4EC2-80F4-DDC623453B4E"));
                bp.m_Enchantments = bp.m_Enchantments.Append(holy.ToReference<BlueprintWeaponEnchantmentReference>()).ToArray();
                bp.m_Cost = 18000;
                bp.CR = 7;
            });
            Resources.AddBlueprint(holyplus1);

            var keenplus1 = Helpers.CreateCopy<BlueprintItemWeapon>(plus1, bp =>
            {
                bp.name = "KeenThrowingDaggerPlus1";
                bp.AssetGuid = new BlueprintGuid(new Guid("94D00BA9-4991-4218-8AC0-24C90E3941D0"));
                bp.m_Enchantments = bp.m_Enchantments.Append(keen.ToReference<BlueprintWeaponEnchantmentReference>()).ToArray();
                bp.m_Cost = 8300;
                bp.CR = 5;
            });
            Resources.AddBlueprint(keenplus1);

            var stirge = Helpers.CreateCopy<BlueprintItemWeapon>(plus2, bp =>
            {
                bp.name = "StirgeItemThrowingDagger";
                bp.AssetGuid = new BlueprintGuid(new Guid("A34554AD-C350-409F-AFE8-AFF88C79CFEE"));
                bp.m_Enchantments = bp.m_Enchantments.Append(bleed.ToReference<BlueprintWeaponEnchantmentReference>()).ToArray();
                bp.m_DisplayNameText = Helpers.CreateString("STIRGEITEM_TD", "The Stirge");
                bp.m_DescriptionText = Helpers.CreateString("STIRGEITEM_TD_DESC", "This throwing dagger plus 2 was made from the proboscises of stirge. The blade causes bleeding damage to its target.");
                bp.m_Cost = 18000;
                bp.CR = 7;
            });
            Resources.AddBlueprint(stirge);

            var nimble = Helpers.CreateCopy<BlueprintItemWeapon>(plus1, bp =>
            {
                bp.name = "NimbleItemThrowingDagger";
                bp.AssetGuid = new BlueprintGuid(new Guid("FD567B09-DD04-43EF-8838-BF5536948513"));
                bp.m_Enchantments = bp.m_Enchantments.Append(dex2.ToReference<BlueprintWeaponEnchantmentReference>()).ToArray();
                bp.m_DisplayNameText = Helpers.CreateString("NIMBLE_TD", "Nimble");
                bp.m_DescriptionText = Helpers.CreateString("NIMBLE_TD_DESC", "This dagger is light in the hand and makes you feel lighter on your feet");
                bp.m_Cost = 8000;
                bp.CR = 5;
            });
            Resources.AddBlueprint(nimble);

            var shadowFang = Helpers.CreateCopy(plus2, bp => 
            {
                bp.name = "ShadowFangItemThrowingDagger";
                bp.AssetGuid = new BlueprintGuid(new Guid("6F8785FD-3B7B-4A8B-B8E4-65444B60E60C"));
                bp.m_Enchantments = bp.m_Enchantments.Append(shadowFangEnch.ToReference<BlueprintWeaponEnchantmentReference>()).ToArray();
                bp.m_DisplayNameText = Helpers.CreateString("SHADOWFANG_TD", "Shadow Fang");
                bp.m_DescriptionText = Helpers.CreateString("SHADOWFANG_TD_DESC", "Seemingly made from the essence of a shadow this blade drains strength on a hit.  Can not drain strength below a 5.");
                bp.m_Cost = 18000;
                bp.CR = 7;
            });
            Resources.AddBlueprint(shadowFang);
        }
    }
}
