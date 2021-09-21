using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x0200105B RID: 4187
	internal class Process_RpcC2G_BuyGoldAndFatigue
	{
		// Token: 0x0600D625 RID: 54821 RVA: 0x00325B1C File Offset: 0x00323D1C
		public static void OnReply(BuyGoldAndFatigueArg oArg, BuyGoldAndFatigueRes oRes)
		{
			bool flag = oRes.result == ErrorCode.ERR_INVALID_REQUEST;
			if (flag)
			{
				string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
				XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
			}
			else
			{
				bool flag2 = oRes.result > ErrorCode.ERR_SUCCESS;
				if (flag2)
				{
					DlgBase<XPurchaseView, XPurchaseBehaviour>.singleton.ShowErrorCode(oRes.result);
				}
				bool flag3 = oArg.type == buyextype.DRAGONCOIN_BUY_GOLD || oArg.type == buyextype.DRAGON_BUY_FATIGUE;
				if (flag3)
				{
					XDailyActivitiesDocument specificDocument = XDocuments.GetSpecificDocument<XDailyActivitiesDocument>(XDailyActivitiesDocument.uuID);
					specificDocument.DealWithBuyReply();
				}
			}
		}

		// Token: 0x0600D626 RID: 54822 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(BuyGoldAndFatigueArg oArg)
		{
		}
	}
}
