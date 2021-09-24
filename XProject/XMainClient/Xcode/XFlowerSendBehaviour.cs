using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XFlowerSendBehaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			Transform transform = base.transform.FindChild("Bg/P1");
			this.m_TabPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);
			this.m_TabPool.SetupPool(transform.parent.gameObject, transform.gameObject, 3U, false);
			this.m_SendItemList = (base.transform.FindChild("Bg/List").GetComponent("XUIList") as IXUIList);
			Transform transform2 = base.transform.FindChild("Bg/List/Tpl");
			this.m_SendItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);
			this.m_SendItemPool.SetupPool(transform2.parent.gameObject, transform2.gameObject, 5U, false);
			this.m_Close = (base.transform.FindChild("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_PointTip = (base.transform.FindChild("Bg/T1").GetComponent("XUILabel") as IXUILabel);
		}

		public IXUIButton m_Close;

		public XUIPool m_TabPool;

		public IXUILabel m_PointTip;

		public XUIPool m_SendItemPool;

		public IXUIList m_SendItemList;
	}
}
