using System;
using UILib;
using XMainClient.UI.UICommon;

namespace XMainClient.UI
{

	internal class MobaBehaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			this.m_Texture = (base.transform.FindChild("End/Icon").GetComponent("XUITexture") as IXUITexture);
		}

		public IXUITexture m_Texture;
	}
}
