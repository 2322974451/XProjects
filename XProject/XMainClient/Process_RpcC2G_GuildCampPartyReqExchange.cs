using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020014F1 RID: 5361
	internal class Process_RpcC2G_GuildCampPartyReqExchange
	{
		// Token: 0x0600E8D9 RID: 59609 RVA: 0x00341D10 File Offset: 0x0033FF10
		public static void OnReply(GuildCampPartyReqExchangeReq oArg, GuildCampPartyReqExchangeRes oRes)
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
					XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("SendExchangeSuccess"), "fece00");
				}
			}
		}

		// Token: 0x0600E8DA RID: 59610 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(GuildCampPartyReqExchangeReq oArg)
		{
		}
	}
}
