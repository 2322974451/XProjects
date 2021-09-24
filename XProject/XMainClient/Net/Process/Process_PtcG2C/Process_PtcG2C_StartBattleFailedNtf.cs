using System;

namespace XMainClient
{

	internal class Process_PtcG2C_StartBattleFailedNtf
	{

		public static void Process(PtcG2C_StartBattleFailedNtf roPtc)
		{
			XTeamDocument specificDocument = XDocuments.GetSpecificDocument<XTeamDocument>(XTeamDocument.uuID);
			specificDocument.ProcessTeamOPErrorCode(roPtc.Data.reason, roPtc.Data.proUserID);
		}
	}
}
