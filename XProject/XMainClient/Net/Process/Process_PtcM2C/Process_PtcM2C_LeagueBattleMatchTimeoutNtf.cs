using System;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_PtcM2C_LeagueBattleMatchTimeoutNtf
	{

		public static void Process(PtcM2C_LeagueBattleMatchTimeoutNtf roPtc)
		{
			XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("MATCH_TIME_OUT_LEAGUE"), "fece00");
			XFreeTeamVersusLeagueDocument specificDocument = XDocuments.GetSpecificDocument<XFreeTeamVersusLeagueDocument>(XFreeTeamVersusLeagueDocument.uuID);
			specificDocument.SetTeamMatchState(false);
		}
	}
}
