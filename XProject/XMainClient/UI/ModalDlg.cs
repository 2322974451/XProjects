using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	public class ModalDlg : DlgBase<ModalDlg, ModalDlgBehaviour>, IModalDlg, IXInterface
	{

		public bool Deprecated { get; set; }

		public override string fileName
		{
			get
			{
				return "Common/GreyModalDlg";
			}
		}

		public override int layer
		{
			get
			{
				return 100;
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

		public ModalDlg()
		{
			int num = 0;
			for (XTempTipDefine xtempTipDefine = (XTempTipDefine)num; xtempTipDefine != XTempTipDefine.OD_END; xtempTipDefine = (XTempTipDefine)num)
			{
				this.tempTip.Add(xtempTipDefine, false);
				num++;
			}
			this._current = XTempTipDefine.OD_START;
		}

		protected override void Init()
		{
			this.SetSingleButtonMode(true);
			base.uiBehaviour.m_CloseButton.SetVisible(false);
			base.uiBehaviour.m_title.gameObject.SetActive(false);
		}

		protected override void OnShow()
		{
			base.OnShow();
			this.ShowNoTip(this.StartTip);
		}

		protected override void OnHide()
		{
			this.StartTip = XTempTipDefine.OD_START;
			base.uiBehaviour.m_lblTip.SetText(XStringDefineProxy.GetString("MODAL_NOTIP"));
			base.uiBehaviour.m_CloseButton.gameObject.SetActive(false);
			base.uiBehaviour.m_title.gameObject.SetActive(false);
			this._title = "";
			base.OnHide();
		}

		public void SetPanelDepth(int depth)
		{
			base.uiBehaviour.m_Panel.SetDepth(depth);
		}

		public void SetSingleButtonMode(bool bFlag)
		{
			float y = base.uiBehaviour.m_OKButton.gameObject.transform.localPosition.y;
			if (bFlag)
			{
				base.uiBehaviour.m_CancelButton.SetVisible(false);
				base.uiBehaviour.m_OKButton.gameObject.transform.localPosition = new Vector3(0f, y);
			}
			else
			{
				base.uiBehaviour.m_CancelButton.SetVisible(true);
				base.uiBehaviour.m_OKButton.gameObject.transform.localPosition = base.uiBehaviour.m_TwoButtonPos0.transform.localPosition;
				base.uiBehaviour.m_CancelButton.gameObject.transform.localPosition = base.uiBehaviour.m_TwoButtonPos1.transform.localPosition;
			}
		}

		public void SetCloseButtonVisible(bool visible)
		{
			base.uiBehaviour.m_CloseButton.SetVisible(visible);
		}

		public void SetTitle(string title)
		{
			this._title = title;
		}

		public void LuaShow(string content, ButtonClickEventHandler handler, ButtonClickEventHandler handler2)
		{
			this.SetVisible(true, true);
			this.SetSingleButtonMode(false);
			this.SetLabelsWithSymbols(content, "OK", "Cancel");
			base.uiBehaviour.m_OKButton.RegisterClickEventHandler(handler);
			base.uiBehaviour.m_CancelButton.RegisterClickEventHandler(handler2);
		}

		public void SetLabels(string mainLabel, string frLabel, string secLabel)
		{
			base.uiBehaviour.m_LabelSymbol.InputText = "";
			base.uiBehaviour.m_Label.SetText(mainLabel);
			base.uiBehaviour.m_OKButton.SetCaption(frLabel);
			base.uiBehaviour.m_CancelButton.SetCaption(secLabel);
		}

		public void SetLabelsWithSymbols(string mainLabel, string frLabel, string secLabel)
		{
			base.uiBehaviour.m_LabelSymbol.InputText = mainLabel;
			base.uiBehaviour.m_OKButton.SetCaption(frLabel);
			base.uiBehaviour.m_CancelButton.SetCaption(secLabel);
			base.uiBehaviour.m_title.gameObject.SetActive(!string.IsNullOrEmpty(this._title));
			base.uiBehaviour.m_title.SetText(this._title);
		}

		public void SetModalCallback(ButtonClickEventHandler handle, ButtonClickEventHandler handle2 = null)
		{
			this._bFrButtonDelegate = new ButtonClickEventHandler(this.SetTempTip);
			this._bFrButtonDelegate = (ButtonClickEventHandler)Delegate.Combine(this._bFrButtonDelegate, handle);
			base.uiBehaviour.m_OKButton.RegisterClickEventHandler(this._bFrButtonDelegate);
			this._bSecButtonDelegate = new ButtonClickEventHandler(this.SetTempTip);
			bool flag = handle2 != null;
			if (flag)
			{
				this._bSecButtonDelegate = (ButtonClickEventHandler)Delegate.Combine(this._bSecButtonDelegate, handle2);
			}
			else
			{
				this._bSecButtonDelegate = (ButtonClickEventHandler)Delegate.Combine(this._bSecButtonDelegate, new ButtonClickEventHandler(this.DoCancel));
			}
			base.uiBehaviour.m_CancelButton.RegisterClickEventHandler(this._bSecButtonDelegate);
		}

		public void SetTweenTargetAndPlay(GameObject go)
		{
			this.SetVisible(true, true);
			base.uiBehaviour.m_PlayTween.SetTargetGameObject(go);
			base.uiBehaviour.m_PlayTween.PlayTween(true, -1f);
		}

		public override void RegisterEvent()
		{
			base.uiBehaviour.m_CancelButton.RegisterClickEventHandler(new ButtonClickEventHandler(this.DoCancel));
			base.uiBehaviour.m_CloseButton.RegisterClickEventHandler(new ButtonClickEventHandler(this.DoClose));
		}

		public bool SetTempTip(IXUIButton go)
		{
			bool flag = this._current == XTempTipDefine.OD_START;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				this.tempTip[this._current] = base.uiBehaviour.m_NoTip.bChecked;
				result = true;
			}
			return result;
		}

		public void ForceSetTipsValue(XTempTipDefine type, bool state)
		{
			this.tempTip[type] = state;
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

		public bool GetTempTip(XTempTipDefine tip)
		{
			bool flag = tip == XTempTipDefine.OD_START;
			return !flag && this.tempTip[tip];
		}

		public void ShowNoTip(XTempTipDefine tip)
		{
			bool flag = tip == XTempTipDefine.OD_START;
			if (flag)
			{
				base.uiBehaviour.m_NoTip.gameObject.transform.parent.gameObject.SetActive(false);
			}
			else
			{
				bool flag2 = tip == XTempTipDefine.OD_CHAT_WORLD;
				if (flag2)
				{
					base.uiBehaviour.m_lblTip.SetText(XStringDefineProxy.GetString("MODAL_CHAT"));
				}
				else
				{
					base.uiBehaviour.m_lblTip.SetText(XStringDefineProxy.GetString("MODAL_NOTIP"));
				}
				base.uiBehaviour.m_NoTip.gameObject.transform.parent.gameObject.SetActive(true);
				base.uiBehaviour.m_NoTip.bChecked = false;
			}
			this._current = tip;
		}

		public bool _bHasGrey = true;

		private ButtonClickEventHandler _bFrButtonDelegate = null;

		private ButtonClickEventHandler _bSecButtonDelegate = null;

		private Dictionary<XTempTipDefine, bool> tempTip = new Dictionary<XTempTipDefine, bool>(default(XFastEnumIntEqualityComparer<XTempTipDefine>));

		private XTempTipDefine _current;

		private string _title = "";

		public XTempTipDefine StartTip = XTempTipDefine.OD_START;
	}
}
