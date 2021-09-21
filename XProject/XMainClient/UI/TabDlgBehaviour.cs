using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XMainClient.Utility;

namespace XMainClient.UI
{
	// Token: 0x02001901 RID: 6401
	internal class TabDlgBehaviour : DlgBehaviourBase
	{
		// Token: 0x06010B50 RID: 68432 RVA: 0x0042A2E4 File Offset: 0x004284E4
		private void Awake()
		{
			this.m_Close = (base.transform.FindChild("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_root = base.transform.FindChild("Bg");
			Transform tabTpl = base.transform.FindChild("Bg/Tabs/TabTpl");
			this.m_tabcontrol.SetTabTpl(tabTpl);
		}

		// Token: 0x04007A31 RID: 31281
		public IXUIButton m_Close;

		// Token: 0x04007A32 RID: 31282
		public Transform m_root;

		// Token: 0x04007A33 RID: 31283
		public XUITabControl m_tabcontrol = new XUITabControl();
	}
}
