using System;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class RecycleItemBagView : DlgHandlerBase
	{

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

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			IXUIButton ixuibutton = base.PanelObject.transform.FindChild("FilterBtn").GetComponent("XUIButton") as IXUIButton;
			ixuibutton.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnFilterClicked));
		}

		protected override void OnShow()
		{
			base.OnShow();
			this.bagWindow.OnShow();
			this.qualityFilter.SetVisible(false);
		}

		protected override void OnHide()
		{
			base.OnHide();
			this.bagWindow.OnHide();
			this._doc.ResetSelection(false);
		}

		public override void OnUnload()
		{
			this._doc.BagView = null;
			this.bagWindow = null;
			base.OnUnload();
		}

		public void Refresh()
		{
			this.bagWindow.RefreshWindow();
		}

		public void UpdateView()
		{
			this.bagWindow.UpdateBag();
		}

		protected bool _OnFilterClicked(IXUIButton btn)
		{
			this.qualityFilter.SetVisible(true);
			return true;
		}

		protected void _OnFilterOK(int mask)
		{
			RecycleItemBagView.QualityMask = mask;
			this._doc.GetQuickSelectItems(mask);
		}

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

		public void OnItemClicked(IXUISprite iSp)
		{
			this._doc.ToggleItemSelect(iSp.ID);
		}

		public void OnItemLongPressed(IXUISprite iSp)
		{
			XItem bagItemByUID = XBagDocument.BagDoc.GetBagItemByUID(iSp.ID);
			XSingleton<UiUtility>.singleton.ShowTooltipDialog(bagItemByUID, null, iSp, false, 0U);
		}

		private XRecycleItemDocument _doc = null;

		private QualityFilterHandler qualityFilter;

		private static int QualityMask = 3;

		private IXUIScrollView bagScrollView = null;

		private XBagWindow bagWindow;
	}
}
