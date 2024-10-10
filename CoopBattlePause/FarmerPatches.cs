using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;
using System;
using System.Diagnostics;
using System.Linq;
using xTile.Dimensions;
using static StardewValley.Debris;
using static System.Net.Mime.MediaTypeNames;

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
                __result = !__instance.hasBuff(Buff.yobaBlessing);
                return false;
            }

            __result = false;
            return false;
        }
    }
}
