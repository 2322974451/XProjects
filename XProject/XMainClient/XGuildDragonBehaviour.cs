using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient
{

	internal class XGuildDragonBehaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			this.m_BtnClose = (base.transform.FindChild("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_BtnRank = (base.transform.FindChild("Bg/Frame/DamageRank").GetComponent("XUIButton") as IXUIButton);
			this.m_BtnGoBattle = (base.transform.FindChild("Bg/Frame/GoBattle").GetComponent("XUIButton") as IXUIButton);
			Transform transform = base.transform.FindChild("Bg/GuildRankPanel/ScrollView");
			this.m_ScrollView = (transform.GetComponent("XUIScrollView") as IXUIScrollView);
			transform = transform.FindChild("WrapContent");
			this.m_WrapContent = (transform.GetComponent("XUIWrapContent") as IXUIWrapContent);
			this.m_RankPanel = base.transform.FindChild("Bg/GuildRankPanel").gameObject;
			this.m_RankPanel_EmptyRank = (base.transform.FindChild("Bg/GuildRankPanel/EmptyRank").GetComponent("XUILabel") as IXUILabel);
			this.m_LeftTime = (base.transform.FindChild("Bg/Frame/LeftTime/Value").GetComponent("XUILabel") as IXUILabel);
			this.m_OpenTime = (base.transform.FindChild("Bg/Frame/LeftTime/sk").GetComponent("XUILabel") as IXUILabel);
			this.m_LeftTimeHint = (base.transform.FindChild("Bg/Frame/LeftTime/Over").GetComponent("XUILabel") as IXUILabel);
			this.m_BossName = (base.transform.FindChild("Bg/Frame/LeftTime/12").GetComponent("XUILabel") as IXUILabel);
			this.m_Condition = (base.transform.FindChild("Bg/Frame/LeftTime/shanghai/shanghai").GetComponent("XUILabel") as IXUILabel);
			this.m_ConditionTitle = (base.transform.FindChild("Bg/Frame/LeftTime/shanghai").GetComponent("XUILabel") as IXUILabel);
			this.m_RewardPanel = base.transform.FindChild("Bg/Frame/RewardDlg").gameObject;
			this.m_BtnReward = (base.transform.FindChild("Bg/Frame/Youxiguize").GetComponent("XUIButton") as IXUIButton);
			this.m_BtnSubscribe = (base.transform.FindChild("Bg/Frame/Subscribe").GetComponent("XUIButton") as IXUIButton);
			this.m_BtnCancelSubscribe = (base.transform.FindChild("Bg/Frame/UnSubscribe").GetComponent("XUIButton") as IXUIButton);
			this.rankInfo = base.transform.FindChild("Bg/GuildRankPanel/RankTpl").gameObject;
			this.rankInfo.SetActive(false);
			this.outofRange = base.transform.FindChild("Bg/GuildRankPanel/OutOfRange").gameObject;
			this.outofRange.SetActive(false);
			this.m_PrivilegeIcon = (base.transform.FindChild("Bg/tq").GetComponent("XUISprite") as IXUISprite);
			this.m_PrivilegeName = (base.transform.FindChild("Bg/tq/t").GetComponent("XUILabel") as IXUILabel);
			this.m_Privilege = (base.transform.FindChild("Bg/tq/p").GetComponent("XUISprite") as IXUISprite);
		}

		public IXUIButton m_BtnClose;

		public IXUIButton m_BtnRank;

		public IXUIButton m_BtnGoBattle;

		public IXUIButton m_BtnSubscribe;

		public IXUIButton m_BtnCancelSubscribe;

		public IXUILabel m_LeftTime;

		public IXUILabel m_OpenTime;

		public IXUILabel m_LeftTimeHint;

		public IXUILabel m_BossName;

		public IXUILabel m_Condition;

		public IXUILabel m_ConditionTitle;

		public IXUIWrapContent m_WrapContent;

		public IXUIScrollView m_ScrollView;

		public GameObject m_RankPanel;

		public IXUILabel m_RankPanel_EmptyRank;

		public IXUIButton m_BtnReward;

		public GameObject m_RewardPanel;

		public GameObject rankInfo;

		public GameObject outofRange;

		public IXUISprite m_PrivilegeIcon;

		public IXUILabel m_PrivilegeName;

		public IXUISprite m_Privilege;
	}
}
