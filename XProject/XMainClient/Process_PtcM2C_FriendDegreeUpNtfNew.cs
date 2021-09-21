using System;

namespace XMainClient
{
	// Token: 0x020011AF RID: 4527
	internal class Process_PtcM2C_FriendDegreeUpNtfNew
	{
		// Token: 0x0600DB87 RID: 56199 RVA: 0x0032F320 File Offset: 0x0032D520
		public static void Process(PtcM2C_FriendDegreeUpNtfNew roPtc)
		{
			XFriendsDocument specificDocument = XDocuments.GetSpecificDocument<XFriendsDocument>(XFriendsDocument.uuID);
			specificDocument.UpdateFriendInfo(roPtc.Data.roleid, roPtc.Data.daydegree, roPtc.Data.alldegree);
			XTeamDocument specificDocument2 = XDocuments.GetSpecificDocument<XTeamDocument>(XTeamDocument.uuID);
			specificDocument2.RefreshMyTeamView();
		}
	}
}
