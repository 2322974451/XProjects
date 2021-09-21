using System;
using UILib;
using XMainClient.UI.UICommon;

namespace XMainClient
{
	// Token: 0x02000CF3 RID: 3315
	internal class GuildDragonChallengeResultBehaviour : DlgBehaviourBase
	{
		// Token: 0x0600B974 RID: 47476 RVA: 0x0025A964 File Offset: 0x00258B64
		private void Awake()
		{
			this.m_Desription = (base.transform.FindChild("Bg/Leader").GetComponent("XUILabel") as IXUILabel);
			this.m_Time = (base.transform.FindChild("Bg/Leader/time").GetComponent("XUILabel") as IXUILabel);
			this.m_ReturnBtn = (base.transform.Find("Bg/p").GetComponent("XUISprite") as IXUISprite);
		}

		// Token: 0x04004A0F RID: 18959
		public IXUILabel m_Desription;

		// Token: 0x04004A10 RID: 18960
		public IXUILabel m_Time;

		// Token: 0x04004A11 RID: 18961
		public IXUISprite m_ReturnBtn;
	}
}
