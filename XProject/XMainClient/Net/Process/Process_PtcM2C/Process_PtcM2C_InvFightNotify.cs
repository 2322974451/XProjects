using System;

namespace XMainClient
{

	internal class Process_PtcM2C_InvFightNotify
	{

		public static void Process(PtcM2C_InvFightNotify roPtc)
		{
			XPKInvitationDocument specificDocument = XDocuments.GetSpecificDocument<XPKInvitationDocument>(XPKInvitationDocument.uuID);
			specificDocument.PKInvitationNotify(roPtc);
		}
	}
}
