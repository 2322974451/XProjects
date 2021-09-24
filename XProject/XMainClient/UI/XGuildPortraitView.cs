using System;
using UILib;
using XMainClient.UI.UICommon;

namespace XMainClient.UI
{

	internal class XGuildPortraitView : DlgBase<XGuildPortraitView, XGuildPortraitBehaviour>
	{

		public int PortraitIndex
		{
			get
			{
				return this.m_SelectedIndex;
			}
		}

		public override string fileName
		{
			get
			{
				return "Guild/GuildPortraitDlg";
			}
		}

		public override int layer
		{
			get
			{
				return 1;
			}
		}

		public override int group
		{
			get
			{
				return 1;
			}
		}

		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		public override bool pushstack
		{
			get
			{
				return true;
			}
		}

		protected override void Init()
		{
			for (int i = 0; i < XGuildPortraitView.PORTRAIT_COUNT; i++)
			{
				IXUISprite ixuisprite = base.uiBehaviour.m_PortraitList[i].GetComponent("XUISprite") as IXUISprite;
				ixuisprite.SetSprite(XGuildDocument.GetPortraitName(i));
				this.m_Portraits[i] = (base.uiBehaviour.m_PortraitList[i].GetComponent("XUICheckBox") as IXUICheckBox);
				this.m_Portraits[i].ID = (ulong)((long)i);
			}
		}

		protected override void OnUnload()
		{
		}

		public override void RegisterEvent()
		{
			base.uiBehaviour.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnCloseBtnClick));
			base.uiBehaviour.m_BtnOK.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnOKBtnClick));
			for (int i = 0; i < XGuildPortraitView.PORTRAIT_COUNT; i++)
			{
				this.m_Portraits[i].RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this._OnPortraitClick));
			}
		}

		protected override void OnShow()
		{
			bool flag = this.m_SelectedIndex >= 0 && this.m_SelectedIndex < XGuildPortraitView.PORTRAIT_COUNT;
			if (flag)
			{
				this.m_Portraits[this.m_SelectedIndex].bChecked = true;
			}
		}

		protected override void OnHide()
		{
			base.OnHide();
			this._OKButtonHandler = null;
		}

		public void Open(int index, ButtonClickEventHandler OKButtonHandler)
		{
			this.m_SelectedIndex = index;
			this._OKButtonHandler = OKButtonHandler;
			this.SetVisibleWithAnimation(true, null);
		}

		private bool _OnPortraitClick(IXUICheckBox iXUICheckBox)
		{
			int num = (int)iXUICheckBox.ID;
			base.uiBehaviour.m_SelectorList[num].SetActive(iXUICheckBox.bChecked);
			bool bChecked = iXUICheckBox.bChecked;
			if (bChecked)
			{
				this.m_SelectedIndex = num;
			}
			return true;
		}

		private bool _OnCloseBtnClick(IXUIButton go)
		{
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

		private bool _OnOKBtnClick(IXUIButton btn)
		{
			bool flag = this._OKButtonHandler != null;
			if (flag)
			{
				this._OKButtonHandler(btn);
			}
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

		public static readonly int PORTRAIT_COUNT = 10;

		public static readonly int COL_COUNT = 5;

		private ButtonClickEventHandler _OKButtonHandler = null;

		private int m_SelectedIndex = 0;

		private IXUICheckBox[] m_Portraits = new IXUICheckBox[XGuildPortraitView.PORTRAIT_COUNT];
	}
}
