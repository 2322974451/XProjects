using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient.UI
{

	internal class ActivityRiftBehaviour : DlgBehaviourBase
	{

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

		public IXUIButton m_Help;

		public IXUIButton mMainClose;

		public IXUIButton m_btnFight;

		public IXUILabel m_lblFight;

		public const int max_rwd = 4;

		public const int max_buff = 5;

		public const int max_tab = 3;

		public GameObject[] m_goRwd = new GameObject[4];

		public GameObject[] m_goBuff = new GameObject[5];

		public IXUILabel m_lbltip;

		public IXUILabel m_lbldesc;

		public IXUILabel m_lbltime;

		public GameObject m_weekRwd;

		public IXUILabel m_lblMFloor;

		public IXUILabel m_lblMName;

		public IXUILabel m_lbblMTime;

		public IXUIButton m_btnShop;

		public IXUIButton m_btnIntro;

		public IXUIButton m_btnMember;

		public IXUIButton m_btnRwd;

		public IXUISprite m_sprRwdRed;

		public GameObject m_guildInfoPanel;

		public GameObject m_frameRankRwd;

		public GameObject m_frameWelfare;

		public GameObject m_frameWeek;

		public Transform m_tab;

		public IXUICheckBox[] m_tabs = new IXUICheckBox[3];

		public IXUISprite[] m_reds = new IXUISprite[3];
	}
}
