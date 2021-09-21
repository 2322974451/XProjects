using System;

namespace XMainClient
{
	// Token: 0x0200135D RID: 4957
	internal class Process_PtcM2C_SendGuildBonusNtf
	{
		// Token: 0x0600E267 RID: 57959 RVA: 0x00338F6C File Offset: 0x0033716C
		public static void Process(PtcM2C_SendGuildBonusNtf roPtc)
		{
			XGuildRedPacketDocument specificDocument = XDocuments.GetSpecificDocument<XGuildRedPacketDocument>(XGuildRedPacketDocument.uuID);
			specificDocument.bHasAvailableFixedRedPoint = roPtc.Data.hasLeftSend;
		}
	}
}
