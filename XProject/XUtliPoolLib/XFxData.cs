using System;
using System.ComponentModel;
using UnityEngine;

namespace XUtliPoolLib
{
	// Token: 0x02000210 RID: 528
	[Serializable]
	public class XFxData : XBaseData
	{
		// Token: 0x06000BFE RID: 3070 RVA: 0x0003E9C0 File Offset: 0x0003CBC0
		public XFxData()
		{
			this.Follow = true;
			this.ScaleX = 1f;
			this.ScaleY = 1f;
			this.ScaleZ = 1f;
		}

		// Token: 0x04000705 RID: 1797
		[SerializeField]
		public SkillFxType Type = SkillFxType.FirerBased;

		// Token: 0x04000706 RID: 1798
		[SerializeField]
		[DefaultValue(0f)]
		public float At;

		// Token: 0x04000707 RID: 1799
		[SerializeField]
		[DefaultValue(0f)]
		public float End;

		// Token: 0x04000708 RID: 1800
		[SerializeField]
		public string Fx = null;

		// Token: 0x04000709 RID: 1801
		[SerializeField]
		public string Bone = null;

		// Token: 0x0400070A RID: 1802
		[SerializeField]
		[DefaultValue(1f)]
		public float ScaleX;

		// Token: 0x0400070B RID: 1803
		[SerializeField]
		[DefaultValue(1f)]
		public float ScaleY;

		// Token: 0x0400070C RID: 1804
		[SerializeField]
		[DefaultValue(1f)]
		public float ScaleZ;

		// Token: 0x0400070D RID: 1805
		[SerializeField]
		[DefaultValue(0f)]
		public float OffsetX;

		// Token: 0x0400070E RID: 1806
		[SerializeField]
		[DefaultValue(0f)]
		public float OffsetY;

		// Token: 0x0400070F RID: 1807
		[SerializeField]
		[DefaultValue(0f)]
		public float OffsetZ;

		// Token: 0x04000710 RID: 1808
		[SerializeField]
		[DefaultValue(0f)]
		public float Target_OffsetX;

		// Token: 0x04000711 RID: 1809
		[SerializeField]
		[DefaultValue(0f)]
		public float Target_OffsetY;

		// Token: 0x04000712 RID: 1810
		[SerializeField]
		[DefaultValue(0f)]
		public float Target_OffsetZ;

		// Token: 0x04000713 RID: 1811
		[SerializeField]
		[DefaultValue(true)]
		public bool Follow;

		// Token: 0x04000714 RID: 1812
		[SerializeField]
		[DefaultValue(false)]
		public bool StickToGround;

		// Token: 0x04000715 RID: 1813
		[SerializeField]
		[DefaultValue(0f)]
		public float Destroy_Delay;

		// Token: 0x04000716 RID: 1814
		[SerializeField]
		[DefaultValue(false)]
		public bool Combined;

		// Token: 0x04000717 RID: 1815
		[SerializeField]
		[DefaultValue(false)]
		public bool Shield;
	}
}
