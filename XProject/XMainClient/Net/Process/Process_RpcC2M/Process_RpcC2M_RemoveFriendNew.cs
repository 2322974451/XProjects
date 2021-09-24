using System;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_RpcC2M_RemoveFriendNew
	{

		public static void OnReply(RemoveFriendArg oArg, RemoveFriendRes oRes)
		{
			bool flag = oRes == null;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowErrorCode(ErrorCode.ERR_FAILED);
			}
			else
			{
				XFriendsDocument specificDocument = XDocuments.GetSpecificDocument<XFriendsDocument>(XFriendsDocument.uuID);
				specificDocument.RemoveFriendRes(oRes.errorcode, oArg.friendroleid);
				bool flag2 = oRes.errorcode == ErrorCode.ERR_SUCCESS;
				if (flag2)
				{
					bool flag3 = DlgBase<XTeamView, TabDlgBehaviour>.singleton.IsVisible() && DlgBase<XTeamView, TabDlgBehaviour>.singleton._MyTeamHandler != null;
					if (flag3)
					{
						DlgBase<XTeamView, TabDlgBehaviour>.singleton._MyTeamHandler.RefreshPage();
					}
				}
			}
		}

		public static void OnTimeout(RemoveFriendArg oArg)
		{
		}
	}
}
