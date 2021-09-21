using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02001099 RID: 4249
	internal class Process_RpcC2G_GetOnlineReward
	{
		// Token: 0x0600D723 RID: 55075 RVA: 0x00327318 File Offset: 0x00325518
		public static void OnReply(GetOnlineRewardArg oArg, GetOnlineRewardRes oRes)
		{
			bool flag = oRes.errorcode == ErrorCode.ERR_INVALID_REQUEST;
			if (flag)
			{
				string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
				XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
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
					XOnlineRewardDocument specificDocument = XDocuments.GetSpecificDocument<XOnlineRewardDocument>(XOnlineRewardDocument.uuID);
					specificDocument.QueryStatus();
				}
			}
		}

		// Token: 0x0600D724 RID: 55076 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(GetOnlineRewardArg oArg)
		{
		}
	}
}
