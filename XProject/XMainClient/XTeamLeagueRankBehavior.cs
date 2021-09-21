using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient
{
	// Token: 0x02000BF5 RID: 3061
	internal class XTeamLeagueRankBehavior : DlgBehaviourBase
	{
		// Token: 0x0600AE1E RID: 44574 RVA: 0x00208F68 File Offset: 0x00207168
		private void Awake()
		{
			this.CloseBtn = (base.transform.Find("Close").GetComponent("XUIButton") as IXUIButton);
			this.WrapContent = (base.transform.Find("Panel/wrapContent").GetComponent("XUIWrapContent") as IXUIWrapContent);
			this.NoRankTrans = base.transform.Find("NoRank");
		}

		// Token: 0x040041F0 RID: 16880
		public IXUIButton CloseBtn;

		// Token: 0x040041F1 RID: 16881
		public IXUIWrapContent WrapContent;

		// Token: 0x040041F2 RID: 16882
		public Transform NoRankTrans;
	}
}
