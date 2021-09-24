using System;
using UILib;
using XMainClient.UI.UICommon;

namespace XMainClient.UI
{

	internal class XGameSirBehaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			this.m_ConnectBtn = (base.transform.FindChild("Bg/Connect").GetComponent("XUIButton") as IXUIButton);
			this.m_ShowKeyBtn = (base.transform.FindChild("Bg/Show").GetComponent("XUIButton") as IXUIButton);
			this.m_ConntectStatus = (base.transform.FindChild("Bg/Connect/Label").GetComponent("XUILabel") as IXUILabel);
			this.m_CloseBtn = (base.transform.FindChild("Bg/Close").GetComponent("XUIButton") as IXUIButton);
		}

		public IXUIButton m_ConnectBtn;

		public IXUILabel m_ConntectStatus;

		public IXUIButton m_ShowKeyBtn;

		public IXUIButton m_CloseBtn;
	}
}
