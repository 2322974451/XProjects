using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x0200149A RID: 5274
	internal class Process_RpcC2M_JoinLeagueEleBattle
	{
		// Token: 0x0600E771 RID: 59249 RVA: 0x00340070 File Offset: 0x0033E270
		public static void OnReply(JoinLeagueEleBattleArg oArg, JoinLeagueEleBattleRes oRes)
		{
			bool flag = oRes == null;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(ErrorCode.ERR_FAILED, "fece00");
			}
			else
			{
				bool flag2 = oRes.result == ErrorCode.ERR_SUCCESS;
				if (!flag2)
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString(oRes.result), "fece00");
				}
			}
		}

		// Token: 0x0600E772 RID: 59250 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(JoinLeagueEleBattleArg oArg)
		{
		}
	}
}
