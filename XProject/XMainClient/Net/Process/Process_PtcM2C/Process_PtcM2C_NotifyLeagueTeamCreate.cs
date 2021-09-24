using System;

namespace XMainClient
{

	internal class Process_PtcM2C_NotifyLeagueTeamCreate
	{

		public static void Process(PtcM2C_NotifyLeagueTeamCreate roPtc)
		{
			XFreeTeamVersusLeagueDocument specificDocument = XDocuments.GetSpecificDocument<XFreeTeamVersusLeagueDocument>(XFreeTeamVersusLeagueDocument.uuID);
			specificDocument.OnTeamLeagueCreateNtf(roPtc);
		}
	}
}
