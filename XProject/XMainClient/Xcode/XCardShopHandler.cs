using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XCardShopHandler : DlgHandlerBase
	{

		protected override void Init()
		{
			base.Init();
			this.doc = XDocuments.GetSpecificDocument<XCardCollectDocument>(XCardCollectDocument.uuID);
			this.m_Close = (base.PanelObject.transform.Find("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_ChipNum = (base.PanelObject.transform.Find("Bg/ChipNum").GetComponent("XUILabel") as IXUILabel);
			this.m_ChipIcon = (base.PanelObject.transform.Find("Bg/ChipNum/MoneyIcon").GetComponent("XUISprite") as IXUISprite);
			this.m_ChipIcon.SetSprite(XBagDocument.GetItemSmallIcon(int.Parse(XSingleton<XGlobalConfig>.singleton.GetValue("CardChip")), 0U));
			this.m_GoodsScrollView = (base.PanelObject.transform.Find("Bg/ShopPanel").GetComponent("XUIScrollView") as IXUIScrollView);
			IXUISprite ixuisprite = base.PanelObject.transform.Find("Bg/ShopPanel/GoodsTpl").GetComponent("XUISprite") as IXUISprite;
			this.m_GoodsPool.SetupPool(null, ixuisprite.gameObject, 9U, false);
			this.disX = ixuisprite.spriteWidth;
			this.disY = ixuisprite.spriteHeight;
			this.InitShow();
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnCloseClicked));
		}

		private bool _OnCloseClicked(IXUIButton go)
		{
			base.PanelObject.SetActive(false);
			bool flag = DlgBase<CardCollectView, CardCollectBehaviour>.singleton.IsVisible();
			if (flag)
			{
				this.doc.View.CloseCurPage(CardPage.CardShop);
			}
			return true;
		}

		public override void OnUnload()
		{
			base.OnUnload();
			this.doc = null;
		}

		protected override void OnShow()
		{
		}

		private void _OnBuyClicked(IXUISprite iSp)
		{
			int index = (int)iSp.ID;
			int itemID = this.goods[index].item.itemID;
			ItemList.RowData itemConf = XBagDocument.GetItemConf(itemID);
			this.m_BuyGoods = this.goods[index];
			bool flag = this.money >= this.goods[index].priceValue;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowModalDialog(string.Format(XSingleton<UiUtility>.singleton.ReplaceReturn(XSingleton<XStringTable>.singleton.GetString("CATD_BUY")), this.goods[index].priceValue, itemConf.ItemName[0], this.money), XStringDefineProxy.GetString("COMMON_OK"), XStringDefineProxy.GetString("COMMON_CANCEL"), new ButtonClickEventHandler(this._OnBuyCompose));
			}
			else
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(XSingleton<XStringTable>.singleton.GetString("CARD_BUY_INSUFFICIENT"), "fece00");
			}
		}

		private bool _OnBuyCompose(IXUIButton btn)
		{
			XNormalShopDocument specificDocument = XDocuments.GetSpecificDocument<XNormalShopDocument>(XNormalShopDocument.uuID);
			specificDocument.DoBuyItem(this.m_BuyGoods, 1U);
			XSingleton<UiUtility>.singleton.CloseModalDlg();
			return true;
		}

		public void SetCardShop(List<XNormalShopGoods> data)
		{
			bool flag = this.doc.View == null;
			if (!flag)
			{
				bool flag2 = this.doc.View.CurPage == CardPage.CardDetail && this.doc.View != null;
				if (flag2)
				{
					for (int i = 0; i < data.Count; i++)
					{
						bool flag3 = data[i].item.itemID == this.doc.View.CurCardID;
						if (flag3)
						{
							this.doc.View.SingleShop(data[i]);
							return;
						}
					}
					XSingleton<UiUtility>.singleton.ShowSystemTip(XSingleton<XStringTable>.singleton.GetString("CATD_NO_CAN_BUY"), "fece00");
				}
				bool flag4 = this.doc.View.CurPage != CardPage.CardShop;
				if (!flag4)
				{
					this.goods.Clear();
					this.m_GoodsPool.FakeReturnAll();
					for (int j = 0; j < data.Count; j++)
					{
						this.goods.Add(data[j]);
						GameObject gameObject = this.m_GoodsPool.FetchGameObject(false);
						gameObject.transform.localPosition = new Vector3((float)((long)this.disX * ((long)j % (long)((ulong)XCardShopHandler.SHOP_LINE_COUNT))), (float)((long)(-(long)this.disY) * ((long)j / (long)((ulong)XCardShopHandler.SHOP_LINE_COUNT))), 0f);
						Transform transform = gameObject.transform.Find("Item");
						XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(transform.gameObject, data[j].item.itemID, 0, false);
						IXUISprite ixuisprite = gameObject.transform.Find("Item/Icon").GetComponent("XUISprite") as IXUISprite;
						ixuisprite.ID = (ulong)((long)data[j].item.itemID);
						ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(DlgBase<CardCollectView, CardCollectBehaviour>.singleton.OnOpenDetailClick));
						IXUISprite ixuisprite2 = gameObject.transform.Find("Buy").GetComponent("XUISprite") as IXUISprite;
						ixuisprite2.ID = (ulong)((long)j);
						ixuisprite2.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this._OnBuyClicked));
						IXUILabel ixuilabel = gameObject.transform.Find("Buy/Price").GetComponent("XUILabel") as IXUILabel;
						ixuilabel.SetText(data[j].priceValue.ToString());
						IXUISprite ixuisprite3 = gameObject.transform.Find("Buy/Money").GetComponent("XUISprite") as IXUISprite;
						ixuisprite3.SetSprite(XBagDocument.GetItemSmallIcon(int.Parse(XSingleton<XGlobalConfig>.singleton.GetValue("CardChip")), 0U));
					}
					this.m_GoodsPool.ActualReturnAll(true);
				}
			}
		}

		private void InitShow()
		{
		}

		public void ShowHandler(int shopId, bool bResetPosition = false)
		{
			bool flag = shopId < 1 || shopId > 4;
			if (!flag)
			{
				if (bResetPosition)
				{
					this.m_GoodsScrollView.ResetPosition();
					this.SetCardShop(new List<XNormalShopGoods>());
					XNormalShopDocument specificDocument = XDocuments.GetSpecificDocument<XNormalShopDocument>(XNormalShopDocument.uuID);
					XSysDefine sys = XSysDefine.XSys_Mall_Card1 + shopId - 1;
					specificDocument.ReqGoodsList(sys);
				}
				this.RefreshChipNum();
			}
		}

		public void RefreshChipNum()
		{
			this.money = (int)XBagDocument.BagDoc.GetItemCount(int.Parse(XSingleton<XGlobalConfig>.singleton.GetValue("CardChip")));
			bool flag = this.m_ChipNum != null;
			if (flag)
			{
				this.m_ChipNum.SetText(this.money.ToString());
			}
		}

		private XCardCollectDocument doc;

		public List<XNormalShopGoods> goods = new List<XNormalShopGoods>();

		private IXUIButton m_Close;

		private IXUILabel m_ChipNum;

		private IXUISprite m_ChipIcon;

		private IXUIScrollView m_GoodsScrollView;

		private XUIPool m_GoodsPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public int money;

		private static readonly uint SHOP_LINE_COUNT = 3U;

		private int disX;

		private int disY;

		private XNormalShopGoods m_BuyGoods;
	}
}
