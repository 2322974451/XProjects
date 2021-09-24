using System;
using UILib;
using XMainClient.UI.UICommon;

namespace XMainClient
{

	internal class XPandoraSDKPopViewBehaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			this.m_Close = (base.transform.Find("Close").GetComponent("XUISprite") as IXUISprite);
		}

		public IXUISprite m_Close;
	}
}
