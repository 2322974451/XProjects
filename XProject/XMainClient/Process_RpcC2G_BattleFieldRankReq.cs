using System;
using KKSG;

namespace XMainClient
{
	// Token: 0x020015F0 RID: 5616
	internal class Process_RpcC2G_BattleFieldRankReq
	{
		// Token: 0x0600ECEE RID: 60654 RVA: 0x00347BBD File Offset: 0x00345DBD
		public static void OnReply(BattleFieldRankArg oArg, BattleFieldRankRes oRes)
		{
			XBattleFieldBattleDocument.Doc.SetRankData(oArg, oRes);
		}

		// Token: 0x0600ECEF RID: 60655 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(BattleFieldRankArg oArg)
		{
		}
	}
}
