using System;

namespace XMainClient
{

	internal class Process_PtcM2C_GuildAuctItemTimeFresh
	{

		public static void Process(PtcM2C_GuildAuctItemTimeFresh roPtc)
		{
			AuctionHouseDocument specificDocument = XDocuments.GetSpecificDocument<AuctionHouseDocument>(AuctionHouseDocument.uuID);
			specificDocument.QueryRefreshGuildUI((int)roPtc.Data.auct_type);
		}
	}
}
