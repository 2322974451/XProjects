using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000C28 RID: 3112
	internal class HeroBattleBehaviour : DlgBehaviourBase
	{
		// Token: 0x0600B064 RID: 45156 RVA: 0x0021A5D4 File Offset: 0x002187D4
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

		// Token: 0x0400439B RID: 17307
		public IXUIButton m_Close;

		// Token: 0x0400439C RID: 17308
		public IXUIButton m_SkillPreViewBtn;

		// Token: 0x0400439D RID: 17309
		public IXUIButton m_BuyBtn;

		// Token: 0x0400439E RID: 17310
		public IXUILabel m_HeroDescription;

		// Token: 0x0400439F RID: 17311
		public IXUILabel m_HeroName;

		// Token: 0x040043A0 RID: 17312
		public IXUILabel m_ExperienceTime;

		// Token: 0x040043A1 RID: 17313
		public Transform m_SkillPreViewTs;

		// Token: 0x040043A2 RID: 17314
		public GameObject m_BattleRecordFrame;

		// Token: 0x040043A3 RID: 17315
		public GameObject m_RewardPreViewFrame;

		// Token: 0x040043A4 RID: 17316
		public IUIDummy m_Snapshot;

		// Token: 0x040043A5 RID: 17317
		public IXUISprite m_SnapDrag;

		// Token: 0x040043A6 RID: 17318
		public IXUIButton m_BattleRecordBtn;

		// Token: 0x040043A7 RID: 17319
		public IXUIButton m_ShopBtn;

		// Token: 0x040043A8 RID: 17320
		public IXUIButton m_RewardPreViewBtn;

		// Token: 0x040043A9 RID: 17321
		public IXUIButton m_SingleMatch;

		// Token: 0x040043AA RID: 17322
		public IXUIButton m_TeamMatch;

		// Token: 0x040043AB RID: 17323
		public IXUILabel m_SingleMatchLabel;

		// Token: 0x040043AC RID: 17324
		public IXUILabel m_BattleTotal;

		// Token: 0x040043AD RID: 17325
		public IXUILabel m_BattleWin;

		// Token: 0x040043AE RID: 17326
		public IXUILabel m_BattleLose;

		// Token: 0x040043AF RID: 17327
		public IXUILabel m_BattleRate;

		// Token: 0x040043B0 RID: 17328
		public XUIPool m_RewardPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x040043B1 RID: 17329
		public IXUILabel m_WeekCurrentWin;

		// Token: 0x040043B2 RID: 17330
		public IXUISprite m_ClickGet;

		// Token: 0x040043B3 RID: 17331
		public GameObject m_HadGet;

		// Token: 0x040043B4 RID: 17332
		public IXUILabel m_BattleTips;

		// Token: 0x040043B5 RID: 17333
		public IXUILabel m_WeekBattleTips;

		// Token: 0x040043B6 RID: 17334
		public Transform m_WeekRewardTs;

		// Token: 0x040043B7 RID: 17335
		public Transform m_DayRewardTs;

		// Token: 0x040043B8 RID: 17336
		public IXUIButton m_RewardPreViewCloseBtn;

		// Token: 0x040043B9 RID: 17337
		public IXUILabel m_CurrentWinThisWeek;

		// Token: 0x040043BA RID: 17338
		public XUIPool m_PreViewItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x040043BB RID: 17339
		public XUIPool m_PreViewBgPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x040043BC RID: 17340
		public IXUITexture m_BgTex;

		// Token: 0x040043BD RID: 17341
		public IXUIButton m_RankBtn;

		// Token: 0x040043BE RID: 17342
		public GameObject m_RankFrame;

		// Token: 0x040043BF RID: 17343
		public IXUIButton m_RankCloseBtn;

		// Token: 0x040043C0 RID: 17344
		public IXUIWrapContent m_RankWrapContent;

		// Token: 0x040043C1 RID: 17345
		public IXUIScrollView m_RankScrollView;

		// Token: 0x040043C2 RID: 17346
		public Transform m_MyRankTs;

		// Token: 0x040043C3 RID: 17347
		public GameObject m_OutOfRank;

		// Token: 0x040043C4 RID: 17348
		public IXUISprite m_PrivilegeIcon;

		// Token: 0x040043C5 RID: 17349
		public IXUILabel m_PrivilegeName;

		// Token: 0x040043C6 RID: 17350
		public IXUISprite m_Privilege;

		// Token: 0x040043C7 RID: 17351
		public IXUISprite m_ResearchBtn;
	}
}
