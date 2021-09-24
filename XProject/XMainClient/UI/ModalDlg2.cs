using System;
using UILib;
using XMainClient.UI.UICommon;

namespace XMainClient.UI
{

	public class ModalDlg2 : DlgBase<ModalDlg2, ModalDlg2Behaviour>
	{

		public override string fileName
		{
			get
			{
				return "Common/GreyModalDlg2";
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

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseBtnClick));
			base.uiBehaviour.m_Select1.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnSelect1BtnClick));
			base.uiBehaviour.m_Select2.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnSelect2BtnClick));
		}

		public bool OnCloseBtnClick(IXUIButton btn)
		{
			this.SetVisible(false, true);
			return true;
		}

		public bool OnSelect1BtnClick(IXUIButton btn)
		{
			this._bFrButtonDelegate(base.uiBehaviour.m_Select1);
			this.SetVisible(false, true);
			return true;
		}

		public bool OnSelect2BtnClick(IXUIButton btn)
		{
			this._bSecButtonDelegate(base.uiBehaviour.m_Select2);
			this.SetVisible(false, true);
			return true;
		}

		public void SetBtnMsg(IXUIButton btn, string price, string label)
		{
			IXUILabelSymbol ixuilabelSymbol = btn.gameObject.transform.FindChild("Price").GetComponent("XUILabelSymbol") as IXUILabelSymbol;
			IXUILabel ixuilabel = btn.gameObject.transform.FindChild("Label").GetComponent("XUILabel") as IXUILabel;
			ixuilabelSymbol.InputText = price;
			ixuilabel.SetText(label);
		}

		public void InitShow(string text, ButtonClickEventHandler func1, ButtonClickEventHandler func2, string price1, string price2, string btnLabel1, string btnLabel2)
		{
			this.SetVisible(true, true);
			this.SetBtnMsg(base.uiBehaviour.m_Select1, price1, btnLabel1);
			this.SetBtnMsg(base.uiBehaviour.m_Select2, price2, btnLabel2);
			base.uiBehaviour.m_Text.InputText = text;
			this._bFrButtonDelegate = func1;
			this._bSecButtonDelegate = func2;
		}

		private ButtonClickEventHandler _bFrButtonDelegate = null;

		private ButtonClickEventHandler _bSecButtonDelegate = null;
	}
}
