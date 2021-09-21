using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient.UI
{
	// Token: 0x020018CC RID: 6348
	internal class XBuyCountBehaviour : DlgBehaviourBase
	{
		// Token: 0x060108CE RID: 67790 RVA: 0x00411300 File Offset: 0x0040F500
		private void Awake()
		{
			Transform transform = base.transform.FindChild("Bg/Content");
			this.m_Content = (transform.GetComponent("XUILabel") as IXUILabel);
			this.m_ContentLabelSymbol = (transform.GetComponent("XUILabelSymbol") as IXUILabelSymbol);
			this.m_LeftBuyCount = (base.transform.Find("Bg/LeftBuyCount").GetComponent("XUILabel") as IXUILabel);
			Transform transform2 = base.transform.FindChild("Bg/OK");
			this.m_OKButton = (transform2.GetComponent("XUIButton") as IXUIButton);
			Transform transform3 = base.transform.FindChild("Bg/Cancel");
			this.m_CancelButton = (transform3.GetComponent("XUIButton") as IXUIButton);
		}

		// Token: 0x040077DF RID: 30687
		public IXUILabel m_Content = null;

		// Token: 0x040077E0 RID: 30688
		public IXUILabelSymbol m_ContentLabelSymbol = null;

		// Token: 0x040077E1 RID: 30689
		public IXUILabel m_LeftBuyCount = null;

		// Token: 0x040077E2 RID: 30690
		public IXUIButton m_OKButton = null;

		// Token: 0x040077E3 RID: 30691
		public IXUIButton m_CancelButton = null;
	}
}
