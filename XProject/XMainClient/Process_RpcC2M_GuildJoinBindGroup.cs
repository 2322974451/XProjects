using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02001312 RID: 4882
	internal class Process_RpcC2M_GuildJoinBindGroup
	{
		// Token: 0x0600E136 RID: 57654 RVA: 0x00337324 File Offset: 0x00335524
		public static void OnReply(GuildJoinBindGroupReq oArg, GuildJoinBindGroupRes oRes)
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
					specificDocument.OnJoinBindQQGroup(oArg, oRes);
				}
			}
		}

		// Token: 0x0600E137 RID: 57655 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(GuildJoinBindGroupReq oArg)
		{
		}
	}
}
