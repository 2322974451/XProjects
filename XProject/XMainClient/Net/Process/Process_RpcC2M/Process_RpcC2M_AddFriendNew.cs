using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_RpcC2M_AddFriendNew
	{

		public static void OnReply(AddFriendArg oArg, AddFriendRes oRes)
		{
			bool flag = oRes == null;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowErrorCode(ErrorCode.ERR_FAILED);
			}
			else
			{
				XFriendsDocument specificDocument = XDocuments.GetSpecificDocument<XFriendsDocument>(XFriendsDocument.uuID);
				specificDocument.AddFriendRes(oRes.errorcode, oArg.friendroleid);
			}
		}

		public static void OnTimeout(AddFriendArg oArg)
		{
		}
	}
}
