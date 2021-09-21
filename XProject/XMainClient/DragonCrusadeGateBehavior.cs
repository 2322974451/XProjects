using System;
using UILib;
using XMainClient.UI.UICommon;

namespace XMainClient
{
	// Token: 0x02000BE7 RID: 3047
	internal class DragonCrusadeGateBehavior : DlgBehaviourBase
	{
		// Token: 0x0600AD94 RID: 44436 RVA: 0x00203DB0 File Offset: 0x00201FB0
		private void Awake()
		{
			this.mClosedBtn = (base.transform.FindChild("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.mRwdBtn = (base.transform.FindChild("Bg/ContentFrame/btm/rwdBtn").GetComponent("XUIButton") as IXUIButton);
			this.mBuff = (base.transform.transform.Find("Bg/ContentFrame/FightValue/Buff").GetComponent("XUISprite") as IXUISprite);
		}

		// Token: 0x04004170 RID: 16752
		public IXUISprite mBuff = null;

		// Token: 0x04004171 RID: 16753
		public IXUIButton mClosedBtn = null;

		// Token: 0x04004172 RID: 16754
		public IXUIButton mRwdBtn = null;
	}
}
