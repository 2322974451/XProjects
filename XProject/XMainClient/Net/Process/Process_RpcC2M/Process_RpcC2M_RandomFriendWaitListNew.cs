using System;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_RpcC2M_RandomFriendWaitListNew
	{

		public static void OnReply(RandomFriendWaitListArg oArg, RandomFriendWaitListRes oRes)
		{
			bool flag = oRes == null;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowErrorCode(ErrorCode.ERR_FAILED);
			}
			else
			{
				bool flag2 = oRes.errorcode > ErrorCode.ERR_SUCCESS;
				if (flag2)
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.errorcode, "fece00");
				}
				else
				{
					for (int i = 0; i < oRes.roleid.Count; i++)
					{
						DlgBase<DemoUI, DemoUIBehaviour>.singleton.AddMessage(oRes.name[i] + ":" + oRes.roleid[i].ToString());
					}
					XFriendsDocument specificDocument = XDocuments.GetSpecificDocument<XFriendsDocument>(XFriendsDocument.uuID);
					specificDocument.RandomFriendRes(oRes);
				}
			}
		}

		public static void OnTimeout(RandomFriendWaitListArg oArg)
		{
		}
	}
}
