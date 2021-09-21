using System;
using System.ComponentModel;
using UnityEngine;

namespace XUtliPoolLib
{
	// Token: 0x02000202 RID: 514
	[Serializable]
	public class XHitData : XBaseData
	{
		// Token: 0x06000BF3 RID: 3059 RVA: 0x0003E841 File Offset: 0x0003CA41
		public XHitData()
		{
			this.Fx_Follow = true;
			this.Additional_Using_Default = true;
		}

		// Token: 0x0400069C RID: 1692
		[SerializeField]
		[DefaultValue(0f)]
		public float Time_Present_Straight;

		// Token: 0x0400069D RID: 1693
		[SerializeField]
		[DefaultValue(0f)]
		public float Time_Hard_Straight;

		// Token: 0x0400069E RID: 1694
		[SerializeField]
		[DefaultValue(0f)]
		public float Offset;

		// Token: 0x0400069F RID: 1695
		[SerializeField]
		[DefaultValue(0f)]
		public float Height;

		// Token: 0x040006A0 RID: 1696
		[SerializeField]
		public XBeHitState State = XBeHitState.Hit_Back;

		// Token: 0x040006A1 RID: 1697
		[SerializeField]
		public XBeHitState_Animation State_Animation = XBeHitState_Animation.Hit_Back_Front;

		// Token: 0x040006A2 RID: 1698
		[SerializeField]
		[DefaultValue(0f)]
		public float Random_Range;

		// Token: 0x040006A3 RID: 1699
		[SerializeField]
		public string Fx = null;

		// Token: 0x040006A4 RID: 1700
		[SerializeField]
		[DefaultValue(true)]
		public bool Fx_Follow;

		// Token: 0x040006A5 RID: 1701
		[SerializeField]
		[DefaultValue(false)]
		public bool Fx_StickToGround;

		// Token: 0x040006A6 RID: 1702
		[SerializeField]
		[DefaultValue(false)]
		public bool CurveUsing;

		// Token: 0x040006A7 RID: 1703
		[SerializeField]
		[DefaultValue(false)]
		public bool FreezePresent;

		// Token: 0x040006A8 RID: 1704
		[SerializeField]
		[DefaultValue(0f)]
		public float FreezeDuration;

		// Token: 0x040006A9 RID: 1705
		[SerializeField]
		[DefaultValue(true)]
		public bool Additional_Using_Default;

		// Token: 0x040006AA RID: 1706
		[SerializeField]
		[DefaultValue(0f)]
		public float Additional_Hit_Time_Present_Straight;

		// Token: 0x040006AB RID: 1707
		[SerializeField]
		[DefaultValue(0f)]
		public float Additional_Hit_Time_Hard_Straight;

		// Token: 0x040006AC RID: 1708
		[SerializeField]
		[DefaultValue(0f)]
		public float Additional_Hit_Offset;

		// Token: 0x040006AD RID: 1709
		[SerializeField]
		[DefaultValue(0f)]
		public float Additional_Hit_Height;
	}
}
