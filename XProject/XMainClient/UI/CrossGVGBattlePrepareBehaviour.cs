using System;
using UILib;
using UnityEngine;

namespace XMainClient.UI
{
	// Token: 0x020016F3 RID: 5875
	internal class CrossGVGBattlePrepareBehaviour : GVGBattlePrepareBehaviour
	{
		// Token: 0x0600F268 RID: 62056 RVA: 0x0035C50C File Offset: 0x0035A70C
		protected override void Awake()
		{
			base.Awake();
			this.mRankFrame = base.transform.Find("RankFrame").gameObject;
			this.mRevive = (base.transform.Find("LeftTime/Revive").GetComponent("XUIButton") as IXUIButton);
			this.mReviveSymbol = (base.transform.Find("LeftTime/Revive/Label").GetComponent("XUILabelSymbol") as IXUILabelSymbol);
		}

		// Token: 0x040067E7 RID: 26599
		public GameObject mRankFrame;

		// Token: 0x040067E8 RID: 26600
		public IGVGBattleMember mRankPanel;

		// Token: 0x040067E9 RID: 26601
		public IXUIButton mRevive;

		// Token: 0x040067EA RID: 26602
		public IXUILabelSymbol mReviveSymbol;
	}
}
