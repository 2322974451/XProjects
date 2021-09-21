using System;

namespace XMainClient
{
	// Token: 0x02001430 RID: 5168
	internal class Process_PtcG2C_GCFSynG2CNtf
	{
		// Token: 0x0600E5C8 RID: 58824 RVA: 0x0033D68C File Offset: 0x0033B88C
		public static void Process(PtcG2C_GCFSynG2CNtf roPtc)
		{
			XGuildTerritoryDocument specificDocument = XDocuments.GetSpecificDocument<XGuildTerritoryDocument>(XGuildTerritoryDocument.uuID);
			specificDocument.OnGCFSynG2CNtf(roPtc.Data);
		}
	}
}
