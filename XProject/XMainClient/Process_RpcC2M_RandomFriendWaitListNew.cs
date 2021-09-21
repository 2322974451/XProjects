using System;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020011AD RID: 4525
	internal class Process_RpcC2M_RandomFriendWaitListNew
	{
		// Token: 0x0600DB7F RID: 56191 RVA: 0x0032F214 File Offset: 0x0032D414
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

		// Token: 0x0600DB80 RID: 56192 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(RandomFriendWaitListArg oArg)
		{
		}
	}
}
