using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02001515 RID: 5397
	internal class Process_RpcC2G_ReportBadPlayer
	{
		// Token: 0x0600E96D RID: 59757 RVA: 0x00342B14 File Offset: 0x00340D14
		public static void OnReply(ReportBadPlayerArg oArg, ReportBadPlayerRes oRes)
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
					XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("PVPReportSuccess"), "fece00");
				}
			}
		}

		// Token: 0x0600E96E RID: 59758 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(ReportBadPlayerArg oArg)
		{
		}
	}
}
