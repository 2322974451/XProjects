using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02001314 RID: 4884
	internal class Process_RpcC2M_GuildUnBindGroup
	{
		// Token: 0x0600E13F RID: 57663 RVA: 0x00337410 File Offset: 0x00335610
		public static void OnReply(GuildUnBindGroupReq oArg, GuildUnBindGroupRes oRes)
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
					XGuildDocument specificDocument = XDocuments.GetSpecificDocument<XGuildDocument>(XGuildDocument.uuID);
					specificDocument.OnUnbindQQGroup(oArg, oRes);
				}
			}
		}

		// Token: 0x0600E140 RID: 57664 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(GuildUnBindGroupReq oArg)
		{
		}
	}
}
