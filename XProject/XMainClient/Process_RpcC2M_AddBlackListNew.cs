using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020011A7 RID: 4519
	internal class Process_RpcC2M_AddBlackListNew
	{
		// Token: 0x0600DB64 RID: 56164 RVA: 0x0032EF70 File Offset: 0x0032D170
		public static void OnReply(AddBlackListArg oArg, AddBlackListRes oRes)
		{
			bool flag = oRes == null;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowErrorCode(ErrorCode.ERR_FAILED);
			}
			else
			{
				bool flag2 = oRes.errorcode == ErrorCode.ERR_SUCCESS;
				if (flag2)
				{
					XFriendsDocument specificDocument = XDocuments.GetSpecificDocument<XFriendsDocument>(XFriendsDocument.uuID);
					specificDocument.AddBlockFriendRes(oRes.black);
				}
				else
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.errorcode, "fece00");
				}
			}
		}

		// Token: 0x0600DB65 RID: 56165 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(AddBlackListArg oArg)
		{
		}
	}
}
