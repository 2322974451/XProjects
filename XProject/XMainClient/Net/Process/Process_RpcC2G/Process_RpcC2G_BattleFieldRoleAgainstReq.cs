using System;
using KKSG;

namespace XMainClient
{

	internal class Process_RpcC2G_BattleFieldRoleAgainstReq
	{

		public static void OnReply(BattleFieldRoleAgainstArg oArg, BattleFieldRoleAgainst oRes)
		{
			XBattleFieldBattleDocument.Doc.SetBattleInfo(oRes);
		}

		public static void OnTimeout(BattleFieldRoleAgainstArg oArg)
		{
		}
	}
}
