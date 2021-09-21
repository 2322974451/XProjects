using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000E37 RID: 3639
	internal class XGuildBoonBehaviour : DlgBehaviourBase
	{
		// Token: 0x0600C3C1 RID: 50113 RVA: 0x002A8DDC File Offset: 0x002A6FDC
		private void Awake()
		{
			Transform transform = base.transform.FindChild("Bg/Panel/BoonTpl");
			this.m_BoonPool.SetupPool(transform.parent.gameObject, transform.gameObject, 3U, false);
			this.m_Close = (base.transform.FindChild("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_ScrollView = (base.transform.FindChild("Bg/Panel").GetComponent("XUIScrollView") as IXUIScrollView);
		}

		// Token: 0x040054B2 RID: 21682
		public IXUIButton m_Close;

		// Token: 0x040054B3 RID: 21683
		public XUIPool m_BoonPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x040054B4 RID: 21684
		public IXUIScrollView m_ScrollView;
	}
}
