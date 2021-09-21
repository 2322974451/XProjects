using System;
using UILib;
using XMainClient.UI.UICommon;

namespace XMainClient.UI
{
	// Token: 0x020018C2 RID: 6338
	internal class XTeamConfirmBehaviour : DlgBehaviourBase
	{
		// Token: 0x06010875 RID: 67701 RVA: 0x0040E6B8 File Offset: 0x0040C8B8
		private void Awake()
		{
			this.m_OK = (base.transform.FindChild("Bg/OK").GetComponent("XUIButton") as IXUIButton);
			this.m_Cancel = (base.transform.FindChild("Bg/Cancel").GetComponent("XUIButton") as IXUIButton);
			this.m_DungeonName = (base.transform.FindChild("Bg/DungeonName").GetComponent("XUILabel") as IXUILabel);
			this.m_LeaderLevel = (base.transform.FindChild("Bg/LeaderLevel").GetComponent("XUILabel") as IXUILabel);
			this.m_LeaderName = (base.transform.FindChild("Bg/LeaderName").GetComponent("XUILabel") as IXUILabel);
			this.m_Content = (base.transform.FindChild("Bg/Content").GetComponent("XUILabel") as IXUILabel);
			this.m_MemberText = (base.transform.FindChild("Bg/Count").GetComponent("XUILabel") as IXUILabel);
			this.m_MemberCount = (base.transform.FindChild("Bg/Count/Value").GetComponent("XUILabel") as IXUILabel);
			this.m_PPT = (base.transform.FindChild("Bg/PPT/Value").GetComponent("XUILabel") as IXUILabel);
			this.m_Progress = (base.transform.FindChild("Bg/Progress").GetComponent("XUIProgress") as IXUIProgress);
		}

		// Token: 0x040077A2 RID: 30626
		public IXUIButton m_OK = null;

		// Token: 0x040077A3 RID: 30627
		public IXUIButton m_Cancel = null;

		// Token: 0x040077A4 RID: 30628
		public IXUILabel m_DungeonName;

		// Token: 0x040077A5 RID: 30629
		public IXUILabel m_LeaderLevel;

		// Token: 0x040077A6 RID: 30630
		public IXUILabel m_LeaderName;

		// Token: 0x040077A7 RID: 30631
		public IXUILabel m_Content;

		// Token: 0x040077A8 RID: 30632
		public IXUILabel m_MemberText;

		// Token: 0x040077A9 RID: 30633
		public IXUILabel m_MemberCount;

		// Token: 0x040077AA RID: 30634
		public IXUILabel m_PPT;

		// Token: 0x040077AB RID: 30635
		public IXUIProgress m_Progress;
	}
}
