using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient.UI
{
	// Token: 0x02001752 RID: 5970
	internal class GuildArenaRankBehaviour : DlgBehaviourBase
	{
		// Token: 0x0600F6A4 RID: 63140 RVA: 0x0037FB9C File Offset: 0x0037DD9C
		private void Awake()
		{
			this.m_NA = base.transform.FindChild("Bg/NA");
			this.m_Close = (base.transform.FindChild("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_ScrollView = (base.transform.FindChild("Bg/ScrollView").GetComponent("XUIScrollView") as IXUIScrollView);
			this.m_WrapContent = (base.transform.FindChild("Bg/ScrollView/WrapContent").GetComponent("XUIWrapContent") as IXUIWrapContent);
		}

		// Token: 0x04006B2A RID: 27434
		public IXUIButton m_Close;

		// Token: 0x04006B2B RID: 27435
		public IXUIScrollView m_ScrollView;

		// Token: 0x04006B2C RID: 27436
		public IXUIWrapContent m_WrapContent;

		// Token: 0x04006B2D RID: 27437
		public Transform m_NA;
	}
}
