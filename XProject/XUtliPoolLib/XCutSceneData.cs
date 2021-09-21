using System;
using System.Collections.Generic;
using UnityEngine;

namespace XUtliPoolLib
{
	// Token: 0x020001D2 RID: 466
	[Serializable]
	public class XCutSceneData
	{
		// Token: 0x04000528 RID: 1320
		[SerializeField]
		public float TotalFrame = 0f;

		// Token: 0x04000529 RID: 1321
		[SerializeField]
		public string CameraClip = null;

		// Token: 0x0400052A RID: 1322
		[SerializeField]
		public string Name = null;

		// Token: 0x0400052B RID: 1323
		[SerializeField]
		public string Script = null;

		// Token: 0x0400052C RID: 1324
		[SerializeField]
		public string Scene = null;

		// Token: 0x0400052D RID: 1325
		[SerializeField]
		public int TypeMask = -1;

		// Token: 0x0400052E RID: 1326
		[SerializeField]
		public bool OverrideBGM = true;

		// Token: 0x0400052F RID: 1327
		[SerializeField]
		public bool Mourningborder = true;

		// Token: 0x04000530 RID: 1328
		[SerializeField]
		public bool AutoEnd = true;

		// Token: 0x04000531 RID: 1329
		[SerializeField]
		public float Length = 0f;

		// Token: 0x04000532 RID: 1330
		[SerializeField]
		public float FieldOfView = 45f;

		// Token: 0x04000533 RID: 1331
		[SerializeField]
		public string Trigger = "ToEffect";

		// Token: 0x04000534 RID: 1332
		[SerializeField]
		public bool GeneralShow = false;

		// Token: 0x04000535 RID: 1333
		[SerializeField]
		public bool GeneralBigGuy = false;

		// Token: 0x04000536 RID: 1334
		[SerializeField]
		public List<XActorDataClip> Actors = new List<XActorDataClip>();

		// Token: 0x04000537 RID: 1335
		[SerializeField]
		public List<XPlayerDataClip> Player = new List<XPlayerDataClip>();

		// Token: 0x04000538 RID: 1336
		[SerializeField]
		public List<XFxDataClip> Fxs = new List<XFxDataClip>();

		// Token: 0x04000539 RID: 1337
		[SerializeField]
		public List<XAudioDataClip> Audios = new List<XAudioDataClip>();

		// Token: 0x0400053A RID: 1338
		[SerializeField]
		public List<XSubTitleDataClip> SubTitle = new List<XSubTitleDataClip>();

		// Token: 0x0400053B RID: 1339
		[SerializeField]
		public List<XSlashDataClip> Slash = new List<XSlashDataClip>();
	}
}
