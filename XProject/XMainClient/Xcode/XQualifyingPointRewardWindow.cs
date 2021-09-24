using System;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XQualifyingPointRewardWindow
	{

		public XQualifyingPointRewardWindow(GameObject go)
		{
			this.m_Go = go;
			this.m_Close = (go.transform.Find("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_RewardPool.SetupPool(go.transform.Find("Bg/Bg/ScrollView").gameObject, go.transform.Find("Bg/Bg/ScrollView/RewardTpl").gameObject, 20U, false);
			this.m_ItemPool.SetupPool(go.transform.FindChild("Bg/Bg/ScrollView").gameObject, go.transform.FindChild("Bg/Bg/ScrollView/Item").gameObject, 50U, false);
			this.m_ScrollView = (go.transform.Find("Bg/Bg/ScrollView").GetComponent("XUIScrollView") as IXUIScrollView);
			this.m_CurrentPoint = (go.transform.Find("Bg/CurrentPoint/Text").GetComponent("XUILabel") as IXUILabel);
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

		public XUIPool m_RewardPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public XUIPool m_ItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public IXUIButton m_Close;

		public IXUIScrollView m_ScrollView;

		public IXUILabel m_CurrentPoint;
	}
}
