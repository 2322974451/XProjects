using System;
using System.ComponentModel;
using UnityEngine;

namespace XUtliPoolLib
{
	// Token: 0x0200020C RID: 524
	[Serializable]
	public class XCameraPostEffectData
	{
		// Token: 0x040006F2 RID: 1778
		[SerializeField]
		[DefaultValue(0f)]
		public float At;

		// Token: 0x040006F3 RID: 1779
		[SerializeField]
		[DefaultValue(0f)]
		public float End;

		// Token: 0x040006F4 RID: 1780
		[SerializeField]
		public string Effect = null;

		// Token: 0x040006F5 RID: 1781
		[SerializeField]
		public string Shader = null;

		// Token: 0x040006F6 RID: 1782
		[SerializeField]
		[DefaultValue(false)]
		public bool SolidBlack;

		// Token: 0x040006F7 RID: 1783
		[SerializeField]
		[DefaultValue(0f)]
		public float Solid_At;

		// Token: 0x040006F8 RID: 1784
		[SerializeField]
		[DefaultValue(0f)]
		public float Solid_End;
	}
}
