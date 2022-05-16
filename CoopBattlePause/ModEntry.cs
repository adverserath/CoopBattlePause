using HarmonyLib;
using StardewModdingAPI;
using StardewValley;
using StardewValley.Monsters;

namespace CoopBattlePause
{
    public class ModEntry : Mod
    {
        public override void Entry(IModHelper helper)
        {
            Harmony harmony = new Harmony(this.ModManifest.UniqueID);

            harmony.Patch(
               original: AccessTools.Method(typeof(Monster), nameof(Monster.withinPlayerThreshold)),
               prefix: new HarmonyMethod(typeof(MonsterPatches), nameof(MonsterPatches.withinPlayerThreshold))
            );
            harmony.Patch(
                original: AccessTools.Method(typeof(Farmer), nameof(Farmer.CanBeDamaged)),
                prefix: new HarmonyMethod(typeof(FarmerPatches), nameof(FarmerPatches.CanBeDamaged))
                );
        }

    }
}