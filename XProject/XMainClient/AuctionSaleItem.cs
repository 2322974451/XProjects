using System;

namespace XMainClient
{
	// Token: 0x020008CD RID: 2253
	internal class AuctionSaleItem : AuctionItem
	{
		// Token: 0x17002A98 RID: 10904
		// (get) Token: 0x0600882E RID: 34862 RVA: 0x001193BC File Offset: 0x001175BC
		public bool isOutTime
		{
			get
			{
				return this.duelefttime == 0U;
			}
		}

		// Token: 0x04002B02 RID: 11010
		public uint duelefttime;
	}
}
