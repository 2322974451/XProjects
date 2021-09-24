using System;

namespace XMainClient
{

	internal class Process_PtcG2C_ResWarTeamResOne
	{

		public static void Process(PtcG2C_ResWarTeamResOne roPtc)
		{
			XGuildMineBattleDocument specificDocument = XDocuments.GetSpecificDocument<XGuildMineBattleDocument>(XGuildMineBattleDocument.uuID);
			specificDocument.SetBattleTeamInfo(roPtc);
		}
	}
}
