using Kingmaker.Blueprints.Items;
using ThrownDaggers.Extensions;
using ThrownDaggers.Utilities;

namespace ThrownDaggers.Loot
{
    public static class Vendor
    {
        public static void Configure()
        {
            var dyra = Resources.GetBlueprint<BlueprintSharedVendorTable>("dec7a716db665ec498134fae15721325");
            dyra.AddVendorItem("49A0EE1D-3684-4C36-9207-7B7F1E16533F", 2); //cold iron
            dyra.AddVendorItem("A1AB772D-47C2-48BE-8E31-DC05EDD00B12", 2); //Cold Iron Masterwork
            dyra.AddVendorItem("763DDAD0-AE58-487D-BDD4-28F2D7FB4D82", 2); //Masterwork

            //JoranVayne
            //Defenders Heart
            //Max price: 17000gp CR:7
            var joranVayne_DH = Resources.GetBlueprint<BlueprintSharedVendorTable>("a7948df9d37efc34e841284cf883370e");
            joranVayne_DH.AddVendorItem("A34554AD-C350-409F-AFE8-AFF88C79CFEE", 1); //Stirge
            joranVayne_DH.AddVendorItem("94D00BA9-4991-4218-8AC0-24C90E3941D0", 1); //Keen
            joranVayne_DH.AddVendorItem("6A28AD07-5656-4203-B680-311CAB3FBCE9", 1); //Frost +1

            //Wilcer Garms
            //Crusader Camp
            //Max price: 75000 CR:15
            var wilcerGarms = Resources.GetBlueprint<BlueprintSharedVendorTable>("5753b6f35e7db234aa44085a358c27af");
            wilcerGarms.AddVendorItem("D6AE4583-6F2E-4ECB-8577-36C6513ACD28", 1); //contrary
            wilcerGarms.AddVendorItem("14E4654E-EA70-42B7-9921-679E9DBC5030", 1); //barrage

            //Blacksmith
            //Drezen
            //Max price: 75000 CR:15
            var blacksmith = Resources.GetBlueprint<BlueprintSharedVendorTable>("1317f39fdc425e94f85c331a79f603d3");
            blacksmith.AddVendorItem("299D9F87-2E52-42A9-8187-CCD7C022E067", 1); //icicle
             
        }
    }
}
