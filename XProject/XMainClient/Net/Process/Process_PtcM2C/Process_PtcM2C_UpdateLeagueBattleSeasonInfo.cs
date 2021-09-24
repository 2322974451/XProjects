using System;

namespace XMainClient
{

	internal class Process_PtcM2C_UpdateLeagueBattleSeasonInfo
	{

		public static void Process(PtcM2C_UpdateLeagueBattleSeasonInfo roPtc)
		{
			XFreeTeamVersusLeagueDocument.Doc.OnGetLeagueSeasonInfo(roPtc);
		}
	}
}
