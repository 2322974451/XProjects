using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02001261 RID: 4705
	internal class Process_RpcC2G_ReEnterRiskBattle
	{
		// Token: 0x0600DE5D RID: 56925 RVA: 0x00333240 File Offset: 0x00331440
		public static void OnReply(ReEnterRiskBattleArg oArg, ReEnterRiskBattleRes oRes)
		{
			bool flag = oRes.error > ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.error, "fece00");
			}
		}

		// Token: 0x0600DE5E RID: 56926 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(ReEnterRiskBattleArg oArg)
		{
		}
	}
}
