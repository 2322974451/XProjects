using System;
using UILib;
using XMainClient.UI.UICommon;

namespace XMainClient
{
	// Token: 0x02000B8E RID: 2958
	internal class XAnnouncementBehaviour : DlgBehaviourBase
	{
		// Token: 0x0600A9A6 RID: 43430 RVA: 0x001E3FF8 File Offset: 0x001E21F8
		private void Awake()
		{
			this.m_Enter = (base.transform.Find("Bg/Enter").GetComponent("XUIButton") as IXUIButton);
			this.m_Announcement = (base.transform.Find("Bg/Panel/Text").GetComponent("XUILabel") as IXUILabel);
		}

		// Token: 0x04003EC4 RID: 16068
		public IXUIButton m_Enter;

		// Token: 0x04003EC5 RID: 16069
		public IXUILabel m_Announcement;
	}
}
