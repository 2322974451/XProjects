using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient.UI
{
	// Token: 0x020018A8 RID: 6312
	internal class XGuildMembersBehaviour : DlgBehaviourBase
	{
		// Token: 0x0601071E RID: 67358 RVA: 0x00405BE0 File Offset: 0x00403DE0
		private void Awake()
		{
			this.m_Close = (base.transform.FindChild("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_ScrollView = (base.transform.FindChild("Bg/Panel").GetComponent("XUIScrollView") as IXUIScrollView);
			this.m_WrapContent = (base.transform.FindChild("Bg/Panel/WrapContent").GetComponent("XUIWrapContent") as IXUIWrapContent);
			Transform transform = base.transform.FindChild("Bg/Titles");
			DlgHandlerBase.EnsureCreate<XTitleBar>(ref this.m_TitleBar, transform.gameObject, null, true);
		}

		// Token: 0x040076CD RID: 30413
		public IXUIButton m_Close = null;

		// Token: 0x040076CE RID: 30414
		public IXUIWrapContent m_WrapContent;

		// Token: 0x040076CF RID: 30415
		public IXUIScrollView m_ScrollView;

		// Token: 0x040076D0 RID: 30416
		public XTitleBar m_TitleBar;
	}
}
