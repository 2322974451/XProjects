using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000CA7 RID: 3239
	internal class XThemeActivityBehaviour : DlgBehaviourBase
	{
		// Token: 0x0600B671 RID: 46705 RVA: 0x00242C3C File Offset: 0x00240E3C
		private void Awake()
		{
			Transform transform = base.transform.Find("Bg/padTabs/Grid/TabTpl");
			this.m_TabPool.SetupPool(transform.parent.gameObject, transform.gameObject, 2U, false);
			this.m_tabParent = base.transform.Find("Bg/padTabs/Grid");
			this.m_Close = (base.transform.FindChild("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_rightTra = base.transform.FindChild("Bg/Right");
		}

		// Token: 0x04004769 RID: 18281
		public IXUIButton m_Close;

		// Token: 0x0400476A RID: 18282
		public Transform m_tabParent;

		// Token: 0x0400476B RID: 18283
		public Transform m_rightTra;

		// Token: 0x0400476C RID: 18284
		public XUIPool m_TabPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);
	}
}
