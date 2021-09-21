using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x0200173D RID: 5949
	internal class XFreeTeamLeagueMainBehavior : DlgBehaviourBase
	{
		// Token: 0x0600F5E8 RID: 62952 RVA: 0x0037A43C File Offset: 0x0037863C
		private void Awake()
		{
			this.HonorShopBtn = (base.transform.Find("Bg/TitleBarFrame/BtnShop").GetComponent("XUIButton") as IXUIButton);
			this.RankBtn = (base.transform.Find("Bg/TitleBarFrame/BtnRank").GetComponent("XUIButton") as IXUIButton);
			this.VersusRecordsBtn = (base.transform.Find("Bg/TitleBarFrame/BtnChallengeRecord").GetComponent("XUIButton") as IXUIButton);
			this.FinalResultBtn = (base.transform.Find("Bg/TitleBarFrame/BtnFinalResult").GetComponent("XUIButton") as IXUIButton);
			this.RankRewardsBtn = (base.transform.Find("Bg/TitleBarFrame/BtnRankReward").GetComponent("XUIButton") as IXUIButton);
			this.TeamMatchBtn = (base.transform.Find("Bg/BeginMatch").GetComponent("XUIButton") as IXUIButton);
			this.CreateTeamBtn = (base.transform.Find("Bg/BtnOrganize").GetComponent("XUIButton") as IXUIButton);
			this.TeamQuitBtn = (base.transform.Find("Bg/BtnQuit").GetComponent("XUIButton") as IXUIButton);
			this.CloseBtn = (base.transform.Find("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.HelpBtn = (base.transform.Find("Bg/Help").GetComponent("XUIButton") as IXUIButton);
			this.TeamNameLabel = (base.transform.Find("Bg/TeamInfo/Name/Content").GetComponent("XUILabel") as IXUILabel);
			this.TeamScoreLabel = (base.transform.Find("Bg/TeamInfo/Score/Content").GetComponent("XUILabel") as IXUILabel);
			this.PartInTimesLabel = (base.transform.Find("Bg/TeamInfo/Frequency/Content").GetComponent("XUILabel") as IXUILabel);
			this.WinPercentageLabel = (base.transform.Find("Bg/TeamInfo/Rating/Content").GetComponent("XUILabel") as IXUILabel);
			this.ActivityRulesLabel = (base.transform.Find("Bg/Intro/rules").GetComponent("XUILabel") as IXUILabel);
			this.rankScrollView = (base.transform.Find("Bg/RankList/ScrollView").GetComponent("XUIScrollView") as IXUIScrollView);
			this.rankWrapContent = (base.transform.Find("Bg/RankList/ScrollView/WrapContent").GetComponent("XUIWrapContent") as IXUIWrapContent);
			this.TeamInfoRoot = base.transform.Find("Bg/TeamInfo");
			this.RankListRoot = base.transform.Find("Bg/RankList");
			this.RankListMask = (this.RankListRoot.Find("Mask").GetComponent("XUISprite") as IXUISprite);
			this.RewardsRoot = base.transform.Find("Bg/Rewards/Root");
			this.MainViewRankLabel = (base.transform.Find("Bg/TeamInfo/Rank/Content").GetComponent("XUILabel") as IXUILabel);
			this.MyRankLabel = (this.RankListRoot.Find("BestRank/Text").GetComponent("XUILabel") as IXUILabel);
			this.RewardsLeftTimeLabel = (this.RankListRoot.Find("LeftTime").GetComponent("XUILabel") as IXUILabel);
			this.MemberUIPool.SetupPool(base.transform.Find("Bg/TeamList").gameObject, base.transform.Find("Bg/TeamList/MemberTpl").gameObject, 4U, false);
		}

		// Token: 0x04006A9B RID: 27291
		public IXUIButton RankBtn;

		// Token: 0x04006A9C RID: 27292
		public IXUIButton VersusRecordsBtn;

		// Token: 0x04006A9D RID: 27293
		public IXUIButton FinalResultBtn;

		// Token: 0x04006A9E RID: 27294
		public IXUIButton CreateTeamBtn;

		// Token: 0x04006A9F RID: 27295
		public IXUIButton TeamMatchBtn;

		// Token: 0x04006AA0 RID: 27296
		public IXUIButton HonorShopBtn;

		// Token: 0x04006AA1 RID: 27297
		public IXUIButton RankRewardsBtn;

		// Token: 0x04006AA2 RID: 27298
		public IXUIButton TeamQuitBtn;

		// Token: 0x04006AA3 RID: 27299
		public IXUIButton CloseBtn;

		// Token: 0x04006AA4 RID: 27300
		public IXUIButton HelpBtn;

		// Token: 0x04006AA5 RID: 27301
		public IXUILabel TeamNameLabel;

		// Token: 0x04006AA6 RID: 27302
		public IXUILabel TeamScoreLabel;

		// Token: 0x04006AA7 RID: 27303
		public IXUILabel PartInTimesLabel;

		// Token: 0x04006AA8 RID: 27304
		public IXUILabel WinPercentageLabel;

		// Token: 0x04006AA9 RID: 27305
		public IXUILabel ActivityRulesLabel;

		// Token: 0x04006AAA RID: 27306
		public IXUISprite RankListMask;

		// Token: 0x04006AAB RID: 27307
		public IXUIWrapContent rankWrapContent;

		// Token: 0x04006AAC RID: 27308
		public IXUIScrollView rankScrollView;

		// Token: 0x04006AAD RID: 27309
		public Transform TeamInfoRoot;

		// Token: 0x04006AAE RID: 27310
		public Transform RankListRoot;

		// Token: 0x04006AAF RID: 27311
		public Transform RewardsRoot;

		// Token: 0x04006AB0 RID: 27312
		public IXUILabel MyRankLabel;

		// Token: 0x04006AB1 RID: 27313
		public IXUILabel RewardsLeftTimeLabel;

		// Token: 0x04006AB2 RID: 27314
		public IXUILabel MainViewRankLabel;

		// Token: 0x04006AB3 RID: 27315
		public XUIPool MemberUIPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);
	}
}
