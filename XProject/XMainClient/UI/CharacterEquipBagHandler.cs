using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x02001902 RID: 6402
	internal class CharacterEquipBagHandler : DlgHandlerBase
	{
		// Token: 0x17003AB6 RID: 15030
		// (get) Token: 0x06010B52 RID: 68434 RVA: 0x0042A360 File Offset: 0x00428560
		private XBagWindow bagWindow
		{
			get
			{
				return DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton.BagWindow;
			}
		}

		// Token: 0x17003AB7 RID: 15031
		// (get) Token: 0x06010B53 RID: 68435 RVA: 0x0042A37C File Offset: 0x0042857C
		private XItemMorePowerfulTipMgr powerfullMgr
		{
			get
			{
				return DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton.RedPointMgr;
			}
		}

		// Token: 0x17003AB8 RID: 15032
		// (get) Token: 0x06010B54 RID: 68436 RVA: 0x0042A398 File Offset: 0x00428598
		private XItemMorePowerfulTipMgr newItemMgr
		{
			get
			{
				return DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton.NewItemMgr;
			}
		}

		// Token: 0x17003AB9 RID: 15033
		// (get) Token: 0x06010B55 RID: 68437 RVA: 0x0042A3B4 File Offset: 0x004285B4
		protected override string FileName
		{
			get
			{
				return "ItemNew/EquipListPanel";
			}
		}

		// Token: 0x06010B56 RID: 68438 RVA: 0x0042A3CC File Offset: 0x004285CC
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

		// Token: 0x06010B57 RID: 68439 RVA: 0x0042A580 File Offset: 0x00428780
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_mastetBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnShowEnhanceMaster));
			this.m_BtnShowAttr.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnShowAttrClick));
			this.m_BtnShowTitle.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnShowTitleClick));
			this.m_Help.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnHelpClicked));
			this.m_expandBagBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnBagExpandClicked));
		}

		// Token: 0x06010B58 RID: 68440 RVA: 0x0042A610 File Offset: 0x00428810
		public bool OnHelpClicked(IXUIButton button)
		{
			DlgBase<XCommonHelpTipView, XCommonHelpTipBehaviour>.singleton.ShowHelp(XSysDefine.XSys_Item_Equip);
			return true;
		}

		// Token: 0x06010B59 RID: 68441 RVA: 0x0042A630 File Offset: 0x00428830
		public override void StackRefresh()
		{
			base.StackRefresh();
			this.RefreshBag();
			this._doc.NewItems.bCanClear = true;
		}

		// Token: 0x06010B5A RID: 68442 RVA: 0x0042A654 File Offset: 0x00428854
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

		// Token: 0x06010B5B RID: 68443 RVA: 0x0042A6B8 File Offset: 0x004288B8
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

		// Token: 0x06010B5C RID: 68444 RVA: 0x0042A83C File Offset: 0x00428A3C
		public void RefreshTitleRedPoint()
		{
			this.m_BtnShowTitle.SetVisible(XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_Title));
			XTitleDocument specificDocument = XDocuments.GetSpecificDocument<XTitleDocument>(XTitleDocument.uuID);
			this.m_TitleRedPoint.SetActive(specificDocument.bEnableTitleLevelUp);
		}

		// Token: 0x06010B5D RID: 68445 RVA: 0x0042A87F File Offset: 0x00428A7F
		protected override void OnHide()
		{
			this.powerfullMgr.ReturnAll();
			this.newItemMgr.ReturnAll();
			this.bagWindow.OnHide();
			this._doc.NewItems.TryClear();
			base.OnHide();
		}

		// Token: 0x06010B5E RID: 68446 RVA: 0x0042A8C0 File Offset: 0x00428AC0
		private void RefreshBag()
		{
			this.bagWindow.ChangeData(new ItemUpdateHandler(this.WrapContentItemUpdated), new GetItemHandler(this._doc.GetEquips));
			DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton._equipHandler.RegisterItemClickEvents(null);
			this.bagWindow.OnShow();
			this.SetBagNum();
		}

		// Token: 0x06010B5F RID: 68447 RVA: 0x0042A91B File Offset: 0x00428B1B
		public override void OnUnload()
		{
			this._doc.Handler = null;
			DlgHandlerBase.EnsureUnload<EnhanceMasterHandler>(ref this.m_EnhanceMasterHandler);
			base.OnUnload();
		}

		// Token: 0x06010B60 RID: 68448 RVA: 0x0042A93E File Offset: 0x00428B3E
		public override void RefreshData()
		{
			base.RefreshData();
			this.RefreshBag();
		}

		// Token: 0x06010B61 RID: 68449 RVA: 0x0042A94F File Offset: 0x00428B4F
		public void Refresh()
		{
			this.bagWindow.RefreshWindow();
			this.SetBagNum();
		}

		// Token: 0x06010B62 RID: 68450 RVA: 0x0042A968 File Offset: 0x00428B68
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

		// Token: 0x06010B63 RID: 68451 RVA: 0x0042A9D4 File Offset: 0x00428BD4
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

		// Token: 0x06010B64 RID: 68452 RVA: 0x0042AAA4 File Offset: 0x00428CA4
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

		// Token: 0x06010B65 RID: 68453 RVA: 0x0042AC80 File Offset: 0x00428E80
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

		// Token: 0x06010B66 RID: 68454 RVA: 0x0042ACD8 File Offset: 0x00428ED8
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

		// Token: 0x06010B67 RID: 68455 RVA: 0x0042AD2D File Offset: 0x00428F2D
		public void AddItem(List<XItem> items)
		{
			this.bagWindow.UpdateBag();
			this.SetBagNum();
		}

		// Token: 0x06010B68 RID: 68456 RVA: 0x0042AD44 File Offset: 0x00428F44
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

		// Token: 0x06010B69 RID: 68457 RVA: 0x0042ADC4 File Offset: 0x00428FC4
		public void ItemNumChanged(XItem item)
		{
			this.bagWindow.UpdateItem(item);
			this.SetBagNum();
		}

		// Token: 0x06010B6A RID: 68458 RVA: 0x0042ADDC File Offset: 0x00428FDC
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

		// Token: 0x06010B6B RID: 68459 RVA: 0x0042AE38 File Offset: 0x00429038
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

		// Token: 0x06010B6C RID: 68460 RVA: 0x0042AEAC File Offset: 0x004290AC
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

		// Token: 0x06010B6D RID: 68461 RVA: 0x0042AF14 File Offset: 0x00429114
		private bool OnShowEnhanceMaster(IXUIButton btn)
		{
			DlgHandlerBase.EnsureCreate<EnhanceMasterHandler>(ref this.m_EnhanceMasterHandler, base.PanelObject.transform.parent.parent.FindChild("LeftPanel"), true, this);
			return true;
		}

		// Token: 0x06010B6E RID: 68462 RVA: 0x0042AF54 File Offset: 0x00429154
		private bool OnShowAttrClick(IXUIButton btn)
		{
			DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton._CharacterAttrHandler.SetVisible(true);
			return true;
		}

		// Token: 0x06010B6F RID: 68463 RVA: 0x0042AF78 File Offset: 0x00429178
		private bool OnShowTitleClick(IXUIButton btn)
		{
			DlgBase<TitleDlg, TitleDlgBehaviour>.singleton.SetVisibleWithAnimation(true, null);
			return true;
		}

		// Token: 0x06010B70 RID: 68464 RVA: 0x0042AF98 File Offset: 0x00429198
		public bool OnBagExpandClicked(IXUIButton button)
		{
			XBagDocument.BagDoc.UseBagExpandTicket(BagType.EquipBag);
			return true;
		}

		// Token: 0x04007A34 RID: 31284
		private XCharacterEquipDocument _doc;

		// Token: 0x04007A35 RID: 31285
		private EnhanceMasterHandler m_EnhanceMasterHandler;

		// Token: 0x04007A36 RID: 31286
		private GameObject m_topGo;

		// Token: 0x04007A37 RID: 31287
		private IXUILabel m_masterHisMaxLevelLab;

		// Token: 0x04007A38 RID: 31288
		private IXUIButton m_mastetBtn;

		// Token: 0x04007A39 RID: 31289
		private IXUIButton m_BtnShowAttr;

		// Token: 0x04007A3A RID: 31290
		private IXUIButton m_BtnShowTitle;

		// Token: 0x04007A3B RID: 31291
		private GameObject m_TitleRedPoint;

		// Token: 0x04007A3C RID: 31292
		private IXUIButton m_Help;

		// Token: 0x04007A3D RID: 31293
		private IXUILabel m_bagNumLab;

		// Token: 0x04007A3E RID: 31294
		private List<int> m_RedPointEquipPosList = new List<int>();

		// Token: 0x04007A3F RID: 31295
		public IXUIButton m_expandBagBtn;
	}
}
