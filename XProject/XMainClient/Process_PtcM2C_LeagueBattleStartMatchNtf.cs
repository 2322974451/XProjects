using System;

namespace XMainClient
{
	// Token: 0x02001471 RID: 5233
	internal class Process_PtcM2C_LeagueBattleStartMatchNtf
	{
		// Token: 0x0600E6C9 RID: 59081 RVA: 0x0033F040 File Offset: 0x0033D240
		public static void Process(PtcM2C_LeagueBattleStartMatchNtf roPtc)
		{
			XFreeTeamVersusLeagueDocument specificDocument = XDocuments.GetSpecificDocument<XFreeTeamVersusLeagueDocument>(XFreeTeamVersusLeagueDocument.uuID);
			specificDocument.SetTeamMatchState(true);
		}
	}
}
