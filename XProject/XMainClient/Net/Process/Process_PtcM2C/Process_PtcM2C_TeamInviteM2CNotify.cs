using System;

namespace XMainClient
{

	internal class Process_PtcM2C_TeamInviteM2CNotify
	{

		public static void Process(PtcM2C_TeamInviteM2CNotify roPtc)
		{
			XTeamInviteDocument specificDocument = XDocuments.GetSpecificDocument<XTeamInviteDocument>(XTeamInviteDocument.uuID);
			specificDocument.OnInviteComing(roPtc.Data);
		}
	}
}
