using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_RpcC2G_BuyVipLevelGift
	{

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

		public static void OnTimeout(BuyVipLevelGiftArg oArg)
		{
		}
	}
}
