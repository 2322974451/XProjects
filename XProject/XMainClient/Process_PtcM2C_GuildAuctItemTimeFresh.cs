using System;

namespace XMainClient
{
	// Token: 0x020014A1 RID: 5281
	internal class Process_PtcM2C_GuildAuctItemTimeFresh
	{
		// Token: 0x0600E78E RID: 59278 RVA: 0x003402BC File Offset: 0x0033E4BC
		public static void Process(PtcM2C_GuildAuctItemTimeFresh roPtc)
		{
			AuctionHouseDocument specificDocument = XDocuments.GetSpecificDocument<AuctionHouseDocument>(AuctionHouseDocument.uuID);
			specificDocument.QueryRefreshGuildUI((int)roPtc.Data.auct_type);
		}
	}
}
