using System;

namespace XMainClient
{
	// Token: 0x0200119F RID: 4511
	internal class Process_PtcM2C_FriendOpNtfNew
	{
		// Token: 0x0600DB40 RID: 56128 RVA: 0x0032EC74 File Offset: 0x0032CE74
		public static void Process(PtcM2C_FriendOpNtfNew roPtc)
		{
			XFriendsDocument specificDocument = XDocuments.GetSpecificDocument<XFriendsDocument>(XFriendsDocument.uuID);
			specificDocument.OnFriendOpNotify(roPtc);
		}
	}
}
