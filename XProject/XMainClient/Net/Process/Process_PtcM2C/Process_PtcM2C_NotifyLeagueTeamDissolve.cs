using System;

namespace XMainClient
{

	internal class Process_PtcM2C_NotifyLeagueTeamDissolve
	{

		public static void Process(PtcM2C_NotifyLeagueTeamDissolve roPtc)
		{
			XFreeTeamVersusLeagueDocument specificDocument = XDocuments.GetSpecificDocument<XFreeTeamVersusLeagueDocument>(XFreeTeamVersusLeagueDocument.uuID);
			specificDocument.OnTeamLeagueDissolveNtf(roPtc);
		}
	}
}
