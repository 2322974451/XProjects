using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class MallSystemDlg : DlgBase<MallSystemDlg, MallSystemBehaviour>
	{

		public XShopPurchaseView PurchaseView
		{
			get
			{
				return this._PurchaseView;
			}
		}

		public override string fileName
		{
			get
			{
				return "GameSystem/MallDlg";
			}
		}

		public override bool pushstack
		{
			get
			{
				return true;
			}
		}

		public override bool hideMainMenu
		{
			get
			{
				return true;
			}
		}

		public override int sysid
		{
			get
			{
				return XFastEnumIntEqualityComparer<XSysDefine>.ToInt(this._sys);
			}
		}

		public XSysDefine SetSys
		{
			set
			{
				this._sys = value;
			}
		}

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

		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		protected override void OnLoad()
		{
			base.OnLoad();
		}

		protected override void OnUnload()
		{
			DlgHandlerBase.EnsureUnload<XMystShopView>(ref this._MystShopView);
			DlgHandlerBase.EnsureUnload<XNormalShopView>(ref this._NormalShopView);
			DlgHandlerBase.EnsureUnload<XShopPurchaseView>(ref this._PurchaseView);
			DlgHandlerBase.EnsureUnload<XShopTabCategoryHandler>(ref this._TabCategoryHandler);
			base.OnUnload();
		}

		public override void RegisterEvent()
		{
			base.uiBehaviour.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseShop));
		}

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

		public void HideShopSystem()
		{
			bool flag = this._NormalShopView != null;
			if (flag)
			{
				this._NormalShopView.SetVisible(false);
			}
		}

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

		public bool OnVirtualItemChanged(ItemEnum e, ulong newValue)
		{
			return true;
		}

		public bool OnItemCountChanged(int itemID, int itemCount)
		{
			return true;
		}

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

		public XMystShopView _MystShopView;

		public XNormalShopView _NormalShopView;

		public XShopPurchaseView _PurchaseView;

		public XShopTabCategoryHandler _TabCategoryHandler;

		public GameObject m_MystShopPanel;

		public GameObject m_NormalShopPanel;

		private GameObject m_TabShopPanel;

		public bool m_OpenFromGeneral = false;

		private XSysDefine _sys = XSysDefine.XSys_Mall_Mall;

		public List<int> m_MoneyTypeList = new List<int>();

		protected XSysDefine m_Sys = XSysDefine.XSys_Invalid;
	}
}
