using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;

namespace XMainClient
{

	internal class XTitleBar : DlgHandlerBase
	{

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

		public void RegisterClickEventHandler(TitleClickEventHandler handler)
		{
			this.m_TitleClickEventHandler = handler;
		}

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

		private void _SetTitleSelect(IXUILabel title)
		{
			this._SetSortArrow(title);
		}

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

		public void SetArrowDir(bool bDirUp)
		{
			this.m_SortArrowDir.localRotation = Quaternion.Euler(0f, 0f, (float)(bDirUp ? -90 : 90));
		}

		private List<IXUILabel> m_TitleButtons = new List<IXUILabel>();

		private Transform m_SortArrow;

		private Transform m_SortArrowDir;

		private TitleClickEventHandler m_TitleClickEventHandler;
	}
}
