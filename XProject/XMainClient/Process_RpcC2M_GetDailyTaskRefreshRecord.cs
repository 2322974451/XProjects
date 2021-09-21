using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02001616 RID: 5654
	internal class Process_RpcC2M_GetDailyTaskRefreshRecord
	{
		// Token: 0x0600ED91 RID: 60817 RVA: 0x003488C4 File Offset: 0x00346AC4
		public static void OnReply(GetDailyTaskRefreshRecordArg oArg, GetDailyTaskRefreshRecordRes oRes)
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
						XGuildDailyTaskDocument.Doc.OnGetRefreshRecordInfo(oRes);
					}
					else
					{
						XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.result, "fece00");
					}
				}
			}
		}

		// Token: 0x0600ED92 RID: 60818 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(GetDailyTaskRefreshRecordArg oArg)
		{
		}
	}
}
