using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020014EF RID: 5359
	internal class Process_RpcC2G_GetGuildCamPartyRandItem
	{
		// Token: 0x0600E8D0 RID: 59600 RVA: 0x00341C2C File Offset: 0x0033FE2C
		public static void OnReply(GetGuildCamPartyRandItemArg oArg, GetGuildCamPartyRandItemRes oRes)
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

		// Token: 0x0600E8D1 RID: 59601 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(GetGuildCamPartyRandItemArg oArg)
		{
		}
	}
}
