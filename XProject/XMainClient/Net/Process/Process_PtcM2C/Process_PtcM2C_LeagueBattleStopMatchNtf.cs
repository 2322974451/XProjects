using System;

namespace XMainClient
{

	internal class Process_PtcM2C_LeagueBattleStopMatchNtf
	{

		public static void Process(PtcM2C_LeagueBattleStopMatchNtf roPtc)
		{
			XFreeTeamVersusLeagueDocument specificDocument = XDocuments.GetSpecificDocument<XFreeTeamVersusLeagueDocument>(XFreeTeamVersusLeagueDocument.uuID);
			specificDocument.SetTeamMatchState(false);
		}
	}
}
