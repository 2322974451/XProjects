using System;

namespace XMainClient
{

	internal class Process_PtcM2C_FriendOpNtfNew
	{

		public static void Process(PtcM2C_FriendOpNtfNew roPtc)
		{
			XFriendsDocument specificDocument = XDocuments.GetSpecificDocument<XFriendsDocument>(XFriendsDocument.uuID);
			specificDocument.OnFriendOpNotify(roPtc);
		}
	}
}
