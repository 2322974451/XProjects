using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_RpcC2M_DoAddFriendNew
	{

		public static void OnReply(DoAddFriendArg oArg, DoAddFriendRes oRes)
		{
			bool flag = oRes == null;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowErrorCode(ErrorCode.ERR_FAILED);
			}
			else
			{
				XFriendsDocument specificDocument = XDocuments.GetSpecificDocument<XFriendsDocument>(XFriendsDocument.uuID);
				specificDocument.OnApply(oArg, oRes);
			}
		}

		public static void OnTimeout(DoAddFriendArg oArg)
		{
		}
	}
}
