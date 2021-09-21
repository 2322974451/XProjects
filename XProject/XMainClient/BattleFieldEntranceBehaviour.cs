using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000A21 RID: 2593
	internal class BattleFieldEntranceBehaviour : DlgBehaviourBase
	{
		// Token: 0x06009E87 RID: 40583 RVA: 0x001A10DC File Offset: 0x0019F2DC
		private void Awake()
		{
			this.m_Bg = base.transform.FindChild("Bg");
			this.m_Close = (base.transform.FindChild("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_Help = (base.transform.FindChild("Bg/Help").GetComponent("XUIButton") as IXUIButton);
			this.m_Join = (base.transform.FindChild("Bg/Join").GetComponent("XUIButton") as IXUIButton);
			this.m_PointRewardBtn = (base.transform.FindChild("Bg/PointRewardBtn").GetComponent("XUIButton") as IXUIButton);
			this.m_FallBtn = (base.transform.FindChild("Bg/FallBtn").GetComponent("XUIButton") as IXUIButton);
			this.m_Rule = (base.transform.FindChild("Bg/Left/Rule").GetComponent("XUILabel") as IXUILabel);
			this.m_Time = (base.transform.FindChild("Bg/Left/Time").GetComponent("XUILabel") as IXUILabel);
			Transform transform = base.transform.FindChild("Bg/Left/Reward/ItemTpl");
			this.m_RewardShowPool.SetupPool(null, transform.gameObject, 5U, false);
		}

		// Token: 0x0400384A RID: 14410
		public Transform m_Bg;

		// Token: 0x0400384B RID: 14411
		public IXUIButton m_Close;

		// Token: 0x0400384C RID: 14412
		public IXUIButton m_Help;

		// Token: 0x0400384D RID: 14413
		public IXUIButton m_Join;

		// Token: 0x0400384E RID: 14414
		public IXUIButton m_PointRewardBtn;

		// Token: 0x0400384F RID: 14415
		public IXUIButton m_FallBtn;

		// Token: 0x04003850 RID: 14416
		public XUIPool m_RewardShowPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04003851 RID: 14417
		public IXUILabel m_Rule;

		// Token: 0x04003852 RID: 14418
		public IXUILabel m_Time;
	}
}
