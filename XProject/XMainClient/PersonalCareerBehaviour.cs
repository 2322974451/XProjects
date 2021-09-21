using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000C8A RID: 3210
	internal class PersonalCareerBehaviour : DlgBehaviourBase
	{
		// Token: 0x0600B554 RID: 46420 RVA: 0x0023C090 File Offset: 0x0023A290
		private void Awake()
		{
			this.m_Close = (base.transform.FindChild("Close").GetComponent("XUIButton") as IXUIButton);
			Transform transform = base.transform.FindChild("Tabs/TabTpl");
			this.m_TabPool.SetupPool(null, transform.gameObject, 3U, false);
		}

		// Token: 0x040046E2 RID: 18146
		public IXUIButton m_Close;

		// Token: 0x040046E3 RID: 18147
		public XUIPool m_TabPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);
	}
}
