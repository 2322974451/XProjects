using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x02001840 RID: 6208
	internal class FashionBagHandler : DlgHandlerBase
	{
		// Token: 0x1700394A RID: 14666
		// (get) Token: 0x060101FE RID: 66046 RVA: 0x003DB728 File Offset: 0x003D9928
		protected override string FileName
		{
			get
			{
				return "ItemNew/FashionListPanel";
			}
		}

		// Token: 0x060101FF RID: 66047 RVA: 0x003DB740 File Offset: 0x003D9940
		protected override void Init()
		{
			base.Init();
			this._doc = (XSingleton<XGame>.singleton.Doc.GetXComponent(XFashionDocument.uuID) as XFashionDocument);
			this._doc.FashionDlg = this;
			this.m_ComboBox = base.PanelObject.transform.FindChild("ComboBox").gameObject;
			this.m_ItemBagPanel = base.PanelObject.gameObject;
			this.m_ShopButton = (base.PanelObject.transform.FindChild("BtnShop").GetComponent("XUIButton") as IXUIButton);
			this.m_Help = (base.transform.Find("Help").GetComponent("XUIButton") as IXUIButton);
			for (int i = XBagDocument.BodyPosition<FashionPosition>(FashionPosition.FASHION_START); i < XBagDocument.BodyPosition<FashionPosition>(FashionPosition.FASHION_END); i++)
			{
				this.m_Fashion[i] = (base.PanelObject.transform.FindChild("EquipFrame/Part" + i + "/Icon").GetComponent("XUISprite") as IXUISprite);
				this.m_FashionBg[i] = (base.PanelObject.transform.FindChild("EquipFrame/Part" + i + "/Bg").GetComponent("XUISprite") as IXUISprite);
				this.m_FashionBg[i].ID = (ulong)((long)i);
			}
			this.m_CollectionButton = (base.PanelObject.transform.FindChild("BtnCollection").GetComponent("XUIButton") as IXUIButton);
			this.m_TotalAttrButton = (base.PanelObject.transform.FindChild("BtnAttrTotal").GetComponent("XUIButton") as IXUIButton);
			this.m_TotalAttrPanel = base.PanelObject.transform.FindChild("AttrTotal").gameObject;
			this.bagWindow = new XBagWindow(this.m_ItemBagPanel, new ItemUpdateHandler(this.WrapContentItemUpdated), new GetItemHandler(this._doc.GetItem));
			this.bagWindow.Init();
			this._comboBox = new FashionComboBox(this.m_ComboBox, new ComboboxClickEventHandler(this.OnSelectPart), 2);
			this.m_BtnClothes = (base.PanelObject.transform.FindChild("Btnclothes").GetComponent("XUIButton") as IXUIButton);
			this.m_OutLookRedPoint = (base.PanelObject.transform.Find("Btnclothes/RedPoint").GetComponent("XUISprite") as IXUISprite);
			this.m_OutLookRedPoint.SetVisible(false);
			for (int j = XBagDocument.BodyPosition<FashionPosition>(FashionPosition.FASHION_START); j < XBagDocument.BodyPosition<FashionPosition>(FashionPosition.FASHION_END); j++)
			{
				this._comboBox.AddItem(XSingleton<UiUtility>.singleton.GetFashionPartName((FashionPosition)j, false), j);
			}
			this._comboBox.AddItem(XSingleton<UiUtility>.singleton.GetFashionPartName(FashionPosition.Hair, false), XFastEnumIntEqualityComparer<FashionPosition>.ToInt(FashionPosition.Hair));
			this._comboBox.AddItem(XStringDefineProxy.GetString("ALL"), -1);
			this._comboBox.SetSelect(-1);
			DlgHandlerBase.EnsureCreate<FashionAttrTotalHandler>(ref this._attrHandler, this.m_TotalAttrPanel, null, false);
			this._attrHandler.ShowCharm = true;
		}

		// Token: 0x06010200 RID: 66048 RVA: 0x003DBA74 File Offset: 0x003D9C74
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			for (int i = XBagDocument.BodyPosition<FashionPosition>(FashionPosition.FASHION_START); i < XBagDocument.BodyPosition<FashionPosition>(FashionPosition.FASHION_END); i++)
			{
				this.m_Fashion[i].RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this._OnItemClicked));
				this.m_FashionBg[i].RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this._OnBgClicked));
			}
			this.m_BtnClothes.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClothClick));
			this.m_TotalAttrButton.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnTotalAttrClick));
			this.m_CollectionButton.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCollectionClick));
			this.m_ShopButton.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnShopClick));
			this.m_Help.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnHelpClicked));
		}

		// Token: 0x06010201 RID: 66049 RVA: 0x003DBB54 File Offset: 0x003D9D54
		public void RefreshOutLookRedPoint()
		{
			this.m_BtnClothes.SetVisible(XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_Fashion_OutLook));
			XFashionStorageDocument specificDocument = XDocuments.GetSpecificDocument<XFashionStorageDocument>(XFashionStorageDocument.uuID);
			this.m_OutLookRedPoint.SetVisible(specificDocument.RedPoint);
		}

		// Token: 0x06010202 RID: 66050 RVA: 0x003DBB9C File Offset: 0x003D9D9C
		public bool OnHelpClicked(IXUIButton button)
		{
			DlgBase<XCommonHelpTipView, XCommonHelpTipBehaviour>.singleton.ShowHelp(XSysDefine.XSys_Fashion_Fashion);
			return true;
		}

		// Token: 0x06010203 RID: 66051 RVA: 0x003DBBC0 File Offset: 0x003D9DC0
		protected override void OnShow()
		{
			base.OnShow();
			this.ShowFashions();
			this.RefreshOutLookRedPoint();
			this.bagWindow.ChangeData(new ItemUpdateHandler(this.WrapContentItemUpdated), new GetItemHandler(this._doc.GetItem));
			this.bagWindow.OnShow();
			this._timer = XSingleton<XTimerMgr>.singleton.SetTimer(this.update_interval, new XTimerMgr.ElapsedEventHandler(this.UpdateFahionCD), null);
		}

		// Token: 0x06010204 RID: 66052 RVA: 0x003DBC3C File Offset: 0x003D9E3C
		protected override void OnHide()
		{
			this.bagWindow.OnHide();
			bool flag = this._timer > 0U;
			if (flag)
			{
				XSingleton<XTimerMgr>.singleton.KillTimer(this._timer);
				this._timer = 0U;
			}
			base.OnHide();
		}

		// Token: 0x06010205 RID: 66053 RVA: 0x003DBC84 File Offset: 0x003D9E84
		public override void OnUnload()
		{
			bool flag = this._timer > 0U;
			if (flag)
			{
				XSingleton<XTimerMgr>.singleton.KillTimer(this._timer);
				this._timer = 0U;
			}
			DlgHandlerBase.EnsureUnload<FashionAttrTotalHandler>(ref this._attrHandler);
			this._doc.FashionDlg = null;
			this.bagWindow = null;
			base.OnUnload();
		}

		// Token: 0x06010206 RID: 66054 RVA: 0x003DBCE0 File Offset: 0x003D9EE0
		public override void StackRefresh()
		{
			base.StackRefresh();
			this.ShowFashions();
			this.RefreshOutLookRedPoint();
			this.bagWindow.OnShow();
			bool flag = this._timer > 0U;
			if (flag)
			{
				XSingleton<XTimerMgr>.singleton.KillTimer(this._timer);
				this._timer = 0U;
			}
			this._timer = XSingleton<XTimerMgr>.singleton.SetTimer(this.update_interval, new XTimerMgr.ElapsedEventHandler(this.UpdateFahionCD), null);
		}

		// Token: 0x06010207 RID: 66055 RVA: 0x003DBD5C File Offset: 0x003D9F5C
		public void ShowFashions()
		{
			for (int i = XBagDocument.BodyPosition<FashionPosition>(FashionPosition.FASHION_START); i < XBagDocument.BodyPosition<FashionPosition>(FashionPosition.FASHION_END); i++)
			{
				ClientFashionData partFashion = this._doc.GetPartFashion(i);
				this.m_Fashion[i].ID = partFashion.uid;
				XSingleton<XItemDrawerMgr>.singleton.fashionDrawer.DrawItem(this.m_Fashion[i].gameObject.transform.parent.gameObject, partFashion);
				this.m_Fashion[i].RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this._OnItemClicked));
				this.SetFashionCD(this.m_Fashion[i].gameObject.transform.parent.gameObject, partFashion);
			}
			bool flag = this.bagWindow != null;
			if (flag)
			{
				this.bagWindow.RefreshWindow();
			}
		}

		// Token: 0x06010208 RID: 66056 RVA: 0x003DBE32 File Offset: 0x003DA032
		public void UpdateBag()
		{
			this.bagWindow.UpdateBag();
		}

		// Token: 0x06010209 RID: 66057 RVA: 0x003DBE44 File Offset: 0x003DA044
		private void UpdateFahionCD(object o)
		{
			bool flag = base.IsVisible();
			if (flag)
			{
				for (int i = XBagDocument.BodyPosition<FashionPosition>(FashionPosition.FASHION_START); i < XBagDocument.BodyPosition<FashionPosition>(FashionPosition.FASHION_END); i++)
				{
					ClientFashionData partFashion = this._doc.GetPartFashion(i);
					this.SetFashionCD(this.m_Fashion[i].gameObject.transform.parent.gameObject, partFashion);
				}
				bool flag2 = this.bagWindow != null;
				if (flag2)
				{
					this.bagWindow.RefreshWindow();
				}
			}
			this._timer = XSingleton<XTimerMgr>.singleton.SetTimer(this.update_interval, new XTimerMgr.ElapsedEventHandler(this.UpdateFahionCD), null);
		}

		// Token: 0x0601020A RID: 66058 RVA: 0x003DBEEC File Offset: 0x003DA0EC
		private void SetFashionCD(GameObject item, ClientFashionData d)
		{
			Transform transform = item.transform.FindChild("Icon/TimeBg/cd");
			bool flag = transform == null;
			if (!flag)
			{
				bool flag2 = d == null;
				if (flag2)
				{
					transform.parent.gameObject.SetActive(false);
				}
				else
				{
					IXUISprite ixuisprite = transform.GetComponent("XUISprite") as IXUISprite;
					ItemList.RowData itemConf = XBagDocument.GetItemConf((int)d.itemID);
					bool flag3 = itemConf != null;
					if (flag3)
					{
						bool flag4 = itemConf.TimeLimit == 0U;
						if (flag4)
						{
							transform.parent.gameObject.SetActive(false);
						}
						else
						{
							transform.parent.gameObject.SetActive(true);
							bool flag5 = d.timeleft < 0.0;
							if (flag5)
							{
								ixuisprite.SetFillAmount(0f);
							}
							else
							{
								ixuisprite.SetFillAmount(1f - (float)d.timeleft / itemConf.TimeLimit);
							}
						}
					}
					else
					{
						transform.parent.gameObject.SetActive(false);
					}
				}
			}
		}

		// Token: 0x0601020B RID: 66059 RVA: 0x003DBFF8 File Offset: 0x003DA1F8
		private void WrapContentItemUpdated(Transform t, int index)
		{
			IXUISprite ixuisprite = t.FindChild("Icon").GetComponent("XUISprite") as IXUISprite;
			GameObject gameObject = t.FindChild("P").gameObject;
			GameObject gameObject2 = t.FindChild("RedPoint").gameObject;
			bool flag = this.bagWindow.m_XItemList == null || index >= this.bagWindow.m_XItemList.Count || index < 0;
			if (flag)
			{
				XSingleton<XItemDrawerMgr>.singleton.DrawItem(t.gameObject, null);
				this.SetFashionCD(t.gameObject, null);
				gameObject2.SetActive(false);
			}
			else
			{
				XItem xitem = this.bagWindow.m_XItemList[index];
				ClientFashionData clientFashionData = this._doc.FindFashion(xitem.uid);
				bool flag2 = clientFashionData == null;
				if (flag2)
				{
					XSingleton<XItemDrawerMgr>.singleton.DrawItem(t.gameObject, null);
					this.SetFashionCD(t.gameObject, null);
					gameObject2.SetActive(false);
				}
				else
				{
					XSingleton<XItemDrawerMgr>.singleton.fashionDrawer.DrawItem(t.gameObject, clientFashionData);
					ixuisprite.ID = xitem.uid;
					ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this._OnItemClicked));
					bool flag3 = index % this.bagWindow.COL_COUNT == 0;
					if (flag3)
					{
						gameObject.SetActive(true);
					}
					else
					{
						gameObject.SetActive(false);
					}
					this.SetFashionCD(t.gameObject, clientFashionData);
					gameObject2.SetActive(this._doc.HasFashionRedPoint(clientFashionData));
				}
			}
		}

		// Token: 0x0601020C RID: 66060 RVA: 0x003DC184 File Offset: 0x003DA384
		private bool OnClothClick(IXUIButton btn)
		{
			DlgBase<FashionStorageDlg, FashionStorageBehaviour>.singleton.SetVisibleWithAnimation(true, null);
			return true;
		}

		// Token: 0x0601020D RID: 66061 RVA: 0x003DC1A4 File Offset: 0x003DA3A4
		private void _OnItemClicked(IXUISprite sp)
		{
			ulong id = sp.ID;
			ClientFashionData clientFashionData = this._doc.FindFashion(id);
			bool flag = clientFashionData != null;
			if (flag)
			{
				XItem mainItem = this._doc.MakeXItem(clientFashionData);
				XSingleton<UiUtility>.singleton.ShowTooltipDialog(mainItem, null, sp, true, 0U);
			}
		}

		// Token: 0x0601020E RID: 66062 RVA: 0x003DC1F0 File Offset: 0x003DA3F0
		private void _OnBgClicked(IXUISprite sp)
		{
			int part = (int)sp.ID;
			XSingleton<UiUtility>.singleton.ShowSystemTip(string.Format(XStringDefineProxy.GetString("FASHION_EQUIP_HINT"), XSingleton<UiUtility>.singleton.GetFashionPartName((FashionPosition)part, false)), "fece00");
		}

		// Token: 0x0601020F RID: 66063 RVA: 0x003DC234 File Offset: 0x003DA434
		private bool OnTotalAttrClick(IXUIButton button)
		{
			this._attrHandler.SetVisible(true);
			return true;
		}

		// Token: 0x06010210 RID: 66064 RVA: 0x003DC254 File Offset: 0x003DA454
		private void OnSelectPart(int value)
		{
			this._doc.fashion_filter = value;
			this.bagWindow.UpdateBag();
		}

		// Token: 0x06010211 RID: 66065 RVA: 0x003DC270 File Offset: 0x003DA470
		private bool OnCollectionClick(IXUIButton button)
		{
			DlgBase<FashionCollectionDlg, FashionCollectionDlgBehaviour>.singleton.SetVisible(true, true);
			return true;
		}

		// Token: 0x06010212 RID: 66066 RVA: 0x003DC290 File Offset: 0x003DA490
		private bool OnShopClick(IXUIButton button)
		{
			XSingleton<UiUtility>.singleton.ShowItemAccess(199, null);
			return true;
		}

		// Token: 0x06010213 RID: 66067 RVA: 0x003DC2B4 File Offset: 0x003DA4B4
		public void OnBodyFashionDisappear(int pos)
		{
			ClientFashionData partFashion = this._doc.GetPartFashion(pos);
			XSingleton<XItemDrawerMgr>.singleton.fashionDrawer.DrawItem(this.m_Fashion[pos].gameObject.transform.parent.gameObject, partFashion);
			this.SetFashionCD(this.m_Fashion[pos].gameObject.transform.parent.gameObject, partFashion);
		}

		// Token: 0x06010214 RID: 66068 RVA: 0x003DBE32 File Offset: 0x003DA032
		public void OnBagFashionDisappear(ulong uid)
		{
			this.bagWindow.UpdateBag();
		}

		// Token: 0x0400730C RID: 29452
		public GameObject m_ComboBox;

		// Token: 0x0400730D RID: 29453
		public GameObject m_ItemBagPanel;

		// Token: 0x0400730E RID: 29454
		public IXUIButton m_ShopButton;

		// Token: 0x0400730F RID: 29455
		public IXUIButton m_BtnClothes;

		// Token: 0x04007310 RID: 29456
		public IXUISprite m_OutLookRedPoint;

		// Token: 0x04007311 RID: 29457
		public IXUIButton m_CollectionButton;

		// Token: 0x04007312 RID: 29458
		public IXUIButton m_TotalAttrButton;

		// Token: 0x04007313 RID: 29459
		public GameObject m_TotalAttrPanel;

		// Token: 0x04007314 RID: 29460
		public IXUIButton m_Help;

		// Token: 0x04007315 RID: 29461
		public IXUISprite[] m_Fashion = new IXUISprite[10];

		// Token: 0x04007316 RID: 29462
		public IXUISprite[] m_FashionBg = new IXUISprite[10];

		// Token: 0x04007317 RID: 29463
		private FashionAttrTotalHandler _attrHandler;

		// Token: 0x04007318 RID: 29464
		private XFashionDocument _doc;

		// Token: 0x04007319 RID: 29465
		private FashionComboBox _comboBox;

		// Token: 0x0400731A RID: 29466
		private XBagWindow bagWindow;

		// Token: 0x0400731B RID: 29467
		private uint _timer;

		// Token: 0x0400731C RID: 29468
		private float update_interval = 180f;
	}
}
