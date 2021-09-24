using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class PersonalCareerBehaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			this.m_Close = (base.transform.FindChild("Close").GetComponent("XUIButton") as IXUIButton);
			Transform transform = base.transform.FindChild("Tabs/TabTpl");
			this.m_TabPool.SetupPool(null, transform.gameObject, 3U, false);
		}

		public IXUIButton m_Close;

		public XUIPool m_TabPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);
	}
}
