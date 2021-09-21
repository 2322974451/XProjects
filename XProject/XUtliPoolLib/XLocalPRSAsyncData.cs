using System;
using UnityEngine;

namespace XUtliPoolLib
{
	// Token: 0x020001E9 RID: 489
	public class XLocalPRSAsyncData
	{
		// Token: 0x06000B40 RID: 2880 RVA: 0x0003AFC4 File Offset: 0x000391C4
		public void Reset()
		{
			this.localPos = Vector3.zero;
			this.localRotation = Quaternion.identity;
			this.localScale = Vector3.one;
			this.mask = 0;
			CommonObjectPool<XLocalPRSAsyncData>.Release(this);
		}

		// Token: 0x0400058B RID: 1419
		public Vector3 localPos = Vector3.zero;

		// Token: 0x0400058C RID: 1420
		public Quaternion localRotation = Quaternion.identity;

		// Token: 0x0400058D RID: 1421
		public Vector3 localScale = Vector3.one;

		// Token: 0x0400058E RID: 1422
		public short mask = 0;
	}
}
