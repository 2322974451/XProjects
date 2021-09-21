using System;
using UnityEngine;

namespace XUtliPoolLib
{
	// Token: 0x0200007D RID: 125
	public interface IXFmod : IXInterface
	{
		// Token: 0x0600043A RID: 1082
		void StartEvent(string key, AudioChannel channel = AudioChannel.Action, bool stopPre = true, string para = "", float value = 0f);

		// Token: 0x0600043B RID: 1083
		void Play(AudioChannel channel = AudioChannel.Action);

		// Token: 0x0600043C RID: 1084
		void Stop(AudioChannel channel = AudioChannel.Action);

		// Token: 0x0600043D RID: 1085
		bool IsPlaying(AudioChannel channel);

		// Token: 0x0600043E RID: 1086
		void Destroy();

		// Token: 0x0600043F RID: 1087
		void Update3DAttributes(Vector3 vec, AudioChannel channel = AudioChannel.Action);

		// Token: 0x06000440 RID: 1088
		void PlayOneShot(string key, Vector3 pos);

		// Token: 0x06000441 RID: 1089
		void Init(GameObject go, Rigidbody rigidbody);
	}
}
