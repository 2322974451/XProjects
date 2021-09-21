using System;
using UnityEngine;

namespace XUtliPoolLib
{
	// Token: 0x020001D7 RID: 471
	[Serializable]
	public class XFxDataClip : XCutSceneClip
	{
		// Token: 0x04000558 RID: 1368
		[SerializeField]
		public string Fx = null;

		// Token: 0x04000559 RID: 1369
		[SerializeField]
		public int BindIdx = 0;

		// Token: 0x0400055A RID: 1370
		[SerializeField]
		public string Bone = null;

		// Token: 0x0400055B RID: 1371
		[SerializeField]
		public float Scale = 1f;

		// Token: 0x0400055C RID: 1372
		[SerializeField]
		public bool Follow = true;

		// Token: 0x0400055D RID: 1373
		[SerializeField]
		public float Destroy_Delay = 0f;

		// Token: 0x0400055E RID: 1374
		[SerializeField]
		public float AppearX = 0f;

		// Token: 0x0400055F RID: 1375
		[SerializeField]
		public float AppearY = 0f;

		// Token: 0x04000560 RID: 1376
		[SerializeField]
		public float AppearZ = 0f;

		// Token: 0x04000561 RID: 1377
		[SerializeField]
		public float Face = 0f;
	}
}
