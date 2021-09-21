using System;

namespace XMainClient
{
	// Token: 0x020013F7 RID: 5111
	internal class Process_PtcM2C_InvFightNotify
	{
		// Token: 0x0600E4E1 RID: 58593 RVA: 0x0033C3D0 File Offset: 0x0033A5D0
		public static void Process(PtcM2C_InvFightNotify roPtc)
		{
			XPKInvitationDocument specificDocument = XDocuments.GetSpecificDocument<XPKInvitationDocument>(XPKInvitationDocument.uuID);
			specificDocument.PKInvitationNotify(roPtc);
		}
	}
}
