using System;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020009B9 RID: 2489
	public class RankRewardStatus
	{
		// Token: 0x04003368 RID: 13160
		public uint rank;

		// Token: 0x04003369 RID: 13161
		public bool isRange;

		// Token: 0x0400336A RID: 13162
		public SeqListRef<uint> reward = default(SeqListRef<uint>);
	}
}
