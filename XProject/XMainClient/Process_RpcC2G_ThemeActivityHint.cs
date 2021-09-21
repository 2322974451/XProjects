using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020015D2 RID: 5586
	internal class Process_RpcC2G_ThemeActivityHint
	{
		// Token: 0x0600EC72 RID: 60530 RVA: 0x003471B0 File Offset: 0x003453B0
		public static void OnReply(ThemeActivityHintArg oArg, ThemeActivityHintRes oRes)
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
			}
		}

		// Token: 0x0600EC73 RID: 60531 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(ThemeActivityHintArg oArg)
		{
		}
	}
}
