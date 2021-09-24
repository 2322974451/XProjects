using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_RpcC2G_BuySpriteEgg
	{

		public static void OnReply(BuySpriteEggArg oArg, BuySpriteEggRes oRes)
		{
			bool flag = oRes.errorcode == ErrorCode.ERR_INVALID_REQUEST;
			if (flag)
			{
				string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
				XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
			}
			else
			{
				bool flag2 = oRes.errorcode == ErrorCode.ERR_ITEM_NOT_ENOUGH;
				if (flag2)
				{
					LotteryType type = (LotteryType)oArg.type;
					if (type - LotteryType.Sprite_Draw_One > 1)
					{
						if (type - LotteryType.Sprite_GoldDraw_One <= 1)
						{
							XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("SpriteLotteryGoldNotEnough"), "fece00");
							DlgBase<XPurchaseView, XPurchaseBehaviour>.singleton.ReqQuickCommonPurchase(ItemEnum.GOLD);
						}
					}
					else
					{
						XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("SpriteLotteryDragonCoinNotEnough"), "fece00");
						DlgBase<XPurchaseView, XPurchaseBehaviour>.singleton.ShowBorad(ItemEnum.DRAGON_COIN);
					}
				}
				else
				{
					bool flag3 = oRes.errorcode > ErrorCode.ERR_SUCCESS;
					if (flag3)
					{
						XSingleton<UiUtility>.singleton.ShowErrorCode(oRes.errorcode);
					}
					else
					{
						XSpriteSystemDocument specificDocument = XDocuments.GetSpecificDocument<XSpriteSystemDocument>(XSpriteSystemDocument.uuID);
						specificDocument.SetBuyEggData(oRes.goldfreebuycooldown, oRes.cooldown, oRes.goldfreebuycount);
						specificDocument.SetBuyEggItem(oRes.item);
					}
				}
			}
		}

		public static void OnTimeout(BuySpriteEggArg oArg)
		{
		}
	}
}
