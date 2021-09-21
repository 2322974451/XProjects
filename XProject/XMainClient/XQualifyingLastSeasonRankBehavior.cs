using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000C7C RID: 3196
	internal class XQualifyingLastSeasonRankBehavior : DlgBehaviourBase
	{
		// Token: 0x0600B4A2 RID: 46242 RVA: 0x00235DC0 File Offset: 0x00233FC0
		private void Awake()
		{
			this.m_Close = (base.transform.Find("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_RolePool.SetupPool(base.transform.Find("Bg/Bg/ScrollView").gameObject, base.transform.Find("Bg/Bg/ScrollView/RoleTpl").gameObject, 100U, false);
			this.m_ScrollView = (base.transform.Find("Bg/Bg/ScrollView").GetComponent("XUIScrollView") as IXUIScrollView);
			this.m_TabTpl = base.transform.Find("Tabs/TabTpl").gameObject;
		}

		// Token: 0x04004628 RID: 17960
		public XUIPool m_RolePool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04004629 RID: 17961
		public IXUIButton m_Close;

		// Token: 0x0400462A RID: 17962
		public IXUIScrollView m_ScrollView;

		// Token: 0x0400462B RID: 17963
		public GameObject m_TabTpl;
	}
}
