using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x020018CD RID: 6349
	internal class ItemUseListDlg : DlgBase<ItemUseListDlg, ItemUseListDlgBehaviour>
	{
		// Token: 0x17003A5F RID: 14943
		// (get) Token: 0x060108D0 RID: 67792 RVA: 0x004113EC File Offset: 0x0040F5EC
		public override string fileName
		{
			get
			{
				return "Hall/ShapeshiftDlg";
			}
		}

		// Token: 0x17003A60 RID: 14944
		// (get) Token: 0x060108D1 RID: 67793 RVA: 0x00411404 File Offset: 0x0040F604
		public override int layer
		{
			get
			{
				return 100;
			}
		}

		// Token: 0x17003A61 RID: 14945
		// (get) Token: 0x060108D2 RID: 67794 RVA: 0x00411418 File Offset: 0x0040F618
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x060108D3 RID: 67795 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		protected override void Init()
		{
		}

		// Token: 0x060108D4 RID: 67796 RVA: 0x0041142B File Offset: 0x0040F62B
		public override void RegisterEvent()
		{
			base.uiBehaviour.m_Close.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnCloseClicked));
			base.uiBehaviour.m_WrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.OnWrapContentUpdated));
		}

		// Token: 0x060108D5 RID: 67797 RVA: 0x00411468 File Offset: 0x0040F668
		public void SetTitle(string text)
		{
			base.uiBehaviour.m_Title.SetText(text);
		}

		// Token: 0x060108D6 RID: 67798 RVA: 0x00411480 File Offset: 0x0040F680
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

		// Token: 0x060108D7 RID: 67799 RVA: 0x004114B0 File Offset: 0x0040F6B0
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

		// Token: 0x060108D8 RID: 67800 RVA: 0x00411500 File Offset: 0x0040F700
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

		// Token: 0x060108D9 RID: 67801 RVA: 0x00411598 File Offset: 0x0040F798
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

		// Token: 0x060108DA RID: 67802 RVA: 0x004115CE File Offset: 0x0040F7CE
		private void OnCloseClicked(IXUISprite iSp)
		{
			this.SetVisible(false, true);
		}

		// Token: 0x040077E4 RID: 30692
		private List<XItem> m_ItemList = null;

		// Token: 0x040077E5 RID: 30693
		private ButtonClickEventHandler m_ClickHandler = null;
	}
}
