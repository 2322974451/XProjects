using System;
using UILib;
using XMainClient.UI.UICommon;

namespace XMainClient.UI
{

	internal class XTeamInputPasswordBehaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			this.m_BtnOK = (base.transform.Find("Bg/OK").GetComponent("XUIButton") as IXUIButton);
			this.m_BtnClose = (base.transform.Find("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_Input = (base.transform.Find("Bg/Input").GetComponent("XUIInput") as IXUIInput);
		}

		public IXUIInput m_Input;

		public IXUIButton m_BtnOK;

		public IXUIButton m_BtnClose;
	}
}
