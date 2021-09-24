using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class CharacterEquipBagHandler : DlgHandlerBase
	{

		private XBagWindow bagWindow
		{
			get
			{
				return DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton.BagWindow;
			}
		}

		private XItemMorePowerfulTipMgr powerfullMgr
		{
			get
			{
				return DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton.RedPointMgr;
			}
		}

		private XItemMorePowerfulTipMgr newItemMgr
		{
			get
			{
				return DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton.NewItemMgr;
			}
		}

		protected override string FileName
		{
			get
			{
				return "ItemNew/EquipListPanel";
			}
		}

		protected override void Init()
		{
			base.Init();
			this._doc = (XSingleton<XGame>.singleton.Doc.GetXComponent(XCharacterEquipDocument.uuID) as XCharacterEquipDocument);
			this._doc.Handler = this;
			this.m_topGo = base.PanelObject.transform.Find("Top").gameObject;
			this.m_masterHisMaxLevelLab = (base.PanelObject.transform.Find("Top/Lab").GetComponent("XUILabel") as IXUILabel);
			this.m_mastetBtn = (base.PanelObject.transform.Find("Top/Btn").GetComponent("XUIButton") as IXUIButton);
			this.m_BtnShowAttr = (base.transform.FindChild("ShowAttr").GetComponent("XUIButton") as IXUIButton);
			this.m_BtnShowTitle = (base.transform.FindChild("ShowTitle").GetComponent("XUIButton") as IXUIButton);
			this.m_TitleRedPoint = base.transform.FindChild("ShowTitle/RedPoint").gameObject;
			this.m_Help = (base.transform.Find("Help").GetComponent("XUIButton") as IXUIButton);
			this.m_bagNumLab = (base.PanelObject.transform.FindChild("BagNum").GetComponent("XUILabel") as IXUILabel);
			this.m_expandBagBtn = (base.PanelObject.transform.FindChild("add").GetComponent("XUIButton") as IXUIButton);
			BagExpandItemListTable.RowData expandItemConfByType = XBagDocument.GetExpandItemConfByType((uint)XFastEnumIntEqualityComparer<BagType>.ToInt(BagType.EquipBag));
			this.m_expandBagBtn.gameObject.SetActive(expandItemConfByType != null);
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_mastetBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnShowEnhanceMaster));
			this.m_BtnShowAttr.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnShowAttrClick));
			this.m_BtnShowTitle.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnShowTitleClick));
			this.m_Help.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnHelpClicked));
			this.m_expandBagBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnBagExpandClicked));
		}

		public bool OnHelpClicked(IXUIButton button)
		{
			DlgBase<XCommonHelpTipView, XCommonHelpTipBehaviour>.singleton.ShowHelp(XSysDefine.XSys_Item_Equip);
			return true;
		}

		public override void StackRefresh()
		{
			base.StackRefresh();
			this.RefreshBag();
			this._doc.NewItems.bCanClear = true;
		}

		protected override void OnShow()
		{
			base.OnShow();
			this.RefreshBag();
			this.ShowEnhanceMasterLevel();
			this._doc.NewItems.bCanClear = true;
			bool flag = this.m_EnhanceMasterHandler != null;
			if (flag)
			{
				this.m_EnhanceMasterHandler.SetVisible(false);
			}
			this.RefreshRedPoints();
			this.RefreshTitleRedPoint();
			this.SetBagNum();
		}

		public void RefreshRedPoints()
		{
			bool flag = DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton.IsVisible() && DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton._equipHandler != null;
			if (flag)
			{
				this.m_RedPointEquipPosList.Clear();
				XEnhanceDocument specificDocument = XDocuments.GetSpecificDocument<XEnhanceDocument>(XEnhanceDocument.uuID);
				bool flag2 = XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_Item_Enhance);
				if (flag2)
				{
					for (int i = 0; i < specificDocument.MorePowerfulEquips.Count; i++)
					{
						this.m_RedPointEquipPosList.Add(specificDocument.MorePowerfulEquips[i]);
					}
				}
				XSmeltDocument doc = XSmeltDocument.Doc;
				doc.GetRedDotEquips();
				bool flag3 = XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_Item_Smelting);
				if (flag3)
				{
					for (int j = 0; j < doc.MorePowerfulEquips.Count; j++)
					{
						bool flag4 = !this.m_RedPointEquipPosList.Contains(doc.MorePowerfulEquips[j]);
						if (flag4)
						{
							this.m_RedPointEquipPosList.Add(doc.MorePowerfulEquips[j]);
						}
					}
				}
				bool flag5 = XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_Item_Enchant);
				if (flag5)
				{
					XEnchantDocument specificDocument2 = XDocuments.GetSpecificDocument<XEnchantDocument>(XEnchantDocument.uuID);
					for (int k = 0; k < XBagDocument.EquipMax; k++)
					{
						bool flag6 = specificDocument2.RedPointStates[k];
						if (flag6)
						{
							this.m_RedPointEquipPosList.Add(k);
						}
					}
				}
				DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton._equipHandler.SetArrows(this.m_RedPointEquipPosList);
			}
		}

		public void RefreshTitleRedPoint()
		{
			this.m_BtnShowTitle.SetVisible(XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_Title));
			XTitleDocument specificDocument = XDocuments.GetSpecificDocument<XTitleDocument>(XTitleDocument.uuID);
			this.m_TitleRedPoint.SetActive(specificDocument.bEnableTitleLevelUp);
		}

		protected override void OnHide()
		{
			this.powerfullMgr.ReturnAll();
			this.newItemMgr.ReturnAll();
			this.bagWindow.OnHide();
			this._doc.NewItems.TryClear();
			base.OnHide();
		}

		private void RefreshBag()
		{
			this.bagWindow.ChangeData(new ItemUpdateHandler(this.WrapContentItemUpdated), new GetItemHandler(this._doc.GetEquips));
			DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton._equipHandler.RegisterItemClickEvents(null);
			this.bagWindow.OnShow();
			this.SetBagNum();
		}

		public override void OnUnload()
		{
			this._doc.Handler = null;
			DlgHandlerBase.EnsureUnload<EnhanceMasterHandler>(ref this.m_EnhanceMasterHandler);
			base.OnUnload();
		}

		public override void RefreshData()
		{
			base.RefreshData();
			this.RefreshBag();
		}

		public void Refresh()
		{
			this.bagWindow.RefreshWindow();
			this.SetBagNum();
		}

		public void ShowEnhanceMasterLevel()
		{
			bool flag = !XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_Item_Enhance);
			if (flag)
			{
				this.m_topGo.SetActive(false);
			}
			else
			{
				this.m_topGo.SetActive(true);
				this.m_masterHisMaxLevelLab.SetText(string.Format(XStringDefineProxy.GetString("EnhanceMasterLevel"), XEnhanceDocument.Doc.HistoryMaxLevel));
			}
		}

		private void SetBagNum()
		{
			int count = this._doc.GetEquips().Count;
			XRechargeDocument specificDocument = XDocuments.GetSpecificDocument<XRechargeDocument>(XRechargeDocument.uuID);
			VIPTable.RowData byVIP = specificDocument.VIPReader.GetByVIP((int)specificDocument.VipLevel);
			bool flag = byVIP != null;
			if (flag)
			{
				uint num = byVIP.EquipMax;
				BagExpandData bagExpandData = XBagDocument.BagDoc.GetBagExpandData(BagType.EquipBag);
				bool flag2 = bagExpandData != null;
				if (flag2)
				{
					num += bagExpandData.ExpandNum;
				}
				bool flag3 = (long)count >= (long)((ulong)num);
				if (flag3)
				{
					this.m_bagNumLab.SetText(string.Format("[ff4366]{0}[-]/{1}", count, num));
				}
				else
				{
					this.m_bagNumLab.SetText(string.Format("{0}[-]/{1}", count, num));
				}
			}
		}

		private void WrapContentItemUpdated(Transform t, int index)
		{
			Transform transform = t.FindChild("Icon/SupplementBrought");
			bool flag = transform != null;
			if (flag)
			{
				transform.gameObject.SetActive(false);
			}
			IXUISprite ixuisprite = t.FindChild("Icon").GetComponent("XUISprite") as IXUISprite;
			bool flag2 = this.bagWindow.m_XItemList == null || index >= this.bagWindow.m_XItemList.Count || index < 0;
			if (flag2)
			{
				XSingleton<XItemDrawerMgr>.singleton.DrawItem(t.gameObject, null);
				this.powerfullMgr.ReturnInstance(ixuisprite);
				this.newItemMgr.ReturnInstance(ixuisprite);
				t.gameObject.name = XSingleton<XCommon>.singleton.StringCombine("empty", index.ToString());
			}
			else
			{
				XSingleton<XItemDrawerMgr>.singleton.DrawItem(t.gameObject, this.bagWindow.m_XItemList[index]);
				ixuisprite.ID = this.bagWindow.m_XItemList[index].uid;
				ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this._OnItemClicked));
				t.gameObject.name = XSingleton<XCommon>.singleton.StringCombine("equip", this.bagWindow.m_XItemList[index].itemID.ToString());
				EquipCompare mix = this._doc.IsEquipMorePowerful(ixuisprite.ID);
				EquipCompare final = XCharacterEquipDocument.GetFinal(mix);
				bool flag3 = final == EquipCompare.EC_MORE_POWERFUL;
				if (flag3)
				{
					this.powerfullMgr.SetTip(ixuisprite);
				}
				else
				{
					this.powerfullMgr.ReturnInstance(ixuisprite);
				}
				bool flag4 = this._doc.NewItems.IsNew(ixuisprite.ID);
				if (flag4)
				{
					this.newItemMgr.SetTip(ixuisprite);
				}
				else
				{
					this.newItemMgr.ReturnInstance(ixuisprite);
				}
			}
		}

		public void LoadEquip(XItem item, int slot)
		{
			DlgBase<EquipTooltipDlg, EquipTooltipDlgBehaviour>.singleton.HideToolTip(true);
			bool flag = DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton._equipHandler != null && DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton._equipHandler.IsVisible();
			if (flag)
			{
				DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton._equipHandler.SetEquipSlot(slot, item);
			}
			this.Refresh();
		}

		public void UnloadEquip(int slot)
		{
			DlgBase<EquipTooltipDlg, EquipTooltipDlgBehaviour>.singleton.HideToolTip(true);
			bool flag = DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton._equipHandler != null && DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton._equipHandler.IsVisible();
			if (flag)
			{
				DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton._equipHandler.SetEquipSlot(slot, null);
			}
			this.Refresh();
		}

		public void AddItem(List<XItem> items)
		{
			this.bagWindow.UpdateBag();
			this.SetBagNum();
		}

		public void RemoveItem(List<ulong> uids)
		{
			this.bagWindow.UpdateBag();
			this.SetBagNum();
			foreach (ulong num in uids)
			{
				bool flag = num == DlgBase<EquipTooltipDlg, EquipTooltipDlgBehaviour>.singleton.MainItemUID;
				if (flag)
				{
					DlgBase<EquipTooltipDlg, EquipTooltipDlgBehaviour>.singleton.HideToolTip(false);
				}
			}
		}

		public void ItemNumChanged(XItem item)
		{
			this.bagWindow.UpdateItem(item);
			this.SetBagNum();
		}

		public void SwapItem(XItem item1, XItem item2, int slot)
		{
			DlgBase<EquipTooltipDlg, EquipTooltipDlgBehaviour>.singleton.HideToolTip(true);
			bool flag = DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton._equipHandler != null && DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton._equipHandler.IsVisible();
			if (flag)
			{
				DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton._equipHandler.SetEquipSlot(slot, item1);
			}
			this.bagWindow.ReplaceItem(item1, item2);
		}

		public void UpdateItem(XItem item)
		{
			this.bagWindow.UpdateItem(item);
			DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton._equipHandler.UpdateEquipSlot(item);
			bool flag = item.uid == DlgBase<EquipTooltipDlg, EquipTooltipDlgBehaviour>.singleton.MainItemUID;
			if (flag)
			{
				DlgBase<EquipTooltipDlg, EquipTooltipDlgBehaviour>.singleton.HideToolTip(false);
			}
			bool flag2 = item.uid == DlgBase<ItemTooltipDlg, ItemTooltipDlgBehaviour>.singleton.MainItemUID;
			if (flag2)
			{
				DlgBase<ItemTooltipDlg, ItemTooltipDlgBehaviour>.singleton.HideToolTip(true);
			}
		}

		private void _OnItemClicked(IXUISprite iSp)
		{
			XItem itemByUID = XSingleton<XGame>.singleton.Doc.XBagDoc.GetItemByUID(iSp.ID);
			bool flag = itemByUID == null;
			if (!flag)
			{
				bool flag2 = this._doc.NewItems.RemoveItem(iSp.ID, itemByUID.Type, false);
				if (flag2)
				{
					this._doc.GetEquips();
				}
				CharacterEquipHandler.OnItemClicked(iSp);
			}
		}

		private bool OnShowEnhanceMaster(IXUIButton btn)
		{
			DlgHandlerBase.EnsureCreate<EnhanceMasterHandler>(ref this.m_EnhanceMasterHandler, base.PanelObject.transform.parent.parent.FindChild("LeftPanel"), true, this);
			return true;
		}

		private bool OnShowAttrClick(IXUIButton btn)
		{
			DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton._CharacterAttrHandler.SetVisible(true);
			return true;
		}

		private bool OnShowTitleClick(IXUIButton btn)
		{
			DlgBase<TitleDlg, TitleDlgBehaviour>.singleton.SetVisibleWithAnimation(true, null);
			return true;
		}

		public bool OnBagExpandClicked(IXUIButton button)
		{
			XBagDocument.BagDoc.UseBagExpandTicket(BagType.EquipBag);
			return true;
		}

		private XCharacterEquipDocument _doc;

		private EnhanceMasterHandler m_EnhanceMasterHandler;

		private GameObject m_topGo;

		private IXUILabel m_masterHisMaxLevelLab;

		private IXUIButton m_mastetBtn;

		private IXUIButton m_BtnShowAttr;

		private IXUIButton m_BtnShowTitle;

		private GameObject m_TitleRedPoint;

		private IXUIButton m_Help;

		private IXUILabel m_bagNumLab;

		private List<int> m_RedPointEquipPosList = new List<int>();

		public IXUIButton m_expandBagBtn;
	}
}
