using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class HeroBattleBehaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			this.m_Close = (base.transform.Find("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_BattleRecordFrame = base.transform.Find("Bg/BattleRecordFrame").gameObject;
			this.m_RewardPreViewFrame = base.transform.Find("Bg/RewardPreView").gameObject;
			this.m_SkillPreViewTs = base.transform.Find("Bg/SkillPreViewParent");
			this.m_SkillPreViewBtn = (base.transform.Find("Bg/SkillBtn").GetComponent("XUIButton") as IXUIButton);
			this.m_BuyBtn = (base.transform.Find("Bg/BuyBtn").GetComponent("XUIButton") as IXUIButton);
			this.m_HeroDescription = (base.transform.Find("Bg/Description").GetComponent("XUILabel") as IXUILabel);
			this.m_HeroName = (base.transform.Find("Bg/Name").GetComponent("XUILabel") as IXUILabel);
			this.m_ExperienceTime = (base.transform.Find("Bg/ExperienceTime").GetComponent("XUILabel") as IXUILabel);
			Transform transform = base.transform.Find("Bg/CharacterFrame");
			this.m_Snapshot = (transform.Find("Snapshot").GetComponent("UIDummy") as IUIDummy);
			this.m_SnapDrag = (transform.Find("SnapDrag").GetComponent("XUISprite") as IXUISprite);
			transform = base.transform.Find("Bg/Right");
			this.m_BattleRecordBtn = (transform.Find("RecordBtn").GetComponent("XUIButton") as IXUIButton);
			this.m_ShopBtn = (transform.Find("ShopBtn").GetComponent("XUIButton") as IXUIButton);
			this.m_RewardPreViewBtn = (transform.Find("RewardPreViewBtn").GetComponent("XUIButton") as IXUIButton);
			this.m_SingleMatch = (transform.Find("SingleMatchBtn").GetComponent("XUIButton") as IXUIButton);
			this.m_TeamMatch = (transform.Find("TeamMatchBtn").GetComponent("XUIButton") as IXUIButton);
			this.m_SingleMatchLabel = (this.m_SingleMatch.gameObject.transform.Find("T").GetComponent("XUILabel") as IXUILabel);
			this.m_BattleTotal = (transform.Find("BattleInfo/BattleInfo0").GetComponent("XUILabel") as IXUILabel);
			this.m_BattleWin = (transform.Find("BattleInfo/BattleInfo2").GetComponent("XUILabel") as IXUILabel);
			this.m_BattleLose = (transform.Find("BattleInfo/BattleInfo3").GetComponent("XUILabel") as IXUILabel);
			this.m_BattleRate = (transform.Find("BattleInfo/BattleInfo1").GetComponent("XUILabel") as IXUILabel);
			Transform transform2 = transform.Find("WeekReward/RewardTs/ItemTpl");
			this.m_RewardPool.SetupPool(transform2.parent.gameObject, transform2.gameObject, 6U, false);
			this.m_WeekCurrentWin = (transform.Find("WeekReward/CurrentWin").GetComponent("XUILabel") as IXUILabel);
			this.m_ClickGet = (transform.Find("WeekReward/ClickGet").GetComponent("XUISprite") as IXUISprite);
			this.m_HadGet = transform.Find("WeekReward/HadGet").gameObject;
			this.m_WeekBattleTips = (transform.Find("WeekReward/WeekTips").GetComponent("XUILabel") as IXUILabel);
			this.m_BattleTips = (transform.Find("ExReward/BattleTips").GetComponent("XUILabel") as IXUILabel);
			this.m_WeekRewardTs = transform.Find("WeekReward/RewardTs");
			this.m_DayRewardTs = transform.Find("ExReward/RewardTs");
			transform = base.transform.Find("Bg/RewardPreView");
			this.m_RewardPreViewCloseBtn = (transform.Find("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_CurrentWinThisWeek = (transform.Find("Bg/CurrentWin/Text").GetComponent("XUILabel") as IXUILabel);
			transform2 = transform.Find("Bg/Bg/ScrollView/ItemTpl");
			this.m_PreViewItemPool.SetupPool(transform2.parent.gameObject, transform2.gameObject, 16U, false);
			transform2 = transform.Find("Bg/Bg/ScrollView/RewardTpl");
			this.m_PreViewBgPool.SetupPool(transform2.parent.gameObject, transform2.gameObject, 4U, false);
			this.m_BgTex = (base.transform.Find("Bg/Bg").GetComponent("XUITexture") as IXUITexture);
			this.m_RankBtn = (base.transform.Find("Bg/Right/RankBtn").GetComponent("XUIButton") as IXUIButton);
			this.m_RankFrame = base.transform.Find("Bg/RankFrame").gameObject;
			this.m_RankCloseBtn = (this.m_RankFrame.transform.Find("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_RankWrapContent = (this.m_RankFrame.transform.Find("Bg/Panel/QualifyList").GetComponent("XUIWrapContent") as IXUIWrapContent);
			this.m_RankScrollView = (this.m_RankFrame.transform.Find("Bg/Panel").GetComponent("XUIScrollView") as IXUIScrollView);
			this.m_MyRankTs = this.m_RankFrame.transform.Find("Bg/MyRankFrame/QualifyList/Tpl");
			this.m_OutOfRank = this.m_RankFrame.transform.Find("Bg/MyRankFrame/QualifyList/OutOfRange").gameObject;
			this.m_PrivilegeIcon = (base.transform.FindChild("Bg/tq").GetComponent("XUISprite") as IXUISprite);
			this.m_PrivilegeName = (base.transform.FindChild("Bg/tq/t").GetComponent("XUILabel") as IXUILabel);
			this.m_Privilege = (base.transform.FindChild("Bg/tq/p").GetComponent("XUISprite") as IXUISprite);
			this.m_ResearchBtn = (base.transform.FindChild("Bg/ResearchBtn").GetComponent("XUISprite") as IXUISprite);
		}

		public IXUIButton m_Close;

		public IXUIButton m_SkillPreViewBtn;

		public IXUIButton m_BuyBtn;

		public IXUILabel m_HeroDescription;

		public IXUILabel m_HeroName;

		public IXUILabel m_ExperienceTime;

		public Transform m_SkillPreViewTs;

		public GameObject m_BattleRecordFrame;

		public GameObject m_RewardPreViewFrame;

		public IUIDummy m_Snapshot;

		public IXUISprite m_SnapDrag;

		public IXUIButton m_BattleRecordBtn;

		public IXUIButton m_ShopBtn;

		public IXUIButton m_RewardPreViewBtn;

		public IXUIButton m_SingleMatch;

		public IXUIButton m_TeamMatch;

		public IXUILabel m_SingleMatchLabel;

		public IXUILabel m_BattleTotal;

		public IXUILabel m_BattleWin;

		public IXUILabel m_BattleLose;

		public IXUILabel m_BattleRate;

		public XUIPool m_RewardPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public IXUILabel m_WeekCurrentWin;

		public IXUISprite m_ClickGet;

		public GameObject m_HadGet;

		public IXUILabel m_BattleTips;

		public IXUILabel m_WeekBattleTips;

		public Transform m_WeekRewardTs;

		public Transform m_DayRewardTs;

		public IXUIButton m_RewardPreViewCloseBtn;

		public IXUILabel m_CurrentWinThisWeek;

		public XUIPool m_PreViewItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public XUIPool m_PreViewBgPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public IXUITexture m_BgTex;

		public IXUIButton m_RankBtn;

		public GameObject m_RankFrame;

		public IXUIButton m_RankCloseBtn;

		public IXUIWrapContent m_RankWrapContent;

		public IXUIScrollView m_RankScrollView;

		public Transform m_MyRankTs;

		public GameObject m_OutOfRank;

		public IXUISprite m_PrivilegeIcon;

		public IXUILabel m_PrivilegeName;

		public IXUISprite m_Privilege;

		public IXUISprite m_ResearchBtn;
	}
}
