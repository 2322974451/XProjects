using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02001614 RID: 5652
	internal class Process_RpcC2M_GetDailyTaskAskHelp
	{
		// Token: 0x0600ED88 RID: 60808 RVA: 0x003487B4 File Offset: 0x003469B4
		public static void OnReply(GetDailyTaskAskHelpArg oArg, GetDailyTaskAskHelpRes oRes)
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
						XGuildDailyTaskDocument.Doc.OnGetTaskHelpInfo(oRes);
					}
					else
					{
						XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.result, "fece00");
					}
				}
			}
		}

		// Token: 0x0600ED89 RID: 60809 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(GetDailyTaskAskHelpArg oArg)
		{
		}
	}
}
