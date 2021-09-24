using System;

namespace XMainClient
{

	internal class Process_PtcM2C_UpdateLeagueEleRoomStateNtf
	{

		public static void Process(PtcM2C_UpdateLeagueEleRoomStateNtf roPtc)
		{
			XFreeTeamVersusLeagueDocument.Doc.OnUpdateEliRoomInfo(roPtc);
		}
	}
}
