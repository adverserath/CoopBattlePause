using StardewModdingAPI;
using StardewValley.Monsters;

namespace CoopBattlePause
{
    public class MonsterPatches
    {
        private static IMonitor Monitor;

        public static void Initialize(IMonitor monitor)
        {
            Monitor = monitor;
        }

        //public static bool findPlayer(Monster __instance, ref Farmer __result)
        //{
        //    if (__instance.currentLocation == null)
        //    {
        //        __result = Game1.player;
        //        return false;
        //    }

        //    __result = Game1.player;
        //    double num = double.MaxValue;
        //    foreach (Farmer farmer in (__instance.currentLocation.farmers))
        //    {
        //        if (!farmer.hidden.Value || !farmer.requestingTimePause.Value)
        //        {
        //            double num2 = (farmer.Position - __instance.Position).LengthSquared();
        //            if (num2 < num)
        //            {
        //                num = num2;
        //                __result = farmer;
        //            }
        //        }
        //    }

        //    return false;
        //}

        public static bool withinPlayerThreshold(Monster __instance, ref bool __result)
        {
            if (!__instance.focusedOnFarmers && !__instance.Player.requestingTimePause.Value)
            {
                __result = __instance.withinPlayerThreshold(__instance.moveTowardPlayerThreshold.Value);
                return false;
            }

            if (__instance.Player.requestingTimePause.Value)
            {
                __result = false;
                return false;
            }
            __result = true;
            return false;
        }

    }
}
