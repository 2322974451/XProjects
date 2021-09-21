using System;

namespace XMainClient
{
	// Token: 0x02001179 RID: 4473
	internal class Process_PtcG2C_GmfBaseDataNtf
	{
		// Token: 0x0600DAB7 RID: 55991 RVA: 0x0032E070 File Offset: 0x0032C270
		public static void Process(PtcG2C_GmfBaseDataNtf roPtc)
		{
			XGuildArenaBattleDocument specificDocument = XDocuments.GetSpecificDocument<XGuildArenaBattleDocument>(XGuildArenaBattleDocument.uuID);
			specificDocument.OnUpdateGuildArenaBattle(roPtc.Data);
		}
	}
}
