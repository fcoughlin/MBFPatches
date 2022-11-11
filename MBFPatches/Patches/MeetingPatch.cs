using HarmonyLib;
using Reactor;
using Reactor.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Rewired.Utils.Classes.Utility.ObjectInstanceTracker;
using UnityEngine;

namespace MBFPatches.Patches
{
    [HarmonyPatch]
    class MeetingHudPatch
    {
        [HarmonyPatch(typeof(MeetingHud), nameof(MeetingHud.VotingComplete))]
        class MeetingHudVotingCompletedPatch
        {
            static void Postfix(MeetingHud __instance, [HarmonyArgument(0)] byte[] states, [HarmonyArgument(1)] GameData.PlayerInfo exiled, [HarmonyArgument(2)] bool tie)
            {
                if (MBFPatchesPlugin.RandomSpawns.Value == true && PlayerControl.LocalPlayer != null)
                {
                    int mapID = PlayerControl.GameOptions.MapId;
                    List<Vector3> skeldCoords = new List<Vector3>() {
                        new Vector3(-1.1f, 5.8f, 0.0f),
                        new Vector3(9.5f, 3.7f, 0.0f),
                        new Vector3(4.9f, -3.8f, 0.0f),
                        new Vector3(18.2f, -3.8f, 0.0f),
                        new Vector3(7.5f, -14.1f, 0.0f),
                        new Vector3(4.7f, -15.4f, 0.0f),
                        new Vector3(-1.4f, -16.2f, 0.0f),
                        new Vector3(6.6f, -7.0f, 0.0f),
                        new Vector3(-7.3f, -4.7f, 0.0f),
                        new Vector3(-19.1f, -1.0f, 0.0f),
                        new Vector3(-21.4f, -5.0f, 0.0f),
                        new Vector3(-18.7f, -13.2f, 0.0f),
                        new Vector3(-6.2f, -7.9f, 0.0f),
                        new Vector3(-12.3f, -3.1f, 0.0f),
                        new Vector3(0.2f, -0.8f, 0.0f),
                        new Vector3(-3.8f, -9.9f, 0.0f),
                        new Vector3(9.4f, -9.0f, 0.0f),
                        new Vector3(4.5f, 3.5f, 0.0f),
                        new Vector3(-11.3f, 1.1f, 0.0f),
                        new Vector3(-12.3f, -14.7f, 0.0f),
                        new Vector3(0.2f, -17.1f, 0.0f)

                    };
                    List<Vector3> miraCoords = new List<Vector3>() {
                        new Vector3(-4.7f, 3.9f, 0.0f),
                        new Vector3(-4.7f, -2.2f, 0.0f),
                        new Vector3(5.5f, -1.7f, 0.0f),
                        new Vector3(12.5f, -1.7f, 0.0f),
                        new Vector3(16.3f, 0.6f, 0.0f),
                        new Vector3(16.2f, 4.4f, 0.0f),
                        new Vector3(12.3f, 7.6f, 0.0f),
                        new Vector3(17.9f, 11.6f, 0.0f),
                        new Vector3(23.7f, 6.5f, 0.0f),
                        new Vector3(28.2f, -1.9f, 0.0f),
                        new Vector3(19.5f, -2.4f, 0.0f),
                        new Vector3(19.9f, 5.3f, 0.0f),
                        new Vector3(17.7f, 15.2f, 0.0f),
                        new Vector3(14.7f, 21.1f, 0.0f),
                        new Vector3(22.3f, 20.9f, 0.0f),
                        new Vector3(18.2f, 25.5f, 0.0f),
                        new Vector3(4.8f, 0.7f, 0.0f),
                        new Vector3(6.0f, 6.9f, 0.0f),
                        new Vector3(1.1f, 14.5f, 0.0f),
                        new Vector3(9.8f, 10.7f, 0.0f),
                        new Vector3(6.4f, 14.4f, 0.0f)

                    };
                    List<Vector3> polusCoords = new List<Vector3>() {
                        new Vector3(16.7f, -0.8f, 0.0f),
                        new Vector3(4.7f, -7.4f, 0.0f),
                        new Vector3(3.0f, -12.4f, 0.0f),
                        new Vector3(10.1f, -12.2f, 0.0f),
                        new Vector3(1.4f, -16.3f, 0.0f),
                        new Vector3(1.3f, -23.8f, 0.0f),
                        new Vector3(8.3f, -25.3f, 0.0f),
                        new Vector3(12.2f, -15.5f, 0.0f),
                        new Vector3(10.4f, -23.0f, 0.0f),
                        new Vector3(22.3f, -25.2f, 0.0f),
                        new Vector3(19.7f, -16.3f, 0.0f),
                        new Vector3(30.5f, -15.6f, 0.0f),
                        new Vector3(25.9f, -12.9f, 0.0f),
                        new Vector3(27.8f, -7.1f, 0.0f),
                        new Vector3(34.0f, -5.6f, 0.0f),
                        new Vector3(39.9f, -9.8f, 0.0f),
                        new Vector3(23.8f, -24.6f, 0.0f),
                        new Vector3(21.4f, -11.7f, 0.0f),
                        new Vector3(24.3f, -3.0f, 0.0f),
                        new Vector3(14.2f, -15.4f, 0.0f),
                        new Vector3(19.4f, -14.9f, 0.0f),
                        new Vector3(11.7f, -9.7f, 0.0f),
                        new Vector3(24.7f, -9.7f, 0.0f)

                    };
                    Vector3 coords = PlayerControl.LocalPlayer.transform.position;
                    if (mapID == 0) coords = skeldCoords[(MBFPatches.rnd.Next(skeldCoords.Count) + PlayerControl.LocalPlayer.PlayerId) % skeldCoords.Count()];
                    else if (mapID == 1) coords = miraCoords[(MBFPatches.rnd.Next(miraCoords.Count) + PlayerControl.LocalPlayer.PlayerId) % miraCoords.Count()];
                    else if (mapID == 2) coords = polusCoords[MBFPatches.rnd.Next((polusCoords.Count) + PlayerControl.LocalPlayer.PlayerId) % polusCoords.Count()];
                    PlayerControl.LocalPlayer.transform.position = coords;
                }

            }
        }


    }
}
