using System;
using KKSG;

namespace XMainClient
{
	// Token: 0x020015FC RID: 5628
	internal class Process_RpcC2G_BattleFieldRoleAgainstReq
	{
		// Token: 0x0600ED20 RID: 60704 RVA: 0x00347F45 File Offset: 0x00346145
		public static void OnReply(BattleFieldRoleAgainstArg oArg, BattleFieldRoleAgainst oRes)
		{
			XBattleFieldBattleDocument.Doc.SetBattleInfo(oRes);
		}

		// Token: 0x0600ED21 RID: 60705 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(BattleFieldRoleAgainstArg oArg)
		{
		}
	}
}
