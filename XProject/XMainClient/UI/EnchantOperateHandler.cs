using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x020017BB RID: 6075
	internal class EnchantOperateHandler : DlgHandlerBase
	{
		// Token: 0x17003885 RID: 14469
		// (get) Token: 0x0600FB71 RID: 64369 RVA: 0x003A6078 File Offset: 0x003A4278
		protected override string FileName
		{
			get
			{
				return "ItemNew/EnchantFrame";
			}
		}

		// Token: 0x0600FB72 RID: 64370 RVA: 0x003A6090 File Offset: 0x003A4290
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

		// Token: 0x0600FB73 RID: 64371 RVA: 0x003A63B0 File Offset: 0x003A45B0
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

		// Token: 0x0600FB74 RID: 64372 RVA: 0x003A64E0 File Offset: 0x003A46E0
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

		// Token: 0x0600FB75 RID: 64373 RVA: 0x003A66D8 File Offset: 0x003A48D8
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

		// Token: 0x0600FB76 RID: 64374 RVA: 0x003A679C File Offset: 0x003A499C
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

		// Token: 0x0600FB77 RID: 64375 RVA: 0x003A680C File Offset: 0x003A4A0C
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

		// Token: 0x0600FB78 RID: 64376 RVA: 0x003A6884 File Offset: 0x003A4A84
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

		// Token: 0x0600FB79 RID: 64377 RVA: 0x003A68DC File Offset: 0x003A4ADC
		public override void RefreshData()
		{
			base.RefreshData();
			this._RefreshPage();
		}

		// Token: 0x0600FB7A RID: 64378 RVA: 0x003A68F0 File Offset: 0x003A4AF0
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

		// Token: 0x0600FB7B RID: 64379 RVA: 0x003A6A17 File Offset: 0x003A4C17
		private void _ShowOperatePage(XEquipItem equipItem, EnchantEquip.RowData enchantData)
		{
			this.m_uiOperateFrame.SetActive(true);
			this.m_uiSelectFrame.SetActive(false);
			this._RefreshItems(enchantData);
		}

		// Token: 0x0600FB7C RID: 64380 RVA: 0x003A6A3C File Offset: 0x003A4C3C
		private void _RefreshItems(EnchantEquip.RowData enchantData)
		{
			this.m_ItemRequiredCollector.Init();
			this._RefreshEnchantItem(enchantData);
			this._RefreshCost(enchantData);
		}

		// Token: 0x0600FB7D RID: 64381 RVA: 0x003A6A5C File Offset: 0x003A4C5C
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

		// Token: 0x0600FB7E RID: 64382 RVA: 0x003A6B14 File Offset: 0x003A4D14
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

		// Token: 0x0600FB7F RID: 64383 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		private void _RefreshOMG(ref XEnchantInfo info)
		{
		}

		// Token: 0x0600FB80 RID: 64384 RVA: 0x003A6C34 File Offset: 0x003A4E34
		public void RefreshItems()
		{
			EnchantEquip.RowData enchantEquipData = this._doc.GetEnchantEquipData(this._doc.SelectedItemID);
			this._RefreshItems(enchantEquipData);
		}

		// Token: 0x0600FB81 RID: 64385 RVA: 0x003A6C64 File Offset: 0x003A4E64
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

		// Token: 0x0600FB82 RID: 64386 RVA: 0x003A6D28 File Offset: 0x003A4F28
		private void _ShowSelectPage()
		{
			this.m_uiOperateFrame.SetActive(false);
			this.m_uiSelectFrame.SetActive(true);
		}

		// Token: 0x0600FB83 RID: 64387 RVA: 0x003A6D48 File Offset: 0x003A4F48
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

		// Token: 0x0600FB84 RID: 64388 RVA: 0x003A6DD0 File Offset: 0x003A4FD0
		private bool _OnCloseClicked(IXUIButton btn)
		{
			base.SetVisible(false);
			return true;
		}

		// Token: 0x0600FB85 RID: 64389 RVA: 0x003A6DEC File Offset: 0x003A4FEC
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

		// Token: 0x0600FB86 RID: 64390 RVA: 0x003A6EF4 File Offset: 0x003A50F4
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

		// Token: 0x0600FB87 RID: 64391 RVA: 0x003A6F58 File Offset: 0x003A5158
		private bool _DoCancel(IXUIButton btn)
		{
			XOptionsDocument specificDocument = XDocuments.GetSpecificDocument<XOptionsDocument>(XOptionsDocument.uuID);
			specificDocument.SetValue(XOptionsDefine.OD_NO_ENCHANT_REPLACE_CONFIRM, DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.GetTempTip(XTempTipDefine.OD_ENCHANT_REPLACE) ? 1 : 0, false);
			XSingleton<UiUtility>.singleton.CloseModalDlg();
			return true;
		}

		// Token: 0x0600FB88 RID: 64392 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public void PlayFx()
		{
		}

		// Token: 0x0600FB89 RID: 64393 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		private void _KillTimer()
		{
		}

		// Token: 0x0600FB8A RID: 64394 RVA: 0x003A6FA0 File Offset: 0x003A51A0
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

		// Token: 0x0600FB8B RID: 64395 RVA: 0x003A7010 File Offset: 0x003A5210
		private void _OnEquipClicked(IXUISprite iSp)
		{
			XItem itemByUID = XSingleton<XGame>.singleton.Doc.XBagDoc.GetItemByUID(iSp.ID);
			bool flag = itemByUID != null;
			if (flag)
			{
				this._doc.SelectEquip(itemByUID.uid);
			}
		}

		// Token: 0x0600FB8C RID: 64396 RVA: 0x003A7054 File Offset: 0x003A5254
		private bool _OnHelpClicked(IXUIButton btn)
		{
			DlgBase<XCommonHelpTipView, XCommonHelpTipBehaviour>.singleton.ShowHelp(XSysDefine.XSys_Item_Enchant);
			return true;
		}

		// Token: 0x0600FB8D RID: 64397 RVA: 0x003A7074 File Offset: 0x003A5274
		private void _OnEquipIconClicked(IXUISprite iSp)
		{
			XSingleton<UiUtility>.singleton.ShowTooltipDialog(XSingleton<XGame>.singleton.Doc.XBagDoc.GetItemByUID(this._doc.SelectedEquipUID), null, iSp, false, 0U);
		}

		// Token: 0x0600FB8E RID: 64398 RVA: 0x003A70A5 File Offset: 0x003A52A5
		private void _OnEnchantIconClicked(IXUISprite iSp)
		{
			XSingleton<UiUtility>.singleton.ShowTooltipDialog(this._doc.SelectedItemID, iSp, 0U);
		}

		// Token: 0x0600FB8F RID: 64399 RVA: 0x003A70C0 File Offset: 0x003A52C0
		private void _OnPreviewClicked(IXUISprite iSp)
		{
			bool flag = this._doc.SelectedItemID > 0;
			if (flag)
			{
				this._PreviewHandler.Show(this._doc.SelectedItemID);
			}
		}

		// Token: 0x0600FB90 RID: 64400 RVA: 0x003A70F7 File Offset: 0x003A52F7
		private void _OnToActiveEnchantAttribute(IXUISprite uiSprite)
		{
			this._activeHandler.SetVisible(true);
		}

		// Token: 0x0600FB91 RID: 64401 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		private void UpdateShowingItems()
		{
		}

		// Token: 0x0600FB92 RID: 64402 RVA: 0x003A7107 File Offset: 0x003A5307
		public void ResetOKCD()
		{
			this.m_BtnOK.ResetCD();
		}

		// Token: 0x04006E56 RID: 28246
		private XEnchantDocument _doc = null;

		// Token: 0x04006E57 RID: 28247
		private EnchantBagHandler _BagHandler = null;

		// Token: 0x04006E58 RID: 28248
		private EnchantAttrPreviewHandler _PreviewHandler = null;

		// Token: 0x04006E59 RID: 28249
		private EnchantActiveHandler _activeHandler = null;

		// Token: 0x04006E5A RID: 28250
		private EnchantResultHandler _resultHandler = null;

		// Token: 0x04006E5B RID: 28251
		private GameObject m_uiOperateFrame;

		// Token: 0x04006E5C RID: 28252
		private GameObject m_uiSelectFrame;

		// Token: 0x04006E5D RID: 28253
		private GameObject m_uiEquipItem;

		// Token: 0x04006E5E RID: 28254
		private GameObject m_uiEnchantItem;

		// Token: 0x04006E5F RID: 28255
		private IXUIButton m_BtnOK;

		// Token: 0x04006E60 RID: 28256
		private IXUIButton m_BtnClose;

		// Token: 0x04006E61 RID: 28257
		private IXUIButton m_BtnHelp;

		// Token: 0x04006E62 RID: 28258
		private IXUILabel m_tipsLab;

		// Token: 0x04006E63 RID: 28259
		private GameObject m_uiNoBeforeAttr;

		// Token: 0x04006E64 RID: 28260
		private IXUILabel m_uiCostValue;

		// Token: 0x04006E65 RID: 28261
		private IXUISprite m_uiCostIcon;

		// Token: 0x04006E66 RID: 28262
		private IXUISprite m_uiSelect;

		// Token: 0x04006E67 RID: 28263
		private IXUISprite m_uiPreview;

		// Token: 0x04006E68 RID: 28264
		private IXUISprite m_uiActiveAttribute;

		// Token: 0x04006E69 RID: 28265
		private IXUIWrapContent _curEnchantPropertiesContent;

		// Token: 0x04006E6A RID: 28266
		private IXUIScrollView _scrollView;

		// Token: 0x04006E6B RID: 28267
		private XItemRequiredCollector m_ItemRequiredCollector = new XItemRequiredCollector();

		// Token: 0x04006E6C RID: 28268
		private List<int> m_RedPointEquipPosList = new List<int>();

		// Token: 0x04006E6D RID: 28269
		private XEnchantInfo _curEnchantInfo;
	}
}
