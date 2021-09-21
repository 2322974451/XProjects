using System;

namespace XMainClient
{
	// Token: 0x020015DA RID: 5594
	internal class Process_PtcM2C_StartBattleFailedM2CNtf
	{
		// Token: 0x0600EC91 RID: 60561 RVA: 0x003473B4 File Offset: 0x003455B4
		public static void Process(PtcM2C_StartBattleFailedM2CNtf roPtc)
		{
			XTeamDocument specificDocument = XDocuments.GetSpecificDocument<XTeamDocument>(XTeamDocument.uuID);
			specificDocument.ProcessTeamOPErrorCode(roPtc.Data.reason, roPtc.Data.proUserID);
		}
	}
}
