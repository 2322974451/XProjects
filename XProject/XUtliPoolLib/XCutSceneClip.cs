using System;
using UnityEngine;

namespace XUtliPoolLib
{
	// Token: 0x020001D4 RID: 468
	[Serializable]
	public abstract class XCutSceneClip
	{
		// Token: 0x04000543 RID: 1347
		[SerializeField]
		public XClipType Type = XClipType.Actor;

		// Token: 0x04000544 RID: 1348
		[SerializeField]
		public float TimeLineAt = 0f;
	}
}
