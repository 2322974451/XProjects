using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_RpcC2G_BuyGoldAndFatigue
	{

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

		public static void OnTimeout(BuyGoldAndFatigueArg oArg)
		{
		}
	}
}
