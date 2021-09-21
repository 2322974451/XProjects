using System;

namespace XMainClient
{
	// Token: 0x02001351 RID: 4945
	internal class Process_PtcG2C_GprAllFightEndNtf
	{
		// Token: 0x0600E237 RID: 57911 RVA: 0x00338B40 File Offset: 0x00336D40
		public static void Process(PtcG2C_GprAllFightEndNtf roPtc)
		{
			XGuildArenaBattleDocument specificDocument = XDocuments.GetSpecificDocument<XGuildArenaBattleDocument>(XGuildArenaBattleDocument.uuID);
			specificDocument.ReceiveDuelFinalResult(roPtc.Data);
		}
	}
}
