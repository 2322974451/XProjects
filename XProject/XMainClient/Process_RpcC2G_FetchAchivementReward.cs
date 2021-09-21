using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x0200101A RID: 4122
	internal class Process_RpcC2G_FetchAchivementReward
	{
		// Token: 0x0600D50D RID: 54541 RVA: 0x00322E34 File Offset: 0x00321034
		public static void OnReply(FetchAchiveArg oArg, FetchAchiveRes oRes)
		{
			bool flag = oRes.Result == ErrorCode.ERR_INVALID_REQUEST;
			if (flag)
			{
				string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
				XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
			}
			else
			{
				bool flag2 = oRes.Result > ErrorCode.ERR_SUCCESS;
				if (flag2)
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.Result, "fece00");
				}
				else
				{
					XSingleton<XTutorialHelper>.singleton.GetReward = true;
				}
			}
		}

		// Token: 0x0600D50E RID: 54542 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(FetchAchiveArg oArg)
		{
		}
	}
}
