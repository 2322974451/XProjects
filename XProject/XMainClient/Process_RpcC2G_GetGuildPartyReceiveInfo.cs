using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x0200151B RID: 5403
	internal class Process_RpcC2G_GetGuildPartyReceiveInfo
	{
		// Token: 0x0600E986 RID: 59782 RVA: 0x00342DEC File Offset: 0x00340FEC
		public static void OnReply(GetGuildPartyReceiveInfoArg oArg, GetGuildPartyReceiveInfoRes oRes)
		{
			bool flag = oRes.result == ErrorCode.ERR_INVALID_REQUEST;
			if (flag)
			{
				string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
				XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
			}
			else
			{
				bool flag2 = oRes.result > ErrorCode.ERR_SUCCESS;
				if (flag2)
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.result, "fece00");
				}
				else
				{
					XGuildCollectDocument specificDocument = XDocuments.GetSpecificDocument<XGuildCollectDocument>(XGuildCollectDocument.uuID);
					specificDocument.OnUseCountGet(oRes.receives);
				}
			}
		}

		// Token: 0x0600E987 RID: 59783 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(GetGuildPartyReceiveInfoArg oArg)
		{
		}
	}
}
