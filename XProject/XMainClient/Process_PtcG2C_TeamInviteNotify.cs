using System;

namespace XMainClient
{
	// Token: 0x020010AD RID: 4269
	internal class Process_PtcG2C_TeamInviteNotify
	{
		// Token: 0x0600D771 RID: 55153 RVA: 0x00327ECC File Offset: 0x003260CC
		public static void Process(PtcG2C_TeamInviteNotify roPtc)
		{
			XTeamInviteDocument specificDocument = XDocuments.GetSpecificDocument<XTeamInviteDocument>(XTeamInviteDocument.uuID);
			specificDocument.OnInviteComing(roPtc.Data);
		}
	}
}
