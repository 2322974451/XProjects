using System;
using KKSG;

namespace XMainClient
{
	// Token: 0x020015EC RID: 5612
	internal class Process_RpcC2G_BattleFieldAwardNumReq
	{
		// Token: 0x0600ECDE RID: 60638 RVA: 0x003479FD File Offset: 0x00345BFD
		public static void OnReply(BattleFieldAwardNumArg oArg, BattleFieldAwardNumRes oRes)
		{
			XBattleFieldEntranceDocument.Doc.SetPointRewardRemainCount(oRes);
		}

		// Token: 0x0600ECDF RID: 60639 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(BattleFieldAwardNumArg oArg)
		{
		}
	}
}
