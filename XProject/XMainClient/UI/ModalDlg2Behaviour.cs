using System;
using UILib;
using XMainClient.UI.UICommon;

namespace XMainClient.UI
{

	public class ModalDlg2Behaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			this.m_Close = (base.transform.FindChild("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_Text = (base.transform.FindChild("Bg/Label").GetComponent("XUILabelSymbol") as IXUILabelSymbol);
			this.m_Select1 = (base.transform.FindChild("Bg/Select1").GetComponent("XUIButton") as IXUIButton);
			this.m_Select2 = (base.transform.FindChild("Bg/Select2").GetComponent("XUIButton") as IXUIButton);
		}

		public IXUIButton m_Close;

		public IXUILabelSymbol m_Text;

		public IXUIButton m_Select1;

		public IXUIButton m_Select2;
	}
}
