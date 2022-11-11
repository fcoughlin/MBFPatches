using BepInEx;
using BepInEx.Configuration;
using BepInEx.Unity.IL2CPP;
using HarmonyLib;
using Reactor;
using Reactor.Utilities;
using Reactor.Patches;
using System;
using MBFPatches.Patches;
using Il2CppSystem.Data;

namespace MBFPatches
{


    
    [BepInPlugin(Id, "MBF - Patches", "1.0.0")]
    [BepInProcess("Among Us.exe")]
    
    public partial class MBFPatchesPlugin : BasePlugin
    {
        
        public const string Id = "me.fcoughlin.mbfpatches";
        public Harmony Harmony { get; } = new(Id);
        public static int optionsPage = 2;

        public static ConfigEntry<bool> RandomSpawns { get; private set; }
        public static ConfigEntry<bool> DynamicImpostors { get; private set; }
        public static MBFPatchesPlugin Instance;

        public override void Load()
        {
            Instance = this;
            
            
            RandomSpawns = MBFPatchesPlugin.Instance.Config.Bind("Custom", "Random Spawns", true, "Enable Random Spawns on Mira, Polus and Skeld");
            DynamicImpostors = MBFPatchesPlugin.Instance.Config.Bind("Custom", "Dynamic Impostors", true, "Enable dynamic impostor count, based on number of players.");

            ReactorVersionShower.TextUpdated += (text) =>
            {
                int index = text.text.LastIndexOf('\n');
                text.text = text.text.Insert(index == -1 ? text.text.Length - 1 : index, "   MBF Patches v1.0.0");
            };

            Harmony.PatchAll();
        }

    }

}