using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XWelfareBehaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			Transform transform = base.transform.Find("Bg/TabList/TabGrid/Tpl");
			this.m_TabPool.SetupPool(transform.gameObject.gameObject, transform.gameObject, 5U, false);
			this.m_RightHandlerParent = base.transform.Find("Bg/RightHander");
			this.m_TabList = (base.transform.Find("Bg/TabList/TabGrid").GetComponent("XUIList") as IXUIList);
			this.m_Close = (base.transform.Find("Bg/Close").GetComponent("XUIButton") as IXUIButton);
		}

		public IXUIButton m_Close;

		public IXUIList m_TabList;

		public XUIPool m_TabPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public Transform m_RightHandlerParent;
	}
}
