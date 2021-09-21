using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000C8F RID: 3215
	internal class MobaEntranceBehaviour : DlgBehaviourBase
	{
		// Token: 0x0600B597 RID: 46487 RVA: 0x0023D890 File Offset: 0x0023BA90
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

		// Token: 0x040046FE RID: 18174
		public IXUIButton m_Close;

		// Token: 0x040046FF RID: 18175
		public IXUIButton m_BuyBtn;

		// Token: 0x04004700 RID: 18176
		public IXUILabel m_HeroDescription;

		// Token: 0x04004701 RID: 18177
		public IXUILabel m_HeroName;

		// Token: 0x04004702 RID: 18178
		public IXUILabel m_ExperienceTime;

		// Token: 0x04004703 RID: 18179
		public Transform m_SkillPreViewTs;

		// Token: 0x04004704 RID: 18180
		public Transform m_BattleRecordFrame;

		// Token: 0x04004705 RID: 18181
		public GameObject m_RewardPreViewFrame;

		// Token: 0x04004706 RID: 18182
		public IUIDummy m_Snapshot;

		// Token: 0x04004707 RID: 18183
		public IXUISprite m_SnapDrag;

		// Token: 0x04004708 RID: 18184
		public IXUIButton m_BattleRecordBtn;

		// Token: 0x04004709 RID: 18185
		public IXUIButton m_ShopBtn;

		// Token: 0x0400470A RID: 18186
		public IXUIButton m_RewardPreViewBtn;

		// Token: 0x0400470B RID: 18187
		public IXUIButton m_SingleMatch;

		// Token: 0x0400470C RID: 18188
		public IXUIButton m_TeamMatch;

		// Token: 0x0400470D RID: 18189
		public IXUILabel m_SingleMatchLabel;

		// Token: 0x0400470E RID: 18190
		public XUIPool m_RewardPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x0400470F RID: 18191
		public IXUILabel m_WeekCurrentWin;

		// Token: 0x04004710 RID: 18192
		public IXUISprite m_ClickGet;

		// Token: 0x04004711 RID: 18193
		public GameObject m_HadGet;

		// Token: 0x04004712 RID: 18194
		public IXUILabel m_WeekBattleTips;

		// Token: 0x04004713 RID: 18195
		public Transform m_WeekRewardTs;

		// Token: 0x04004714 RID: 18196
		public IXUIButton m_RewardPreViewCloseBtn;

		// Token: 0x04004715 RID: 18197
		public IXUILabel m_CurrentWinThisWeek;

		// Token: 0x04004716 RID: 18198
		public XUIPool m_PreViewItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04004717 RID: 18199
		public XUIPool m_PreViewBgPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04004718 RID: 18200
		public IXUITexture m_BgTex;

		// Token: 0x04004719 RID: 18201
		public IXUIButton m_RankBtn;

		// Token: 0x0400471A RID: 18202
		public IXUISprite m_PrivilegeIcon;

		// Token: 0x0400471B RID: 18203
		public IXUILabel m_PrivilegeName;

		// Token: 0x0400471C RID: 18204
		public IXUISprite m_Privilege;

		// Token: 0x0400471D RID: 18205
		public XUIPool m_AttributesPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x0400471E RID: 18206
		public XUIPool m_SkillsPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);
	}
}
