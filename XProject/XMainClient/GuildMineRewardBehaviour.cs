using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000C15 RID: 3093
	internal class GuildMineRewardBehaviour : DlgBehaviourBase
	{
		// Token: 0x0600AFA7 RID: 44967 RVA: 0x0021575C File Offset: 0x0021395C
		private void Awake()
		{
			this.m_Close = (base.transform.FindChild("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_Help = (base.transform.FindChild("Bg/Help").GetComponent("XUIButton") as IXUIButton);
			this.m_Bg = base.transform.FindChild("Bg");
			this.m_Rank = (base.transform.FindChild("Bg/BtnRank").GetComponent("XUIButton") as IXUIButton);
			this.m_Win = (base.transform.FindChild("Bg/GuildWin/Info").GetComponent("XUILabel") as IXUILabel);
			Transform transform = base.transform.FindChild("Bg/Guild/GuildTpl");
			this.m_GuildPool.SetupPool(null, transform.gameObject, 3U, false);
		}

		// Token: 0x04004304 RID: 17156
		public IXUIButton m_Close;

		// Token: 0x04004305 RID: 17157
		public IXUIButton m_Help;

		// Token: 0x04004306 RID: 17158
		public Transform m_Bg;

		// Token: 0x04004307 RID: 17159
		public IXUIButton m_Rank;

		// Token: 0x04004308 RID: 17160
		public IXUILabel m_Win;

		// Token: 0x04004309 RID: 17161
		public XUIPool m_GuildPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);
	}
}
