using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020011A3 RID: 4515
	internal class Process_RpcC2M_DoAddFriendNew
	{
		// Token: 0x0600DB52 RID: 56146 RVA: 0x0032EDB0 File Offset: 0x0032CFB0
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

		// Token: 0x0600DB53 RID: 56147 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(DoAddFriendArg oArg)
		{
		}
	}
}
