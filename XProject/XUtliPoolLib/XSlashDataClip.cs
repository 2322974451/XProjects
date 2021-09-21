using System;
using UnityEngine;

namespace XUtliPoolLib
{
	// Token: 0x020001DA RID: 474
	[Serializable]
	public class XSlashDataClip : XCutSceneClip
	{
		// Token: 0x04000567 RID: 1383
		[SerializeField]
		public float Duration = 1f;

		// Token: 0x04000568 RID: 1384
		[SerializeField]
		public string Name;

		// Token: 0x04000569 RID: 1385
		[SerializeField]
		public string Discription;

		// Token: 0x0400056A RID: 1386
		[SerializeField]
		public float AnchorX;

		// Token: 0x0400056B RID: 1387
		[SerializeField]
		public float AnchorY;
	}
}
