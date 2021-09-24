using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XQualifyingLastSeasonRankBehavior : DlgBehaviourBase
	{

		private void Awake()
		{
			this.m_Close = (base.transform.Find("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_RolePool.SetupPool(base.transform.Find("Bg/Bg/ScrollView").gameObject, base.transform.Find("Bg/Bg/ScrollView/RoleTpl").gameObject, 100U, false);
			this.m_ScrollView = (base.transform.Find("Bg/Bg/ScrollView").GetComponent("XUIScrollView") as IXUIScrollView);
			this.m_TabTpl = base.transform.Find("Tabs/TabTpl").gameObject;
		}

		public XUIPool m_RolePool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public IXUIButton m_Close;

		public IXUIScrollView m_ScrollView;

		public GameObject m_TabTpl;
	}
}
