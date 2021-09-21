using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient
{
	// Token: 0x02000E92 RID: 3730
	internal class XWorldBossEndRankBehaviour : DlgBehaviourBase
	{
		// Token: 0x0600C729 RID: 50985 RVA: 0x002C2EF4 File Offset: 0x002C10F4
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

		// Token: 0x04005778 RID: 22392
		public IXUIButton m_BtnClose;

		// Token: 0x04005779 RID: 22393
		public IXUIButton m_BtnGoReward;

		// Token: 0x0400577A RID: 22394
		public IXUIWrapContent m_WrapContent;

		// Token: 0x0400577B RID: 22395
		public IXUIScrollView m_ScrollView;

		// Token: 0x0400577C RID: 22396
		public GameObject m_RankPanel;

		// Token: 0x0400577D RID: 22397
		public IXUILabel m_RankPanel_EmptyRank;

		// Token: 0x0400577E RID: 22398
		public GameObject m_MyRank;

		// Token: 0x0400577F RID: 22399
		public GameObject m_MyOutOfRange;

		// Token: 0x04005780 RID: 22400
		public IXUICheckBox m_GuildRankTab;

		// Token: 0x04005781 RID: 22401
		public IXUICheckBox m_DamageRankTab;

		// Token: 0x04005782 RID: 22402
		public IXUILabel m_RankTitle;
	}
}
