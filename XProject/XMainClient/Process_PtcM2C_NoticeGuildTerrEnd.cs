using System;

namespace XMainClient
{
	// Token: 0x020014AD RID: 5293
	internal class Process_PtcM2C_NoticeGuildTerrEnd
	{
		// Token: 0x0600E7C0 RID: 59328 RVA: 0x003407A4 File Offset: 0x0033E9A4
		public static void Process(PtcM2C_NoticeGuildTerrEnd roPtc)
		{
			XGuildTerritoryDocument specificDocument = XDocuments.GetSpecificDocument<XGuildTerritoryDocument>(XGuildTerritoryDocument.uuID);
			specificDocument.bHavaShowMessageIcon = true;
		}
	}
}
