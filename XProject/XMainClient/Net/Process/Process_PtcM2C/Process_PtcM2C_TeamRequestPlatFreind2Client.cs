using System;
using XMainClient.UI.UICommon;

namespace XMainClient
{

	internal class Process_PtcM2C_TeamRequestPlatFreind2Client
	{

		public static void Process(PtcM2C_TeamRequestPlatFreind2Client roPtc)
		{
			DlgBase<XFriendsView, XFriendsBehaviour>.singleton.NoticeFriendShare(roPtc.Data.openID, XFriendsView.ShareType.Invite);
		}
	}
}
