using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;

namespace XMainClient
{
	// Token: 0x02000E79 RID: 3705
	internal class XTitleBar : DlgHandlerBase
	{
		// Token: 0x0600C65C RID: 50780 RVA: 0x002BE78C File Offset: 0x002BC98C
		protected override void Init()
		{
			base.Init();
			for (int i = 0; i <= 20; i++)
			{
				Transform transform = base.PanelObject.transform.FindChild("Title" + i);
				bool flag = transform == null;
				if (!flag)
				{
					IXUILabel ixuilabel = transform.GetComponent("XUILabel") as IXUILabel;
					ixuilabel.ID = (ulong)((long)i);
					this.m_TitleButtons.Add(ixuilabel);
				}
			}
			this.m_SortArrow = base.PanelObject.transform.FindChild("Sort");
			this.m_SortArrowDir = this.m_SortArrow.FindChild("Arrow");
		}

		// Token: 0x0600C65D RID: 50781 RVA: 0x002BE840 File Offset: 0x002BCA40
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			for (int i = 0; i < this.m_TitleButtons.Count; i++)
			{
				IXUIButton ixuibutton = this.m_TitleButtons[i].gameObject.transform.FindChild("Button").GetComponent("XUIButton") as IXUIButton;
				bool flag = ixuibutton == null;
				if (!flag)
				{
					ixuibutton.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnTitleClicked));
				}
			}
		}

		// Token: 0x0600C65E RID: 50782 RVA: 0x002BE8BE File Offset: 0x002BCABE
		public void RegisterClickEventHandler(TitleClickEventHandler handler)
		{
			this.m_TitleClickEventHandler = handler;
		}

		// Token: 0x0600C65F RID: 50783 RVA: 0x002BE8C8 File Offset: 0x002BCAC8
		public void Refresh(ulong selectedID)
		{
			IXUILabel title = null;
			for (int i = 0; i < this.m_TitleButtons.Count; i++)
			{
				bool flag = this.m_TitleButtons[i].ID == selectedID;
				if (flag)
				{
					title = this.m_TitleButtons[i];
					break;
				}
			}
			this._SetTitleSelect(title);
		}

		// Token: 0x0600C660 RID: 50784 RVA: 0x002BE924 File Offset: 0x002BCB24
		private bool _OnTitleClicked(IXUIButton btn)
		{
			IXUILabel ixuilabel = btn.gameObject.transform.parent.GetComponent("XUILabel") as IXUILabel;
			this._SetTitleSelect(ixuilabel);
			bool flag = this.m_TitleClickEventHandler != null;
			if (flag)
			{
				this.SetArrowDir(this.m_TitleClickEventHandler(ixuilabel.ID));
			}
			return true;
		}

		// Token: 0x0600C661 RID: 50785 RVA: 0x002BE984 File Offset: 0x002BCB84
		private void _SetTitleSelect(IXUILabel title)
		{
			this._SetSortArrow(title);
		}

		// Token: 0x0600C662 RID: 50786 RVA: 0x002BE990 File Offset: 0x002BCB90
		private void _SetSortArrow(IXUILabel title)
		{
			bool flag = title != null;
			if (flag)
			{
				this.m_SortArrow.gameObject.SetActive(true);
				this.m_SortArrow.parent = title.gameObject.transform;
				this.m_SortArrow.localPosition = new Vector3((float)(title.spriteWidth / 2), 0f);
			}
			else
			{
				this.m_SortArrow.gameObject.SetActive(false);
			}
		}

		// Token: 0x0600C663 RID: 50787 RVA: 0x002BEA06 File Offset: 0x002BCC06
		public void SetArrowDir(bool bDirUp)
		{
			this.m_SortArrowDir.localRotation = Quaternion.Euler(0f, 0f, (float)(bDirUp ? -90 : 90));
		}

		// Token: 0x04005706 RID: 22278
		private List<IXUILabel> m_TitleButtons = new List<IXUILabel>();

		// Token: 0x04005707 RID: 22279
		private Transform m_SortArrow;

		// Token: 0x04005708 RID: 22280
		private Transform m_SortArrowDir;

		// Token: 0x04005709 RID: 22281
		private TitleClickEventHandler m_TitleClickEventHandler;
	}
}
