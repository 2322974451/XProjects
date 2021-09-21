using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x02001905 RID: 6405
	internal class MallSystemDlg : DlgBase<MallSystemDlg, MallSystemBehaviour>
	{
		// Token: 0x17003ABC RID: 15036
		// (get) Token: 0x06010B86 RID: 68486 RVA: 0x0042C6D0 File Offset: 0x0042A8D0
		public XShopPurchaseView PurchaseView
		{
			get
			{
				return this._PurchaseView;
			}
		}

		// Token: 0x17003ABD RID: 15037
		// (get) Token: 0x06010B87 RID: 68487 RVA: 0x0042C6E8 File Offset: 0x0042A8E8
		public override string fileName
		{
			get
			{
				return "GameSystem/MallDlg";
			}
		}

		// Token: 0x17003ABE RID: 15038
		// (get) Token: 0x06010B88 RID: 68488 RVA: 0x0042C700 File Offset: 0x0042A900
		public override bool pushstack
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17003ABF RID: 15039
		// (get) Token: 0x06010B89 RID: 68489 RVA: 0x0042C714 File Offset: 0x0042A914
		public override bool hideMainMenu
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17003AC0 RID: 15040
		// (get) Token: 0x06010B8A RID: 68490 RVA: 0x0042C728 File Offset: 0x0042A928
		public override int sysid
		{
			get
			{
				return XFastEnumIntEqualityComparer<XSysDefine>.ToInt(this._sys);
			}
		}

		// Token: 0x17003AC1 RID: 15041
		// (set) Token: 0x06010B8B RID: 68491 RVA: 0x0042C745 File Offset: 0x0042A945
		public XSysDefine SetSys
		{
			set
			{
				this._sys = value;
			}
		}

		// Token: 0x06010B8C RID: 68492 RVA: 0x0042C750 File Offset: 0x0042A950
		protected override void Init()
		{
			base.Init();
			this.m_MystShopPanel = base.uiBehaviour.transform.FindChild("Bg/MystShopFrame").gameObject;
			this.m_MystShopPanel.SetActive(false);
			this.m_NormalShopPanel = base.uiBehaviour.transform.FindChild("Bg/NormalShopFrame").gameObject;
			this.m_NormalShopPanel.SetActive(false);
			this.m_TabShopPanel = base.uiBehaviour.transform.FindChild("Bg/TabShopFrame").gameObject;
			this.m_TabShopPanel.SetActive(false);
			DlgHandlerBase.EnsureCreate<XMystShopView>(ref this._MystShopView, this.m_MystShopPanel, null, false);
			DlgHandlerBase.EnsureCreate<XNormalShopView>(ref this._NormalShopView, this.m_NormalShopPanel, this, false);
			DlgHandlerBase.EnsureCreate<XShopTabCategoryHandler>(ref this._TabCategoryHandler, this.m_TabShopPanel, null, false);
			Transform parent = base.uiBehaviour.transform.FindChild("Bg");
			DlgHandlerBase.EnsureCreate<XShopPurchaseView>(ref this._PurchaseView, parent, false, this);
		}

		// Token: 0x17003AC2 RID: 15042
		// (get) Token: 0x06010B8D RID: 68493 RVA: 0x0042C850 File Offset: 0x0042AA50
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x06010B8E RID: 68494 RVA: 0x0042C863 File Offset: 0x0042AA63
		protected override void OnLoad()
		{
			base.OnLoad();
		}

		// Token: 0x06010B8F RID: 68495 RVA: 0x0042C86D File Offset: 0x0042AA6D
		protected override void OnUnload()
		{
			DlgHandlerBase.EnsureUnload<XMystShopView>(ref this._MystShopView);
			DlgHandlerBase.EnsureUnload<XNormalShopView>(ref this._NormalShopView);
			DlgHandlerBase.EnsureUnload<XShopPurchaseView>(ref this._PurchaseView);
			DlgHandlerBase.EnsureUnload<XShopTabCategoryHandler>(ref this._TabCategoryHandler);
			base.OnUnload();
		}

		// Token: 0x06010B90 RID: 68496 RVA: 0x0042C8A7 File Offset: 0x0042AAA7
		public override void RegisterEvent()
		{
			base.uiBehaviour.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseShop));
		}

		// Token: 0x06010B91 RID: 68497 RVA: 0x0042C8C8 File Offset: 0x0042AAC8
		public bool OnCloseShop(IXUIButton sp)
		{
			this.SetVisible(false, true);
			this._PurchaseView.SetVisible(false);
			this._NormalShopView.SetVisible(false);
			this._MystShopView.SetVisible(false);
			this._TabCategoryHandler.SetVisible(false);
			this.m_OpenFromGeneral = false;
			return true;
		}

		// Token: 0x06010B92 RID: 68498 RVA: 0x0042C920 File Offset: 0x0042AB20
		public void HideShopSystem()
		{
			bool flag = this._NormalShopView != null;
			if (flag)
			{
				this._NormalShopView.SetVisible(false);
			}
		}

		// Token: 0x06010B93 RID: 68499 RVA: 0x0042C94C File Offset: 0x0042AB4C
		public void ShowShopSystem(XSysDefine sys, ulong itemID = 0UL)
		{
			XNormalShopDocument specificDocument = XDocuments.GetSpecificDocument<XNormalShopDocument>(XNormalShopDocument.uuID);
			specificDocument.ToSelectShopItemID = itemID;
			ShopTypeTable.RowData shopTypeData = specificDocument.GetShopTypeData(sys);
			bool flag = shopTypeData == null;
			if (!flag)
			{
				this.m_Sys = sys;
				this.SetVisibleWithAnimation(true, null);
				base.uiBehaviour.m_ShopName.SetText(shopTypeData.ShopName);
				bool flag2 = sys == XSysDefine.XSys_Mall_MystShop;
				if (flag2)
				{
					this.m_NormalShopPanel.SetActive(false);
					this.m_MystShopPanel.SetActive(true);
					this._MystShopView.SetVisible(true);
				}
				else
				{
					bool flag3 = specificDocument.IsTabShop(sys);
					if (flag3)
					{
						this.m_NormalShopPanel.SetActive(false);
						this.m_MystShopPanel.SetActive(false);
						this._TabCategoryHandler.SetShopType(sys);
						bool flag4 = this._TabCategoryHandler.IsVisible();
						if (flag4)
						{
							this._TabCategoryHandler.OnRefreshData();
						}
						else
						{
							this._TabCategoryHandler.SetVisible(true);
						}
					}
					else
					{
						bool flag5 = specificDocument.IsShop(sys);
						if (flag5)
						{
							this.m_TabShopPanel.SetActive(false);
							this.m_NormalShopPanel.SetActive(true);
							this.m_MystShopPanel.SetActive(false);
							this._NormalShopView.SetShopType(sys);
							bool flag6 = this._NormalShopView.IsVisible();
							if (flag6)
							{
								this._NormalShopView.OnRefreshData();
							}
							else
							{
								this._NormalShopView.SetVisible(true);
							}
						}
						else
						{
							XSingleton<XDebug>.singleton.AddErrorLog("System has not finished:", sys.ToString(), null, null, null, null);
						}
					}
				}
			}
		}

		// Token: 0x06010B94 RID: 68500 RVA: 0x0042CAE0 File Offset: 0x0042ACE0
		public void RefreshMoneyBoard(List<XNormalShopGoods> goodsList)
		{
			Dictionary<int, int> dictionary = new Dictionary<int, int>();
			this.m_MoneyTypeList.Clear();
			for (int i = 0; i < goodsList.Count; i++)
			{
				int priceType = goodsList[i].priceType;
				dictionary[priceType] = 0;
			}
			foreach (int item in dictionary.Keys)
			{
				this.m_MoneyTypeList.Add(item);
			}
			for (int j = 0; j < MallSystemBehaviour.MAX_MONEY_NUM; j++)
			{
				bool flag = this.m_MoneyTypeList.Count > j;
				if (flag)
				{
					base.uiBehaviour.m_MoneyBoard[j].SetVisible(true);
					string itemSmallIcon = XBagDocument.GetItemSmallIcon(this.m_MoneyTypeList[j], 0U);
					base.uiBehaviour.m_MoneyIcon[j].SetSprite(itemSmallIcon);
					base.uiBehaviour.m_MoneyBack[j].ID = (ulong)((long)this.m_MoneyTypeList[j]);
					base.uiBehaviour.m_MoneyBack[j].RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnMoneyAddClick));
					XSingleton<UiUtility>.singleton.SetVirtualItem(base.uiBehaviour.m_MoneyTween[j], XSingleton<XGame>.singleton.Doc.XBagDoc.GetItemCount(this.m_MoneyTypeList[j]), false, "");
				}
				else
				{
					base.uiBehaviour.m_MoneyBoard[j].SetVisible(false);
				}
			}
		}

		// Token: 0x06010B95 RID: 68501 RVA: 0x0042CCB0 File Offset: 0x0042AEB0
		public bool OnVirtualItemChanged(ItemEnum e, ulong newValue)
		{
			return true;
		}

		// Token: 0x06010B96 RID: 68502 RVA: 0x0042CCC4 File Offset: 0x0042AEC4
		public bool OnItemCountChanged(int itemID, int itemCount)
		{
			return true;
		}

		// Token: 0x06010B97 RID: 68503 RVA: 0x0042CCD8 File Offset: 0x0042AED8
		protected void OnMoneyAddClick(IXUISprite sp)
		{
			int num = (int)sp.ID;
			FashionList.RowData fashionConf = XBagDocument.GetFashionConf(num);
			bool flag = fashionConf == null;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowItemAccess(num, null);
			}
		}

		// Token: 0x04007A41 RID: 31297
		public XMystShopView _MystShopView;

		// Token: 0x04007A42 RID: 31298
		public XNormalShopView _NormalShopView;

		// Token: 0x04007A43 RID: 31299
		public XShopPurchaseView _PurchaseView;

		// Token: 0x04007A44 RID: 31300
		public XShopTabCategoryHandler _TabCategoryHandler;

		// Token: 0x04007A45 RID: 31301
		public GameObject m_MystShopPanel;

		// Token: 0x04007A46 RID: 31302
		public GameObject m_NormalShopPanel;

		// Token: 0x04007A47 RID: 31303
		private GameObject m_TabShopPanel;

		// Token: 0x04007A48 RID: 31304
		public bool m_OpenFromGeneral = false;

		// Token: 0x04007A49 RID: 31305
		private XSysDefine _sys = XSysDefine.XSys_Mall_Mall;

		// Token: 0x04007A4A RID: 31306
		public List<int> m_MoneyTypeList = new List<int>();

		// Token: 0x04007A4B RID: 31307
		protected XSysDefine m_Sys = XSysDefine.XSys_Invalid;
	}
}
