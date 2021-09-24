using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_RpcC2M_FriendGiftOpNew
	{

		public static void OnReply(FriendGiftOpArg oArg, FriendGiftOpRes oRes)
		{
			bool flag = oRes == null;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowErrorCode(ErrorCode.ERR_FAILED);
			}
			else
			{
				XFriendsDocument specificDocument = XDocuments.GetSpecificDocument<XFriendsDocument>(XFriendsDocument.uuID);
				specificDocument.OnFriendGiftOp(oArg, oRes);
			}
		}

		public static void OnTimeout(FriendGiftOpArg oArg)
		{
		}
	}
}
