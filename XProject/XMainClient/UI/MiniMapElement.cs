using System;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x02001887 RID: 6279
	internal class MiniMapElement
	{
		// Token: 0x040075A5 RID: 30117
		public IXUISprite sp;

		// Token: 0x040075A6 RID: 30118
		public Transform transform;

		// Token: 0x040075A7 RID: 30119
		public Vector3 pos;

		// Token: 0x040075A8 RID: 30120
		public XFx notice;

		// Token: 0x040075A9 RID: 30121
		public uint heroID = 0U;
	}
}
