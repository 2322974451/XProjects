using System;
using UILib;
using XMainClient.UI.UICommon;

namespace XMainClient
{

	internal class XAnnouncementBehaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			this.m_Enter = (base.transform.Find("Bg/Enter").GetComponent("XUIButton") as IXUIButton);
			this.m_Announcement = (base.transform.Find("Bg/Panel/Text").GetComponent("XUILabel") as IXUILabel);
		}

		public IXUIButton m_Enter;

		public IXUILabel m_Announcement;
	}
}
