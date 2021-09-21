using System;

namespace XMainClient
{
	// Token: 0x02001443 RID: 5187
	internal class Process_PtcM2C_GuildBonusGetAll
	{
		// Token: 0x0600E616 RID: 58902 RVA: 0x0033DDAC File Offset: 0x0033BFAC
		public static void Process(PtcM2C_GuildBonusGetAll roPtc)
		{
			XGuildRedPacketDocument specificDocument = XDocuments.GetSpecificDocument<XGuildRedPacketDocument>(XGuildRedPacketDocument.uuID);
			specificDocument.ReceiveGuildBonusGetAll(roPtc.Data.bonusID);
		}
	}
}
