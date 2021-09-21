using System;

namespace XMainClient
{
	// Token: 0x02001401 RID: 5121
	internal class Process_PtcG2C_GCFZhanLingNotify
	{
		// Token: 0x0600E508 RID: 58632 RVA: 0x0033C6C4 File Offset: 0x0033A8C4
		public static void Process(PtcG2C_GCFZhanLingNotify roPtc)
		{
			XGuildTerritoryDocument specificDocument = XDocuments.GetSpecificDocument<XGuildTerritoryDocument>(XGuildTerritoryDocument.uuID);
			specificDocument.OnZhanLingNotify(roPtc.Data);
		}
	}
}
