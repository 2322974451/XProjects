using System;
using KKSG;

namespace XMainClient
{
	// Token: 0x02001056 RID: 4182
	internal class Process_PtcG2C_LeaveTeam
	{
		// Token: 0x0600D611 RID: 54801 RVA: 0x0032577C File Offset: 0x0032397C
		public static void Process(PtcG2C_LeaveTeam roPtc)
		{
			XTeamDocument specificDocument = XDocuments.GetSpecificDocument<XTeamDocument>(XTeamDocument.uuID);
			specificDocument.OnLeaveTeam((LeaveTeamType)roPtc.Data.errorno);
		}
	}
}
