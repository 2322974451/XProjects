using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XWorldBossBehaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			this.m_BtnClose = (base.transform.FindChild("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_BtnGoBattle = (base.transform.FindChild("Bg/Frame/GoBattle").GetComponent("XUIButton") as IXUIButton);
			Transform transform = base.transform.FindChild("Bg/GuildRankPanel/ScrollView");
			this.m_ScrollView = (transform.GetComponent("XUIScrollView") as IXUIScrollView);
			transform = transform.FindChild("WrapContent");
			this.m_WrapContent = (transform.GetComponent("XUIWrapContent") as IXUIWrapContent);
			this.m_RankPanel = base.transform.FindChild("Bg/GuildRankPanel").gameObject;
			this.m_RankPanel_EmptyRank = (base.transform.FindChild("Bg/GuildRankPanel/EmptyRank").GetComponent("XUILabel") as IXUILabel);
			GameObject gameObject = this.m_RankPanel.transform.FindChild("RankTpl").gameObject;
			GameObject gameObject2 = this.m_RankPanel.transform.FindChild("OutOfRange").gameObject;
			gameObject.gameObject.SetActive(false);
			gameObject2.gameObject.SetActive(false);
			this.m_RankPanel_EmptyRank.gameObject.SetActive(false);
			this.m_OpenTime = (base.transform.FindChild("Bg/Frame/LeftTime/sk").GetComponent("XUILabel") as IXUILabel);
			this.m_LeftTime = (base.transform.FindChild("Bg/Frame/LeftTime/Value").GetComponent("XUILabel") as IXUILabel);
			this.m_LeftTimeHint = (base.transform.FindChild("Bg/Frame/LeftTime/Over").GetComponent("XUILabel") as IXUILabel);
			this.m_BossName = (base.transform.FindChild("Bg/Frame/LeftTime/12").GetComponent("XUILabel") as IXUILabel);
			this.m_LeftTime.SetText("");
			this.m_LeftTimeHint.SetText("");
			this.m_OpenTime.SetText("");
			this.m_BossName.SetText("");
			this.m_RewardPanel = base.transform.FindChild("Bg/Frame/RewardDlg").gameObject;
			this.m_BtnReward = (base.transform.FindChild("Bg/Frame/AwardDetail").GetComponent("XUIButton") as IXUIButton);
			this.m_BtnRewardPanelClose = (base.transform.FindChild("Bg/Frame/RewardDlg/Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_DropAward = (base.transform.FindChild("Bg/Frame/DropFrame/Grid").GetComponent("XUIList") as IXUIList);
			Transform transform2 = this.m_DropAward.gameObject.transform.FindChild("ItemTpl");
			this.m_DropAwardPool.SetupPool(transform2.parent.parent.gameObject, transform2.gameObject, 6U, false);
			this.m_AwardScrollView = (base.transform.FindChild("Bg/Frame/RewardDlg/Bg/Bg/ScrollView").GetComponent("XUIScrollView") as IXUIScrollView);
			this.m_AwardWrapContent = (this.m_AwardScrollView.gameObject.transform.FindChild("AwardList").GetComponent("XUIWrapContent") as IXUIWrapContent);
			this.m_AwardTip = (base.transform.FindChild("Bg/Frame/RewardDlg/Bg/Bg/Tip").GetComponent("XUILabel") as IXUILabel);
			this.m_BossTexture = (base.transform.Find("Bg/Frame/BossTexture").GetComponent("XUITexture") as IXUITexture);
			this.m_GuildRankTab = (base.transform.Find("Bg/GuildRankPanel/TabTpl/ToggleGuild").GetComponent("XUICheckBox") as IXUICheckBox);
			this.m_DamageRankTab = (base.transform.Find("Bg/GuildRankPanel/TabTpl/ToggleFriend").GetComponent("XUICheckBox") as IXUICheckBox);
			this.m_BtnSubscribe = (base.transform.FindChild("Bg/Frame/Subscribe").GetComponent("XUIButton") as IXUIButton);
			this.m_BtnCancelSubscribe = (base.transform.FindChild("Bg/Frame/UnSubscribe").GetComponent("XUIButton") as IXUIButton);
			this.m_PrivilegeIcon = (base.transform.FindChild("Bg/tq").GetComponent("XUISprite") as IXUISprite);
			this.m_PrivilegeName = (base.transform.FindChild("Bg/tq/t").GetComponent("XUILabel") as IXUILabel);
			this.m_Privilege = (base.transform.FindChild("Bg/tq/p").GetComponent("XUISprite") as IXUISprite);
		}

		public IXUIButton m_BtnClose;

		public IXUIButton m_BtnGoBattle;

		public IXUIButton m_BtnSubscribe;

		public IXUIButton m_BtnCancelSubscribe;

		public IXUILabel m_LeftTime;

		public IXUILabel m_LeftTimeHint;

		public IXUILabel m_BossName;

		public IXUILabel m_OpenTime;

		public IXUIWrapContent m_WrapContent;

		public IXUIScrollView m_ScrollView;

		public IXUIWrapContent m_AwardWrapContent;

		public IXUIScrollView m_AwardScrollView;

		public GameObject m_RankPanel;

		public IXUILabel m_RankPanel_EmptyRank;

		public IXUIButton m_BtnReward;

		public GameObject m_RewardPanel;

		public IXUIButton m_BtnRewardPanelClose;

		public IXUIList m_DropAward;

		public XUIPool m_DropAwardPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public IXUILabel m_AwardTip;

		public IXUITexture m_BossTexture;

		public IXUICheckBox m_GuildRankTab;

		public IXUICheckBox m_DamageRankTab;

		public IXUISprite m_PrivilegeIcon;

		public IXUILabel m_PrivilegeName;

		public IXUISprite m_Privilege;
	}
}
