using System;
using KKSG;

namespace XMainClient
{

	internal class Process_RpcC2G_BattleFieldRankReq
	{

		public static void OnReply(BattleFieldRankArg oArg, BattleFieldRankRes oRes)
		{
			XBattleFieldBattleDocument.Doc.SetRankData(oArg, oRes);
		}

		public static void OnTimeout(BattleFieldRankArg oArg)
		{
		}
	}
}
