using System;
using UILib;
using XMainClient.UI.UICommon;

namespace XMainClient
{
	// Token: 0x02000CA9 RID: 3241
	internal class TutorialSkipBehaviour : DlgBehaviourBase
	{
		// Token: 0x0600B68D RID: 46733 RVA: 0x0024353C File Offset: 0x0024173C
		private void Awake()
		{
			this.m_Close = (base.transform.FindChild("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_Skip = (base.transform.FindChild("Bg/Skip").GetComponent("XUIButton") as IXUIButton);
			this.m_NoSkip = (base.transform.FindChild("Bg/NoSkip").GetComponent("XUIButton") as IXUIButton);
			this.m_Label = (base.transform.FindChild("Bg/Label").GetComponent("XUILabel") as IXUILabel);
		}

		// Token: 0x04004773 RID: 18291
		public IXUIButton m_Close;

		// Token: 0x04004774 RID: 18292
		public IXUIButton m_Skip;

		// Token: 0x04004775 RID: 18293
		public IXUIButton m_NoSkip;

		// Token: 0x04004776 RID: 18294
		public IXUILabel m_Label;
	}
}
