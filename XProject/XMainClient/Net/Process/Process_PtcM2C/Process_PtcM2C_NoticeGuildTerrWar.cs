using System;

namespace XMainClient
{

	internal class Process_PtcM2C_NoticeGuildTerrWar
	{

		public static void Process(PtcM2C_NoticeGuildTerrWar roPtc)
		{
			XGuildTerritoryDocument specificDocument = XDocuments.GetSpecificDocument<XGuildTerritoryDocument>(XGuildTerritoryDocument.uuID);
			specificDocument.bHavaTerritoryRecCount = 0U;
			specificDocument.TerritoryStyle = (roPtc.Data.isbegin ? XGuildTerritoryDocument.GuildTerritoryStyle.ACTIVITY : XGuildTerritoryDocument.GuildTerritoryStyle.NONE);
		}
	}
}
