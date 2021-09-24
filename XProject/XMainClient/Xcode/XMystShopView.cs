using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XMystShopView : DlgHandlerBase
	{

		protected override void Init()
		{
			base.Init();
			this._doc = XDocuments.GetSpecificDocument<XMystShopDocument>(XMystShopDocument.uuID);
			this._doc.View = this;
			GameObject gameObject = base.PanelObject.transform.FindChild("Panel").gameObject;
			GameObject gameObject2 = base.PanelObject.transform.FindChild("Panel/ShopItemTpl").gameObject;
			this.m_ShopItemPool.SetupPool(gameObject, gameObject2, 6U, false);
			string[] array = XSingleton<XGlobalConfig>.singleton.GetValue("shopTimming").Split(XGlobalConfig.ListSeparator);
			string text = "";
			foreach (string str in array)
			{
				text = text + str + ":00 ";
			}
			IXUILabel ixuilabel = base.PanelObject.transform.FindChild("Title").GetComponent("XUILabel") as IXUILabel;
			ixuilabel.SetText(XStringDefineProxy.GetString("MYSTSHOP_REFRESH_TIME", new object[]
			{
				text
			}));
			this.refreshConfirmPanel = base.PanelObject.transform.FindChild("RefreshConfirm").gameObject;
			this.refreshConfirmOK = (this.refreshConfirmPanel.transform.FindChild("P/OK").GetComponent("XUIButton") as IXUIButton);
			this.refreshConfirmCancel = (this.refreshConfirmPanel.transform.FindChild("P/Cancel").GetComponent("XUIButton") as IXUIButton);
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			IXUIButton ixuibutton = base.PanelObject.transform.FindChild("BtnRefresh").GetComponent("XUIButton") as IXUIButton;
			ixuibutton.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnRefreshBtnClicked));
			this.refreshConfirmOK.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnRefreshBtnOKClicked));
			this.refreshConfirmCancel.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnRefreshBtnCancelClicked));
		}

		protected override void OnShow()
		{
			base.OnShow();
			this._doc.ReqOperateMystShop(MythShopOP.MythShopQuery, 0);
			this.refreshConfirmPanel.SetActive(false);
		}

		protected override void OnHide()
		{
			base.OnHide();
			this.refreshConfirmPanel.SetActive(false);
		}

		public override void OnUnload()
		{
			this._doc.View = null;
			base.OnUnload();
		}

		public void RefreshGoodsList()
		{
			List<XMystShopGoods> goodsList = this._doc.GoodsList;
			int num = Math.Max(goodsList.Count, this.m_ShopItemList.Count);
			for (int i = this.m_ShopItemList.Count; i < num; i++)
			{
				GameObject gameObject = this.m_ShopItemPool.FetchGameObject(false);
				this.m_ShopItemList.Add(gameObject);
				IXUIButton ixuibutton = gameObject.transform.FindChild("BtnBuy").GetComponent("XUIButton") as IXUIButton;
				IXUISprite ixuisprite = gameObject.transform.FindChild("Item/Icon").GetComponent("XUISprite") as IXUISprite;
				ixuibutton.ID = (ulong)((long)i);
				ixuisprite.ID = (ulong)((long)i);
				ixuibutton.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnItemBuyClicked));
				ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnItemIconClicked));
			}
			num = Math.Min(goodsList.Count, this.m_ShopItemList.Count);
			for (int j = this.m_ShopItemList.Count - 1; j >= num; j--)
			{
				GameObject go = this.m_ShopItemList[j];
				this.m_ShopItemList.RemoveAt(j);
				this.m_ShopItemPool.ReturnInstance(go, false);
			}
			for (int k = 0; k < goodsList.Count; k++)
			{
				XMystShopGoods goods = goodsList[k];
				GameObject gameObject2 = this.m_ShopItemList[k];
				this.UpdateGoodsInfo(goods, gameObject2);
				gameObject2.transform.localPosition = new Vector3(this.m_ShopItemPool.TplPos.x + (float)(k % 3 * this.m_ShopItemPool.TplWidth), this.m_ShopItemPool.TplPos.y - (float)(k / 3 * this.m_ShopItemPool.TplHeight), this.m_ShopItemPool.TplPos.z);
			}
		}

		private void UpdateGoodsInfo(XMystShopGoods goods, GameObject shopItem)
		{
		}

		private void OnItemIconClicked(IXUISprite iSp)
		{
		}

		private bool OnItemBuyClicked(IXUIButton btn)
		{
			this._doc.ReqOperateMystShop(MythShopOP.MythShopBuy, (int)btn.ID);
			return true;
		}

		private bool OnRefreshBtnClicked(IXUIButton btn)
		{
			this.refreshConfirmPanel.SetActive(true);
			IXUILabel ixuilabel = this.refreshConfirmPanel.transform.FindChild("P/Cost").GetComponent("XUILabel") as IXUILabel;
			ixuilabel.SetText(this._doc.refreshCost.ToString());
			return true;
		}

		private bool OnRefreshBtnOKClicked(IXUIButton btn)
		{
			this.refreshConfirmPanel.SetActive(false);
			this._doc.ReqOperateMystShop(MythShopOP.MythShopRefresh, 0);
			return true;
		}

		private bool OnRefreshBtnCancelClicked(IXUIButton btn)
		{
			this.refreshConfirmPanel.SetActive(false);
			return true;
		}

		private XUIPool m_ShopItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		private List<GameObject> m_ShopItemList = new List<GameObject>();

		private XMystShopDocument _doc = null;

		private GameObject refreshConfirmPanel;

		private IXUIButton refreshConfirmOK;

		private IXUIButton refreshConfirmCancel;
	}
}
