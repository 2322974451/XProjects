using System;

namespace XMainClient
{

	internal class Process_PtcG2C_LeagueBattleResultNtf
	{

		public static void Process(PtcG2C_LeagueBattleResultNtf roPtc)
		{
			XTeamLeagueBattleDocument specificDocument = XDocuments.GetSpecificDocument<XTeamLeagueBattleDocument>(XTeamLeagueBattleDocument.uuID);
			specificDocument.OnBigReward(roPtc.Data);
		}
	}
}
