using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class ItemUseListDlg : DlgBase<ItemUseListDlg, ItemUseListDlgBehaviour>
	{

		public override string fileName
		{
			get
			{
				return "Hall/ShapeshiftDlg";
			}
		}

		public override int layer
		{
			get
			{
				return 100;
			}
		}

		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		protected override void Init()
		{
		}

		public override void RegisterEvent()
		{
			base.uiBehaviour.m_Close.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnCloseClicked));
			base.uiBehaviour.m_WrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.OnWrapContentUpdated));
		}

		public void SetTitle(string text)
		{
			base.uiBehaviour.m_Title.SetText(text);
		}

		public void Set(ButtonClickEventHandler clickHandler, List<XItem> itemList)
		{
			bool flag = itemList == null;
			if (!flag)
			{
				this.m_ItemList = itemList;
				this.m_ClickHandler = clickHandler;
				this.SetVisible(true, true);
			}
		}

		protected override void OnShow()
		{
			base.OnShow();
			bool flag = this.m_ItemList != null;
			if (flag)
			{
				base.uiBehaviour.m_WrapContent.SetContentCount(this.m_ItemList.Count, false);
			}
			base.uiBehaviour.m_ScrollView.ResetPosition();
		}

		private void OnWrapContentUpdated(Transform t, int index)
		{
			bool flag = index < 0 || this.m_ItemList == null || index >= this.m_ItemList.Count;
			if (!flag)
			{
				XItem item = this.m_ItemList[index];
				Transform transform = t.Find("Item");
				IXUIButton ixuibutton = t.Find("BtnUse").GetComponent("XUIButton") as IXUIButton;
				XSingleton<XItemDrawerMgr>.singleton.DrawItem(transform.gameObject, item);
				ixuibutton.ID = (ulong)((long)index);
				ixuibutton.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnUseClicked));
			}
		}

		private bool OnUseClicked(IXUIButton btn)
		{
			bool flag = this.m_ClickHandler != null;
			if (flag)
			{
				this.m_ClickHandler(btn);
			}
			this.SetVisible(false, true);
			return true;
		}

		private void OnCloseClicked(IXUISprite iSp)
		{
			this.SetVisible(false, true);
		}

		private List<XItem> m_ItemList = null;

		private ButtonClickEventHandler m_ClickHandler = null;
	}
}
