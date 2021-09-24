using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XOperatingActivityBehaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			Transform transform = base.transform.Find("Bg/Left/padTabs/Grid/TabTpl");
			this.m_TabPool.SetupPool(transform.parent.gameObject, transform.gameObject, 2U, false);
			this.m_tabParent = base.transform.Find("Bg/Left/padTabs/Grid");
			this.m_Close = (base.transform.FindChild("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_rightTra = base.transform.FindChild("Bg/Right");
			this.m_midTra = base.transform.FindChild("Bg/Middle");
		}

		public IXUIButton m_Close;

		public Transform m_tabParent;

		public Transform m_rightTra;

		public Transform m_midTra;

		public XUIPool m_TabPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);
	}
}
