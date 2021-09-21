using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x020017AC RID: 6060
	internal class ArtifactBagHandler : DlgHandlerBase
	{
		// Token: 0x17003871 RID: 14449
		// (get) Token: 0x0600FA8A RID: 64138 RVA: 0x0039F378 File Offset: 0x0039D578
		protected override string FileName
		{
			get
			{
				return "ItemNew/ArtifactListPanel";
			}
		}

		// Token: 0x0600FA8B RID: 64139 RVA: 0x0039F390 File Offset: 0x0039D590
		protected override void Init()
		{
			base.Init();
			this.m_doc = ArtifactBagDocument.Doc;
			this.m_artifactBagPanel = base.PanelObject;
			this.m_bagNumLab = (base.PanelObject.transform.FindChild("BagNum").GetComponent("XUILabel") as IXUILabel);
			this.m_Help = (base.PanelObject.transform.FindChild("Help").GetComponent("XUIButton") as IXUIButton);
			this.m_atlasBtn = (base.PanelObject.transform.FindChild("BtnShop").GetComponent("XUIButton") as IXUIButton);
			this.m_expandBagBtn = (base.PanelObject.transform.FindChild("add").GetComponent("XUIButton") as IXUIButton);
			this.m_bagWindow = new XBagWindow(this.m_artifactBagPanel, new ItemUpdateHandler(this.WrapContentItemUpdated), new GetItemHandler(this.m_doc.GetArtifacts));
			this.m_bagWindow.Init();
			BagExpandItemListTable.RowData expandItemConfByType = XBagDocument.GetExpandItemConfByType((uint)XFastEnumIntEqualityComparer<BagType>.ToInt(BagType.ArtifactBag));
			this.m_expandBagBtn.gameObject.SetActive(expandItemConfByType != null);
			DlgHandlerBase.EnsureCreate<ArtifactAtlasHandler>(ref this.m_atlasHandler, base.PanelObject.transform.parent.parent, false, this);
		}

		// Token: 0x0600FA8C RID: 64140 RVA: 0x0039F4E4 File Offset: 0x0039D6E4
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_Help.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnHelpClicked));
			this.m_atlasBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnAtlasClicked));
			this.m_expandBagBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnBagExpandClicked));
		}

		// Token: 0x0600FA8D RID: 64141 RVA: 0x0039F541 File Offset: 0x0039D741
		protected override void OnShow()
		{
			base.OnShow();
			this.m_doc.BagHandler = this;
			this.RefreshBag();
			this.m_doc.NewItems.bCanClear = true;
			this.RefreshRedPoints();
			this.SetBagNum();
		}

		// Token: 0x0600FA8E RID: 64142 RVA: 0x0039F57F File Offset: 0x0039D77F
		protected override void OnHide()
		{
			base.OnHide();
			this.m_doc.NewItems.TryClear();
		}

		// Token: 0x0600FA8F RID: 64143 RVA: 0x0039F59A File Offset: 0x0039D79A
		public override void StackRefresh()
		{
			base.StackRefresh();
			this.RefreshBag();
			this.m_doc.NewItems.bCanClear = true;
		}

		// Token: 0x0600FA90 RID: 64144 RVA: 0x0039F5BD File Offset: 0x0039D7BD
		public override void OnUnload()
		{
			DlgHandlerBase.EnsureUnload<ArtifactAtlasHandler>(ref this.m_atlasHandler);
			this.m_doc.BagHandler = null;
			base.OnUnload();
		}

		// Token: 0x0600FA91 RID: 64145 RVA: 0x0039F5E0 File Offset: 0x0039D7E0
		private void RefreshBag()
		{
			this.m_bagWindow.ChangeData(new ItemUpdateHandler(this.WrapContentItemUpdated), new GetItemHandler(this.m_doc.GetArtifacts));
			this.m_bagWindow.OnShow();
			this.SetBagNum();
		}

		// Token: 0x0600FA92 RID: 64146 RVA: 0x0039F61F File Offset: 0x0039D81F
		public void Refresh()
		{
			this.m_bagWindow.RefreshWindow();
			this.SetBagNum();
		}

		// Token: 0x0600FA93 RID: 64147 RVA: 0x0039F638 File Offset: 0x0039D838
		private void WrapContentItemUpdated(Transform t, int index)
		{
			bool flag = this.m_bagWindow.m_XItemList == null || index >= this.m_bagWindow.m_XItemList.Count || index < 0;
			if (flag)
			{
				XSingleton<XItemDrawerMgr>.singleton.DrawItem(t.gameObject, null);
				t.gameObject.name = XSingleton<XCommon>.singleton.StringCombine("empty", index.ToString());
			}
			else
			{
				IXUISprite ixuisprite = t.FindChild("Icon").GetComponent("XUISprite") as IXUISprite;
				XSingleton<XItemDrawerMgr>.singleton.DrawItem(t.gameObject, this.m_bagWindow.m_XItemList[index]);
				ixuisprite.ID = this.m_bagWindow.m_XItemList[index].uid;
				ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnItemClicked));
				t.gameObject.name = XSingleton<XCommon>.singleton.StringCombine("artifact", this.m_bagWindow.m_XItemList[index].itemID.ToString());
				EquipCompare mix = this.m_doc.IsEquipMorePowerful(ixuisprite.ID);
				EquipCompare final = ArtifactBagDocument.GetFinal(mix);
				Transform transform = t.FindChild("Icon/RedPoint");
				bool flag2 = transform != null;
				if (flag2)
				{
					transform.gameObject.SetActive(final == EquipCompare.EC_MORE_POWERFUL);
				}
				transform = t.FindChild("Icon/New");
				bool flag3 = transform != null;
				if (flag3)
				{
					transform.gameObject.SetActive(this.m_doc.NewItems.IsNew(ixuisprite.ID));
				}
				transform = t.Find("Icon/TimeBg");
				bool flag4 = transform != null;
				if (flag4)
				{
					transform.gameObject.SetActive(false);
				}
			}
		}

		// Token: 0x0600FA94 RID: 64148 RVA: 0x0039F804 File Offset: 0x0039DA04
		private void SetBagNum()
		{
			int count = this.m_doc.GetArtifacts().Count;
			XRechargeDocument specificDocument = XDocuments.GetSpecificDocument<XRechargeDocument>(XRechargeDocument.uuID);
			VIPTable.RowData byVIP = specificDocument.VIPReader.GetByVIP((int)specificDocument.VipLevel);
			bool flag = byVIP != null;
			if (flag)
			{
				uint num = byVIP.ArtifactMax;
				BagExpandData bagExpandData = XBagDocument.BagDoc.GetBagExpandData(BagType.ArtifactBag);
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

		// Token: 0x0600FA95 RID: 64149 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public void RefreshRedPoints()
		{
		}

		// Token: 0x0600FA96 RID: 64150 RVA: 0x0039F8D4 File Offset: 0x0039DAD4
		public void LoadEquip(XItem item, int slot)
		{
			DlgBase<EquipTooltipDlg, EquipTooltipDlgBehaviour>.singleton.HideToolTip(true);
			bool flag = DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton._ArtifactFrameHandler != null && DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton._ArtifactFrameHandler.IsVisible();
			if (flag)
			{
				DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton._ArtifactFrameHandler.SetEquipSlot(slot, item);
			}
			this.Refresh();
		}

		// Token: 0x0600FA97 RID: 64151 RVA: 0x0039F92C File Offset: 0x0039DB2C
		public void UnloadEquip(int slot)
		{
			DlgBase<EquipTooltipDlg, EquipTooltipDlgBehaviour>.singleton.HideToolTip(true);
			bool flag = DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton._ArtifactFrameHandler != null && DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton._ArtifactFrameHandler.IsVisible();
			if (flag)
			{
				DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton._ArtifactFrameHandler.SetEquipSlot(slot, null);
			}
			this.Refresh();
		}

		// Token: 0x0600FA98 RID: 64152 RVA: 0x0039F981 File Offset: 0x0039DB81
		public void AddItem(List<XItem> items)
		{
			this.m_bagWindow.UpdateBag();
			this.SetBagNum();
		}

		// Token: 0x0600FA99 RID: 64153 RVA: 0x0039F998 File Offset: 0x0039DB98
		public void RemoveItem(List<ulong> uids)
		{
			this.m_bagWindow.UpdateBag();
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

		// Token: 0x0600FA9A RID: 64154 RVA: 0x0039FA18 File Offset: 0x0039DC18
		public void SwapItem(XItem item1, XItem item2, int slot)
		{
			DlgBase<EquipTooltipDlg, EquipTooltipDlgBehaviour>.singleton.HideToolTip(true);
			bool flag = DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton._ArtifactFrameHandler != null && DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton._ArtifactFrameHandler.IsVisible();
			if (flag)
			{
				DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton._ArtifactFrameHandler.SetEquipSlot(slot, item1);
			}
			this.m_bagWindow.ReplaceItem(item1, item2);
		}

		// Token: 0x0600FA9B RID: 64155 RVA: 0x0039FA74 File Offset: 0x0039DC74
		public void UpdateItem(XItem item)
		{
			this.m_bagWindow.UpdateItem(item);
			DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton._ArtifactFrameHandler.UpdateEquipSlot(item);
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

		// Token: 0x0600FA9C RID: 64156 RVA: 0x0039FAE8 File Offset: 0x0039DCE8
		public void ItemNumChanged(XItem item)
		{
			this.m_bagWindow.UpdateItem(item);
			this.SetBagNum();
		}

		// Token: 0x0600FA9D RID: 64157 RVA: 0x0039FB00 File Offset: 0x0039DD00
		public bool OnHelpClicked(IXUIButton button)
		{
			bool flag = DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton.IsVisible() && DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton._ArtifactFrameHandler != null && DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton._ArtifactFrameHandler.IsVisible();
			if (flag)
			{
				DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton._ArtifactFrameHandler.HideEffects();
			}
			DlgBase<XCommonHelpTipView, XCommonHelpTipBehaviour>.singleton.ShowHelp(XSysDefine.XSys_Artifact);
			return true;
		}

		// Token: 0x0600FA9E RID: 64158 RVA: 0x0039FB64 File Offset: 0x0039DD64
		public bool OnAtlasClicked(IXUIButton button)
		{
			bool flag = DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton.IsVisible() && DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton._ArtifactFrameHandler != null && DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton._ArtifactFrameHandler.IsVisible();
			if (flag)
			{
				DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton._ArtifactFrameHandler.HideEffects();
			}
			bool flag2 = this.m_atlasHandler != null;
			if (flag2)
			{
				this.m_atlasHandler.SetVisible(true);
			}
			return true;
		}

		// Token: 0x0600FA9F RID: 64159 RVA: 0x0039FBD4 File Offset: 0x0039DDD4
		public bool OnBagExpandClicked(IXUIButton button)
		{
			bool flag = DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton.IsVisible() && DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton._ArtifactFrameHandler != null && DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton._ArtifactFrameHandler.IsVisible();
			if (flag)
			{
				DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton._ArtifactFrameHandler.HideEffects();
			}
			XBagDocument.BagDoc.UseBagExpandTicket(BagType.ArtifactBag);
			return true;
		}

		// Token: 0x0600FAA0 RID: 64160 RVA: 0x0039FC34 File Offset: 0x0039DE34
		private void OnItemClicked(IXUISprite iSp)
		{
			XItem itemByUID = XSingleton<XGame>.singleton.Doc.XBagDoc.GetItemByUID(iSp.ID);
			bool flag = itemByUID == null;
			if (!flag)
			{
				bool flag2 = this.m_doc.NewItems.RemoveItem(iSp.ID, itemByUID.Type, false);
				if (flag2)
				{
					this.m_doc.GetArtifacts();
				}
				CharacterEquipHandler.OnItemClicked(iSp);
				bool flag3 = DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton.IsVisible() && DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton._ArtifactFrameHandler != null && DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton._ArtifactFrameHandler.IsVisible();
				if (flag3)
				{
					DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton._ArtifactFrameHandler.HideEffects();
				}
			}
		}

		// Token: 0x04006DD7 RID: 28119
		private ArtifactAtlasHandler m_atlasHandler;

		// Token: 0x04006DD8 RID: 28120
		private ArtifactBagDocument m_doc;

		// Token: 0x04006DD9 RID: 28121
		private XBagWindow m_bagWindow;

		// Token: 0x04006DDA RID: 28122
		private GameObject m_artifactBagPanel;

		// Token: 0x04006DDB RID: 28123
		private IXUIButton m_Help;

		// Token: 0x04006DDC RID: 28124
		private IXUIButton m_atlasBtn;

		// Token: 0x04006DDD RID: 28125
		private IXUILabel m_bagNumLab;

		// Token: 0x04006DDE RID: 28126
		public IXUIButton m_expandBagBtn;
	}
}
