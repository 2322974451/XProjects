using System;

namespace XMainClient
{
	// Token: 0x020011E5 RID: 4581
	internal class Process_PtcM2C_TeamInviteM2CNotify
	{
		// Token: 0x0600DC5C RID: 56412 RVA: 0x0033037C File Offset: 0x0032E57C
		public static void Process(PtcM2C_TeamInviteM2CNotify roPtc)
		{
			XTeamInviteDocument specificDocument = XDocuments.GetSpecificDocument<XTeamInviteDocument>(XTeamInviteDocument.uuID);
			specificDocument.OnInviteComing(roPtc.Data);
		}
	}
}
