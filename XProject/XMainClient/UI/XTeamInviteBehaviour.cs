using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient.UI
{

	internal class XTeamInviteBehaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			this.m_ToggleRecommand = (base.transform.FindChild("Bg/ToggleRecommand").GetComponent("XUICheckBox") as IXUICheckBox);
			this.m_ToggleFriend = (base.transform.FindChild("Bg/ToggleFriend").GetComponent("XUICheckBox") as IXUICheckBox);
			this.m_ToggleGuild = (base.transform.FindChild("Bg/ToggleGuild").GetComponent("XUICheckBox") as IXUICheckBox);
			this.m_TogglePlatFriend = (base.transform.FindChild("Bg/TogglePlatFriend").GetComponent("XUICheckBox") as IXUICheckBox);
			this.m_ToggleRecommand.ID = 0UL;
			this.m_ToggleFriend.ID = 1UL;
			this.m_ToggleGuild.ID = 2UL;
			this.m_TogglePlatFriend.ID = 3UL;
			this.m_ScrollView = (base.transform.FindChild("Bg/Panel").GetComponent("XUIScrollView") as IXUIScrollView);
			this.m_WrapContent = (base.transform.FindChild("Bg/Panel/WrapContent").GetComponent("XUIWrapContent") as IXUIWrapContent);
			this.m_EmptyList = base.transform.FindChild("Bg/Empty").gameObject;
			this.m_BtnAddFriendBottom = (base.transform.Find("Bg/BtnAddFriendBottom").GetComponent("XUIButton") as IXUIButton);
			this.m_BtnAddFriendMiddle = (base.transform.Find("Bg/BtnAddFriendMiddle").GetComponent("XUIButton") as IXUIButton);
			this.m_BtnJoinGuild = (base.transform.Find("Bg/BtnJoinGuild").GetComponent("XUIButton") as IXUIButton);
			this.m_ClosedSpr = (base.transform.FindChild("Bg/Close").GetComponent("XUISprite") as IXUISprite);
		}

		public IXUICheckBox m_ToggleRecommand;

		public IXUICheckBox m_ToggleFriend;

		public IXUICheckBox m_ToggleGuild;

		public IXUICheckBox m_TogglePlatFriend;

		public IXUIScrollView m_ScrollView;

		public IXUIWrapContent m_WrapContent;

		public GameObject m_EmptyList;

		public IXUIButton m_BtnAddFriendBottom;

		public IXUIButton m_BtnAddFriendMiddle;

		public IXUIButton m_BtnJoinGuild;

		public IXUISprite m_ClosedSpr;
	}
}
