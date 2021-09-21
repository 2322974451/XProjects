using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient
{
	// Token: 0x02000A5A RID: 2650
	internal class XGuildTaskRefreshResultDlgBehavior : DlgBehaviourBase
	{
		// Token: 0x0600A0CE RID: 41166 RVA: 0x001AFB78 File Offset: 0x001ADD78
		private void Awake()
		{
			this.beforeSprite = (base.transform.Find("P2/TaskLevelBefore").GetComponent("XUISprite") as IXUISprite);
			this.afterSprite = (base.transform.Find("P2/TaskLevelAfter").GetComponent("XUISprite") as IXUISprite);
			this.blockBtn = (base.transform.Find("Block").GetComponent("XUIButton") as IXUIButton);
			this.resultLabel = (base.transform.Find("P2/ResultText").GetComponent("XUILabel") as IXUILabel);
			this.m_FxDepth = base.transform.Find("Fx/FxDepth");
			this.m_FxDepth2 = base.transform.Find("Fx/FxDepth2");
			this.TweenGroup = (base.transform.Find("P2").GetComponent("XUIPlayTweenGroup") as IXUIPlayTweenGroup);
		}

		// Token: 0x040039AA RID: 14762
		public IXUISprite beforeSprite;

		// Token: 0x040039AB RID: 14763
		public IXUISprite afterSprite;

		// Token: 0x040039AC RID: 14764
		public IXUIButton blockBtn;

		// Token: 0x040039AD RID: 14765
		public Transform m_FxDepth;

		// Token: 0x040039AE RID: 14766
		public Transform m_FxDepth2;

		// Token: 0x040039AF RID: 14767
		public IXUILabel resultLabel;

		// Token: 0x040039B0 RID: 14768
		public IXUIPlayTweenGroup TweenGroup;
	}
}
