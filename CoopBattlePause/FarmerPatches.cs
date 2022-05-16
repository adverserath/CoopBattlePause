using StardewModdingAPI;
using StardewValley;

namespace CoopBattlePause
{
    public class FarmerPatches
    {
        private static IMonitor Monitor;

        public static void Initialize(IMonitor monitor)
        {
            Monitor = monitor;
        }

        public static bool CanBeDamaged(Farmer __instance, ref bool __result)
        {
            if (!__instance.temporarilyInvincible && !Game1.player.isEating && !Game1.fadeToBlack && !__instance.requestingTimePause.Value)
            {
                __result = !Game1.buffsDisplay.hasBuff(21);
                return false;
            }

            __result = false;
            return false;
        }
    }
}
