using System;

namespace XMainClient
{

	internal class Process_PtcG2C_LeagueBattleStateNtf
	{

		public static void Process(PtcG2C_LeagueBattleStateNtf roPtc)
		{
			XTeamLeagueBattleDocument specificDocument = XDocuments.GetSpecificDocument<XTeamLeagueBattleDocument>(XTeamLeagueBattleDocument.uuID);
			specificDocument.OnLeagueBattleStateNtf(roPtc.Data);
		}
	}
}
