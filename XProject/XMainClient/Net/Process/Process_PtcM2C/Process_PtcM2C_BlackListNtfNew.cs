using System;

namespace XMainClient
{

	internal class Process_PtcM2C_BlackListNtfNew
	{

		public static void Process(PtcM2C_BlackListNtfNew roPtc)
		{
			XFriendsDocument specificDocument = XDocuments.GetSpecificDocument<XFriendsDocument>(XFriendsDocument.uuID);
			specificDocument.RefreshBlockFriendData(roPtc.Data);
		}
	}
}
