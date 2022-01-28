using HarmonyLib;
using Microsoft.Xbox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using XGamingRuntime;
using BepInEx;

namespace TaikoLoginPatch
{
    [BepInPlugin("org.bepinex.plugins.taikologinpatch", "TaikoLoginPatch", "1.0.0.0")]
    public class TaikoLoginPatch : BaseUnityPlugin
    {
        private void Awake()
        {
            Logger.LogInfo("Loaded");

            // Load patches
            Harmony.CreateAndPatchAll(typeof(TaikoLoginPatch));
            Logger.LogInfo("Patched all");
        }

        [HarmonyPatch(typeof(SDK), "XUserAddAsync")]
        [HarmonyPrefix]
        private static void SDK_XUserAddAsync_Prefix(ref XUserAddOptions options, XUserAddCompleted completionRoutine)
        {
            options = XUserAddOptions.AddDefaultUserAllowingUI;
        }
    }
}
