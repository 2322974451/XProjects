using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02001310 RID: 4880
	internal class Process_RpcC2M_GuildBindGroup
	{
		// Token: 0x0600E12D RID: 57645 RVA: 0x00337238 File Offset: 0x00335438
		public static void OnReply(GuildBindGroupReq oArg, GuildBindGroupRes oRes)
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
					specificDocument.OnBindQQGroup(oArg, oRes);
				}
			}
		}

		// Token: 0x0600E12E RID: 57646 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(GuildBindGroupReq oArg)
		{
		}
	}
}
