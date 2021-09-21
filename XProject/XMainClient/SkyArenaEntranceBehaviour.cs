using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000CB2 RID: 3250
	internal class SkyArenaEntranceBehaviour : DlgBehaviourBase
	{
		// Token: 0x0600B6F0 RID: 46832 RVA: 0x00245A5C File Offset: 0x00243C5C
		private void Awake()
		{
			this.m_Bg = base.transform.FindChild("Bg");
			this.m_Close = (base.transform.FindChild("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_Help = (base.transform.FindChild("Bg/Help").GetComponent("XUIButton") as IXUIButton);
			this.m_SingleJoin = (base.transform.FindChild("Bg/SingleJoin").GetComponent("XUIButton") as IXUIButton);
			this.m_TeamJoin = (base.transform.FindChild("Bg/TeamJoin").GetComponent("XUIButton") as IXUIButton);
			this.m_RewardBtn = (base.transform.FindChild("Bg/PointRewardBtn").GetComponent("XUIButton") as IXUIButton);
			Transform transform = base.transform.FindChild("Bg/Reward/ItemTpl");
			this.m_RewardPool.SetupPool(null, transform.gameObject, 5U, false);
			this.m_Time = (base.transform.FindChild("Bg/Time").GetComponent("XUILabel") as IXUILabel);
		}

		// Token: 0x040047B3 RID: 18355
		public Transform m_Bg;

		// Token: 0x040047B4 RID: 18356
		public IXUIButton m_Close;

		// Token: 0x040047B5 RID: 18357
		public IXUIButton m_Help;

		// Token: 0x040047B6 RID: 18358
		public IXUIButton m_SingleJoin;

		// Token: 0x040047B7 RID: 18359
		public IXUIButton m_TeamJoin;

		// Token: 0x040047B8 RID: 18360
		public IXUIButton m_RewardBtn;

		// Token: 0x040047B9 RID: 18361
		public IXUILabel m_Time;

		// Token: 0x040047BA RID: 18362
		public XUIPool m_RewardPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);
	}
}
