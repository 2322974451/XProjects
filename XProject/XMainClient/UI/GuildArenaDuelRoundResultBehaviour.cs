using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient.UI
{
	// Token: 0x02001748 RID: 5960
	internal class GuildArenaDuelRoundResultBehaviour : DlgBehaviourBase
	{
		// Token: 0x0600F671 RID: 63089 RVA: 0x0037E7E0 File Offset: 0x0037C9E0
		private void Awake()
		{
			this.m_Blue.Init(base.transform.FindChild("Bg/Blue"));
			this.m_Red.Init(base.transform.FindChild("Bg/Red"));
			this.m_RoundLabel = (base.transform.FindChild("Bg/Round").GetComponent("XUILabel") as IXUILabel);
			this.m_TimeLabel = (base.transform.FindChild("Bg/Time").GetComponent("XUILabel") as IXUILabel);
			this.m_MaskSprite = (base.transform.FindChild("Bg/Mask").GetComponent("XUISprite") as IXUISprite);
			this.m_GuildName = (base.transform.FindChild("Bg/EmptyWin/GuildName").GetComponent("XUILabel") as IXUILabel);
			this.m_EmptyWin = base.transform.FindChild("Bg/EmptyWin");
		}

		// Token: 0x04006AEE RID: 27374
		public IXUILabel m_RoundLabel;

		// Token: 0x04006AEF RID: 27375
		public IXUILabel m_TimeLabel;

		// Token: 0x04006AF0 RID: 27376
		public IXUISprite m_MaskSprite;

		// Token: 0x04006AF1 RID: 27377
		public IXUILabel m_GuildName;

		// Token: 0x04006AF2 RID: 27378
		public Transform m_EmptyWin;

		// Token: 0x04006AF3 RID: 27379
		public GuildArenaDuelResultInfo m_Blue = new GuildArenaDuelResultInfo();

		// Token: 0x04006AF4 RID: 27380
		public GuildArenaDuelResultInfo m_Red = new GuildArenaDuelResultInfo();
	}
}
