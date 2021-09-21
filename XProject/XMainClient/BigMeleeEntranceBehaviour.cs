using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000C4F RID: 3151
	internal class BigMeleeEntranceBehaviour : DlgBehaviourBase
	{
		// Token: 0x0600B2CC RID: 45772 RVA: 0x0022A76C File Offset: 0x0022896C
		private void Awake()
		{
			this.m_Bg = base.transform.FindChild("Bg");
			this.m_Close = (base.transform.FindChild("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_Help = (base.transform.FindChild("Bg/Help").GetComponent("XUIButton") as IXUIButton);
			this.m_Join = (base.transform.FindChild("Bg/Join").GetComponent("XUIButton") as IXUIButton);
			this.m_PointRewardBtn = (base.transform.FindChild("Bg/PointRewardBtn").GetComponent("XUIButton") as IXUIButton);
			this.m_RankRewardBtn = (base.transform.FindChild("Bg/RankRewardBtn").GetComponent("XUIButton") as IXUIButton);
			this.m_Rule = (base.transform.FindChild("Bg/Rule").GetComponent("XUILabel") as IXUILabel);
			this.m_Time = (base.transform.FindChild("Bg/Time").GetComponent("XUILabel") as IXUILabel);
			Transform transform = base.transform.FindChild("Bg/Reward/ItemTpl");
			this.m_RewardShowPool.SetupPool(null, transform.gameObject, 5U, false);
		}

		// Token: 0x04004509 RID: 17673
		public Transform m_Bg;

		// Token: 0x0400450A RID: 17674
		public IXUIButton m_Close;

		// Token: 0x0400450B RID: 17675
		public IXUIButton m_Help;

		// Token: 0x0400450C RID: 17676
		public IXUIButton m_Join;

		// Token: 0x0400450D RID: 17677
		public IXUIButton m_PointRewardBtn;

		// Token: 0x0400450E RID: 17678
		public IXUIButton m_RankRewardBtn;

		// Token: 0x0400450F RID: 17679
		public XUIPool m_RewardShowPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04004510 RID: 17680
		public IXUILabel m_Rule;

		// Token: 0x04004511 RID: 17681
		public IXUILabel m_Time;
	}
}
