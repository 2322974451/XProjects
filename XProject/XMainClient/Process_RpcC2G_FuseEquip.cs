using System;
using KKSG;

namespace XMainClient
{
	// Token: 0x02001606 RID: 5638
	internal class Process_RpcC2G_FuseEquip
	{
		// Token: 0x0600ED49 RID: 60745 RVA: 0x00348205 File Offset: 0x00346405
		public static void OnReply(FuseEquipArg oArg, FuseEquipRes oRes)
		{
			EquipFusionDocument.Doc.OnGetEquipFuseInfo(oRes);
		}

		// Token: 0x0600ED4A RID: 60746 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(FuseEquipArg oArg)
		{
		}
	}
}
