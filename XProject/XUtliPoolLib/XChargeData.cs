using System;
using System.ComponentModel;
using UnityEngine;

namespace XUtliPoolLib
{
	// Token: 0x020001FE RID: 510
	[Serializable]
	public class XChargeData : XBaseData
	{
		// Token: 0x06000BF2 RID: 3058 RVA: 0x0003E81B File Offset: 0x0003CA1B
		public XChargeData()
		{
			this.StandOnAtEnd = true;
		}

		// Token: 0x0400067F RID: 1663
		[SerializeField]
		[DefaultValue(0f)]
		public float At;

		// Token: 0x04000680 RID: 1664
		[SerializeField]
		[DefaultValue(0f)]
		public float End;

		// Token: 0x04000681 RID: 1665
		[SerializeField]
		[DefaultValue(0f)]
		public float Offset;

		// Token: 0x04000682 RID: 1666
		[SerializeField]
		[DefaultValue(0f)]
		public float Height;

		// Token: 0x04000683 RID: 1667
		[SerializeField]
		[DefaultValue(0f)]
		public float Velocity;

		// Token: 0x04000684 RID: 1668
		[SerializeField]
		[DefaultValue(0f)]
		public float Rotation_Speed;

		// Token: 0x04000685 RID: 1669
		[SerializeField]
		[DefaultValue(false)]
		public bool Using_Curve;

		// Token: 0x04000686 RID: 1670
		[SerializeField]
		[DefaultValue(false)]
		public bool Control_Towards;

		// Token: 0x04000687 RID: 1671
		[SerializeField]
		public string Curve_Forward = null;

		// Token: 0x04000688 RID: 1672
		[SerializeField]
		public string Curve_Side = null;

		// Token: 0x04000689 RID: 1673
		[SerializeField]
		[DefaultValue(false)]
		public bool Using_Up;

		// Token: 0x0400068A RID: 1674
		[SerializeField]
		public string Curve_Up = null;

		// Token: 0x0400068B RID: 1675
		[SerializeField]
		[DefaultValue(true)]
		public bool StandOnAtEnd;

		// Token: 0x0400068C RID: 1676
		[SerializeField]
		[DefaultValue(false)]
		public bool AimTarget;
	}
}
