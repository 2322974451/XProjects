using System;
using UILib;
using XMainClient.UI.UICommon;

namespace XMainClient
{

	internal class XPatfaceBehaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			this.m_OK = (base.transform.Find("Bg/Ok").GetComponent("XUIButton") as IXUIButton);
			this.m_Pic = (base.transform.Find("Bg/Texture").GetComponent("XUITexture") as IXUITexture);
		}

		public IXUIButton m_OK;

		public IXUITexture m_Pic;
	}
}
