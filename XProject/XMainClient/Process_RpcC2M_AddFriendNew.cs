using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000B5E RID: 2910
	internal class Process_RpcC2M_AddFriendNew
	{
		// Token: 0x0600A901 RID: 43265 RVA: 0x001E17DC File Offset: 0x001DF9DC
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

		// Token: 0x0600A902 RID: 43266 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(AddFriendArg oArg)
		{
		}
	}
}
