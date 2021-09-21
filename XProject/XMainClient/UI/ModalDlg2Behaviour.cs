using System;
using UILib;
using XMainClient.UI.UICommon;

namespace XMainClient.UI
{
	// Token: 0x0200186D RID: 6253
	public class ModalDlg2Behaviour : DlgBehaviourBase
	{
		// Token: 0x06010472 RID: 66674 RVA: 0x003F0798 File Offset: 0x003EE998
		private void Awake()
		{
			this.m_Close = (base.transform.FindChild("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_Text = (base.transform.FindChild("Bg/Label").GetComponent("XUILabelSymbol") as IXUILabelSymbol);
			this.m_Select1 = (base.transform.FindChild("Bg/Select1").GetComponent("XUIButton") as IXUIButton);
			this.m_Select2 = (base.transform.FindChild("Bg/Select2").GetComponent("XUIButton") as IXUIButton);
		}

		// Token: 0x04007510 RID: 29968
		public IXUIButton m_Close;

		// Token: 0x04007511 RID: 29969
		public IXUILabelSymbol m_Text;

		// Token: 0x04007512 RID: 29970
		public IXUIButton m_Select1;

		// Token: 0x04007513 RID: 29971
		public IXUIButton m_Select2;
	}
}
