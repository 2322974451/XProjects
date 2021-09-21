using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000F11 RID: 3857
	internal class XMystShopView : DlgHandlerBase
	{
		// Token: 0x0600CCA1 RID: 52385 RVA: 0x002F26DC File Offset: 0x002F08DC
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

		// Token: 0x0600CCA2 RID: 52386 RVA: 0x002F2858 File Offset: 0x002F0A58
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			IXUIButton ixuibutton = base.PanelObject.transform.FindChild("BtnRefresh").GetComponent("XUIButton") as IXUIButton;
			ixuibutton.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnRefreshBtnClicked));
			this.refreshConfirmOK.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnRefreshBtnOKClicked));
			this.refreshConfirmCancel.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnRefreshBtnCancelClicked));
		}

		// Token: 0x0600CCA3 RID: 52387 RVA: 0x002F28D5 File Offset: 0x002F0AD5
		protected override void OnShow()
		{
			base.OnShow();
			this._doc.ReqOperateMystShop(MythShopOP.MythShopQuery, 0);
			this.refreshConfirmPanel.SetActive(false);
		}

		// Token: 0x0600CCA4 RID: 52388 RVA: 0x002F28FA File Offset: 0x002F0AFA
		protected override void OnHide()
		{
			base.OnHide();
			this.refreshConfirmPanel.SetActive(false);
		}

		// Token: 0x0600CCA5 RID: 52389 RVA: 0x002F2911 File Offset: 0x002F0B11
		public override void OnUnload()
		{
			this._doc.View = null;
			base.OnUnload();
		}

		// Token: 0x0600CCA6 RID: 52390 RVA: 0x002F2928 File Offset: 0x002F0B28
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

		// Token: 0x0600CCA7 RID: 52391 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		private void UpdateGoodsInfo(XMystShopGoods goods, GameObject shopItem)
		{
		}

		// Token: 0x0600CCA8 RID: 52392 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		private void OnItemIconClicked(IXUISprite iSp)
		{
		}

		// Token: 0x0600CCA9 RID: 52393 RVA: 0x002F2B2C File Offset: 0x002F0D2C
		private bool OnItemBuyClicked(IXUIButton btn)
		{
			this._doc.ReqOperateMystShop(MythShopOP.MythShopBuy, (int)btn.ID);
			return true;
		}

		// Token: 0x0600CCAA RID: 52394 RVA: 0x002F2B54 File Offset: 0x002F0D54
		private bool OnRefreshBtnClicked(IXUIButton btn)
		{
			this.refreshConfirmPanel.SetActive(true);
			IXUILabel ixuilabel = this.refreshConfirmPanel.transform.FindChild("P/Cost").GetComponent("XUILabel") as IXUILabel;
			ixuilabel.SetText(this._doc.refreshCost.ToString());
			return true;
		}

		// Token: 0x0600CCAB RID: 52395 RVA: 0x002F2BB4 File Offset: 0x002F0DB4
		private bool OnRefreshBtnOKClicked(IXUIButton btn)
		{
			this.refreshConfirmPanel.SetActive(false);
			this._doc.ReqOperateMystShop(MythShopOP.MythShopRefresh, 0);
			return true;
		}

		// Token: 0x0600CCAC RID: 52396 RVA: 0x002F2BE4 File Offset: 0x002F0DE4
		private bool OnRefreshBtnCancelClicked(IXUIButton btn)
		{
			this.refreshConfirmPanel.SetActive(false);
			return true;
		}

		// Token: 0x04005B06 RID: 23302
		private XUIPool m_ShopItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04005B07 RID: 23303
		private List<GameObject> m_ShopItemList = new List<GameObject>();

		// Token: 0x04005B08 RID: 23304
		private XMystShopDocument _doc = null;

		// Token: 0x04005B09 RID: 23305
		private GameObject refreshConfirmPanel;

		// Token: 0x04005B0A RID: 23306
		private IXUIButton refreshConfirmOK;

		// Token: 0x04005B0B RID: 23307
		private IXUIButton refreshConfirmCancel;
	}
}
