using System;
using System.Collections.Generic;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020009F9 RID: 2553
	public class TargetItemInfo
	{
		// Token: 0x040036B2 RID: 14002
		public List<GoalAwards.RowData> subItems = new List<GoalAwards.RowData>();

		// Token: 0x040036B3 RID: 14003
		public uint goalAwardsID;

		// Token: 0x040036B4 RID: 14004
		public uint doneIndex;

		// Token: 0x040036B5 RID: 14005
		public uint gottenAwardsIndex;

		// Token: 0x040036B6 RID: 14006
		public uint minLevel;

		// Token: 0x040036B7 RID: 14007
		public double totalvalue;
	}
}
