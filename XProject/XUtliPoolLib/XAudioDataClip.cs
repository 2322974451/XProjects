using System;
using UnityEngine;

namespace XUtliPoolLib
{
	// Token: 0x020001D8 RID: 472
	[Serializable]
	public class XAudioDataClip : XCutSceneClip
	{
		// Token: 0x04000562 RID: 1378
		[SerializeField]
		public string Clip = null;

		// Token: 0x04000563 RID: 1379
		[SerializeField]
		public int BindIdx = 0;

		// Token: 0x04000564 RID: 1380
		[SerializeField]
		public AudioChannel Channel = AudioChannel.Skill;
	}
}
