using System;
using UILib;
using XMainClient.UI.UICommon;

namespace XMainClient.UI
{
	// Token: 0x020018A1 RID: 6305
	internal class XGuildPortraitView : DlgBase<XGuildPortraitView, XGuildPortraitBehaviour>
	{
		// Token: 0x170039FC RID: 14844
		// (get) Token: 0x0601069C RID: 67228 RVA: 0x00401A80 File Offset: 0x003FFC80
		public int PortraitIndex
		{
			get
			{
				return this.m_SelectedIndex;
			}
		}

		// Token: 0x170039FD RID: 14845
		// (get) Token: 0x0601069D RID: 67229 RVA: 0x00401A98 File Offset: 0x003FFC98
		public override string fileName
		{
			get
			{
				return "Guild/GuildPortraitDlg";
			}
		}

		// Token: 0x170039FE RID: 14846
		// (get) Token: 0x0601069E RID: 67230 RVA: 0x00401AB0 File Offset: 0x003FFCB0
		public override int layer
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x170039FF RID: 14847
		// (get) Token: 0x0601069F RID: 67231 RVA: 0x00401AC4 File Offset: 0x003FFCC4
		public override int group
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x17003A00 RID: 14848
		// (get) Token: 0x060106A0 RID: 67232 RVA: 0x00401AD8 File Offset: 0x003FFCD8
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17003A01 RID: 14849
		// (get) Token: 0x060106A1 RID: 67233 RVA: 0x00401AEC File Offset: 0x003FFCEC
		public override bool pushstack
		{
			get
			{
				return true;
			}
		}

		// Token: 0x060106A2 RID: 67234 RVA: 0x00401B00 File Offset: 0x003FFD00
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

		// Token: 0x060106A3 RID: 67235 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		protected override void OnUnload()
		{
		}

		// Token: 0x060106A4 RID: 67236 RVA: 0x00401B84 File Offset: 0x003FFD84
		public override void RegisterEvent()
		{
			base.uiBehaviour.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnCloseBtnClick));
			base.uiBehaviour.m_BtnOK.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnOKBtnClick));
			for (int i = 0; i < XGuildPortraitView.PORTRAIT_COUNT; i++)
			{
				this.m_Portraits[i].RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this._OnPortraitClick));
			}
		}

		// Token: 0x060106A5 RID: 67237 RVA: 0x00401BFC File Offset: 0x003FFDFC
		protected override void OnShow()
		{
			bool flag = this.m_SelectedIndex >= 0 && this.m_SelectedIndex < XGuildPortraitView.PORTRAIT_COUNT;
			if (flag)
			{
				this.m_Portraits[this.m_SelectedIndex].bChecked = true;
			}
		}

		// Token: 0x060106A6 RID: 67238 RVA: 0x00401C3D File Offset: 0x003FFE3D
		protected override void OnHide()
		{
			base.OnHide();
			this._OKButtonHandler = null;
		}

		// Token: 0x060106A7 RID: 67239 RVA: 0x00401C4E File Offset: 0x003FFE4E
		public void Open(int index, ButtonClickEventHandler OKButtonHandler)
		{
			this.m_SelectedIndex = index;
			this._OKButtonHandler = OKButtonHandler;
			this.SetVisibleWithAnimation(true, null);
		}

		// Token: 0x060106A8 RID: 67240 RVA: 0x00401C68 File Offset: 0x003FFE68
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

		// Token: 0x060106A9 RID: 67241 RVA: 0x00401CB0 File Offset: 0x003FFEB0
		private bool _OnCloseBtnClick(IXUIButton go)
		{
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

		// Token: 0x060106AA RID: 67242 RVA: 0x00401CCC File Offset: 0x003FFECC
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

		// Token: 0x0400768A RID: 30346
		public static readonly int PORTRAIT_COUNT = 10;

		// Token: 0x0400768B RID: 30347
		public static readonly int COL_COUNT = 5;

		// Token: 0x0400768C RID: 30348
		private ButtonClickEventHandler _OKButtonHandler = null;

		// Token: 0x0400768D RID: 30349
		private int m_SelectedIndex = 0;

		// Token: 0x0400768E RID: 30350
		private IXUICheckBox[] m_Portraits = new IXUICheckBox[XGuildPortraitView.PORTRAIT_COUNT];
	}
}
