using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_RpcC2G_ReEnterRiskBattle
	{

		public static void OnReply(ReEnterRiskBattleArg oArg, ReEnterRiskBattleRes oRes)
		{
			bool flag = oRes.error > ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.error, "fece00");
			}
		}

		public static void OnTimeout(ReEnterRiskBattleArg oArg)
		{
		}
	}
}
