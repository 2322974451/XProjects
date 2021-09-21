using System;
using KKSG;

namespace XMainClient
{
	// Token: 0x020015E0 RID: 5600
	internal class Process_RpcC2G_UpgradeEquip
	{
		// Token: 0x0600ECA9 RID: 60585 RVA: 0x003475A9 File Offset: 0x003457A9
		public static void OnReply(UpgradeEquipArg oArg, UpgradeEquipRes oRes)
		{
			EquipUpgradeDocument.Doc.OnUpgradeBack(oRes);
		}

		// Token: 0x0600ECAA RID: 60586 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(UpgradeEquipArg oArg)
		{
		}
	}
}
