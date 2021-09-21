using System;
using UILib;
using XMainClient.UI.UICommon;

namespace XMainClient.UI
{
	// Token: 0x020017EC RID: 6124
	internal class XGameSirBehaviour : DlgBehaviourBase
	{
		// Token: 0x0600FDD8 RID: 64984 RVA: 0x003B92C4 File Offset: 0x003B74C4
		private void Awake()
		{
			this.m_ConnectBtn = (base.transform.FindChild("Bg/Connect").GetComponent("XUIButton") as IXUIButton);
			this.m_ShowKeyBtn = (base.transform.FindChild("Bg/Show").GetComponent("XUIButton") as IXUIButton);
			this.m_ConntectStatus = (base.transform.FindChild("Bg/Connect/Label").GetComponent("XUILabel") as IXUILabel);
			this.m_CloseBtn = (base.transform.FindChild("Bg/Close").GetComponent("XUIButton") as IXUIButton);
		}

		// Token: 0x0400700C RID: 28684
		public IXUIButton m_ConnectBtn;

		// Token: 0x0400700D RID: 28685
		public IXUILabel m_ConntectStatus;

		// Token: 0x0400700E RID: 28686
		public IXUIButton m_ShowKeyBtn;

		// Token: 0x0400700F RID: 28687
		public IXUIButton m_CloseBtn;
	}
}
