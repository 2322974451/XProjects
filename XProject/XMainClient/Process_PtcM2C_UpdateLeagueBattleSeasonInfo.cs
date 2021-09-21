using System;

namespace XMainClient
{
	// Token: 0x0200145F RID: 5215
	internal class Process_PtcM2C_UpdateLeagueBattleSeasonInfo
	{
		// Token: 0x0600E682 RID: 59010 RVA: 0x0033EA38 File Offset: 0x0033CC38
		public static void Process(PtcM2C_UpdateLeagueBattleSeasonInfo roPtc)
		{
			XFreeTeamVersusLeagueDocument.Doc.OnGetLeagueSeasonInfo(roPtc);
		}
	}
}
