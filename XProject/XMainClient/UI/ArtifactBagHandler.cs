using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class ArtifactBagHandler : DlgHandlerBase
	{

		protected override string FileName
		{
			get
			{
				return "ItemNew/ArtifactListPanel";
			}
		}

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

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_Help.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnHelpClicked));
			this.m_atlasBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnAtlasClicked));
			this.m_expandBagBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnBagExpandClicked));
		}

		protected override void OnShow()
		{
			base.OnShow();
			this.m_doc.BagHandler = this;
			this.RefreshBag();
			this.m_doc.NewItems.bCanClear = true;
			this.RefreshRedPoints();
			this.SetBagNum();
		}

		protected override void OnHide()
		{
			base.OnHide();
			this.m_doc.NewItems.TryClear();
		}

		public override void StackRefresh()
		{
			base.StackRefresh();
			this.RefreshBag();
			this.m_doc.NewItems.bCanClear = true;
		}

		public override void OnUnload()
		{
			DlgHandlerBase.EnsureUnload<ArtifactAtlasHandler>(ref this.m_atlasHandler);
			this.m_doc.BagHandler = null;
			base.OnUnload();
		}

		private void RefreshBag()
		{
			this.m_bagWindow.ChangeData(new ItemUpdateHandler(this.WrapContentItemUpdated), new GetItemHandler(this.m_doc.GetArtifacts));
			this.m_bagWindow.OnShow();
			this.SetBagNum();
		}

		public void Refresh()
		{
			this.m_bagWindow.RefreshWindow();
			this.SetBagNum();
		}

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

		public void RefreshRedPoints()
		{
		}

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

		public void AddItem(List<XItem> items)
		{
			this.m_bagWindow.UpdateBag();
			this.SetBagNum();
		}

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

		public void ItemNumChanged(XItem item)
		{
			this.m_bagWindow.UpdateItem(item);
			this.SetBagNum();
		}

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

		private ArtifactAtlasHandler m_atlasHandler;

		private ArtifactBagDocument m_doc;

		private XBagWindow m_bagWindow;

		private GameObject m_artifactBagPanel;

		private IXUIButton m_Help;

		private IXUIButton m_atlasBtn;

		private IXUILabel m_bagNumLab;

		public IXUIButton m_expandBagBtn;
	}
}
