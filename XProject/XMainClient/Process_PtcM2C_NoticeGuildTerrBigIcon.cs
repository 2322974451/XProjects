using System;

namespace XMainClient
{
	// Token: 0x020014B3 RID: 5299
	internal class Process_PtcM2C_NoticeGuildTerrBigIcon
	{
		// Token: 0x0600E7D7 RID: 59351 RVA: 0x00340968 File Offset: 0x0033EB68
		public static void Process(PtcM2C_NoticeGuildTerrBigIcon roPtc)
		{
			XGuildTerritoryDocument specificDocument = XDocuments.GetSpecificDocument<XGuildTerritoryDocument>(XGuildTerritoryDocument.uuID);
			specificDocument.TerritoryStyle = (roPtc.Data.isnow ? XGuildTerritoryDocument.GuildTerritoryStyle.INFORM : XGuildTerritoryDocument.GuildTerritoryStyle.NONE);
		}
	}
}
