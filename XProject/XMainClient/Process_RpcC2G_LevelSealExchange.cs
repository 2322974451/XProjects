using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02001265 RID: 4709
	internal class Process_RpcC2G_LevelSealExchange
	{
		// Token: 0x0600DE6F RID: 56943 RVA: 0x003333E4 File Offset: 0x003315E4
		public static void OnReply(LevelSealExchangeArg oArg, LevelSealExchangeRes oRes)
		{
			bool flag = oRes.errcode > ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.errcode, "fece00");
			}
		}

		// Token: 0x0600DE70 RID: 56944 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(LevelSealExchangeArg oArg)
		{
		}
	}
}
