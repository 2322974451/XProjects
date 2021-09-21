using System;

namespace XMainClient
{
	// Token: 0x02001467 RID: 5223
	internal class Process_PtcM2C_NotifyLeagueTeamCreate
	{
		// Token: 0x0600E6A2 RID: 59042 RVA: 0x0033ECF8 File Offset: 0x0033CEF8
		public static void Process(PtcM2C_NotifyLeagueTeamCreate roPtc)
		{
			XFreeTeamVersusLeagueDocument specificDocument = XDocuments.GetSpecificDocument<XFreeTeamVersusLeagueDocument>(XFreeTeamVersusLeagueDocument.uuID);
			specificDocument.OnTeamLeagueCreateNtf(roPtc);
		}
	}
}
