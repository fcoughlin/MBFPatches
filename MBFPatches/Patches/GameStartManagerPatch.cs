using Hazel;
using Reactor.Networking.Rpc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBFPatches.Patches
{
    public class GameStartManagerPatch
    {
        public class GameStartManagerBeginGame
        {
            public static bool Prefix(GameStartManager __instance)
            {
                // Block game start if not everyone has the same mod version
                bool continueStart = true;

                if (AmongUsClient.Instance.AmHost)
                {
                    

                    if (MBFPatchesPlugin.DynamicImpostors.Value)
                    {
                        var playerCount = GameData.Instance.PlayerCount;

                        if (playerCount < 8) PlayerControl.GameOptions.NumImpostors = 1;
                        else if (playerCount < 13) PlayerControl.GameOptions.NumImpostors = 2;
                        else PlayerControl.GameOptions.NumImpostors = 3;
                    }


                }
                return continueStart;
            }
        }
    }
}
