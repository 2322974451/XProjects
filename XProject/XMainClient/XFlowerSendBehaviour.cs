using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000CEA RID: 3306
	internal class XFlowerSendBehaviour : DlgBehaviourBase
	{
		// Token: 0x0600B922 RID: 47394 RVA: 0x002586A4 File Offset: 0x002568A4
		private void Awake()
		{
			Transform transform = base.transform.FindChild("Bg/P1");
			this.m_TabPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);
			this.m_TabPool.SetupPool(transform.parent.gameObject, transform.gameObject, 3U, false);
			this.m_SendItemList = (base.transform.FindChild("Bg/List").GetComponent("XUIList") as IXUIList);
			Transform transform2 = base.transform.FindChild("Bg/List/Tpl");
			this.m_SendItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);
			this.m_SendItemPool.SetupPool(transform2.parent.gameObject, transform2.gameObject, 5U, false);
			this.m_Close = (base.transform.FindChild("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_PointTip = (base.transform.FindChild("Bg/T1").GetComponent("XUILabel") as IXUILabel);
		}

		// Token: 0x040049AB RID: 18859
		public IXUIButton m_Close;

		// Token: 0x040049AC RID: 18860
		public XUIPool m_TabPool;

		// Token: 0x040049AD RID: 18861
		public IXUILabel m_PointTip;

		// Token: 0x040049AE RID: 18862
		public XUIPool m_SendItemPool;

		// Token: 0x040049AF RID: 18863
		public IXUIList m_SendItemList;
	}
}
