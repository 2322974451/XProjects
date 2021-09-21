using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient
{
	// Token: 0x02000C5A RID: 3162
	internal class WeekNestRankBehavior : DlgBehaviourBase
	{
		// Token: 0x0600B323 RID: 45859 RVA: 0x0022C7A8 File Offset: 0x0022A9A8
		private void Awake()
		{
			this.m_wrapContent = (base.transform.FindChild("Panel/FourNameList").GetComponent("XUIWrapContent") as IXUIWrapContent);
			this.m_CloseBtn = (base.transform.Find("Close").GetComponent("XUIButton") as IXUIButton);
			this.m_ScrollView = (base.transform.Find("Panel").GetComponent("XUIScrollView") as IXUIScrollView);
			this.m_tipsGo = base.transform.FindChild("Tips").gameObject;
		}

		// Token: 0x0400454B RID: 17739
		public IXUIWrapContent m_wrapContent;

		// Token: 0x0400454C RID: 17740
		public IXUIButton m_CloseBtn;

		// Token: 0x0400454D RID: 17741
		public IXUIScrollView m_ScrollView;

		// Token: 0x0400454E RID: 17742
		public GameObject m_tipsGo;
	}
}
