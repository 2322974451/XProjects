using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x0200157D RID: 5501
	internal class Process_RpcC2M_GroupChatGetGroupInfo
	{
		// Token: 0x0600EB16 RID: 60182 RVA: 0x00345308 File Offset: 0x00343508
		public static void OnReply(GroupChatGetGroupInfoC2S oArg, GroupChatGetGroupInfoS2C oRes)
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
						specificDocument.ResGroupInfo(oRes.playerlist);
					}
					else
					{
						XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.errorcode, "fece00");
					}
				}
			}
		}

		// Token: 0x0600EB17 RID: 60183 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(GroupChatGetGroupInfoC2S oArg)
		{
		}
	}
}
