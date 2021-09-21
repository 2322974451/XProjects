using System;
using KKSG;

namespace XMainClient
{
	// Token: 0x02001507 RID: 5383
	internal class Process_PtcG2C_GuildCampPartyTradeNotify
	{
		// Token: 0x0600E933 RID: 59699 RVA: 0x0034252C File Offset: 0x0034072C
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
