using System;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020011A5 RID: 4517
	internal class Process_RpcC2M_RemoveFriendNew
	{
		// Token: 0x0600DB5B RID: 56155 RVA: 0x0032EE6C File Offset: 0x0032D06C
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

		// Token: 0x0600DB5C RID: 56156 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(RemoveFriendArg oArg)
		{
		}
	}
}
