using System;

namespace XMainClient
{

	internal class Process_PtcM2C_FriendDegreeUpNtfNew
	{

		public static void Process(PtcM2C_FriendDegreeUpNtfNew roPtc)
		{
			XFriendsDocument specificDocument = XDocuments.GetSpecificDocument<XFriendsDocument>(XFriendsDocument.uuID);
			specificDocument.UpdateFriendInfo(roPtc.Data.roleid, roPtc.Data.daydegree, roPtc.Data.alldegree);
			XTeamDocument specificDocument2 = XDocuments.GetSpecificDocument<XTeamDocument>(XTeamDocument.uuID);
			specificDocument2.RefreshMyTeamView();
		}
	}
}
