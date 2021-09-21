using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient
{
	// Token: 0x02000E3F RID: 3647
	internal class XGuildDragonBehaviour : DlgBehaviourBase
	{
		// Token: 0x0600C3F2 RID: 50162 RVA: 0x002AA2D8 File Offset: 0x002A84D8
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

		// Token: 0x040054F4 RID: 21748
		public IXUIButton m_BtnClose;

		// Token: 0x040054F5 RID: 21749
		public IXUIButton m_BtnRank;

		// Token: 0x040054F6 RID: 21750
		public IXUIButton m_BtnGoBattle;

		// Token: 0x040054F7 RID: 21751
		public IXUIButton m_BtnSubscribe;

		// Token: 0x040054F8 RID: 21752
		public IXUIButton m_BtnCancelSubscribe;

		// Token: 0x040054F9 RID: 21753
		public IXUILabel m_LeftTime;

		// Token: 0x040054FA RID: 21754
		public IXUILabel m_OpenTime;

		// Token: 0x040054FB RID: 21755
		public IXUILabel m_LeftTimeHint;

		// Token: 0x040054FC RID: 21756
		public IXUILabel m_BossName;

		// Token: 0x040054FD RID: 21757
		public IXUILabel m_Condition;

		// Token: 0x040054FE RID: 21758
		public IXUILabel m_ConditionTitle;

		// Token: 0x040054FF RID: 21759
		public IXUIWrapContent m_WrapContent;

		// Token: 0x04005500 RID: 21760
		public IXUIScrollView m_ScrollView;

		// Token: 0x04005501 RID: 21761
		public GameObject m_RankPanel;

		// Token: 0x04005502 RID: 21762
		public IXUILabel m_RankPanel_EmptyRank;

		// Token: 0x04005503 RID: 21763
		public IXUIButton m_BtnReward;

		// Token: 0x04005504 RID: 21764
		public GameObject m_RewardPanel;

		// Token: 0x04005505 RID: 21765
		public GameObject rankInfo;

		// Token: 0x04005506 RID: 21766
		public GameObject outofRange;

		// Token: 0x04005507 RID: 21767
		public IXUISprite m_PrivilegeIcon;

		// Token: 0x04005508 RID: 21768
		public IXUILabel m_PrivilegeName;

		// Token: 0x04005509 RID: 21769
		public IXUISprite m_Privilege;
	}
}
