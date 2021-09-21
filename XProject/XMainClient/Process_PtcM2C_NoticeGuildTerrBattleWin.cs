using System;

namespace XMainClient
{
	// Token: 0x020014B1 RID: 5297
	internal class Process_PtcM2C_NoticeGuildTerrBattleWin
	{
		// Token: 0x0600E7D0 RID: 59344 RVA: 0x003408DC File Offset: 0x0033EADC
		public static void Process(PtcM2C_NoticeGuildTerrBattleWin roPtc)
		{
			XGuildTerritoryDocument specificDocument = XDocuments.GetSpecificDocument<XGuildTerritoryDocument>(XGuildTerritoryDocument.uuID);
			specificDocument.SetGuildTerritoryCityInfo(roPtc.Data.id, roPtc.Data.guildid);
		}
	}
}
