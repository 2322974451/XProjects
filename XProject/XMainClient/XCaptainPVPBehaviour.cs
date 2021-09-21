using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000CBA RID: 3258
	internal class XCaptainPVPBehaviour : DlgBehaviourBase
	{
		// Token: 0x0600B735 RID: 46901 RVA: 0x00247160 File Offset: 0x00245360
		private void Awake()
		{
			this.m_Close = (base.transform.Find("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_Help = (base.transform.Find("Bg/Help").GetComponent("XUIButton") as IXUIButton);
			this.m_BtnShop = (base.transform.Find("Bg/Right/BtnShop").GetComponent("XUIButton") as IXUIButton);
			this.m_BtnRecord = (base.transform.Find("Bg/Right/BtnRecord").GetComponent("XUIButton") as IXUIButton);
			this.m_BtnStartSingle = (base.transform.Find("Bg/Right/BtnStartSingle").GetComponent("XUIButton") as IXUIButton);
			this.m_BtnStartTeam = (base.transform.Find("Bg/Right/BtnStartTeam").GetComponent("XUIButton") as IXUIButton);
			this.m_BattleRecord = (base.transform.Find("Bg/Left/BattleRecord").GetComponent("XUILabel") as IXUILabel);
			this.m_BoxLabel = (base.transform.Find("Bg/Left/Box/T").GetComponent("XUILabel") as IXUILabel);
			this.m_MatchNum = (base.transform.Find("Bg/Right/MatchNum").GetComponent("XUILabel") as IXUILabel);
			this.m_BtnStartSingleLabel = (base.transform.Find("Bg/Right/BtnStartSingle/T").GetComponent("XUILabel") as IXUILabel);
			this.m_BattleRecordFrame = base.transform.Find("Bg/BattleRecordFrame").gameObject;
			this.m_Bg = base.transform.Find("Bg").gameObject;
			this.m_WeekRewardLabel = (this.m_Bg.transform.Find("WeekReward/T").GetComponent("XUILabel") as IXUILabel);
			this.m_WeekRewardList = this.m_Bg.transform.Find("WeekReward/ListPanel/ItemTpl").gameObject;
			this.m_WeekRewardPool.SetupPool(this.m_WeekRewardList.transform.parent.gameObject, this.m_WeekRewardList, 2U, false);
			this.m_ExRewardLabel = (this.m_Bg.transform.Find("ExReward/T").GetComponent("XUILabel") as IXUILabel);
			this.m_ExRewardList = this.m_Bg.transform.Find("ExReward/ListPanel/ItemTpl").gameObject;
			this.m_ExRewardPool.SetupPool(this.m_ExRewardList.transform.parent.gameObject, this.m_ExRewardList, 2U, false);
		}

		// Token: 0x040047E7 RID: 18407
		public IXUIButton m_Close;

		// Token: 0x040047E8 RID: 18408
		public IXUIButton m_Help;

		// Token: 0x040047E9 RID: 18409
		public IXUIButton m_BtnShop;

		// Token: 0x040047EA RID: 18410
		public IXUIButton m_BtnRecord;

		// Token: 0x040047EB RID: 18411
		public IXUIButton m_BtnStartSingle;

		// Token: 0x040047EC RID: 18412
		public IXUIButton m_BtnStartTeam;

		// Token: 0x040047ED RID: 18413
		public IXUILabel m_BattleRecord;

		// Token: 0x040047EE RID: 18414
		public IXUILabel m_BoxLabel;

		// Token: 0x040047EF RID: 18415
		public IXUILabel m_MatchNum;

		// Token: 0x040047F0 RID: 18416
		public IXUILabel m_BtnStartSingleLabel;

		// Token: 0x040047F1 RID: 18417
		public IXUILabel m_WeekRewardLabel;

		// Token: 0x040047F2 RID: 18418
		public IXUILabel m_ExRewardLabel;

		// Token: 0x040047F3 RID: 18419
		public GameObject m_BattleRecordFrame;

		// Token: 0x040047F4 RID: 18420
		public GameObject m_Bg;

		// Token: 0x040047F5 RID: 18421
		public GameObject m_WeekRewardList;

		// Token: 0x040047F6 RID: 18422
		public GameObject m_ExRewardList;

		// Token: 0x040047F7 RID: 18423
		public XUIPool m_ExRewardPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x040047F8 RID: 18424
		public XUIPool m_WeekRewardPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);
	}
}
