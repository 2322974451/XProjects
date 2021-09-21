using System;
using KKSG;

namespace XMainClient
{
	// Token: 0x020009C8 RID: 2504
	public class BagExpandData
	{
		// Token: 0x0600978B RID: 38795 RVA: 0x00171852 File Offset: 0x0016FA52
		public BagExpandData(BagType type)
		{
			this.Type = type;
		}

		// Token: 0x040033E7 RID: 13287
		public uint ExpandNum = 0U;

		// Token: 0x040033E8 RID: 13288
		public uint ExpandTimes = 0U;

		// Token: 0x040033E9 RID: 13289
		public BagType Type = BagType.ItemBag;
	}
}
