using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02001326 RID: 4902
	internal class Process_RpcC2M_GardenOverview
	{
		// Token: 0x0600E188 RID: 57736 RVA: 0x00337B68 File Offset: 0x00335D68
		public static void OnReply(GardenOverviewArg oArg, GardenOverviewRes oRes)
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
						HomeMainDocument.Doc.OnGetGardenOverview(oRes);
					}
					else
					{
						XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.result, "fece00");
					}
				}
			}
		}

		// Token: 0x0600E189 RID: 57737 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(GardenOverviewArg oArg)
		{
		}
	}
}
