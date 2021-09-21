using System;
using KKSG;

namespace XMainClient
{
	// Token: 0x02001479 RID: 5241
	internal class Process_RpcC2G_ForgeEquip
	{
		// Token: 0x0600E6E8 RID: 59112 RVA: 0x0033F421 File Offset: 0x0033D621
		public static void OnReply(ForgeEquipArg oArg, ForgeEquipRes oRes)
		{
			XForgeDocument.Doc.OnForgeEquipBack(oArg.type, oRes);
		}

		// Token: 0x0600E6E9 RID: 59113 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(ForgeEquipArg oArg)
		{
		}
	}
}
