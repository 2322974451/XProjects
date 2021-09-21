using System;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x020018F4 RID: 6388
	internal struct BattleIndicator
	{
		// Token: 0x04007938 RID: 31032
		public ulong id;

		// Token: 0x04007939 RID: 31033
		public GameObject go;

		// Token: 0x0400793A RID: 31034
		public IXUISprite sp;

		// Token: 0x0400793B RID: 31035
		public Transform arrow;

		// Token: 0x0400793C RID: 31036
		public IXUISprite leader;

		// Token: 0x0400793D RID: 31037
		public XGameObject xGameObject;
	}
}
