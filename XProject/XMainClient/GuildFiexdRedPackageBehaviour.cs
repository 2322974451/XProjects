using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient
{
	// Token: 0x02000C0A RID: 3082
	internal class GuildFiexdRedPackageBehaviour : DlgBehaviourBase
	{
		// Token: 0x0600AF2E RID: 44846 RVA: 0x00212488 File Offset: 0x00210688
		private void Awake()
		{
			this.m_Close = (base.transform.FindChild("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_ScrollView = (base.transform.FindChild("Bg/RightView").GetComponent("XUIScrollView") as IXUIScrollView);
			this.m_WrapContent = (base.transform.FindChild("Bg/RightView/WrapContent").GetComponent("XUIWrapContent") as IXUIWrapContent);
			this.m_Empty = base.transform.FindChild("Bg/Empty");
			this.m_HelpBtn = (base.transform.FindChild("Bg/Help").GetComponent("XUIButton") as IXUIButton);
		}

		// Token: 0x040042B4 RID: 17076
		public IXUIScrollView m_ScrollView;

		// Token: 0x040042B5 RID: 17077
		public IXUIButton m_Close;

		// Token: 0x040042B6 RID: 17078
		public IXUIWrapContent m_WrapContent;

		// Token: 0x040042B7 RID: 17079
		public IXUIButton m_HelpBtn;

		// Token: 0x040042B8 RID: 17080
		public Transform m_Empty;
	}
}
