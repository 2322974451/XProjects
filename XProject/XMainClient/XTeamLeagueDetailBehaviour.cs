using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000BF0 RID: 3056
	internal class XTeamLeagueDetailBehaviour : DlgBehaviourBase
	{
		// Token: 0x0600AE01 RID: 44545 RVA: 0x002085A4 File Offset: 0x002067A4
		private void Awake()
		{
			this.m_Close = (base.transform.FindChild("p/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_TeamName = (base.transform.FindChild("p/Name").GetComponent("XUILabel") as IXUILabel);
			this.m_MemberList = (base.transform.FindChild("p/Grid").GetComponent("XUIList") as IXUIList);
			Transform transform = base.transform.FindChild("p/Grid/Tpl");
			this.m_MemberPool.SetupPool(this.m_MemberList.gameObject, transform.gameObject, 4U, false);
		}

		// Token: 0x040041DC RID: 16860
		public IXUIButton m_Close;

		// Token: 0x040041DD RID: 16861
		public IXUILabel m_TeamName;

		// Token: 0x040041DE RID: 16862
		public IXUIList m_MemberList;

		// Token: 0x040041DF RID: 16863
		public XUIPool m_MemberPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);
	}
}
