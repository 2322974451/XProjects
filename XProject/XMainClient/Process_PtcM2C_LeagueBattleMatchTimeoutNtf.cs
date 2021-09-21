using System;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02001487 RID: 5255
	internal class Process_PtcM2C_LeagueBattleMatchTimeoutNtf
	{
		// Token: 0x0600E720 RID: 59168 RVA: 0x0033F8FC File Offset: 0x0033DAFC
		public static void Process(PtcM2C_LeagueBattleMatchTimeoutNtf roPtc)
		{
			XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("MATCH_TIME_OUT_LEAGUE"), "fece00");
			XFreeTeamVersusLeagueDocument specificDocument = XDocuments.GetSpecificDocument<XFreeTeamVersusLeagueDocument>(XFreeTeamVersusLeagueDocument.uuID);
			specificDocument.SetTeamMatchState(false);
		}
	}
}
