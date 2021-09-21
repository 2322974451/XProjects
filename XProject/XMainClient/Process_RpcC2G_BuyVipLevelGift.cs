using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02001209 RID: 4617
	internal class Process_RpcC2G_BuyVipLevelGift
	{
		// Token: 0x0600DCEC RID: 56556 RVA: 0x00330FD0 File Offset: 0x0032F1D0
		public static void OnReply(BuyVipLevelGiftArg oArg, BuyVipLevelGiftRes oRes)
		{
			bool flag = oRes.errcode > ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.errcode, "fece00");
			}
			else
			{
				XRechargeDocument specificDocument = XDocuments.GetSpecificDocument<XRechargeDocument>(XRechargeDocument.uuID);
				specificDocument.OnGetVIPGift(oArg.vipLevel);
			}
		}

		// Token: 0x0600DCED RID: 56557 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(BuyVipLevelGiftArg oArg)
		{
		}
	}
}
