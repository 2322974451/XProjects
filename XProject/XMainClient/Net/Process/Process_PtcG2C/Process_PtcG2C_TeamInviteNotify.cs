using System;

namespace XMainClient
{

	internal class Process_PtcG2C_TeamInviteNotify
	{

		public static void Process(PtcG2C_TeamInviteNotify roPtc)
		{
			XTeamInviteDocument specificDocument = XDocuments.GetSpecificDocument<XTeamInviteDocument>(XTeamInviteDocument.uuID);
			specificDocument.OnInviteComing(roPtc.Data);
		}
	}
}
