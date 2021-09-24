using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient.UI
{

	public class ModalThreeDlg : DlgBase<ModalThreeDlg, ModalThreeDlgBehaviour>
	{

		public bool Deprecated { get; set; }

		public override string fileName
		{
			get
			{
				return "Common/ThreeChoiceModalDlg";
			}
		}

		public override int layer
		{
			get
			{
				return 90;
			}
		}

		public override bool isHideChat
		{
			get
			{
				return false;
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

		protected override void OnShow()
		{
			base.OnShow();
		}

		protected override void OnHide()
		{
			base.OnHide();
		}

		public void SetPanelDepth(int depth)
		{
			base.uiBehaviour.m_Panel.SetDepth(depth);
		}

		public void SetCloseButtonVisible(bool visible)
		{
			base.uiBehaviour.m_CloseButton.SetVisible(visible);
		}

		public void SetLabels(string mainLabel, string frLabel, string secLabel, string thdLabel)
		{
			base.uiBehaviour.m_LabelSymbol.InputText = "";
			base.uiBehaviour.m_Label.SetText(mainLabel);
			base.uiBehaviour.m_Button1.SetCaption(frLabel);
			base.uiBehaviour.m_Button2.SetCaption(secLabel);
			base.uiBehaviour.m_Button3.SetCaption(thdLabel);
		}

		public void SetLabelsWithSymbols(string mainLabel, string frLabel, string secLabel, string thdLabel)
		{
			base.uiBehaviour.m_LabelSymbol.InputText = mainLabel;
			base.uiBehaviour.m_Button1.SetCaption(frLabel);
			base.uiBehaviour.m_Button2.SetCaption(secLabel);
			base.uiBehaviour.m_Button3.SetCaption(thdLabel);
		}

		public void SetMainLabel(string mainlabel)
		{
			base.uiBehaviour.m_LabelSymbol.InputText = mainlabel;
		}

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

		public void SetTweenTargetAndPlay(GameObject go)
		{
			this.SetVisible(true, true);
		}

		public override void RegisterEvent()
		{
			base.uiBehaviour.m_CloseButton.RegisterClickEventHandler(new ButtonClickEventHandler(this.DoClose));
		}

		public bool DoCancel(IXUIButton go)
		{
			this.SetVisible(false, true);
			return true;
		}

		public void DoCancel(IXUISprite sp)
		{
			this.SetVisible(false, true);
		}

		public bool DoClose(IXUIButton go)
		{
			this.SetVisible(false, true);
			return true;
		}

		private ButtonClickEventHandler _bFrButtonDelegate = null;

		private ButtonClickEventHandler _bSecButtonDelegate = null;

		private ButtonClickEventHandler _bTrdButtonDelegate = null;
	}
}
