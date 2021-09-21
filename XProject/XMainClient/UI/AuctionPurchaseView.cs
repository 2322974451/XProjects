using System;
using UILib;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x0200171D RID: 5917
	internal class AuctionPurchaseView : DlgBase<AuctionPurchaseView, AuctionPurchaseBehaviour>
	{
		// Token: 0x170037A3 RID: 14243
		// (get) Token: 0x0600F468 RID: 62568 RVA: 0x0036E4EC File Offset: 0x0036C6EC
		public override string fileName
		{
			get
			{
				return "GameSystem/Auction/AuctionPurchaseFrame";
			}
		}

		// Token: 0x170037A4 RID: 14244
		// (get) Token: 0x0600F469 RID: 62569 RVA: 0x0036E504 File Offset: 0x0036C704
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x0600F46A RID: 62570 RVA: 0x0036E517 File Offset: 0x0036C717
		public void Set(AuctionItem item)
		{
			this.m_curOverlapItem = item;
			this.SetVisibleWithAnimation(true, null);
		}

		// Token: 0x0600F46B RID: 62571 RVA: 0x0036E52C File Offset: 0x0036C72C
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_maskSprite.RegisterClickEventHandler(new ButtonClickEventHandler(this.ClickCloseHandler));
			base.uiBehaviour.m_Ok.RegisterClickEventHandler(new ButtonClickEventHandler(this.ClickPurchaseHandler));
			base.uiBehaviour.m_CurCountOperate.RegisterOperateChange(new AuctionNumberOperate.NumberOperateCallBack(this.OnOperateChangeHandler));
		}

		// Token: 0x0600F46C RID: 62572 RVA: 0x0036E598 File Offset: 0x0036C798
		protected override void OnShow()
		{
			base.OnShow();
			base.uiBehaviour.m_SinglePrice.SetText(this.m_curOverlapItem.perprice.ToString());
			base.uiBehaviour.m_HavCoin.SetText(XSingleton<UiUtility>.singleton.NumberFormat(XBagDocument.BagDoc.GetItemCount(7)));
			base.uiBehaviour.m_CurCountOperate.Set(this.m_curOverlapItem.itemData.itemCount, 1, 1, 1, true, false);
			XSingleton<XItemDrawerMgr>.singleton.DrawItem(base.uiBehaviour.m_ItemTpl.gameObject, this.m_curOverlapItem.itemData);
		}

		// Token: 0x0600F46D RID: 62573 RVA: 0x0036E640 File Offset: 0x0036C840
		public void OnVirtuelRefresh()
		{
			this.OnOperateChangeHandler();
		}

		// Token: 0x0600F46E RID: 62574 RVA: 0x0036E64C File Offset: 0x0036C84C
		private void OnOperateChangeHandler()
		{
			ulong num = (ulong)((long)(base.uiBehaviour.m_CurCountOperate.Cur * (int)this.m_curOverlapItem.perprice));
			ulong itemCount = XBagDocument.BagDoc.GetItemCount(7);
			bool flag = num > itemCount;
			if (flag)
			{
				base.uiBehaviour.m_TotalPrice.SetText(string.Format("[ff0000]{0}[-]", num));
			}
			else
			{
				base.uiBehaviour.m_TotalPrice.SetText(num.ToString());
			}
		}

		// Token: 0x0600F46F RID: 62575 RVA: 0x0036E6C8 File Offset: 0x0036C8C8
		private bool ClickCloseHandler(IXUIButton sprite)
		{
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

		// Token: 0x0600F470 RID: 62576 RVA: 0x0036E6E4 File Offset: 0x0036C8E4
		private bool ClickPurchaseHandler(IXUIButton btn)
		{
			ItemList.RowData itemConf = XBagDocument.GetItemConf(this.m_curOverlapItem.itemData.itemID);
			string text = (itemConf != null && itemConf.ItemName.Length != 0) ? itemConf.ItemName[0] : string.Empty;
			ulong num = (ulong)((long)base.uiBehaviour.m_CurCountOperate.Cur * (long)((ulong)this.m_curOverlapItem.perprice));
			ulong itemCount = XBagDocument.BagDoc.GetItemCount(XFastEnumIntEqualityComparer<ItemEnum>.ToInt(ItemEnum.DRAGON_COIN));
			AuctionDocument specificDocument = XDocuments.GetSpecificDocument<AuctionDocument>(AuctionDocument.uuID);
			bool flag = specificDocument.TryDragonCoinFull(num, itemCount);
			if (flag)
			{
				bool flag2 = itemCount > 200UL;
				if (flag2)
				{
					this.ShowDailog(XStringDefineProxy.GetString("AUCTION_SALE_FROST", new object[]
					{
						XLabelSymbolHelper.FormatCostWithIcon((int)num, ItemEnum.DRAGON_COIN),
						text
					}), new ButtonClickEventHandler(this.OnSureAuctionBuy));
				}
				else
				{
					this.SendAuctionBuy();
				}
			}
			return true;
		}

		// Token: 0x0600F471 RID: 62577 RVA: 0x0011A6E1 File Offset: 0x001188E1
		private void ShowDailog(string message, ButtonClickEventHandler handler)
		{
			XSingleton<UiUtility>.singleton.ShowModalDialog(message, XStringDefineProxy.GetString("COMMON_OK"), XStringDefineProxy.GetString("COMMON_CANCEL"), handler);
		}

		// Token: 0x0600F472 RID: 62578 RVA: 0x0036E7C4 File Offset: 0x0036C9C4
		private bool OnSureAuctionBuy(IXUIButton btn)
		{
			XSingleton<UiUtility>.singleton.CloseModalDlg();
			this.SendAuctionBuy();
			return true;
		}

		// Token: 0x0600F473 RID: 62579 RVA: 0x0036E7EC File Offset: 0x0036C9EC
		private void SendAuctionBuy()
		{
			AuctionDocument specificDocument = XDocuments.GetSpecificDocument<AuctionDocument>(AuctionDocument.uuID);
			specificDocument.RequestAuctionBuy(this.m_curOverlapItem.uid, (uint)this.m_curOverlapItem.itemData.itemID, (uint)base.uiBehaviour.m_CurCountOperate.Cur);
			this.SetVisibleWithAnimation(false, null);
		}

		// Token: 0x04006959 RID: 26969
		private AuctionItem m_curOverlapItem;
	}
}
