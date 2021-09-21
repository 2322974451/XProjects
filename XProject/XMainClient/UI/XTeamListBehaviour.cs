using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x020018C4 RID: 6340
	internal class XTeamListBehaviour : DlgBehaviourBase
	{
		// Token: 0x06010888 RID: 67720 RVA: 0x0040ECF0 File Offset: 0x0040CEF0
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

		// Token: 0x040077B3 RID: 30643
		public IXUIButton m_Close = null;

		// Token: 0x040077B4 RID: 30644
		public IXUIButton m_BtnJoin;

		// Token: 0x040077B5 RID: 30645
		public GameObject m_NoTeam;

		// Token: 0x040077B6 RID: 30646
		public IXUIScrollView m_ScrollView;

		// Token: 0x040077B7 RID: 30647
		public IXUIWrapContent m_WrapContent;

		// Token: 0x040077B8 RID: 30648
		public XUIPool m_CategoryPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x040077B9 RID: 30649
		public IXUIScrollView m_CategoryScrollView;

		// Token: 0x040077BA RID: 30650
		public XTitleBar m_TitleBar;

		// Token: 0x040077BB RID: 30651
		public IXUILabel m_PPTRequirement;
	}
}
