using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020011AB RID: 4523
	internal class Process_RpcC2M_FriendGiftOpNew
	{
		// Token: 0x0600DB76 RID: 56182 RVA: 0x0032F158 File Offset: 0x0032D358
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

		// Token: 0x0600DB77 RID: 56183 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(FriendGiftOpArg oArg)
		{
		}
	}
}
