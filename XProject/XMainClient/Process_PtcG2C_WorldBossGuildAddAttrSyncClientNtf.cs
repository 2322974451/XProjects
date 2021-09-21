using System;

namespace XMainClient
{
	// Token: 0x020014C6 RID: 5318
	internal class Process_PtcG2C_WorldBossGuildAddAttrSyncClientNtf
	{
		// Token: 0x0600E821 RID: 59425 RVA: 0x00340F18 File Offset: 0x0033F118
		public static void Process(PtcG2C_WorldBossGuildAddAttrSyncClientNtf roPtc)
		{
			XWorldBossDocument specificDocument = XDocuments.GetSpecificDocument<XWorldBossDocument>(XWorldBossDocument.uuID);
			specificDocument.ReceiveGuildAttAttrSync(roPtc.Data);
		}
	}
}
