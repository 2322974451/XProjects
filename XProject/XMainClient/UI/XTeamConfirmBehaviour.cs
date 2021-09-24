using System;
using UILib;
using XMainClient.UI.UICommon;

namespace XMainClient.UI
{

	internal class XTeamConfirmBehaviour : DlgBehaviourBase
	{

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

		public IXUIButton m_OK = null;

		public IXUIButton m_Cancel = null;

		public IXUILabel m_DungeonName;

		public IXUILabel m_LeaderLevel;

		public IXUILabel m_LeaderName;

		public IXUILabel m_Content;

		public IXUILabel m_MemberText;

		public IXUILabel m_MemberCount;

		public IXUILabel m_PPT;

		public IXUIProgress m_Progress;
	}
}
