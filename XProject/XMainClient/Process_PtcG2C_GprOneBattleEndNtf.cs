using System;

namespace XMainClient
{
	// Token: 0x0200134F RID: 4943
	internal class Process_PtcG2C_GprOneBattleEndNtf
	{
		// Token: 0x0600E230 RID: 57904 RVA: 0x00338AC4 File Offset: 0x00336CC4
		public static void Process(PtcG2C_GprOneBattleEndNtf roPtc)
		{
			XGuildArenaBattleDocument specificDocument = XDocuments.GetSpecificDocument<XGuildArenaBattleDocument>(XGuildArenaBattleDocument.uuID);
			specificDocument.ReceiveDuelRoundResult(roPtc.Data);
		}
	}
}
