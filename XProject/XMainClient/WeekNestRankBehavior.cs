using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient
{

	internal class WeekNestRankBehavior : DlgBehaviourBase
	{

		private void Awake()
		{
			this.m_wrapContent = (base.transform.FindChild("Panel/FourNameList").GetComponent("XUIWrapContent") as IXUIWrapContent);
			this.m_CloseBtn = (base.transform.Find("Close").GetComponent("XUIButton") as IXUIButton);
			this.m_ScrollView = (base.transform.Find("Panel").GetComponent("XUIScrollView") as IXUIScrollView);
			this.m_tipsGo = base.transform.FindChild("Tips").gameObject;
		}

		public IXUIWrapContent m_wrapContent;

		public IXUIButton m_CloseBtn;

		public IXUIScrollView m_ScrollView;

		public GameObject m_tipsGo;
	}
}
