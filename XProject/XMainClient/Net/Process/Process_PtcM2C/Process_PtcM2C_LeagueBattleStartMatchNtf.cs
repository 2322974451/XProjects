using System;

namespace XMainClient
{

	internal class Process_PtcM2C_LeagueBattleStartMatchNtf
	{

		public static void Process(PtcM2C_LeagueBattleStartMatchNtf roPtc)
		{
			XFreeTeamVersusLeagueDocument specificDocument = XDocuments.GetSpecificDocument<XFreeTeamVersusLeagueDocument>(XFreeTeamVersusLeagueDocument.uuID);
			specificDocument.SetTeamMatchState(true);
		}
	}
}
