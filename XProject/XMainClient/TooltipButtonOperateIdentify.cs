using System;
using UILib;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000C96 RID: 3222
	internal class TooltipButtonOperateIdentify : TooltipButtonOperateBase
	{
		// Token: 0x0600B5F5 RID: 46581 RVA: 0x002407DC File Offset: 0x0023E9DC
		public override string GetButtonText()
		{
			return XStringDefineProxy.GetString("IDENTIFY");
		}

		// Token: 0x0600B5F6 RID: 46582 RVA: 0x002407F8 File Offset: 0x0023E9F8
		public override bool HasRedPoint(XItem item)
		{
			return false;
		}

		// Token: 0x0600B5F7 RID: 46583 RVA: 0x0024080C File Offset: 0x0023EA0C
		public override bool IsButtonVisible(XItem item)
		{
			XEmblemItem xemblemItem = item as XEmblemItem;
			return xemblemItem.emblemInfo.thirdslot == 1U;
		}

		// Token: 0x0600B5F8 RID: 46584 RVA: 0x00240834 File Offset: 0x0023EA34
		public override void OnButtonClick(ulong mainUID, ulong compareUID)
		{
			base.OnButtonClick(mainUID, compareUID);
			XItem itemByUID = XSingleton<XGame>.singleton.Doc.XBagDoc.GetItemByUID(mainUID);
			bool flag = itemByUID != null;
			if (flag)
			{
				ItemList.RowData itemConf = XBagDocument.GetItemConf(itemByUID.itemID);
				EmblemBasic.RowData emblemConf = XBagDocument.GetEmblemConf(itemByUID.itemID);
				bool flag2 = emblemConf != null && itemConf != null;
				if (flag2)
				{
					bool flag3 = (long)emblemConf.DragonCoinCost <= (long)XBagDocument.BagDoc.GetVirtualItemCount(ItemEnum.DRAGON_COIN);
					if (flag3)
					{
						XSingleton<UiUtility>.singleton.ShowModalDialog(XStringDefineProxy.GetString("TOOLTIP_EMBLEM_IDENTIFY_MSG_FMT", new object[]
						{
							XSingleton<UiUtility>.singleton.ChooseProfString(itemConf.ItemName, 0U),
							emblemConf.DragonCoinCost
						}), XStringDefineProxy.GetString("COMMON_OK"), XStringDefineProxy.GetString("COMMON_CANCEL"), new ButtonClickEventHandler(this._Identify));
					}
					else
					{
						int level = (int)XSingleton<XAttributeMgr>.singleton.XPlayerData.Level;
						XRechargeDocument specificDocument = XDocuments.GetSpecificDocument<XRechargeDocument>(XRechargeDocument.uuID);
						int vipLevel = (int)specificDocument.VipLevel;
						XPurchaseDocument specificDocument2 = XDocuments.GetSpecificDocument<XPurchaseDocument>(XPurchaseDocument.uuID);
						XPurchaseInfo purchaseInfo = specificDocument2.GetPurchaseInfo(level, vipLevel, ItemEnum.DRAGON_COIN);
						bool flag4 = purchaseInfo.totalBuyNum > purchaseInfo.curBuyNum;
						if (flag4)
						{
							DlgBase<XPurchaseView, XPurchaseBehaviour>.singleton.ReqQuickCommonPurchase(ItemEnum.DRAGON_COIN);
						}
						else
						{
							XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("ERR_AUCT_DRAGONCOINLESS"), "fece00");
						}
					}
				}
			}
		}

		// Token: 0x0600B5F9 RID: 46585 RVA: 0x002409A0 File Offset: 0x0023EBA0
		private bool _Identify(IXUIButton btn)
		{
			XSingleton<UiUtility>.singleton.CloseModalDlg();
			RpcC2G_IdentifyEmblem rpcC2G_IdentifyEmblem = new RpcC2G_IdentifyEmblem();
			rpcC2G_IdentifyEmblem.oArg.uid = this.mainItemUID;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_IdentifyEmblem);
			return true;
		}
	}
}
