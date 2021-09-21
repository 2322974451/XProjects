using System;
using System.ComponentModel;
using UnityEngine;

namespace XUtliPoolLib
{
	// Token: 0x02000214 RID: 532
	[Serializable]
	public class XWarningData : XBaseData
	{
		// Token: 0x06000C00 RID: 3072 RVA: 0x0003EA38 File Offset: 0x0003CC38
		public XWarningData()
		{
			this.Scale = 1f;
		}

		// Token: 0x0400072E RID: 1838
		[SerializeField]
		public XWarningType Type = XWarningType.Warning_None;

		// Token: 0x0400072F RID: 1839
		[SerializeField]
		[DefaultValue(0f)]
		public float At;

		// Token: 0x04000730 RID: 1840
		[SerializeField]
		[DefaultValue(0f)]
		public float FxDuration;

		// Token: 0x04000731 RID: 1841
		[SerializeField]
		[DefaultValue(0f)]
		public float OffsetX;

		// Token: 0x04000732 RID: 1842
		[SerializeField]
		[DefaultValue(0f)]
		public float OffsetY;

		// Token: 0x04000733 RID: 1843
		[SerializeField]
		[DefaultValue(0f)]
		public float OffsetZ;

		// Token: 0x04000734 RID: 1844
		[SerializeField]
		public string Fx = null;

		// Token: 0x04000735 RID: 1845
		[SerializeField]
		[DefaultValue(1f)]
		public float Scale = 1f;

		// Token: 0x04000736 RID: 1846
		[SerializeField]
		[DefaultValue(false)]
		public bool Mobs_Inclusived;

		// Token: 0x04000737 RID: 1847
		[SerializeField]
		[DefaultValue(0)]
		public int MaxRandomTarget;

		// Token: 0x04000738 RID: 1848
		[SerializeField]
		[DefaultValue(false)]
		public bool RandomWarningPos;

		// Token: 0x04000739 RID: 1849
		[SerializeField]
		[DefaultValue(0)]
		public float PosRandomRange;

		// Token: 0x0400073A RID: 1850
		[SerializeField]
		[DefaultValue(0)]
		public int PosRandomCount;
	}
}
