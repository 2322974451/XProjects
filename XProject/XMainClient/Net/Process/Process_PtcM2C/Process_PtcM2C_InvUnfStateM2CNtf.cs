using System;

namespace XMainClient
{

	internal class Process_PtcM2C_InvUnfStateM2CNtf
	{

		public static void Process(PtcM2C_InvUnfStateM2CNtf roPtc)
		{
			XTeamInviteDocument specificDocument = XDocuments.GetSpecificDocument<XTeamInviteDocument>(XTeamInviteDocument.uuID);
			XTeamInviteDocument xteamInviteDocument = specificDocument;
			int invitedCount = xteamInviteDocument.InvitedCount - 1;
			xteamInviteDocument.InvitedCount = invitedCount;
		}
	}
}
