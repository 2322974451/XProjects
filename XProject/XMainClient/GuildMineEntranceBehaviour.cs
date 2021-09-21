using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000C19 RID: 3097
	internal class GuildMineEntranceBehaviour : DlgBehaviourBase
	{
		// Token: 0x0600AFD6 RID: 45014 RVA: 0x00216928 File Offset: 0x00214B28
		private void Awake()
		{
			this.m_Close = (base.transform.FindChild("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_Help = (base.transform.FindChild("Bg/Help").GetComponent("XUIButton") as IXUIButton);
			this.m_Join = (base.transform.FindChild("Bg/Join").GetComponent("XUIButton") as IXUIButton);
			this.m_GameRule = (base.transform.FindChild("Bg/GameRule").GetComponent("XUILabel") as IXUILabel);
			this.m_ActivityTime = (base.transform.FindChild("Bg/Time").GetComponent("XUILabel") as IXUILabel);
			Transform transform = base.transform.FindChild("Bg/ExReward/ListPanel/ItemTpl");
			this.m_RewardPool.SetupPool(null, transform.gameObject, 5U, false);
		}

		// Token: 0x04004322 RID: 17186
		public IXUIButton m_Close;

		// Token: 0x04004323 RID: 17187
		public IXUIButton m_Help;

		// Token: 0x04004324 RID: 17188
		public IXUIButton m_Join;

		// Token: 0x04004325 RID: 17189
		public IXUILabel m_GameRule;

		// Token: 0x04004326 RID: 17190
		public IXUILabel m_ActivityTime;

		// Token: 0x04004327 RID: 17191
		public XUIPool m_RewardPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);
	}
}
