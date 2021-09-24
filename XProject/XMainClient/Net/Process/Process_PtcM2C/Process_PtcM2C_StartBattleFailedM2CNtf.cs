using System;

namespace XMainClient
{

	internal class Process_PtcM2C_StartBattleFailedM2CNtf
	{

		public static void Process(PtcM2C_StartBattleFailedM2CNtf roPtc)
		{
			XTeamDocument specificDocument = XDocuments.GetSpecificDocument<XTeamDocument>(XTeamDocument.uuID);
			specificDocument.ProcessTeamOPErrorCode(roPtc.Data.reason, roPtc.Data.proUserID);
		}
	}
}
