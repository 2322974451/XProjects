using System;

namespace XMainClient
{
	// Token: 0x020011F6 RID: 4598
	internal class Process_PtcM2C_RoleMatchStateM2CNotify
	{
		// Token: 0x0600DC9F RID: 56479 RVA: 0x00330A0C File Offset: 0x0032EC0C
		public static void Process(PtcM2C_RoleMatchStateM2CNotify roPtc)
		{
			XTeamDocument specificDocument = XDocuments.GetSpecificDocument<XTeamDocument>(XTeamDocument.uuID);
			specificDocument.OnRoleMatchStateNotify(roPtc.Data);
		}
	}
}
