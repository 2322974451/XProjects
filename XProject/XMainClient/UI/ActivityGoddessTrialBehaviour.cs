using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x02001706 RID: 5894
	internal class ActivityGoddessTrialBehaviour : DlgBehaviourBase
	{
		// Token: 0x0600F329 RID: 62249 RVA: 0x00362608 File Offset: 0x00360808
		private void Awake()
		{
			this.m_Help = (base.transform.Find("Bg/Help").GetComponent("XUIButton") as IXUIButton);
			Transform transform = base.transform.FindChild("Bg");
			this.m_closedBtn = (transform.FindChild("Close").GetComponent("XUIButton") as IXUIButton);
			this.m_goBattleBtn = (transform.FindChild("GoBattle").GetComponent("XUIButton") as IXUIButton);
			this.m_getBtn = (transform.FindChild("GetRewardBtn").GetComponent("XUIButton") as IXUIButton);
			this.m_shopBtn = (transform.FindChild("BtnShop").GetComponent("XUIButton") as IXUIButton);
			this.m_canJoinTimeslab = (transform.FindChild("times").GetComponent("XUILabel") as IXUILabel);
			this.m_NeedTimesLab = (transform.FindChild("Reward/NeedTimes").GetComponent("XUILabel") as IXUILabel);
			this.m_noTimesGo = transform.FindChild("NoJoinTimesTips").gameObject;
			this.m_hadGetGo = transform.FindChild("HadGet").gameObject;
			transform = transform.FindChild("Reward/Item");
			this.m_ItemPool.SetupPool(transform.gameObject, transform.FindChild("Item").gameObject, 2U, true);
			this.m_canJoinTimeslab.SetText("");
			this.m_NeedTimesLab.SetText("");
		}

		// Token: 0x0400686A RID: 26730
		public IXUILabel m_canJoinTimeslab;

		// Token: 0x0400686B RID: 26731
		public IXUILabel m_NeedTimesLab;

		// Token: 0x0400686C RID: 26732
		public IXUIButton m_goBattleBtn;

		// Token: 0x0400686D RID: 26733
		public IXUIButton m_closedBtn;

		// Token: 0x0400686E RID: 26734
		public IXUIButton m_getBtn;

		// Token: 0x0400686F RID: 26735
		public IXUIButton m_shopBtn;

		// Token: 0x04006870 RID: 26736
		public IXUIButton m_Help;

		// Token: 0x04006871 RID: 26737
		public GameObject m_noTimesGo;

		// Token: 0x04006872 RID: 26738
		public GameObject m_hadGetGo;

		// Token: 0x04006873 RID: 26739
		public XUIPool m_ItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);
	}
}
