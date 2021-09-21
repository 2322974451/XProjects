using System;
using KKSG;

namespace XMainClient
{
	// Token: 0x020009E2 RID: 2530
	internal class ClientBoxInfo
	{
		// Token: 0x06009A8F RID: 39567 RVA: 0x001879D7 File Offset: 0x00185BD7
		public ClientBoxInfo(RiskBoxInfo r)
		{
			this.Apply(r);
		}

		// Token: 0x06009A90 RID: 39568 RVA: 0x001879EC File Offset: 0x00185BEC
		public void Apply(RiskBoxInfo r)
		{
			this.slot = r.slot;
			this.itemID = r.item.itemID;
			this.itemCount = r.item.itemCount;
			this.state = r.state;
			this.leftTime = (float)r.leftTime;
		}

		// Token: 0x04003546 RID: 13638
		public int slot;

		// Token: 0x04003547 RID: 13639
		public uint itemID;

		// Token: 0x04003548 RID: 13640
		public uint itemCount;

		// Token: 0x04003549 RID: 13641
		public RiskBoxState state;

		// Token: 0x0400354A RID: 13642
		public float leftTime;
	}
}
