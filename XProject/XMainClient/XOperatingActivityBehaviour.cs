using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000CFC RID: 3324
	internal class XOperatingActivityBehaviour : DlgBehaviourBase
	{
		// Token: 0x0600BA0C RID: 47628 RVA: 0x0025E430 File Offset: 0x0025C630
		private void Awake()
		{
			Transform transform = base.transform.Find("Bg/Left/padTabs/Grid/TabTpl");
			this.m_TabPool.SetupPool(transform.parent.gameObject, transform.gameObject, 2U, false);
			this.m_tabParent = base.transform.Find("Bg/Left/padTabs/Grid");
			this.m_Close = (base.transform.FindChild("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_rightTra = base.transform.FindChild("Bg/Right");
			this.m_midTra = base.transform.FindChild("Bg/Middle");
		}

		// Token: 0x04004A66 RID: 19046
		public IXUIButton m_Close;

		// Token: 0x04004A67 RID: 19047
		public Transform m_tabParent;

		// Token: 0x04004A68 RID: 19048
		public Transform m_rightTra;

		// Token: 0x04004A69 RID: 19049
		public Transform m_midTra;

		// Token: 0x04004A6A RID: 19050
		public XUIPool m_TabPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);
	}
}
