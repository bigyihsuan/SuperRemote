using System;
using System.Reflection;

using HarmonyLib;
using UnityEngine;
using UnityModManagerNet;

namespace SuperRemote
{
	static class Main
	{
		static void Load(UnityModManager.ModEntry modEntry)
		{
			Debug.Log("SuperRemote loaded");
			var harmony = new Harmony(modEntry.Info.Id);
			harmony.PatchAll(Assembly.GetExecutingAssembly());
			Debug.Log("SuperRemote patched things!");
		}
	}
	// Forever set the signal to its max
	[HarmonyPatch(typeof(LocomotiveRemoteController), "UpdateSignal")]
	class LocomotiveRemoteController_UpdateSignal_Patch
	{
		static void Prefix(ref float ___signal)
		{
			___signal = 1f;
		}
	}
	// Forever set the battery to its max capacity
	[HarmonyPatch(typeof(LocomotiveRemoteController), "UpdateSolarPanel")]
	class LocomotiveRemoteController_UpdateSolarPanel_Patch
	{
		static void Prefix(ref LocomotiveRemoteController __instance)
		{
			__instance.battery = 1f;
		}
	}


}
