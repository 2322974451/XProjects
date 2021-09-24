using System;

namespace XMainClient
{

	internal class Process_PtcG2C_LeagueBattleLoadInfoNtf
	{

		public static void Process(PtcG2C_LeagueBattleLoadInfoNtf roPtc)
		{
			XTeamLeagueBattleDocument specificDocument = XDocuments.GetSpecificDocument<XTeamLeagueBattleDocument>(XTeamLeagueBattleDocument.uuID);
			specificDocument.SetBattlePKInfo(roPtc.Data);
		}
	}
}
