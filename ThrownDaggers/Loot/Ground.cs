﻿using Kingmaker.Blueprints.Loot;
using ThrownDaggers.Extensions;
using ThrownDaggers.Utilities;

namespace ThrownDaggers.Loot
{
    public static class Ground
    {
        public static void Configure()
        {
            //prologue caves initial loot
            Resources.GetBlueprint<BlueprintLoot>("a8c3754c534a414498e9f8134c62830c").AddToBlueprintLoot("97B6A7AA-C762-40AB-BC25-82B3D4018816", 2); //standard throwing dagger

            //prologue maze weapon stand
            Resources.GetBlueprint<BlueprintLoot>("49ccd1725820cda46b32a65089857673").AddToBlueprintLoot("A1AB772D-47C2-48BE-8E31-DC05EDD00B12", 1); //mastwork cold iron

            //prologue maze chest w/ Radiance
            Resources.GetBlueprint<BlueprintLoot>("607e67d08e7bcb44b9aafa3884032d9e").AddToBlueprintLoot("F977EB30-9C34-4956-9BF3-A81355FC5505", 1); //Plus 1

            //Hidden chest Woljif quest
            Resources.GetBlueprint<BlueprintLoot>("5ea039fa39e262042be98d8b40bc626e").AddToBlueprintLoot("FD567B09-DD04-43EF-8838-BF5536948513", 1); //Nimble

            //Behind hidden wall with storyteller
            Resources.GetBlueprint<BlueprintLoot>("bacdb3e66115d4647b84016e038b5f0b").AddToBlueprintLoot("6F8785FD-3B7B-4A8B-B8E4-65444B60E60C", 1); //Shadow Fang

            //Gray Garrison, behind bookcase
            Resources.GetBlueprint<BlueprintLoot>("36c7a0b43c4078c4584e67820cdd9163").AddToBlueprintLoot("DA09AA28-EF8F-4EC2-80F4-DDC623453B4E", 1); //holy acid plus 1
        }
    }
}