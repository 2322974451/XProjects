using System;

namespace XMainClient
{
	// Token: 0x020011B2 RID: 4530
	internal class Process_PtcM2C_BlackListNtfNew
	{
		// Token: 0x0600DB93 RID: 56211 RVA: 0x0032F414 File Offset: 0x0032D614
		public static void Process(PtcM2C_BlackListNtfNew roPtc)
		{
			XFriendsDocument specificDocument = XDocuments.GetSpecificDocument<XFriendsDocument>(XFriendsDocument.uuID);
			specificDocument.RefreshBlockFriendData(roPtc.Data);
		}
	}
}
