using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class XFreeTeamLeagueMainBehavior : DlgBehaviourBase
	{

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

		public IXUIButton RankBtn;

		public IXUIButton VersusRecordsBtn;

		public IXUIButton FinalResultBtn;

		public IXUIButton CreateTeamBtn;

		public IXUIButton TeamMatchBtn;

		public IXUIButton HonorShopBtn;

		public IXUIButton RankRewardsBtn;

		public IXUIButton TeamQuitBtn;

		public IXUIButton CloseBtn;

		public IXUIButton HelpBtn;

		public IXUILabel TeamNameLabel;

		public IXUILabel TeamScoreLabel;

		public IXUILabel PartInTimesLabel;

		public IXUILabel WinPercentageLabel;

		public IXUILabel ActivityRulesLabel;

		public IXUISprite RankListMask;

		public IXUIWrapContent rankWrapContent;

		public IXUIScrollView rankScrollView;

		public Transform TeamInfoRoot;

		public Transform RankListRoot;

		public Transform RewardsRoot;

		public IXUILabel MyRankLabel;

		public IXUILabel RewardsLeftTimeLabel;

		public IXUILabel MainViewRankLabel;

		public XUIPool MemberUIPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);
	}
}
