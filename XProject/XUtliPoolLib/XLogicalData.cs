using System;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

namespace XUtliPoolLib
{
	// Token: 0x02000209 RID: 521
	[Serializable]
	public class XLogicalData
	{
		// Token: 0x06000BF9 RID: 3065 RVA: 0x0003E8F1 File Offset: 0x0003CAF1
		public XLogicalData()
		{
			this.AttackOnHitDown = true;
		}

		// Token: 0x040006CB RID: 1739
		[SerializeField]
		public XStrickenResponse StrickenMask = XStrickenResponse.Cease;

		// Token: 0x040006CC RID: 1740
		[SerializeField]
		[DefaultValue(0)]
		public int CanReplacedby;

		// Token: 0x040006CD RID: 1741
		[SerializeField]
		[DefaultValue(0f)]
		public float Not_Move_At;

		// Token: 0x040006CE RID: 1742
		[SerializeField]
		[DefaultValue(0f)]
		public float Not_Move_End;

		// Token: 0x040006CF RID: 1743
		[SerializeField]
		[DefaultValue(0f)]
		public float Rotate_At;

		// Token: 0x040006D0 RID: 1744
		[SerializeField]
		[DefaultValue(0f)]
		public float Rotate_End;

		// Token: 0x040006D1 RID: 1745
		[SerializeField]
		[DefaultValue(0f)]
		public float Rotate_Speed;

		// Token: 0x040006D2 RID: 1746
		[SerializeField]
		[DefaultValue(false)]
		public bool Rotate_Server_Sync;

		// Token: 0x040006D3 RID: 1747
		[SerializeField]
		[DefaultValue(0)]
		public int CanCastAt_QTE;

		// Token: 0x040006D4 RID: 1748
		[SerializeField]
		[DefaultValue(0)]
		public int QTE_Key;

		// Token: 0x040006D5 RID: 1749
		[SerializeField]
		public List<XQTEData> QTEData = null;

		// Token: 0x040006D6 RID: 1750
		[SerializeField]
		[DefaultValue(0f)]
		public float CanCancelAt;

		// Token: 0x040006D7 RID: 1751
		[SerializeField]
		[DefaultValue(false)]
		public bool SuppressPlayer;

		// Token: 0x040006D8 RID: 1752
		[SerializeField]
		[DefaultValue(true)]
		public bool AttackOnHitDown;

		// Token: 0x040006D9 RID: 1753
		[SerializeField]
		[DefaultValue(false)]
		public bool Association;

		// Token: 0x040006DA RID: 1754
		[SerializeField]
		[DefaultValue(false)]
		public bool MoveType;

		// Token: 0x040006DB RID: 1755
		[SerializeField]
		public string Association_Skill = null;

		// Token: 0x040006DC RID: 1756
		[SerializeField]
		public string Syntonic_CoolDown_Skill = null;

		// Token: 0x040006DD RID: 1757
		[SerializeField]
		[DefaultValue(0)]
		public int PreservedStrength;

		// Token: 0x040006DE RID: 1758
		[SerializeField]
		[DefaultValue(0f)]
		public float PreservedAt;

		// Token: 0x040006DF RID: 1759
		[SerializeField]
		[DefaultValue(0f)]
		public float PreservedEndAt;

		// Token: 0x040006E0 RID: 1760
		[SerializeField]
		public string Exstring = null;

		// Token: 0x040006E1 RID: 1761
		[SerializeField]
		[DefaultValue(0f)]
		public float Exstring_At;

		// Token: 0x040006E2 RID: 1762
		[SerializeField]
		[DefaultValue(0f)]
		public float Not_Selected_At;

		// Token: 0x040006E3 RID: 1763
		[SerializeField]
		[DefaultValue(0f)]
		public float Not_Selected_End;
	}
}
