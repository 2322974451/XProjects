using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02001581 RID: 5505
	internal class Process_RpcC2M_GroupChatQuit
	{
		// Token: 0x0600EB28 RID: 60200 RVA: 0x00345530 File Offset: 0x00343730
		public static void OnReply(GroupChatQuitC2S oArg, GroupChatQuitS2C oRes)
		{
			bool flag = oRes == null;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(ErrorCode.ERR_FAILED, "fece00");
			}
			else
			{
				bool flag2 = oRes.errorcode == ErrorCode.ERR_INVALID_REQUEST;
				if (flag2)
				{
					string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
					XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
				}
				else
				{
					bool flag3 = oRes.errorcode == ErrorCode.ERR_SUCCESS;
					if (flag3)
					{
						GroupChatDocument specificDocument = XDocuments.GetSpecificDocument<GroupChatDocument>(GroupChatDocument.uuID);
						specificDocument.ResQuitGroup(oArg.groupchatID);
					}
					else
					{
						XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.errorcode, "fece00");
					}
				}
			}
		}

		// Token: 0x0600EB29 RID: 60201 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(GroupChatQuitC2S oArg)
		{
		}
	}
}
