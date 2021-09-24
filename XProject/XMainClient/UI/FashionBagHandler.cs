using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class FashionBagHandler : DlgHandlerBase
	{

		protected override string FileName
		{
			get
			{
				return "ItemNew/FashionListPanel";
			}
		}

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

		public void RefreshOutLookRedPoint()
		{
			this.m_BtnClothes.SetVisible(XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_Fashion_OutLook));
			XFashionStorageDocument specificDocument = XDocuments.GetSpecificDocument<XFashionStorageDocument>(XFashionStorageDocument.uuID);
			this.m_OutLookRedPoint.SetVisible(specificDocument.RedPoint);
		}

		public bool OnHelpClicked(IXUIButton button)
		{
			DlgBase<XCommonHelpTipView, XCommonHelpTipBehaviour>.singleton.ShowHelp(XSysDefine.XSys_Fashion_Fashion);
			return true;
		}

		protected override void OnShow()
		{
			base.OnShow();
			this.ShowFashions();
			this.RefreshOutLookRedPoint();
			this.bagWindow.ChangeData(new ItemUpdateHandler(this.WrapContentItemUpdated), new GetItemHandler(this._doc.GetItem));
			this.bagWindow.OnShow();
			this._timer = XSingleton<XTimerMgr>.singleton.SetTimer(this.update_interval, new XTimerMgr.ElapsedEventHandler(this.UpdateFahionCD), null);
		}

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

		public void UpdateBag()
		{
			this.bagWindow.UpdateBag();
		}

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

		private bool OnClothClick(IXUIButton btn)
		{
			DlgBase<FashionStorageDlg, FashionStorageBehaviour>.singleton.SetVisibleWithAnimation(true, null);
			return true;
		}

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

		private void _OnBgClicked(IXUISprite sp)
		{
			int part = (int)sp.ID;
			XSingleton<UiUtility>.singleton.ShowSystemTip(string.Format(XStringDefineProxy.GetString("FASHION_EQUIP_HINT"), XSingleton<UiUtility>.singleton.GetFashionPartName((FashionPosition)part, false)), "fece00");
		}

		private bool OnTotalAttrClick(IXUIButton button)
		{
			this._attrHandler.SetVisible(true);
			return true;
		}

		private void OnSelectPart(int value)
		{
			this._doc.fashion_filter = value;
			this.bagWindow.UpdateBag();
		}

		private bool OnCollectionClick(IXUIButton button)
		{
			DlgBase<FashionCollectionDlg, FashionCollectionDlgBehaviour>.singleton.SetVisible(true, true);
			return true;
		}

		private bool OnShopClick(IXUIButton button)
		{
			XSingleton<UiUtility>.singleton.ShowItemAccess(199, null);
			return true;
		}

		public void OnBodyFashionDisappear(int pos)
		{
			ClientFashionData partFashion = this._doc.GetPartFashion(pos);
			XSingleton<XItemDrawerMgr>.singleton.fashionDrawer.DrawItem(this.m_Fashion[pos].gameObject.transform.parent.gameObject, partFashion);
			this.SetFashionCD(this.m_Fashion[pos].gameObject.transform.parent.gameObject, partFashion);
		}

		public void OnBagFashionDisappear(ulong uid)
		{
			this.bagWindow.UpdateBag();
		}

		public GameObject m_ComboBox;

		public GameObject m_ItemBagPanel;

		public IXUIButton m_ShopButton;

		public IXUIButton m_BtnClothes;

		public IXUISprite m_OutLookRedPoint;

		public IXUIButton m_CollectionButton;

		public IXUIButton m_TotalAttrButton;

		public GameObject m_TotalAttrPanel;

		public IXUIButton m_Help;

		public IXUISprite[] m_Fashion = new IXUISprite[10];

		public IXUISprite[] m_FashionBg = new IXUISprite[10];

		private FashionAttrTotalHandler _attrHandler;

		private XFashionDocument _doc;

		private FashionComboBox _comboBox;

		private XBagWindow bagWindow;

		private uint _timer;

		private float update_interval = 180f;
	}
}
