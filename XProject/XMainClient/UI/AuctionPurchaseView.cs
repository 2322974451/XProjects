using System;
using UILib;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class AuctionPurchaseView : DlgBase<AuctionPurchaseView, AuctionPurchaseBehaviour>
	{

		public override string fileName
		{
			get
			{
				return "GameSystem/Auction/AuctionPurchaseFrame";
			}
		}

		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		public void Set(AuctionItem item)
		{
			this.m_curOverlapItem = item;
			this.SetVisibleWithAnimation(true, null);
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_maskSprite.RegisterClickEventHandler(new ButtonClickEventHandler(this.ClickCloseHandler));
			base.uiBehaviour.m_Ok.RegisterClickEventHandler(new ButtonClickEventHandler(this.ClickPurchaseHandler));
			base.uiBehaviour.m_CurCountOperate.RegisterOperateChange(new AuctionNumberOperate.NumberOperateCallBack(this.OnOperateChangeHandler));
		}

		protected override void OnShow()
		{
			base.OnShow();
			base.uiBehaviour.m_SinglePrice.SetText(this.m_curOverlapItem.perprice.ToString());
			base.uiBehaviour.m_HavCoin.SetText(XSingleton<UiUtility>.singleton.NumberFormat(XBagDocument.BagDoc.GetItemCount(7)));
			base.uiBehaviour.m_CurCountOperate.Set(this.m_curOverlapItem.itemData.itemCount, 1, 1, 1, true, false);
			XSingleton<XItemDrawerMgr>.singleton.DrawItem(base.uiBehaviour.m_ItemTpl.gameObject, this.m_curOverlapItem.itemData);
		}

		public void OnVirtuelRefresh()
		{
			this.OnOperateChangeHandler();
		}

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

		private bool ClickCloseHandler(IXUIButton sprite)
		{
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

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

		private void ShowDailog(string message, ButtonClickEventHandler handler)
		{
			XSingleton<UiUtility>.singleton.ShowModalDialog(message, XStringDefineProxy.GetString("COMMON_OK"), XStringDefineProxy.GetString("COMMON_CANCEL"), handler);
		}

		private bool OnSureAuctionBuy(IXUIButton btn)
		{
			XSingleton<UiUtility>.singleton.CloseModalDlg();
			this.SendAuctionBuy();
			return true;
		}

		private void SendAuctionBuy()
		{
			AuctionDocument specificDocument = XDocuments.GetSpecificDocument<AuctionDocument>(AuctionDocument.uuID);
			specificDocument.RequestAuctionBuy(this.m_curOverlapItem.uid, (uint)this.m_curOverlapItem.itemData.itemID, (uint)base.uiBehaviour.m_CurCountOperate.Cur);
			this.SetVisibleWithAnimation(false, null);
		}

		private AuctionItem m_curOverlapItem;
	}
}
