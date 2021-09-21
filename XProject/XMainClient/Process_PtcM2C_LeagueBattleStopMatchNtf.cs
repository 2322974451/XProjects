using System;

namespace XMainClient
{
	// Token: 0x02001473 RID: 5235
	internal class Process_PtcM2C_LeagueBattleStopMatchNtf
	{
		// Token: 0x0600E6D0 RID: 59088 RVA: 0x0033F0B8 File Offset: 0x0033D2B8
		public static void Process(PtcM2C_LeagueBattleStopMatchNtf roPtc)
		{
			XFreeTeamVersusLeagueDocument specificDocument = XDocuments.GetSpecificDocument<XFreeTeamVersusLeagueDocument>(XFreeTeamVersusLeagueDocument.uuID);
			specificDocument.SetTeamMatchState(false);
		}
	}
}
