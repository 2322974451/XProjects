using System;

namespace XMainClient
{

	internal class Process_PtcG2C_LeagueBattleOneResultNft
	{

		public static void Process(PtcG2C_LeagueBattleOneResultNft roPtc)
		{
			XTeamLeagueBattleDocument specificDocument = XDocuments.GetSpecificDocument<XTeamLeagueBattleDocument>(XTeamLeagueBattleDocument.uuID);
			specificDocument.OnSmallReward(roPtc.Data);
		}
	}
}
