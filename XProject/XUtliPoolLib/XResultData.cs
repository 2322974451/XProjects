using System;
using System.ComponentModel;
using UnityEngine;

namespace XUtliPoolLib
{
	// Token: 0x020001FC RID: 508
	[Serializable]
	public class XResultData : XBaseData
	{
		// Token: 0x06000BF0 RID: 3056 RVA: 0x0003E789 File Offset: 0x0003C989
		public XResultData()
		{
			this.Sector_Type = true;
		}

		// Token: 0x0400063B RID: 1595
		[SerializeField]
		[DefaultValue(false)]
		public bool LongAttackEffect;

		// Token: 0x0400063C RID: 1596
		[SerializeField]
		[DefaultValue(false)]
		public bool Attack_Only_Target;

		// Token: 0x0400063D RID: 1597
		[SerializeField]
		[DefaultValue(false)]
		public bool Attack_All;

		// Token: 0x0400063E RID: 1598
		[SerializeField]
		[DefaultValue(false)]
		public bool Mobs_Inclusived;

		// Token: 0x0400063F RID: 1599
		[SerializeField]
		[DefaultValue(true)]
		public bool Sector_Type;

		// Token: 0x04000640 RID: 1600
		[SerializeField]
		[DefaultValue(false)]
		public bool Rect_HalfEffect;

		// Token: 0x04000641 RID: 1601
		[SerializeField]
		[DefaultValue(0)]
		public int None_Sector_Angle_Shift;

		// Token: 0x04000642 RID: 1602
		[SerializeField]
		[DefaultValue(0f)]
		public float At;

		// Token: 0x04000643 RID: 1603
		[SerializeField]
		[DefaultValue(0f)]
		public float Low_Range;

		// Token: 0x04000644 RID: 1604
		[SerializeField]
		[DefaultValue(0f)]
		public float Range;

		// Token: 0x04000645 RID: 1605
		[SerializeField]
		[DefaultValue(0f)]
		public float Scope;

		// Token: 0x04000646 RID: 1606
		[SerializeField]
		[DefaultValue(0f)]
		public float Offset_X;

		// Token: 0x04000647 RID: 1607
		[SerializeField]
		[DefaultValue(0f)]
		public float Offset_Z;

		// Token: 0x04000648 RID: 1608
		[SerializeField]
		[DefaultValue(false)]
		public bool Loop;

		// Token: 0x04000649 RID: 1609
		[SerializeField]
		[DefaultValue(false)]
		public bool Group;

		// Token: 0x0400064A RID: 1610
		[SerializeField]
		[DefaultValue(0f)]
		public float Cycle;

		// Token: 0x0400064B RID: 1611
		[SerializeField]
		[DefaultValue(0)]
		public int Loop_Count;

		// Token: 0x0400064C RID: 1612
		[SerializeField]
		[DefaultValue(0)]
		public int Deviation_Angle;

		// Token: 0x0400064D RID: 1613
		[SerializeField]
		[DefaultValue(0)]
		public int Angle_Step;

		// Token: 0x0400064E RID: 1614
		[SerializeField]
		[DefaultValue(0f)]
		public float Time_Step;

		// Token: 0x0400064F RID: 1615
		[SerializeField]
		[DefaultValue(0)]
		public int Group_Count;

		// Token: 0x04000650 RID: 1616
		[SerializeField]
		[DefaultValue(0)]
		public int Token;

		// Token: 0x04000651 RID: 1617
		[SerializeField]
		[DefaultValue(false)]
		public bool Clockwise;

		// Token: 0x04000652 RID: 1618
		[SerializeField]
		public XLongAttackResultData LongAttackData;

		// Token: 0x04000653 RID: 1619
		[SerializeField]
		[DefaultValue(false)]
		public bool Warning;

		// Token: 0x04000654 RID: 1620
		[SerializeField]
		[DefaultValue(0)]
		public int Warning_Idx;

		// Token: 0x04000655 RID: 1621
		[SerializeField]
		public XResultAffectDirection Affect_Direction = XResultAffectDirection.AttackDir;
	}
}
