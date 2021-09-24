using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_RpcC2M_JoinLeagueEleBattle
	{

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

		public static void OnTimeout(JoinLeagueEleBattleArg oArg)
		{
		}
	}
}
