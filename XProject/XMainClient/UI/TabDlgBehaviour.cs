using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XMainClient.Utility;

namespace XMainClient.UI
{

	internal class TabDlgBehaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			this.m_Close = (base.transform.FindChild("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_root = base.transform.FindChild("Bg");
			Transform tabTpl = base.transform.FindChild("Bg/Tabs/TabTpl");
			this.m_tabcontrol.SetTabTpl(tabTpl);
		}

		public IXUIButton m_Close;

		public Transform m_root;

		public XUITabControl m_tabcontrol = new XUITabControl();
	}
}
