using System;

namespace XMainClient
{
	// Token: 0x02001187 RID: 4487
	internal class Process_PtcG2C_GmfAllFightEndNtf
	{
		// Token: 0x0600DAEA RID: 56042 RVA: 0x0032E408 File Offset: 0x0032C608
		public static void Process(PtcG2C_GmfAllFightEndNtf roPtc)
		{
			XGuildArenaBattleDocument specificDocument = XDocuments.GetSpecificDocument<XGuildArenaBattleDocument>(XGuildArenaBattleDocument.uuID);
			specificDocument.OnAllFightEnd(roPtc.Data);
		}
	}
}
