using System;
using UILib;
using XMainClient.UI.UICommon;

namespace XMainClient
{

	internal class RadioBehaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			this.m_lblMicro = (base.transform.Find("Hoster").GetComponent("XUILabel") as IXUILabel);
			this.m_btnRadio = (base.transform.Find("Btn").GetComponent("XUIButton") as IXUIButton);
			this.m_sprPlay = (base.transform.Find("Btn/Play").GetComponent("XUISprite") as IXUISprite);
		}

		public IXUILabel m_lblMicro;

		public IXUIButton m_btnRadio;

		public IXUISprite m_sprPlay;
	}
}
