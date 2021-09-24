using System;
using UILib;
using XMainClient.UI.UICommon;

namespace XMainClient
{

	internal class XTeamLeagueCreateBehaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			this.m_Close = (base.transform.FindChild("CreateMenu/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_OK = (base.transform.FindChild("CreateMenu/OK").GetComponent("XUIButton") as IXUIButton);
			this.m_Cancel = (base.transform.FindChild("CreateMenu/Cancel").GetComponent("XUIButton") as IXUIButton);
			this.m_NameInput = (base.transform.FindChild("CreateMenu/NameInput").GetComponent("XUIInput") as IXUIInput);
		}

		public IXUIButton m_Close;

		public IXUIButton m_OK;

		public IXUIButton m_Cancel;

		public IXUIInput m_NameInput;
	}
}
