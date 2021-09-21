using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02001612 RID: 5650
	internal class Process_RpcC2M_GetDailyTaskRefreshInfo
	{
		// Token: 0x0600ED7F RID: 60799 RVA: 0x003486A4 File Offset: 0x003468A4
		public static void OnReply(GetDailyTaskRefreshInfoArg oArg, GetDailyTaskRefreshInfoRes oRes)
		{
			bool flag = oRes == null;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(ErrorCode.ERR_FAILED, "fece00");
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
					bool flag3 = oRes.result == ErrorCode.ERR_SUCCESS;
					if (flag3)
					{
						XGuildDailyTaskDocument.Doc.OnGetTaskRefreshInfo(oRes);
					}
					else
					{
						XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.result, "fece00");
					}
				}
			}
		}

		// Token: 0x0600ED80 RID: 60800 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(GetDailyTaskRefreshInfoArg oArg)
		{
		}
	}
}
