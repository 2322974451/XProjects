using System;
using UnityEngine;

namespace XUtliPoolLib
{
	// Token: 0x020001D5 RID: 469
	[Serializable]
	public class XActorDataClip : XCutSceneClip
	{
		// Token: 0x04000545 RID: 1349
		[SerializeField]
		public string Prefab = null;

		// Token: 0x04000546 RID: 1350
		[SerializeField]
		public string Clip = null;

		// Token: 0x04000547 RID: 1351
		[SerializeField]
		public float AppearX = 0f;

		// Token: 0x04000548 RID: 1352
		[SerializeField]
		public float AppearY = 0f;

		// Token: 0x04000549 RID: 1353
		[SerializeField]
		public float AppearZ = 0f;

		// Token: 0x0400054A RID: 1354
		[SerializeField]
		public int StatisticsID = 0;

		// Token: 0x0400054B RID: 1355
		[SerializeField]
		public bool bUsingID = false;

		// Token: 0x0400054C RID: 1356
		[SerializeField]
		public bool bToCommonPool = false;

		// Token: 0x0400054D RID: 1357
		[SerializeField]
		public string Tag = null;
	}
}
