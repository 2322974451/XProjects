using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient.UI
{
	// Token: 0x02001871 RID: 6257
	public class ModalThreeDlg : DlgBase<ModalThreeDlg, ModalThreeDlgBehaviour>
	{
		// Token: 0x170039B6 RID: 14774
		// (get) Token: 0x06010495 RID: 66709 RVA: 0x003F0EA3 File Offset: 0x003EF0A3
		// (set) Token: 0x06010496 RID: 66710 RVA: 0x003F0EAB File Offset: 0x003EF0AB
		public bool Deprecated { get; set; }

		// Token: 0x170039B7 RID: 14775
		// (get) Token: 0x06010497 RID: 66711 RVA: 0x003F0EB4 File Offset: 0x003EF0B4
		public override string fileName
		{
			get
			{
				return "Common/ThreeChoiceModalDlg";
			}
		}

		// Token: 0x170039B8 RID: 14776
		// (get) Token: 0x06010498 RID: 66712 RVA: 0x003F0ECC File Offset: 0x003EF0CC
		public override int layer
		{
			get
			{
				return 90;
			}
		}

		// Token: 0x170039B9 RID: 14777
		// (get) Token: 0x06010499 RID: 66713 RVA: 0x003F0EE0 File Offset: 0x003EF0E0
		public override bool isHideChat
		{
			get
			{
				return false;
			}
		}

		// Token: 0x170039BA RID: 14778
		// (get) Token: 0x0601049A RID: 66714 RVA: 0x003F0EF4 File Offset: 0x003EF0F4
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x0601049B RID: 66715 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		protected override void Init()
		{
		}

		// Token: 0x0601049C RID: 66716 RVA: 0x003F0F07 File Offset: 0x003EF107
		protected override void OnShow()
		{
			base.OnShow();
		}

		// Token: 0x0601049D RID: 66717 RVA: 0x003F0F11 File Offset: 0x003EF111
		protected override void OnHide()
		{
			base.OnHide();
		}

		// Token: 0x0601049E RID: 66718 RVA: 0x003F0F1B File Offset: 0x003EF11B
		public void SetPanelDepth(int depth)
		{
			base.uiBehaviour.m_Panel.SetDepth(depth);
		}

		// Token: 0x0601049F RID: 66719 RVA: 0x003F0F30 File Offset: 0x003EF130
		public void SetCloseButtonVisible(bool visible)
		{
			base.uiBehaviour.m_CloseButton.SetVisible(visible);
		}

		// Token: 0x060104A0 RID: 66720 RVA: 0x003F0F48 File Offset: 0x003EF148
		public void SetLabels(string mainLabel, string frLabel, string secLabel, string thdLabel)
		{
			base.uiBehaviour.m_LabelSymbol.InputText = "";
			base.uiBehaviour.m_Label.SetText(mainLabel);
			base.uiBehaviour.m_Button1.SetCaption(frLabel);
			base.uiBehaviour.m_Button2.SetCaption(secLabel);
			base.uiBehaviour.m_Button3.SetCaption(thdLabel);
		}

		// Token: 0x060104A1 RID: 66721 RVA: 0x003F0FB8 File Offset: 0x003EF1B8
		public void SetLabelsWithSymbols(string mainLabel, string frLabel, string secLabel, string thdLabel)
		{
			base.uiBehaviour.m_LabelSymbol.InputText = mainLabel;
			base.uiBehaviour.m_Button1.SetCaption(frLabel);
			base.uiBehaviour.m_Button2.SetCaption(secLabel);
			base.uiBehaviour.m_Button3.SetCaption(thdLabel);
		}

		// Token: 0x060104A2 RID: 66722 RVA: 0x003F100F File Offset: 0x003EF20F
		public void SetMainLabel(string mainlabel)
		{
			base.uiBehaviour.m_LabelSymbol.InputText = mainlabel;
		}

		// Token: 0x060104A3 RID: 66723 RVA: 0x003F1024 File Offset: 0x003EF224
		public void SetModalCallback(ButtonClickEventHandler handle, ButtonClickEventHandler handle2 = null, ButtonClickEventHandler handle3 = null)
		{
			this._bFrButtonDelegate = new ButtonClickEventHandler(this.DoCancel);
			bool flag = handle != null;
			if (flag)
			{
				this._bFrButtonDelegate = handle;
			}
			base.uiBehaviour.m_Button1.RegisterClickEventHandler(this._bFrButtonDelegate);
			this._bSecButtonDelegate = new ButtonClickEventHandler(this.DoCancel);
			bool flag2 = handle2 != null;
			if (flag2)
			{
				this._bSecButtonDelegate = handle2;
			}
			base.uiBehaviour.m_Button2.RegisterClickEventHandler(this._bSecButtonDelegate);
			this._bTrdButtonDelegate = new ButtonClickEventHandler(this.DoCancel);
			bool flag3 = handle3 != null;
			if (flag3)
			{
				this._bTrdButtonDelegate = handle3;
			}
			base.uiBehaviour.m_Button3.RegisterClickEventHandler(this._bTrdButtonDelegate);
		}

		// Token: 0x060104A4 RID: 66724 RVA: 0x003F10DA File Offset: 0x003EF2DA
		public void SetTweenTargetAndPlay(GameObject go)
		{
			this.SetVisible(true, true);
		}

		// Token: 0x060104A5 RID: 66725 RVA: 0x003F10E6 File Offset: 0x003EF2E6
		public override void RegisterEvent()
		{
			base.uiBehaviour.m_CloseButton.RegisterClickEventHandler(new ButtonClickEventHandler(this.DoClose));
		}

		// Token: 0x060104A6 RID: 66726 RVA: 0x003F1108 File Offset: 0x003EF308
		public bool DoCancel(IXUIButton go)
		{
			this.SetVisible(false, true);
			return true;
		}

		// Token: 0x060104A7 RID: 66727 RVA: 0x003F1124 File Offset: 0x003EF324
		public void DoCancel(IXUISprite sp)
		{
			this.SetVisible(false, true);
		}

		// Token: 0x060104A8 RID: 66728 RVA: 0x003F1130 File Offset: 0x003EF330
		public bool DoClose(IXUIButton go)
		{
			this.SetVisible(false, true);
			return true;
		}

		// Token: 0x04007524 RID: 29988
		private ButtonClickEventHandler _bFrButtonDelegate = null;

		// Token: 0x04007525 RID: 29989
		private ButtonClickEventHandler _bSecButtonDelegate = null;

		// Token: 0x04007526 RID: 29990
		private ButtonClickEventHandler _bTrdButtonDelegate = null;
	}
}
