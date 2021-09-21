using System;
using KKSG;

namespace XMainClient
{
	// Token: 0x020011E1 RID: 4577
	internal class Process_PtcM2C_LeaveTeamM2CNtf
	{
		// Token: 0x0600DC4E RID: 56398 RVA: 0x00330280 File Offset: 0x0032E480
		public static void Process(PtcM2C_LeaveTeamM2CNtf roPtc)
		{
			XTeamDocument specificDocument = XDocuments.GetSpecificDocument<XTeamDocument>(XTeamDocument.uuID);
			specificDocument.OnLeaveTeam((LeaveTeamType)roPtc.Data.errorno);
		}
	}
}
