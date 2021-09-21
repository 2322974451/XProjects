using System;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x020018C0 RID: 6336
	internal class RecycleItemBagView : DlgHandlerBase
	{
		// Token: 0x06010855 RID: 67669 RVA: 0x0040DADC File Offset: 0x0040BCDC
		protected override void Init()
		{
			base.Init();
			this._doc = XDocuments.GetSpecificDocument<XRecycleItemDocument>(XRecycleItemDocument.uuID);
			this._doc.BagView = this;
			DlgHandlerBase.EnsureCreate<QualityFilterHandler>(ref this.qualityFilter, base.PanelObject.transform.FindChild("FilterPanel").gameObject, null, true);
			this.qualityFilter.Set(RecycleItemBagView.QualityMask, new QualityFilterCallback(this._OnFilterOK));
			this.bagScrollView = (base.PanelObject.transform.FindChild("Panel").GetComponent("XUIScrollView") as IXUIScrollView);
			this.bagWindow = new XBagWindow(base.PanelObject, new ItemUpdateHandler(this.WrapContentItemUpdated), new GetItemHandler(this._doc.GetItems));
			this.bagWindow.Init();
		}

		// Token: 0x06010856 RID: 67670 RVA: 0x0040DBB8 File Offset: 0x0040BDB8
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			IXUIButton ixuibutton = base.PanelObject.transform.FindChild("FilterBtn").GetComponent("XUIButton") as IXUIButton;
			ixuibutton.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnFilterClicked));
		}

		// Token: 0x06010857 RID: 67671 RVA: 0x0040DC05 File Offset: 0x0040BE05
		protected override void OnShow()
		{
			base.OnShow();
			this.bagWindow.OnShow();
			this.qualityFilter.SetVisible(false);
		}

		// Token: 0x06010858 RID: 67672 RVA: 0x0040DC28 File Offset: 0x0040BE28
		protected override void OnHide()
		{
			base.OnHide();
			this.bagWindow.OnHide();
			this._doc.ResetSelection(false);
		}

		// Token: 0x06010859 RID: 67673 RVA: 0x0040DC4B File Offset: 0x0040BE4B
		public override void OnUnload()
		{
			this._doc.BagView = null;
			this.bagWindow = null;
			base.OnUnload();
		}

		// Token: 0x0601085A RID: 67674 RVA: 0x0040DC69 File Offset: 0x0040BE69
		public void Refresh()
		{
			this.bagWindow.RefreshWindow();
		}

		// Token: 0x0601085B RID: 67675 RVA: 0x0040DC78 File Offset: 0x0040BE78
		public void UpdateView()
		{
			this.bagWindow.UpdateBag();
		}

		// Token: 0x0601085C RID: 67676 RVA: 0x0040DC88 File Offset: 0x0040BE88
		protected bool _OnFilterClicked(IXUIButton btn)
		{
			this.qualityFilter.SetVisible(true);
			return true;
		}

		// Token: 0x0601085D RID: 67677 RVA: 0x0040DCA8 File Offset: 0x0040BEA8
		protected void _OnFilterOK(int mask)
		{
			RecycleItemBagView.QualityMask = mask;
			this._doc.GetQuickSelectItems(mask);
		}

		// Token: 0x0601085E RID: 67678 RVA: 0x0040DCC0 File Offset: 0x0040BEC0
		private void WrapContentItemUpdated(Transform t, int index)
		{
			IXUISprite ixuisprite = t.FindChild("Icon").GetComponent("XUISprite") as IXUISprite;
			IXUILongPress ixuilongPress = ixuisprite.gameObject.GetComponent("XUILongPress") as IXUILongPress;
			bool flag = this.bagWindow.m_XItemList == null || index >= this.bagWindow.m_XItemList.Count || index < 0;
			if (flag)
			{
				XSingleton<XItemDrawerMgr>.singleton.DrawItem(t.gameObject, null);
				ixuilongPress.RegisterSpriteLongPressEventHandler(null);
			}
			else
			{
				ixuisprite.ID = this.bagWindow.m_XItemList[index].uid;
				int num = 0;
				this._doc.IsSelected(ixuisprite.ID, out num);
				bool flag2 = num == 0;
				if (flag2)
				{
					XSingleton<XItemDrawerMgr>.singleton.DrawItem(t.gameObject, null);
					ixuilongPress.RegisterSpriteLongPressEventHandler(null);
					ixuisprite.RegisterSpriteClickEventHandler(null);
				}
				else
				{
					XSingleton<XItemDrawerMgr>.singleton.DrawItem(t.gameObject, this.bagWindow.m_XItemList[index]);
					ixuilongPress.RegisterSpriteLongPressEventHandler(new SpriteClickEventHandler(this.OnItemLongPressed));
					IXUILabel ixuilabel = t.FindChild("Num").GetComponent("XUILabel") as IXUILabel;
					ixuilabel.SetText(num.ToString());
					ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnItemClicked));
				}
			}
		}

		// Token: 0x0601085F RID: 67679 RVA: 0x0040DE25 File Offset: 0x0040C025
		public void OnItemClicked(IXUISprite iSp)
		{
			this._doc.ToggleItemSelect(iSp.ID);
		}

		// Token: 0x06010860 RID: 67680 RVA: 0x0040DE3C File Offset: 0x0040C03C
		public void OnItemLongPressed(IXUISprite iSp)
		{
			XItem bagItemByUID = XBagDocument.BagDoc.GetBagItemByUID(iSp.ID);
			XSingleton<UiUtility>.singleton.ShowTooltipDialog(bagItemByUID, null, iSp, false, 0U);
		}

		// Token: 0x04007793 RID: 30611
		private XRecycleItemDocument _doc = null;

		// Token: 0x04007794 RID: 30612
		private QualityFilterHandler qualityFilter;

		// Token: 0x04007795 RID: 30613
		private static int QualityMask = 3;

		// Token: 0x04007796 RID: 30614
		private IXUIScrollView bagScrollView = null;

		// Token: 0x04007797 RID: 30615
		private XBagWindow bagWindow;
	}
}
