using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02001492 RID: 5266
	internal class Process_RpcC2G_ItemSell
	{
		// Token: 0x0600E74F RID: 59215 RVA: 0x0033FD0C File Offset: 0x0033DF0C
		public static void OnReply(ItemSellArg oArg, ItemSellRes oRes)
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
					XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("SELL_SUCCESS"), "fece00");
				}
			}
		}

		// Token: 0x0600E750 RID: 59216 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(ItemSellArg oArg)
		{
		}
	}
}
