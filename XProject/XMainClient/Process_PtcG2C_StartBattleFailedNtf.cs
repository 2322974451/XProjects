using System;

namespace XMainClient
{
	// Token: 0x0200114F RID: 4431
	internal class Process_PtcG2C_StartBattleFailedNtf
	{
		// Token: 0x0600DA04 RID: 55812 RVA: 0x0032C810 File Offset: 0x0032AA10
		public static void Process(PtcG2C_StartBattleFailedNtf roPtc)
		{
			XTeamDocument specificDocument = XDocuments.GetSpecificDocument<XTeamDocument>(XTeamDocument.uuID);
			specificDocument.ProcessTeamOPErrorCode(roPtc.Data.reason, roPtc.Data.proUserID);
		}
	}
}
