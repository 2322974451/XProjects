using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class EnchantOperateHandler : DlgHandlerBase
	{

		protected override string FileName
		{
			get
			{
				return "ItemNew/EnchantFrame";
			}
		}

		protected override void Init()
		{
			base.Init();
			this._doc = XDocuments.GetSpecificDocument<XEnchantDocument>(XEnchantDocument.uuID);
			this._doc._EnchantOperateHandler = this;
			this.m_tipsLab = (base.PanelObject.transform.FindChild("Bg/AttrTip/T2").GetComponent("XUILabel") as IXUILabel);
			this.m_BtnClose = (base.PanelObject.transform.Find("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_BtnHelp = (base.PanelObject.transform.Find("Bg/Help").GetComponent("XUIButton") as IXUIButton);
			this.m_uiOperateFrame = base.PanelObject.transform.Find("Bg/OperateFrame").gameObject;
			this.m_uiSelectFrame = base.PanelObject.transform.Find("Bg/SelectFrame").gameObject;
			this.m_uiSelect = (this.m_uiSelectFrame.transform.Find("Select").GetComponent("XUISprite") as IXUISprite);
			this.m_uiPreview = (this.m_uiOperateFrame.transform.Find("Preview").GetComponent("XUISprite") as IXUISprite);
			this.m_uiActiveAttribute = (base.transform.Find("Bg/BtnActivation").GetComponent("XUISprite") as IXUISprite);
			this.m_uiEquipItem = base.PanelObject.transform.Find("Bg/Top/EquipItem").gameObject;
			this.m_uiEnchantItem = this.m_uiOperateFrame.transform.Find("EnchantItem").gameObject;
			this.m_BtnOK = (base.transform.Find("Bg/BtnOK").GetComponent("XUIButton") as IXUIButton);
			this.m_uiCostValue = (this.m_uiOperateFrame.transform.Find("Bottom/Cost").GetComponent("XUILabel") as IXUILabel);
			this.m_uiCostIcon = (this.m_uiOperateFrame.transform.Find("Bottom/Cost/Icon").GetComponent("XUISprite") as IXUISprite);
			this.m_uiNoBeforeAttr = base.transform.Find("Bg/Enchant/NoBeforeAttr").gameObject;
			this._curEnchantPropertiesContent = (base.transform.Find("Bg/Enchant/CurEnchantList").GetComponent("XUIWrapContent") as IXUIWrapContent);
			this._scrollView = (base.transform.Find("Bg/Enchant").GetComponent("XUIScrollView") as IXUIScrollView);
			this.m_tipsLab.SetText(XSingleton<UiUtility>.singleton.ReplaceReturn(XSingleton<XStringTable>.singleton.GetString("EnchantNewTip")));
			DlgHandlerBase.EnsureCreate<EnchantBagHandler>(ref this._BagHandler, base.PanelObject.transform, false, this);
			DlgHandlerBase.EnsureCreate<EnchantAttrPreviewHandler>(ref this._PreviewHandler, base.PanelObject.transform.Find("Bg/AttrPanel").gameObject, this, false);
			DlgHandlerBase.EnsureCreate<EnchantActiveHandler>(ref this._activeHandler, base.PanelObject.transform, false, this);
			DlgHandlerBase.EnsureCreate<EnchantResultHandler>(ref this._resultHandler, base.PanelObject.transform, false, this);
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_BtnOK.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnOKClicked));
			this.m_BtnClose.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnCloseClicked));
			this.m_uiSelect.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this._OnEnchantItemClicked));
			this.m_BtnHelp.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnHelpClicked));
			this.m_uiPreview.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this._OnPreviewClicked));
			this.m_uiActiveAttribute.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this._OnToActiveEnchantAttribute));
			IXUISprite ixuisprite = this.m_uiEquipItem.transform.Find("Icon").GetComponent("XUISprite") as IXUISprite;
			ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this._OnEquipIconClicked));
			IXUISprite ixuisprite2 = this.m_uiEnchantItem.transform.Find("Icon").GetComponent("XUISprite") as IXUISprite;
			ixuisprite2.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this._OnEnchantItemClicked));
			this._curEnchantPropertiesContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.EnchantListUpdate));
		}

		private void EnchantListUpdate(Transform itemTransform, int index)
		{
			bool flag = index < this._curEnchantInfo.AttrList.Count;
			if (flag)
			{
				XItemChangeAttr xitemChangeAttr = this._curEnchantInfo.AttrList[index];
				IXUISprite ixuisprite = itemTransform.Find("Sprite").GetComponent("XUISprite") as IXUISprite;
				ixuisprite.SetVisible(this._curEnchantInfo.ChooseAttr == xitemChangeAttr.AttrID);
				IXUILabel ixuilabel = itemTransform.Find("Value").GetComponent("XUILabel") as IXUILabel;
				ixuilabel.SetText("+" + xitemChangeAttr.AttrValue);
				IXUILabel ixuilabel2 = itemTransform.GetComponent("XUILabel") as IXUILabel;
				ixuilabel2.SetText(XAttributeCommon.GetAttrStr((int)xitemChangeAttr.AttrID));
				IXUILabel ixuilabel3 = itemTransform.Find("AfterAttr").GetComponent("XUILabel") as IXUILabel;
				ixuilabel3.SetText("");
				EnchantEquip.RowData enchantEquipData = this._doc.GetEnchantEquipData(this._doc.SelectedItemID);
				bool flag2 = false;
				bool flag3 = enchantEquipData != null;
				if (flag3)
				{
					for (int i = 0; i < (int)enchantEquipData.Attribute.count; i++)
					{
						bool flag4 = enchantEquipData.Attribute[i, 0] == xitemChangeAttr.AttrID;
						if (flag4)
						{
							ixuilabel3.SetText(string.Concat(new object[]
							{
								"[",
								enchantEquipData.Attribute[i, 1],
								",",
								enchantEquipData.Attribute[i, 2],
								"]"
							}));
							flag2 = true;
							break;
						}
					}
				}
				bool flag5 = !flag2 && !this.m_uiSelectFrame.activeInHierarchy;
				if (flag5)
				{
					ixuilabel3.SetText(XSingleton<XStringTable>.singleton.GetString("CurEnchantNoAttr"));
				}
			}
		}

		protected override void OnShow()
		{
			base.OnShow();
			bool flag = DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton._equipHandler != null;
			if (flag)
			{
				DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton._equipHandler.RegisterItemClickEvents(new SpriteClickEventHandler(this._OnEquipClicked));
			}
			bool flag2 = this._BagHandler.IsVisible();
			if (flag2)
			{
				this._BagHandler.SetVisible(false);
			}
			bool flag3 = this._PreviewHandler.IsVisible();
			if (flag3)
			{
				this._PreviewHandler.SetVisible(false);
			}
			bool flag4 = this._activeHandler.IsVisible();
			if (flag4)
			{
				this._activeHandler.SetVisible(false);
			}
			bool flag5 = this._resultHandler.IsVisible();
			if (flag5)
			{
				this._resultHandler.SetVisible(false);
			}
			this.UpdateShowingItems();
			this.RefreshData();
		}

		public override void StackRefresh()
		{
			base.StackRefresh();
			this.RefreshData();
			bool flag = this._BagHandler != null && this._BagHandler.IsVisible();
			if (flag)
			{
				this._BagHandler.StackRefresh();
			}
			bool flag2 = DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton._equipHandler != null;
			if (flag2)
			{
				DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton._equipHandler.RegisterItemClickEvents(new SpriteClickEventHandler(this._OnEquipClicked));
			}
		}

		protected override void OnHide()
		{
			this._doc.ToggleBlock(false);
			this._KillTimer();
			DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton.OnPopHandlerSetVisible(false, null);
			DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton.StackRefresh();
			bool flag = DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton._equipHandler != null;
			if (flag)
			{
				DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton._equipHandler.RegisterItemClickEvents(null);
				DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton._equipHandler.SelectEquip(0UL);
			}
			base.OnHide();
		}

		public override void OnUnload()
		{
			DlgHandlerBase.EnsureUnload<EnchantBagHandler>(ref this._BagHandler);
			DlgHandlerBase.EnsureUnload<EnchantAttrPreviewHandler>(ref this._PreviewHandler);
			DlgHandlerBase.EnsureUnload<EnchantResultHandler>(ref this._resultHandler);
			DlgHandlerBase.EnsureUnload<EnchantActiveHandler>(ref this._activeHandler);
			this._doc._EnchantOperateHandler = null;
			this._KillTimer();
			base.OnUnload();
		}

		public override void RefreshData()
		{
			base.RefreshData();
			this._RefreshPage();
		}

		private void _RefreshPage()
		{
			XEquipItem xequipItem = XSingleton<XGame>.singleton.Doc.XBagDoc.GetItemByUID(this._doc.SelectedEquipUID) as XEquipItem;
			bool flag = xequipItem == null;
			if (flag)
			{
				base.SetVisible(false);
			}
			else
			{
				this._curEnchantInfo = xequipItem.enchantInfo;
				this._doc.ToggleBlock(false);
				this.ResetOKCD();
				XSingleton<XItemDrawerMgr>.singleton.DrawItem(this.m_uiEquipItem, xequipItem);
				EquipList.RowData equipConf = XBagDocument.GetEquipConf(xequipItem.itemID);
				bool flag2 = equipConf == null;
				if (!flag2)
				{
					EnchantEquip.RowData enchantEquipData = this._doc.GetEnchantEquipData(this._doc.SelectedItemID);
					ItemList.RowData itemConf = XBagDocument.GetItemConf(this._doc.SelectedItemID);
					bool flag3 = XEnchantDocument.IsEnchantMatched(equipConf, enchantEquipData) && this._doc.CanEnchant(enchantEquipData) == EnchantCheckResult.ECR_OK;
					if (flag3)
					{
						this._ShowOperatePage(xequipItem, enchantEquipData);
					}
					else
					{
						this._ShowSelectPage();
					}
					this._curEnchantPropertiesContent.SetContentCount(xequipItem.enchantInfo.AttrList.Count, false);
					this._scrollView.ResetPosition();
					this._RefreshNoAttr(xequipItem, enchantEquipData);
				}
			}
		}

		private void _ShowOperatePage(XEquipItem equipItem, EnchantEquip.RowData enchantData)
		{
			this.m_uiOperateFrame.SetActive(true);
			this.m_uiSelectFrame.SetActive(false);
			this._RefreshItems(enchantData);
		}

		private void _RefreshItems(EnchantEquip.RowData enchantData)
		{
			this.m_ItemRequiredCollector.Init();
			this._RefreshEnchantItem(enchantData);
			this._RefreshCost(enchantData);
		}

		private void _RefreshEnchantItem(EnchantEquip.RowData enchantData)
		{
			bool flag = this._doc.SelectedItemID == 0 || enchantData == null;
			if (!flag)
			{
				XItemRequired requiredItem = this.m_ItemRequiredCollector.GetRequiredItem((uint)this._doc.SelectedItemID, (ulong)enchantData.Num, 1f);
				bool flag2 = requiredItem == null;
				if (!flag2)
				{
					Color value = requiredItem.bEnough ? Color.white : Color.red;
					XItemDrawerMgr.Param.MaxItemCount = (int)enchantData.Num;
					XItemDrawerMgr.Param.NumColor = new Color?(value);
					XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(this.m_uiEnchantItem, this._doc.SelectedItemID, (int)requiredItem.ownedCount, true);
				}
			}
		}

		private void _RefreshNoAttr(XEquipItem equipItem, EnchantEquip.RowData enchantData)
		{
			bool flag = equipItem == null;
			if (flag)
			{
				equipItem = (XSingleton<XGame>.singleton.Doc.XBagDoc.GetItemByUID(this._doc.SelectedEquipUID) as XEquipItem);
			}
			this.m_uiActiveAttribute.gameObject.SetActive(this._curEnchantInfo.AttrList.Count > 0);
			this.m_uiNoBeforeAttr.SetActive(true);
			IXUILabel ixuilabel = this.m_uiNoBeforeAttr.GetComponent("XUILabel") as IXUILabel;
			bool flag2 = this.m_uiSelectFrame.activeInHierarchy && equipItem.enchantInfo.AttrList.Count == 0;
			if (flag2)
			{
				ixuilabel.SetText(XSingleton<UiUtility>.singleton.ReplaceReturn(XSingleton<XStringTable>.singleton.GetString("EnchantNOItemTip")));
			}
			else
			{
				bool flag3 = equipItem != null && equipItem.enchantInfo.AttrList.Count == 0;
				if (flag3)
				{
					ixuilabel.SetText(XSingleton<UiUtility>.singleton.ReplaceReturn(XSingleton<XStringTable>.singleton.GetString("EnchantNOAttrTip")));
				}
				else
				{
					this.m_uiNoBeforeAttr.SetActive(false);
				}
			}
		}

		private void _RefreshOMG(ref XEnchantInfo info)
		{
		}

		public void RefreshItems()
		{
			EnchantEquip.RowData enchantEquipData = this._doc.GetEnchantEquipData(this._doc.SelectedItemID);
			this._RefreshItems(enchantEquipData);
		}

		private void _RefreshCost(EnchantEquip.RowData enchantData)
		{
			bool flag = enchantData != null;
			if (flag)
			{
				for (int i = 0; i < enchantData.Cost.Count; i++)
				{
					XItemRequired requiredItem = this.m_ItemRequiredCollector.GetRequiredItem(enchantData.Cost[i, 0], (ulong)enchantData.Cost[i, 1], 1f);
					bool flag2 = requiredItem == null;
					if (!flag2)
					{
						this.m_uiCostValue.SetText(requiredItem.requiredCount.ToString());
						this.m_uiCostValue.SetColor(requiredItem.bEnough ? Color.white : Color.red);
						this.m_uiCostIcon.SetSprite(XBagDocument.GetItemSmallIcon(requiredItem.itemID, 0U));
					}
				}
			}
		}

		private void _ShowSelectPage()
		{
			this.m_uiOperateFrame.SetActive(false);
			this.m_uiSelectFrame.SetActive(true);
		}

		public void RefreshRedPoints()
		{
			bool flag = DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton.IsVisible() && DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton._equipHandler != null;
			if (flag)
			{
				this.m_RedPointEquipPosList.Clear();
				for (int i = 0; i < XBagDocument.EquipMax; i++)
				{
					bool flag2 = this._doc.RedPointStates[i];
					if (flag2)
					{
						this.m_RedPointEquipPosList.Add(i);
					}
				}
				DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton._equipHandler.SetArrows(this.m_RedPointEquipPosList);
			}
		}

		private bool _OnCloseClicked(IXUIButton btn)
		{
			base.SetVisible(false);
			return true;
		}

		private bool _OnOKClicked(IXUIButton btn)
		{
			bool activeInHierarchy = this.m_uiSelectFrame.activeInHierarchy;
			bool result;
			if (activeInHierarchy)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(XSingleton<XStringTable>.singleton.GetString("NoEnchantItem"), "fece00");
				result = true;
			}
			else
			{
				bool flag = !this.m_ItemRequiredCollector.bItemsEnough;
				if (flag)
				{
					for (int i = 0; i < this.m_ItemRequiredCollector.RequiredItems.Count; i++)
					{
						bool flag2 = !this.m_ItemRequiredCollector.RequiredItems[i].bEnough;
						if (flag2)
						{
							DlgBase<XPurchaseView, XPurchaseBehaviour>.singleton.ShowBorad(this.m_ItemRequiredCollector.RequiredItems[i].itemID);
							break;
						}
					}
					result = true;
				}
				else
				{
					XEquipItem xequipItem = XSingleton<XGame>.singleton.Doc.XBagDoc.GetItemByUID(this._doc.SelectedEquipUID) as XEquipItem;
					bool flag3 = xequipItem == null;
					if (flag3)
					{
						result = true;
					}
					else
					{
						this._DoOK(null);
						result = true;
					}
				}
			}
			return result;
		}

		private bool _DoOK(IXUIButton btn)
		{
			this._resultHandler.SetVisible(true);
			bool flag = DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.IsVisible();
			if (flag)
			{
				XOptionsDocument specificDocument = XDocuments.GetSpecificDocument<XOptionsDocument>(XOptionsDocument.uuID);
				specificDocument.SetValue(XOptionsDefine.OD_NO_ENCHANT_REPLACE_CONFIRM, DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.GetTempTip(XTempTipDefine.OD_ENCHANT_REPLACE) ? 1 : 0, false);
			}
			XSingleton<UiUtility>.singleton.CloseModalDlg();
			return true;
		}

		private bool _DoCancel(IXUIButton btn)
		{
			XOptionsDocument specificDocument = XDocuments.GetSpecificDocument<XOptionsDocument>(XOptionsDocument.uuID);
			specificDocument.SetValue(XOptionsDefine.OD_NO_ENCHANT_REPLACE_CONFIRM, DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.GetTempTip(XTempTipDefine.OD_ENCHANT_REPLACE) ? 1 : 0, false);
			XSingleton<UiUtility>.singleton.CloseModalDlg();
			return true;
		}

		public void PlayFx()
		{
		}

		private void _KillTimer()
		{
		}

		private void _OnEnchantItemClicked(IXUISprite iSp)
		{
			this._doc.GetEnchantItems();
			bool flag = this._doc.ItemList.Count > 0;
			if (flag)
			{
				this._BagHandler.SetVisible(true);
			}
			else
			{
				int itemid = (this._doc.SelectedItemID == 0) ? 240 : this._doc.SelectedItemID;
				XSingleton<UiUtility>.singleton.ShowItemAccess(itemid, null);
			}
		}

		private void _OnEquipClicked(IXUISprite iSp)
		{
			XItem itemByUID = XSingleton<XGame>.singleton.Doc.XBagDoc.GetItemByUID(iSp.ID);
			bool flag = itemByUID != null;
			if (flag)
			{
				this._doc.SelectEquip(itemByUID.uid);
			}
		}

		private bool _OnHelpClicked(IXUIButton btn)
		{
			DlgBase<XCommonHelpTipView, XCommonHelpTipBehaviour>.singleton.ShowHelp(XSysDefine.XSys_Item_Enchant);
			return true;
		}

		private void _OnEquipIconClicked(IXUISprite iSp)
		{
			XSingleton<UiUtility>.singleton.ShowTooltipDialog(XSingleton<XGame>.singleton.Doc.XBagDoc.GetItemByUID(this._doc.SelectedEquipUID), null, iSp, false, 0U);
		}

		private void _OnEnchantIconClicked(IXUISprite iSp)
		{
			XSingleton<UiUtility>.singleton.ShowTooltipDialog(this._doc.SelectedItemID, iSp, 0U);
		}

		private void _OnPreviewClicked(IXUISprite iSp)
		{
			bool flag = this._doc.SelectedItemID > 0;
			if (flag)
			{
				this._PreviewHandler.Show(this._doc.SelectedItemID);
			}
		}

		private void _OnToActiveEnchantAttribute(IXUISprite uiSprite)
		{
			this._activeHandler.SetVisible(true);
		}

		private void UpdateShowingItems()
		{
		}

		public void ResetOKCD()
		{
			this.m_BtnOK.ResetCD();
		}

		private XEnchantDocument _doc = null;

		private EnchantBagHandler _BagHandler = null;

		private EnchantAttrPreviewHandler _PreviewHandler = null;

		private EnchantActiveHandler _activeHandler = null;

		private EnchantResultHandler _resultHandler = null;

		private GameObject m_uiOperateFrame;

		private GameObject m_uiSelectFrame;

		private GameObject m_uiEquipItem;

		private GameObject m_uiEnchantItem;

		private IXUIButton m_BtnOK;

		private IXUIButton m_BtnClose;

		private IXUIButton m_BtnHelp;

		private IXUILabel m_tipsLab;

		private GameObject m_uiNoBeforeAttr;

		private IXUILabel m_uiCostValue;

		private IXUISprite m_uiCostIcon;

		private IXUISprite m_uiSelect;

		private IXUISprite m_uiPreview;

		private IXUISprite m_uiActiveAttribute;

		private IXUIWrapContent _curEnchantPropertiesContent;

		private IXUIScrollView _scrollView;

		private XItemRequiredCollector m_ItemRequiredCollector = new XItemRequiredCollector();

		private List<int> m_RedPointEquipPosList = new List<int>();

		private XEnchantInfo _curEnchantInfo;
	}
}
