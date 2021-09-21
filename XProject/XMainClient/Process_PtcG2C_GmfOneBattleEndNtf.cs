using System;

namespace XMainClient
{
	// Token: 0x02001177 RID: 4471
	internal class Process_PtcG2C_GmfOneBattleEndNtf
	{
		// Token: 0x0600DAB0 RID: 55984 RVA: 0x0032DFF4 File Offset: 0x0032C1F4
		public static void Process(PtcG2C_GmfOneBattleEndNtf roPtc)
		{
			XGuildArenaBattleDocument specificDocument = XDocuments.GetSpecificDocument<XGuildArenaBattleDocument>(XGuildArenaBattleDocument.uuID);
			specificDocument.OnUpdateBattleEnd(roPtc.Data);
		}
	}
}
