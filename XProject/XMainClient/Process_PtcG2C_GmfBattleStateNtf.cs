using System;

namespace XMainClient
{
	// Token: 0x02001318 RID: 4888
	internal class Process_PtcG2C_GmfBattleStateNtf
	{
		// Token: 0x0600E150 RID: 57680 RVA: 0x0033758C File Offset: 0x0033578C
		public static void Process(PtcG2C_GmfBattleStateNtf roPtc)
		{
			XGuildArenaBattleDocument specificDocument = XDocuments.GetSpecificDocument<XGuildArenaBattleDocument>(XGuildArenaBattleDocument.uuID);
			specificDocument.OnBattleState(roPtc.Data);
		}
	}
}
