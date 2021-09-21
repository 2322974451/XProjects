using System;
using System.ComponentModel;
using UnityEngine;

namespace XUtliPoolLib
{
	// Token: 0x02000203 RID: 515
	[Serializable]
	public class XManipulationData : XBaseData
	{
		// Token: 0x06000BF4 RID: 3060 RVA: 0x0003E86E File Offset: 0x0003CA6E
		public XManipulationData()
		{
			this.TargetIsOpponent = true;
		}

		// Token: 0x040006AE RID: 1710
		[SerializeField]
		[DefaultValue(0f)]
		public float At;

		// Token: 0x040006AF RID: 1711
		[SerializeField]
		[DefaultValue(0f)]
		public float End;

		// Token: 0x040006B0 RID: 1712
		[SerializeField]
		[DefaultValue(0f)]
		public float OffsetX;

		// Token: 0x040006B1 RID: 1713
		[SerializeField]
		[DefaultValue(0f)]
		public float OffsetZ;

		// Token: 0x040006B2 RID: 1714
		[SerializeField]
		[DefaultValue(0f)]
		public float Degree;

		// Token: 0x040006B3 RID: 1715
		[SerializeField]
		[DefaultValue(0f)]
		public float Radius;

		// Token: 0x040006B4 RID: 1716
		[SerializeField]
		[DefaultValue(0f)]
		public float Force;

		// Token: 0x040006B5 RID: 1717
		[SerializeField]
		[DefaultValue(true)]
		public bool TargetIsOpponent;
	}
}
