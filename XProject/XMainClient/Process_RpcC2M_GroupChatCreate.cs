using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02001585 RID: 5509
	internal class Process_RpcC2M_GroupChatCreate
	{
		// Token: 0x0600EB38 RID: 60216 RVA: 0x003456C4 File Offset: 0x003438C4
		public static void OnReply(GroupChatCreateC2S oArg, GroupChatCreateS2C oRes)
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
						specificDocument.ResCreateGroupChat(oArg, oRes);
					}
					else
					{
						XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.errorcode, "fece00");
					}
				}
			}
		}

		// Token: 0x0600EB39 RID: 60217 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(GroupChatCreateC2S oArg)
		{
		}
	}
}
