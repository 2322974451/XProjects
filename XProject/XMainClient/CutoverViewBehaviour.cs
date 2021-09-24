using System;
using UILib;
using XMainClient.UI.UICommon;

namespace XMainClient
{

	internal class CutoverViewBehaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			this.m_OK = (base.transform.Find("Bg/OK").GetComponent("XUIButton") as IXUIButton);
			this.m_3D = (base.transform.Find("Bg/3D").GetComponent("XUICheckBox") as IXUICheckBox);
			this.m_25D = (base.transform.Find("Bg/2.5D").GetComponent("XUICheckBox") as IXUICheckBox);
		}

		public IXUICheckBox m_3D;

		public IXUICheckBox m_25D;

		public IXUIButton m_OK;
	}
}
