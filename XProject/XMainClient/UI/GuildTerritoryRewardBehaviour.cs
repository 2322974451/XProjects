using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class GuildTerritoryRewardBehaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			this.m_scrool = (base.transform.Find("Bg/Bg/ScrollView").GetComponent("XUIScrollView") as IXUIScrollView);
			this.m_objTpl = base.transform.Find("Bg/Bg/ScrollView/wrapcontent/Item").gameObject;
			this._close_btn = (base.transform.Find("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_wrap = (base.transform.Find("Bg/Bg/ScrollView/wrapcontent").GetComponent("XUIWrapContent") as IXUIWrapContent);
			this.m_RewardItemPool.SetupPool(base.transform.gameObject, this.m_objTpl, 30U, false);
		}

		public IXUIButton _close_btn;

		public IXUIWrapContent m_wrap;

		public IXUIScrollView m_scrool;

		public GameObject m_objTpl;

		public XUIPool m_RewardItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);
	}
}
