using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XBackFlowBehavior : DlgBehaviourBase
	{

		private void Awake()
		{
			Transform transform = base.transform.Find("Bg/Tabs/TabTpl");
			this.TabItemPool.SetupPool(transform.parent.gameObject, transform.gameObject, 10U, false);
			this.CloseBtn = (base.transform.Find("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.HandlersParent = base.transform.Find("Bg/Handler");
		}

		public XUIPool TabItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public IXUIButton CloseBtn;

		public Transform HandlersParent;
	}
}
