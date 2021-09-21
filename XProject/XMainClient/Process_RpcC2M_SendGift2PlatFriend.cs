using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02001343 RID: 4931
	internal class Process_RpcC2M_SendGift2PlatFriend
	{
		// Token: 0x0600E201 RID: 57857 RVA: 0x003386B8 File Offset: 0x003368B8
		public static void OnReply(SendGift2PlatFriendArg oArg, SendGift2PlatFriendRes oRes)
		{
			bool flag = oRes == null;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowErrorCode(ErrorCode.ERR_FAILED);
			}
			else
			{
				bool flag2 = oRes.error == ErrorCode.ERR_INVALID_REQUEST;
				if (flag2)
				{
					string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
					XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
				}
				else
				{
					XFriendsDocument specificDocument = XDocuments.GetSpecificDocument<XFriendsDocument>(XFriendsDocument.uuID);
					specificDocument.OnSendGift2PlatFriend(oArg, oRes);
				}
			}
		}

		// Token: 0x0600E202 RID: 57858 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(SendGift2PlatFriendArg oArg)
		{
		}
	}
}
