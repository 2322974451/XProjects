using System;
using KKSG;

namespace XMainClient
{

	internal class Process_RpcC2G_BattleFieldAwardNumReq
	{

		public static void OnReply(BattleFieldAwardNumArg oArg, BattleFieldAwardNumRes oRes)
		{
			XBattleFieldEntranceDocument.Doc.SetPointRewardRemainCount(oRes);
		}

		public static void OnTimeout(BattleFieldAwardNumArg oArg)
		{
		}
	}
}
