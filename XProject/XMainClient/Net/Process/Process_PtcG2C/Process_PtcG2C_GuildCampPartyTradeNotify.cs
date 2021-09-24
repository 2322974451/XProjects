using System;
using KKSG;

namespace XMainClient
{

	internal class Process_PtcG2C_GuildCampPartyTradeNotify
	{

		public static void Process(PtcG2C_GuildCampPartyTradeNotify roPtc)
		{
			bool flag = roPtc.Data.notify_type == GuildCampPartyTradeType.TRADE_INVITATION;
			if (flag)
			{
				XRequestDocument specificDocument = XDocuments.GetSpecificDocument<XRequestDocument>(XRequestDocument.uuID);
				specificDocument.SetMainInterfaceNum((int)roPtc.Data.lauch_count);
			}
			else
			{
				bool flag2 = roPtc.Data.notify_type == GuildCampPartyTradeType.UPDATA_TRADE_STATUS;
				if (flag2)
				{
					XExchangeItemDocument specificDocument2 = XDocuments.GetSpecificDocument<XExchangeItemDocument>(XExchangeItemDocument.uuID);
					specificDocument2.OnServerDataGet(roPtc.Data);
				}
			}
		}
	}
}
