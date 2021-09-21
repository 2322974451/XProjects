using System;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020011A9 RID: 4521
	internal class Process_RpcC2M_RemoveBlackListNew
	{
		// Token: 0x0600DB6D RID: 56173 RVA: 0x0032F058 File Offset: 0x0032D258
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

		// Token: 0x0600DB6E RID: 56174 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(RemoveBlackListArg oArg)
		{
		}
	}
}
