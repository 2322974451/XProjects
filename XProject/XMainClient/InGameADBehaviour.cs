using System;
using UILib;
using XMainClient.UI.UICommon;

namespace XMainClient
{

	internal class InGameADBehaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			this.m_Close = (base.transform.FindChild("Close").GetComponent("XUIButton") as IXUIButton);
			this.m_Tex = (base.transform.FindChild("Tex").GetComponent("XUITexture") as IXUITexture);
			this.m_BtnGo = (base.transform.FindChild("BtnGo").GetComponent("XUISprite") as IXUISprite);
		}

		public IXUIButton m_Close;

		public IXUITexture m_Tex;

		public IXUISprite m_BtnGo;
	}
}
