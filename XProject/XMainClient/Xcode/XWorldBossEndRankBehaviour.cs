using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient
{

	internal class XWorldBossEndRankBehaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			this.m_BtnClose = (base.transform.FindChild("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_BtnGoReward = (base.transform.FindChild("Bg/BtnStart").GetComponent("XUIButton") as IXUIButton);
			this.m_ScrollView = (base.transform.FindChild("Bg/Bg/Panel").GetComponent("XUIScrollView") as IXUIScrollView);
			this.m_WrapContent = (base.transform.FindChild("Bg/Bg/Panel/BaseList").GetComponent("XUIWrapContent") as IXUIWrapContent);
			this.m_RankPanel = base.transform.FindChild("Bg/Bg/Panel").gameObject;
			this.m_RankPanel_EmptyRank = (base.transform.FindChild("Bg/Bg/Panel/EmptyRank").GetComponent("XUILabel") as IXUILabel);
			this.m_MyRank = base.transform.FindChild("Bg/Bg/RankTpl").gameObject;
			this.m_MyOutOfRange = base.transform.FindChild("Bg/Bg/OutOfRange").gameObject;
			this.m_MyRank.SetActive(false);
			this.m_MyOutOfRange.SetActive(false);
			this.m_RankPanel_EmptyRank.gameObject.SetActive(false);
			this.m_GuildRankTab = (base.transform.Find("Bg/TabTpl/ToggleGuild").GetComponent("XUICheckBox") as IXUICheckBox);
			this.m_DamageRankTab = (base.transform.Find("Bg/TabTpl/ToggleFriend").GetComponent("XUICheckBox") as IXUICheckBox);
			this.m_RankTitle = (base.transform.Find("Bg/Bg/Titles/BaseList/Name").GetComponent("XUILabel") as IXUILabel);
		}

		public IXUIButton m_BtnClose;

		public IXUIButton m_BtnGoReward;

		public IXUIWrapContent m_WrapContent;

		public IXUIScrollView m_ScrollView;

		public GameObject m_RankPanel;

		public IXUILabel m_RankPanel_EmptyRank;

		public GameObject m_MyRank;

		public GameObject m_MyOutOfRange;

		public IXUICheckBox m_GuildRankTab;

		public IXUICheckBox m_DamageRankTab;

		public IXUILabel m_RankTitle;
	}
}
