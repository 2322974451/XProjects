using System;

namespace XMainClient
{
	// Token: 0x02001469 RID: 5225
	internal class Process_PtcM2C_NotifyLeagueTeamDissolve
	{
		// Token: 0x0600E6A9 RID: 59049 RVA: 0x0033ED70 File Offset: 0x0033CF70
		public static void Process(PtcM2C_NotifyLeagueTeamDissolve roPtc)
		{
			XFreeTeamVersusLeagueDocument specificDocument = XDocuments.GetSpecificDocument<XFreeTeamVersusLeagueDocument>(XFreeTeamVersusLeagueDocument.uuID);
			specificDocument.OnTeamLeagueDissolveNtf(roPtc);
		}
	}
}
