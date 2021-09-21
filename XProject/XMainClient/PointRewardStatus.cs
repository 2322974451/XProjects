using System;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020009B8 RID: 2488
	public class PointRewardStatus
	{
		// Token: 0x04003365 RID: 13157
		public uint point;

		// Token: 0x04003366 RID: 13158
		public uint status;

		// Token: 0x04003367 RID: 13159
		public SeqListRef<uint> reward = default(SeqListRef<uint>);
	}
}
