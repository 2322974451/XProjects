using System;

namespace XMainClient
{

	internal class Process_PtcM2C_NoticeGuildTerrBattleWin
	{

		public static void Process(PtcM2C_NoticeGuildTerrBattleWin roPtc)
		{
			XGuildTerritoryDocument specificDocument = XDocuments.GetSpecificDocument<XGuildTerritoryDocument>(XGuildTerritoryDocument.uuID);
			specificDocument.SetGuildTerritoryCityInfo(roPtc.Data.id, roPtc.Data.guildid);
		}
	}
}
