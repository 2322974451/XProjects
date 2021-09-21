using System;

namespace XMainClient
{
	// Token: 0x02001438 RID: 5176
	internal class Process_PtcM2C_NoticeGuildTerrWar
	{
		// Token: 0x0600E5EA RID: 58858 RVA: 0x0033D9BC File Offset: 0x0033BBBC
		public static void Process(PtcM2C_NoticeGuildTerrWar roPtc)
		{
			XGuildTerritoryDocument specificDocument = XDocuments.GetSpecificDocument<XGuildTerritoryDocument>(XGuildTerritoryDocument.uuID);
			specificDocument.bHavaTerritoryRecCount = 0U;
			specificDocument.TerritoryStyle = (roPtc.Data.isbegin ? XGuildTerritoryDocument.GuildTerritoryStyle.ACTIVITY : XGuildTerritoryDocument.GuildTerritoryStyle.NONE);
		}
	}
}
