using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class XTeamListBehaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			this.m_Close = (base.transform.FindChild("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			Transform transform = base.transform.FindChild("Bg");
			this.m_BtnJoin = (transform.FindChild("BtnJoin").GetComponent("XUIButton") as IXUIButton);
			transform = transform.FindChild("Titles");
			DlgHandlerBase.EnsureCreate<XTitleBar>(ref this.m_TitleBar, transform.gameObject, null, true);
			transform = base.transform.FindChild("Bg/Categories/Category");
			this.m_CategoryPool.SetupPool(transform.parent.gameObject, transform.gameObject, 2U, false);
			this.m_CategoryScrollView = (base.transform.Find("Bg/Categories/ScrollView").GetComponent("XUIScrollView") as IXUIScrollView);
			transform = base.transform.FindChild("Bg/AllTeamsFrame");
			this.m_NoTeam = transform.FindChild("NoTeams").gameObject;
			this.m_ScrollView = (transform.FindChild("Panel").GetComponent("XUIScrollView") as IXUIScrollView);
			this.m_WrapContent = (transform.FindChild("Panel/WrapContent").GetComponent("XUIWrapContent") as IXUIWrapContent);
			this.m_PPTRequirement = (base.transform.Find("Bg/BattlePoint/Num").GetComponent("XUILabel") as IXUILabel);
		}

		public IXUIButton m_Close = null;

		public IXUIButton m_BtnJoin;

		public GameObject m_NoTeam;

		public IXUIScrollView m_ScrollView;

		public IXUIWrapContent m_WrapContent;

		public XUIPool m_CategoryPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public IXUIScrollView m_CategoryScrollView;

		public XTitleBar m_TitleBar;

		public IXUILabel m_PPTRequirement;
	}
}
