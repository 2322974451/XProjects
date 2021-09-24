using System;
using UILib;
using XMainClient.UI.UICommon;

namespace XMainClient
{

	internal class TutorialSkipBehaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			this.m_Close = (base.transform.FindChild("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_Skip = (base.transform.FindChild("Bg/Skip").GetComponent("XUIButton") as IXUIButton);
			this.m_NoSkip = (base.transform.FindChild("Bg/NoSkip").GetComponent("XUIButton") as IXUIButton);
			this.m_Label = (base.transform.FindChild("Bg/Label").GetComponent("XUILabel") as IXUILabel);
		}

		public IXUIButton m_Close;

		public IXUIButton m_Skip;

		public IXUIButton m_NoSkip;

		public IXUILabel m_Label;
	}
}
