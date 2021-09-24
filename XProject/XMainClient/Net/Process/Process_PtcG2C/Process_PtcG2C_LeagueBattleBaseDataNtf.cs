using System;

namespace XMainClient
{

	internal class Process_PtcG2C_LeagueBattleBaseDataNtf
	{

		public static void Process(PtcG2C_LeagueBattleBaseDataNtf roPtc)
		{
			XTeamLeagueBattleDocument specificDocument = XDocuments.GetSpecificDocument<XTeamLeagueBattleDocument>(XTeamLeagueBattleDocument.uuID);
			specificDocument.UpdateBattleBaseData(roPtc.Data);
		}
	}
}
