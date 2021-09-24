using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class MobaEntranceBehaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			this.m_Close = (base.transform.Find("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_BattleRecordFrame = base.transform.Find("Bg/BattleRecordFrame");
			this.m_RewardPreViewFrame = base.transform.Find("Bg/RewardPreView").gameObject;
			this.m_SkillPreViewTs = base.transform.Find("Bg/SkillPreViewParent");
			Transform transform = base.transform.FindChild("Bg/SkillBtn/SkillBtnTpl");
			this.m_SkillsPool.SetupPool(null, transform.gameObject, MobaEntranceView.SKILL_MAX, false);
			this.m_BuyBtn = (base.transform.Find("Bg/BuyBtn").GetComponent("XUIButton") as IXUIButton);
			this.m_HeroDescription = (base.transform.Find("Bg/Description").GetComponent("XUILabel") as IXUILabel);
			this.m_HeroName = (base.transform.Find("Bg/Name").GetComponent("XUILabel") as IXUILabel);
			this.m_ExperienceTime = (base.transform.Find("Bg/ExperienceTime").GetComponent("XUILabel") as IXUILabel);
			Transform transform2 = base.transform.Find("Bg/CharacterFrame");
			this.m_Snapshot = (transform2.Find("Snapshot").GetComponent("UIDummy") as IUIDummy);
			this.m_SnapDrag = (transform2.Find("SnapDrag").GetComponent("XUISprite") as IXUISprite);
			transform2 = base.transform.Find("Bg/Right");
			this.m_BattleRecordBtn = (transform2.Find("RecordBtn").GetComponent("XUIButton") as IXUIButton);
			this.m_ShopBtn = (transform2.Find("ShopBtn").GetComponent("XUIButton") as IXUIButton);
			this.m_RewardPreViewBtn = (transform2.Find("RewardPreViewBtn").GetComponent("XUIButton") as IXUIButton);
			this.m_SingleMatch = (transform2.Find("SingleMatchBtn").GetComponent("XUIButton") as IXUIButton);
			this.m_TeamMatch = (transform2.Find("TeamMatchBtn").GetComponent("XUIButton") as IXUIButton);
			this.m_SingleMatchLabel = (this.m_SingleMatch.gameObject.transform.Find("T").GetComponent("XUILabel") as IXUILabel);
			Transform transform3 = transform2.Find("WeekReward/RewardTs/ItemTpl");
			this.m_RewardPool.SetupPool(transform3.parent.gameObject, transform3.gameObject, 6U, false);
			this.m_WeekCurrentWin = (transform2.Find("WeekReward/CurrentWin").GetComponent("XUILabel") as IXUILabel);
			this.m_ClickGet = (transform2.Find("WeekReward/ClickGet").GetComponent("XUISprite") as IXUISprite);
			this.m_HadGet = transform2.Find("WeekReward/HadGet").gameObject;
			this.m_WeekBattleTips = (transform2.Find("WeekReward/WeekTips").GetComponent("XUILabel") as IXUILabel);
			this.m_WeekRewardTs = transform2.Find("WeekReward/RewardTs");
			transform2 = base.transform.Find("Bg/RewardPreView");
			this.m_RewardPreViewCloseBtn = (transform2.Find("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_CurrentWinThisWeek = (transform2.Find("Bg/CurrentWin/Text").GetComponent("XUILabel") as IXUILabel);
			transform3 = transform2.Find("Bg/Bg/ScrollView/ItemTpl");
			this.m_PreViewItemPool.SetupPool(transform3.parent.gameObject, transform3.gameObject, 16U, false);
			transform3 = transform2.Find("Bg/Bg/ScrollView/RewardTpl");
			this.m_PreViewBgPool.SetupPool(transform3.parent.gameObject, transform3.gameObject, 4U, false);
			this.m_BgTex = (base.transform.Find("Bg/Bg").GetComponent("XUITexture") as IXUITexture);
			this.m_RankBtn = (base.transform.Find("Bg/Right/RankBtn").GetComponent("XUIButton") as IXUIButton);
			this.m_PrivilegeIcon = (base.transform.FindChild("Bg/tq").GetComponent("XUISprite") as IXUISprite);
			this.m_PrivilegeName = (base.transform.FindChild("Bg/tq/t").GetComponent("XUILabel") as IXUILabel);
			this.m_Privilege = (base.transform.FindChild("Bg/tq/p").GetComponent("XUISprite") as IXUISprite);
			Transform transform4 = base.transform.FindChild("Bg/HeroInfo/HeroInfoTpl");
			this.m_AttributesPool.SetupPool(null, transform4.gameObject, 4U, false);
		}

		public IXUIButton m_Close;

		public IXUIButton m_BuyBtn;

		public IXUILabel m_HeroDescription;

		public IXUILabel m_HeroName;

		public IXUILabel m_ExperienceTime;

		public Transform m_SkillPreViewTs;

		public Transform m_BattleRecordFrame;

		public GameObject m_RewardPreViewFrame;

		public IUIDummy m_Snapshot;

		public IXUISprite m_SnapDrag;

		public IXUIButton m_BattleRecordBtn;

		public IXUIButton m_ShopBtn;

		public IXUIButton m_RewardPreViewBtn;

		public IXUIButton m_SingleMatch;

		public IXUIButton m_TeamMatch;

		public IXUILabel m_SingleMatchLabel;

		public XUIPool m_RewardPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public IXUILabel m_WeekCurrentWin;

		public IXUISprite m_ClickGet;

		public GameObject m_HadGet;

		public IXUILabel m_WeekBattleTips;

		public Transform m_WeekRewardTs;

		public IXUIButton m_RewardPreViewCloseBtn;

		public IXUILabel m_CurrentWinThisWeek;

		public XUIPool m_PreViewItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public XUIPool m_PreViewBgPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public IXUITexture m_BgTex;

		public IXUIButton m_RankBtn;

		public IXUISprite m_PrivilegeIcon;

		public IXUILabel m_PrivilegeName;

		public IXUISprite m_Privilege;

		public XUIPool m_AttributesPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public XUIPool m_SkillsPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);
	}
}
