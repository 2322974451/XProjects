using System;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XQualifyingRankWindow
	{

		public XQualifyingRankWindow(GameObject go)
		{
			this.m_Go = go;
			this.m_Close = (go.transform.Find("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_RolePool.SetupPool(go.transform.Find("Bg/Bg/ScrollView").gameObject, go.transform.Find("Bg/Bg/ScrollView/RoleTpl").gameObject, 100U, false);
			this.m_ScrollView = (go.transform.Find("Bg/Bg/ScrollView").GetComponent("XUIScrollView") as IXUIScrollView);
			this.m_TabTpl = go.transform.Find("Tabs/TabTpl").gameObject;
		}

		public void SetVisible(bool v)
		{
			this.m_Go.SetActive(v);
		}

		public bool IsVisible
		{
			get
			{
				return this.m_Go.activeSelf;
			}
		}

		public GameObject m_Go;

		public XUIPool m_RolePool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public IXUIButton m_Close;

		public IXUIScrollView m_ScrollView;

		public GameObject m_TabTpl;
	}
}
