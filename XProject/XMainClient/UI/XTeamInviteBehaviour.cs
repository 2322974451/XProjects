using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient.UI
{
	// Token: 0x02001867 RID: 6247
	internal class XTeamInviteBehaviour : DlgBehaviourBase
	{
		// Token: 0x06010435 RID: 66613 RVA: 0x003EEEB0 File Offset: 0x003ED0B0
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

		// Token: 0x040074E7 RID: 29927
		public IXUICheckBox m_ToggleRecommand;

		// Token: 0x040074E8 RID: 29928
		public IXUICheckBox m_ToggleFriend;

		// Token: 0x040074E9 RID: 29929
		public IXUICheckBox m_ToggleGuild;

		// Token: 0x040074EA RID: 29930
		public IXUICheckBox m_TogglePlatFriend;

		// Token: 0x040074EB RID: 29931
		public IXUIScrollView m_ScrollView;

		// Token: 0x040074EC RID: 29932
		public IXUIWrapContent m_WrapContent;

		// Token: 0x040074ED RID: 29933
		public GameObject m_EmptyList;

		// Token: 0x040074EE RID: 29934
		public IXUIButton m_BtnAddFriendBottom;

		// Token: 0x040074EF RID: 29935
		public IXUIButton m_BtnAddFriendMiddle;

		// Token: 0x040074F0 RID: 29936
		public IXUIButton m_BtnJoinGuild;

		// Token: 0x040074F1 RID: 29937
		public IXUISprite m_ClosedSpr;
	}
}
