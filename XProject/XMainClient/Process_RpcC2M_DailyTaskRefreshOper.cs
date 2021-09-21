using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02001618 RID: 5656
	internal class Process_RpcC2M_DailyTaskRefreshOper
	{
		// Token: 0x0600ED9A RID: 60826 RVA: 0x003489D4 File Offset: 0x00346BD4
		public static void OnReply(DailyTaskRefreshOperArg oArg, DailyTaskRefreshOperRes oRes)
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
					XGuildDailyTaskDocument.Doc.OnGetTaskRefreshOperResult(oArg, oRes);
				}
			}
		}

		// Token: 0x0600ED9B RID: 60827 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(DailyTaskRefreshOperArg oArg)
		{
		}
	}
}
