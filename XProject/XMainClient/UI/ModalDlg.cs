using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x02001924 RID: 6436
	public class ModalDlg : DlgBase<ModalDlg, ModalDlgBehaviour>, IModalDlg, IXInterface
	{
		// Token: 0x17003B00 RID: 15104
		// (get) Token: 0x06010DA2 RID: 69026 RVA: 0x00442EE8 File Offset: 0x004410E8
		// (set) Token: 0x06010DA3 RID: 69027 RVA: 0x00442EF0 File Offset: 0x004410F0
		public bool Deprecated { get; set; }

		// Token: 0x17003B01 RID: 15105
		// (get) Token: 0x06010DA4 RID: 69028 RVA: 0x00442EFC File Offset: 0x004410FC
		public override string fileName
		{
			get
			{
				return "Common/GreyModalDlg";
			}
		}

		// Token: 0x17003B02 RID: 15106
		// (get) Token: 0x06010DA5 RID: 69029 RVA: 0x00442F14 File Offset: 0x00441114
		public override int layer
		{
			get
			{
				return 100;
			}
		}

		// Token: 0x17003B03 RID: 15107
		// (get) Token: 0x06010DA6 RID: 69030 RVA: 0x00442F28 File Offset: 0x00441128
		public override bool isHideChat
		{
			get
			{
				return false;
			}
		}

		// Token: 0x17003B04 RID: 15108
		// (get) Token: 0x06010DA7 RID: 69031 RVA: 0x00442F3C File Offset: 0x0044113C
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x06010DA8 RID: 69032 RVA: 0x00442F50 File Offset: 0x00441150
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

		// Token: 0x06010DA9 RID: 69033 RVA: 0x00442FD4 File Offset: 0x004411D4
		protected override void Init()
		{
			this.SetSingleButtonMode(true);
			base.uiBehaviour.m_CloseButton.SetVisible(false);
			base.uiBehaviour.m_title.gameObject.SetActive(false);
		}

		// Token: 0x06010DAA RID: 69034 RVA: 0x00443008 File Offset: 0x00441208
		protected override void OnShow()
		{
			base.OnShow();
			this.ShowNoTip(this.StartTip);
		}

		// Token: 0x06010DAB RID: 69035 RVA: 0x00443020 File Offset: 0x00441220
		protected override void OnHide()
		{
			this.StartTip = XTempTipDefine.OD_START;
			base.uiBehaviour.m_lblTip.SetText(XStringDefineProxy.GetString("MODAL_NOTIP"));
			base.uiBehaviour.m_CloseButton.gameObject.SetActive(false);
			base.uiBehaviour.m_title.gameObject.SetActive(false);
			this._title = "";
			base.OnHide();
		}

		// Token: 0x06010DAC RID: 69036 RVA: 0x00443090 File Offset: 0x00441290
		public void SetPanelDepth(int depth)
		{
			base.uiBehaviour.m_Panel.SetDepth(depth);
		}

		// Token: 0x06010DAD RID: 69037 RVA: 0x004430A8 File Offset: 0x004412A8
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

		// Token: 0x06010DAE RID: 69038 RVA: 0x0044318B File Offset: 0x0044138B
		public void SetCloseButtonVisible(bool visible)
		{
			base.uiBehaviour.m_CloseButton.SetVisible(visible);
		}

		// Token: 0x06010DAF RID: 69039 RVA: 0x004431A0 File Offset: 0x004413A0
		public void SetTitle(string title)
		{
			this._title = title;
		}

		// Token: 0x06010DB0 RID: 69040 RVA: 0x004431AC File Offset: 0x004413AC
		public void LuaShow(string content, ButtonClickEventHandler handler, ButtonClickEventHandler handler2)
		{
			this.SetVisible(true, true);
			this.SetSingleButtonMode(false);
			this.SetLabelsWithSymbols(content, "OK", "Cancel");
			base.uiBehaviour.m_OKButton.RegisterClickEventHandler(handler);
			base.uiBehaviour.m_CancelButton.RegisterClickEventHandler(handler2);
		}

		// Token: 0x06010DB1 RID: 69041 RVA: 0x00443204 File Offset: 0x00441404
		public void SetLabels(string mainLabel, string frLabel, string secLabel)
		{
			base.uiBehaviour.m_LabelSymbol.InputText = "";
			base.uiBehaviour.m_Label.SetText(mainLabel);
			base.uiBehaviour.m_OKButton.SetCaption(frLabel);
			base.uiBehaviour.m_CancelButton.SetCaption(secLabel);
		}

		// Token: 0x06010DB2 RID: 69042 RVA: 0x00443260 File Offset: 0x00441460
		public void SetLabelsWithSymbols(string mainLabel, string frLabel, string secLabel)
		{
			base.uiBehaviour.m_LabelSymbol.InputText = mainLabel;
			base.uiBehaviour.m_OKButton.SetCaption(frLabel);
			base.uiBehaviour.m_CancelButton.SetCaption(secLabel);
			base.uiBehaviour.m_title.gameObject.SetActive(!string.IsNullOrEmpty(this._title));
			base.uiBehaviour.m_title.SetText(this._title);
		}

		// Token: 0x06010DB3 RID: 69043 RVA: 0x004432E0 File Offset: 0x004414E0
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

		// Token: 0x06010DB4 RID: 69044 RVA: 0x0044339E File Offset: 0x0044159E
		public void SetTweenTargetAndPlay(GameObject go)
		{
			this.SetVisible(true, true);
			base.uiBehaviour.m_PlayTween.SetTargetGameObject(go);
			base.uiBehaviour.m_PlayTween.PlayTween(true, -1f);
		}

		// Token: 0x06010DB5 RID: 69045 RVA: 0x004433D3 File Offset: 0x004415D3
		public override void RegisterEvent()
		{
			base.uiBehaviour.m_CancelButton.RegisterClickEventHandler(new ButtonClickEventHandler(this.DoCancel));
			base.uiBehaviour.m_CloseButton.RegisterClickEventHandler(new ButtonClickEventHandler(this.DoClose));
		}

		// Token: 0x06010DB6 RID: 69046 RVA: 0x00443410 File Offset: 0x00441610
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

		// Token: 0x06010DB7 RID: 69047 RVA: 0x00443456 File Offset: 0x00441656
		public void ForceSetTipsValue(XTempTipDefine type, bool state)
		{
			this.tempTip[type] = state;
		}

		// Token: 0x06010DB8 RID: 69048 RVA: 0x00443468 File Offset: 0x00441668
		public bool DoCancel(IXUIButton go)
		{
			this.SetVisible(false, true);
			return true;
		}

		// Token: 0x06010DB9 RID: 69049 RVA: 0x00443484 File Offset: 0x00441684
		public void DoCancel(IXUISprite sp)
		{
			this.SetVisible(false, true);
		}

		// Token: 0x06010DBA RID: 69050 RVA: 0x00443490 File Offset: 0x00441690
		public bool DoClose(IXUIButton go)
		{
			this.SetVisible(false, true);
			return true;
		}

		// Token: 0x06010DBB RID: 69051 RVA: 0x004434AC File Offset: 0x004416AC
		public bool GetTempTip(XTempTipDefine tip)
		{
			bool flag = tip == XTempTipDefine.OD_START;
			return !flag && this.tempTip[tip];
		}

		// Token: 0x06010DBC RID: 69052 RVA: 0x004434D8 File Offset: 0x004416D8
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

		// Token: 0x04007C0C RID: 31756
		public bool _bHasGrey = true;

		// Token: 0x04007C0D RID: 31757
		private ButtonClickEventHandler _bFrButtonDelegate = null;

		// Token: 0x04007C0E RID: 31758
		private ButtonClickEventHandler _bSecButtonDelegate = null;

		// Token: 0x04007C0F RID: 31759
		private Dictionary<XTempTipDefine, bool> tempTip = new Dictionary<XTempTipDefine, bool>(default(XFastEnumIntEqualityComparer<XTempTipDefine>));

		// Token: 0x04007C10 RID: 31760
		private XTempTipDefine _current;

		// Token: 0x04007C11 RID: 31761
		private string _title = "";

		// Token: 0x04007C12 RID: 31762
		public XTempTipDefine StartTip = XTempTipDefine.OD_START;
	}
}
