using System;
using System.ComponentModel;
using UnityEngine;

namespace XUtliPoolLib
{
	// Token: 0x0200020E RID: 526
	[Serializable]
	public class XAudioData : XBaseData
	{
		// Token: 0x040006FF RID: 1791
		[SerializeField]
		[DefaultValue(0f)]
		public float At;

		// Token: 0x04000700 RID: 1792
		[SerializeField]
		public string Clip = null;

		// Token: 0x04000701 RID: 1793
		[SerializeField]
		public AudioChannel Channel = AudioChannel.Skill;
	}
}
