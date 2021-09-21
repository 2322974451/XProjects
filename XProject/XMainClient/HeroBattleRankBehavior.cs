using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient
{
	// Token: 0x02000C2A RID: 3114
	internal class HeroBattleRankBehavior : DlgBehaviourBase
	{
		// Token: 0x0600B068 RID: 45160 RVA: 0x0021AE18 File Offset: 0x00219018
		private void Awake()
		{
			this.m_OutOfRank = base.transform.Find("Bg/MyRankFrame/QualifyList/OutOfRange").gameObject;
			this.m_MyRankTs = base.transform.Find("Bg/MyRankFrame/QualifyList/Tpl");
			this.m_RankWrapContent = (base.transform.Find("Bg/Panel/QualifyList").GetComponent("XUIWrapContent") as IXUIWrapContent);
			this.m_RankScrollView = (base.transform.Find("Bg/Panel").GetComponent("XUIScrollView") as IXUIScrollView);
			this.m_CloseBtn = (base.transform.Find("Bg/Close").GetComponent("XUIButton") as IXUIButton);
		}

		// Token: 0x040043D5 RID: 17365
		public IXUIWrapContent m_RankWrapContent;

		// Token: 0x040043D6 RID: 17366
		public IXUIScrollView m_RankScrollView;

		// Token: 0x040043D7 RID: 17367
		public Transform m_MyRankTs;

		// Token: 0x040043D8 RID: 17368
		public GameObject m_OutOfRank;

		// Token: 0x040043D9 RID: 17369
		public IXUIButton m_CloseBtn;
	}
}
