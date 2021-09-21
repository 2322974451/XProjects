using System;
using UnityEngine;

namespace XUtliPoolLib
{
	// Token: 0x0200007E RID: 126
	public interface IXFmodBus : IXInterface
	{
		// Token: 0x06000442 RID: 1090
		void SetBusVolume(string bus, float volume);

		// Token: 0x06000443 RID: 1091
		void SetMainVolume(float volume);

		// Token: 0x06000444 RID: 1092
		void SetBGMVolume(float volume);

		// Token: 0x06000445 RID: 1093
		void SetSFXVolume(float volume);

		// Token: 0x06000446 RID: 1094
		void PlayOneShot(string key, Vector3 pos);

		// Token: 0x06000447 RID: 1095
		void StartEvent(string key);

		// Token: 0x06000448 RID: 1096
		void StopEvent();
	}
}
