using System;
using XMainClient.UI.UICommon;

namespace XMainClient
{
	// Token: 0x02001517 RID: 5399
	internal class Process_PtcM2C_TeamRequestPlatFreind2Client
	{
		// Token: 0x0600E975 RID: 59765 RVA: 0x00342BE8 File Offset: 0x00340DE8
		public static void Process(PtcM2C_TeamRequestPlatFreind2Client roPtc)
		{
			DlgBase<XFriendsView, XFriendsBehaviour>.singleton.NoticeFriendShare(roPtc.Data.openID, XFriendsView.ShareType.Invite);
		}
	}
}
