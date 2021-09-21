using System;
using UILib;
using XMainClient.UI.UICommon;

namespace XMainClient.UI
{
	// Token: 0x02001745 RID: 5957
	internal class GuildArenaDuelFinalResultBehaviour : DlgBehaviourBase
	{
		// Token: 0x0600F65E RID: 63070 RVA: 0x0037E33C File Offset: 0x0037C53C
		private void Awake()
		{
			this.m_BlueInfo.Init(base.transform.FindChild("Bg/Blue"));
			this.m_RedInfo.Init(base.transform.FindChild("Bg/Red"));
			this.m_maskSprite = (base.transform.FindChild("Bg/Mask").GetComponent("XUISprite") as IXUISprite);
			this.m_timeLabel = (base.transform.FindChild("Bg/CountDown/Time").GetComponent("XUILabel") as IXUILabel);
		}

		// Token: 0x04006AE0 RID: 27360
		public IXUISprite m_maskSprite;

		// Token: 0x04006AE1 RID: 27361
		public IXUILabel m_timeLabel;

		// Token: 0x04006AE2 RID: 27362
		public GuildArenadDuelFinalInfo m_BlueInfo = new GuildArenadDuelFinalInfo();

		// Token: 0x04006AE3 RID: 27363
		public GuildArenadDuelFinalInfo m_RedInfo = new GuildArenadDuelFinalInfo();
	}
}
