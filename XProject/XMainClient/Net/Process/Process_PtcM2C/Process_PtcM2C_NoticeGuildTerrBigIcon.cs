using System;

namespace XMainClient
{

	internal class Process_PtcM2C_NoticeGuildTerrBigIcon
	{

		public static void Process(PtcM2C_NoticeGuildTerrBigIcon roPtc)
		{
			XGuildTerritoryDocument specificDocument = XDocuments.GetSpecificDocument<XGuildTerritoryDocument>(XGuildTerritoryDocument.uuID);
			specificDocument.TerritoryStyle = (roPtc.Data.isnow ? XGuildTerritoryDocument.GuildTerritoryStyle.INFORM : XGuildTerritoryDocument.GuildTerritoryStyle.NONE);
		}
	}
}
