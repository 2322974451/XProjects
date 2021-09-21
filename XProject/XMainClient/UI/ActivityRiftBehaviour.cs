using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient.UI
{
	// Token: 0x020016C9 RID: 5833
	internal class ActivityRiftBehaviour : DlgBehaviourBase
	{
		// Token: 0x0600F083 RID: 61571 RVA: 0x0034DB0C File Offset: 0x0034BD0C
		private void Awake()
		{
			this.m_Help = (base.transform.Find("Bg/Stage/Help").GetComponent("XUIButton") as IXUIButton);
			this.mMainClose = (base.transform.FindChild("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_btnFight = (base.transform.FindChild("Bg/Stage/GoBattle").GetComponent("XUIButton") as IXUIButton);
			this.m_lblFight = (base.transform.FindChild("Bg/Stage/fp").GetComponent("XUILabel") as IXUILabel);
			for (int i = 0; i < 4; i++)
			{
				this.m_goRwd[i] = base.transform.FindChild("Bg/Stage/Reward/Item" + i).gameObject;
			}
			for (int j = 0; j < 5; j++)
			{
				this.m_goBuff[j] = base.transform.FindChild("Bg/Stage/Buff/BossBuff" + j).gameObject;
			}
			this.m_tab = base.transform.FindChild("Bg/Rewd/TabsFrame");
			for (int k = 0; k < 3; k++)
			{
				this.m_tabs[k] = (this.m_tab.FindChild("item" + k + "/Bg").GetComponent("XUICheckBox") as IXUICheckBox);
				this.m_reds[k] = (this.m_tabs[k].gameObject.transform.FindChild("RedPoint").GetComponent("XUISprite") as IXUISprite);
			}
			this.m_lbltime = (base.transform.FindChild("Bg/Top/name").GetComponent("XUILabel") as IXUILabel);
			this.m_weekRwd = base.transform.FindChild("Bg/WeekReward").gameObject;
			this.m_lbblMTime = (base.transform.FindChild("Bg/Main/Time").GetComponent("XUILabel") as IXUILabel);
			this.m_lblMFloor = (base.transform.FindChild("Bg/Main/Floor").GetComponent("XUILabel") as IXUILabel);
			this.m_lblMName = (base.transform.FindChild("Bg/Main/Name").GetComponent("XUILabel") as IXUILabel);
			this.m_lbltip = (base.transform.FindChild("Bg/Stage/Buff/Tip").GetComponent("XUILabel") as IXUILabel);
			this.m_lbldesc = (base.transform.FindChild("Bg/Top/Text/T").GetComponent("XUILabel") as IXUILabel);
			this.m_btnShop = (base.transform.FindChild("Bg/btns/BtnShop").GetComponent("XUIButton") as IXUIButton);
			this.m_btnIntro = (base.transform.FindChild("Bg/btns/BtnIntroduce").GetComponent("XUIButton") as IXUIButton);
			this.m_btnMember = (base.transform.FindChild("Bg/btns/BtnMemberRank").GetComponent("XUIButton") as IXUIButton);
			this.m_btnRwd = (base.transform.FindChild("Bg/btns/BtnRwd").GetComponent("XUIButton") as IXUIButton);
			this.m_sprRwdRed = (this.m_btnRwd.gameObject.transform.FindChild("redpoint").GetComponent("XUISprite") as IXUISprite);
			this.m_guildInfoPanel = base.transform.FindChild("Bg/GuildRank").gameObject;
			this.m_frameRankRwd = base.transform.FindChild("Bg/Rewd/frames/RankRewardFrame").gameObject;
			this.m_frameWelfare = base.transform.FindChild("Bg/Rewd/frames/WelfareRewardFrame").gameObject;
			this.m_frameWeek = base.transform.FindChild("Bg/Rewd/frames/weekRewardFrame").gameObject;
		}

		// Token: 0x04006683 RID: 26243
		public IXUIButton m_Help;

		// Token: 0x04006684 RID: 26244
		public IXUIButton mMainClose;

		// Token: 0x04006685 RID: 26245
		public IXUIButton m_btnFight;

		// Token: 0x04006686 RID: 26246
		public IXUILabel m_lblFight;

		// Token: 0x04006687 RID: 26247
		public const int max_rwd = 4;

		// Token: 0x04006688 RID: 26248
		public const int max_buff = 5;

		// Token: 0x04006689 RID: 26249
		public const int max_tab = 3;

		// Token: 0x0400668A RID: 26250
		public GameObject[] m_goRwd = new GameObject[4];

		// Token: 0x0400668B RID: 26251
		public GameObject[] m_goBuff = new GameObject[5];

		// Token: 0x0400668C RID: 26252
		public IXUILabel m_lbltip;

		// Token: 0x0400668D RID: 26253
		public IXUILabel m_lbldesc;

		// Token: 0x0400668E RID: 26254
		public IXUILabel m_lbltime;

		// Token: 0x0400668F RID: 26255
		public GameObject m_weekRwd;

		// Token: 0x04006690 RID: 26256
		public IXUILabel m_lblMFloor;

		// Token: 0x04006691 RID: 26257
		public IXUILabel m_lblMName;

		// Token: 0x04006692 RID: 26258
		public IXUILabel m_lbblMTime;

		// Token: 0x04006693 RID: 26259
		public IXUIButton m_btnShop;

		// Token: 0x04006694 RID: 26260
		public IXUIButton m_btnIntro;

		// Token: 0x04006695 RID: 26261
		public IXUIButton m_btnMember;

		// Token: 0x04006696 RID: 26262
		public IXUIButton m_btnRwd;

		// Token: 0x04006697 RID: 26263
		public IXUISprite m_sprRwdRed;

		// Token: 0x04006698 RID: 26264
		public GameObject m_guildInfoPanel;

		// Token: 0x04006699 RID: 26265
		public GameObject m_frameRankRwd;

		// Token: 0x0400669A RID: 26266
		public GameObject m_frameWelfare;

		// Token: 0x0400669B RID: 26267
		public GameObject m_frameWeek;

		// Token: 0x0400669C RID: 26268
		public Transform m_tab;

		// Token: 0x0400669D RID: 26269
		public IXUICheckBox[] m_tabs = new IXUICheckBox[3];

		// Token: 0x0400669E RID: 26270
		public IXUISprite[] m_reds = new IXUISprite[3];
	}
}
