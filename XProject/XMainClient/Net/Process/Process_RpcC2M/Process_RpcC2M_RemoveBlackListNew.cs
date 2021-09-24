using System;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_RpcC2M_RemoveBlackListNew
	{

		public static void OnReply(RemoveBlackListArg oArg, RemoveBlackListRes oRes)
		{
			bool flag = oRes == null;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowErrorCode(ErrorCode.ERR_FAILED);
			}
			else
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.errorcode, "fece00");
				XFriendsDocument specificDocument = XDocuments.GetSpecificDocument<XFriendsDocument>(XFriendsDocument.uuID);
				specificDocument.RemoveBlockFriendRes(oRes.errorcode, oArg.otherroleid);
				bool flag2 = DlgBase<XCharacterCommonMenuView, XCharacterCommonMenuBehaviour>.singleton.IsVisible();
				if (flag2)
				{
					DlgBase<XCharacterCommonMenuView, XCharacterCommonMenuBehaviour>.singleton.SetBlock();
					DlgBase<XCharacterCommonMenuView, XCharacterCommonMenuBehaviour>.singleton.RefreshBtns();
				}
			}
		}

		public static void OnTimeout(RemoveBlackListArg oArg)
		{
		}
	}
}
