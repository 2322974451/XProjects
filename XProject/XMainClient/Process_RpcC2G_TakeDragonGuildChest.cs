using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02001625 RID: 5669
	internal class Process_RpcC2G_TakeDragonGuildChest
	{
		// Token: 0x0600EDD1 RID: 60881 RVA: 0x00348E2C File Offset: 0x0034702C
		public static void OnReply(TakePartnerChestArg oArg, TakePartnerChestRes oRes)
		{
			bool flag = oRes.result > ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowErrorCode(oRes.result);
			}
			else
			{
				XDragonGuildDocument.DragonGuildLivenessData.OnTakeDragonGuildChestBack(oArg, oRes);
			}
		}

		// Token: 0x0600EDD2 RID: 60882 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(TakePartnerChestArg oArg)
		{
		}
	}
}
