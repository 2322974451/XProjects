using System;

namespace XMainClient
{
	// Token: 0x02001328 RID: 4904
	internal class Process_PtcM2C_InvUnfStateM2CNtf
	{
		// Token: 0x0600E190 RID: 57744 RVA: 0x00337C50 File Offset: 0x00335E50
		public static void Process(PtcM2C_InvUnfStateM2CNtf roPtc)
		{
			XTeamInviteDocument specificDocument = XDocuments.GetSpecificDocument<XTeamInviteDocument>(XTeamInviteDocument.uuID);
			XTeamInviteDocument xteamInviteDocument = specificDocument;
			int invitedCount = xteamInviteDocument.InvitedCount - 1;
			xteamInviteDocument.InvitedCount = invitedCount;
		}
	}
}
