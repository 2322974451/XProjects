using System;

namespace XMainClient
{
	// Token: 0x02001498 RID: 5272
	internal class Process_PtcM2C_UpdateLeagueEleRoomStateNtf
	{
		// Token: 0x0600E769 RID: 59241 RVA: 0x0033FFE0 File Offset: 0x0033E1E0
		public static void Process(PtcM2C_UpdateLeagueEleRoomStateNtf roPtc)
		{
			XFreeTeamVersusLeagueDocument.Doc.OnUpdateEliRoomInfo(roPtc);
		}
	}
}
