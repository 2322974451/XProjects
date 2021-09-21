using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02001296 RID: 4758
	internal class Process_RpcC2M_GuildApprovalNew
	{
		// Token: 0x0600DF39 RID: 57145 RVA: 0x003343B4 File Offset: 0x003325B4
		public static void OnReply(GuildApprovalArg oArg, GuildApprovalRes oRes)
		{
			bool flag = oRes == null;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowErrorCode(ErrorCode.ERR_FAILED);
			}
			else
			{
				bool flag2 = oRes.result == ErrorCode.ERR_INVALID_REQUEST;
				if (flag2)
				{
					string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
					XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
				}
				else
				{
					XGuildApproveDocument specificDocument = XDocuments.GetSpecificDocument<XGuildApproveDocument>(XGuildApproveDocument.uuID);
					specificDocument.OnApprove(oArg, oRes);
				}
			}
		}

		// Token: 0x0600DF3A RID: 57146 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(GuildApprovalArg oArg)
		{
		}
	}
}
