using System;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class GuildMineMainBehaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			this.m_Close = (base.transform.FindChild("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_Help = (base.transform.FindChild("Bg/Help").GetComponent("XUIButton") as IXUIButton);
			this.m_BtnExplore = (base.transform.FindChild("Bg/Btn/BtnExplore").GetComponent("XUIButton") as IXUIButton);
			this.m_BtnChallenge = (base.transform.FindChild("Bg/Btn/BtnChallenge").GetComponent("XUIButton") as IXUIButton);
			this.m_BtnExploreAgain = (base.transform.FindChild("Bg/Btn/BtnExploreAgain").GetComponent("XUIButton") as IXUIButton);
			this.m_BtnWarehouse = (base.transform.FindChild("Bg/Btn/BtnCk").GetComponent("XUIButton") as IXUIButton);
			this.m_BtnRank = (base.transform.FindChild("Bg/Btn/BtnRank").GetComponent("XUIButton") as IXUIButton);
			this.m_BtnTeam = (base.transform.FindChild("Bg/Btn/BtnTeam").GetComponent("XUIButton") as IXUIButton);
			this.m_MemberNum = (this.m_BtnTeam.gameObject.transform.FindChild("MemberNum").GetComponent("XUILabel") as IXUILabel);
			this.m_PropsFrame = base.transform.Find("Bg/PropsFrame");
			this.m_RankFrame = base.transform.Find("Bg/RankFrame");
			this.m_selfBuffIcons = base.transform.Find("Bg/InfoSelf/BuffIcons");
			this.m_RoleProtrait = (base.transform.Find("Bg/InfoSelf/P").GetComponent("XUISprite") as IXUISprite);
			this.m_RoleName = (base.transform.Find("Bg/InfoSelf/T").GetComponent("XUILabel") as IXUILabel);
			this.m_TExplore = (this.m_BtnExplore.gameObject.transform.FindChild("T").GetComponent("XUILabel") as IXUILabel);
			this.m_ActivityTimeLabel = (base.transform.FindChild("Bg/Time").GetComponent("XUILabel") as IXUILabel);
			this.m_ActivityTimeDescription = (base.transform.FindChild("Bg/Time/T").GetComponent("XUILabel") as IXUILabel);
			this.m_ActivityCDCounter = new XLeftTimeCounter(this.m_ActivityTimeLabel, false);
			this.m_Exploring = base.transform.FindChild("Bg/Searching");
			this.m_ExploreTimeLabel = (base.transform.FindChild("Bg/Searching/Time").GetComponent("XUILabel") as IXUILabel);
			this.m_ExploreTimeSlider = (base.transform.FindChild("Bg/Searching/LoadingProgress").GetComponent("XUISlider") as IXUISlider);
			this.m_ExploreCDCounter = new XLeftTimeCounter(this.m_ExploreTimeLabel, false);
			this.m_NewFindTween = (base.transform.FindChild("Bg/NewFind").GetComponent("XUIPlayTween") as IXUITweenTool);
			this.m_BossTween = (base.transform.FindChild("Bg/PVE").GetComponent("XUIPlayTween") as IXUITweenTool);
			this.m_RecordScrollView = (base.transform.Find("Bg/Log/BuffRecords").GetComponent("XUIScrollView") as IXUIScrollView);
			this.m_BuffTipPool.SetupPool(null, base.transform.Find("Bg/InfoBuff/InfoBuffTpl").gameObject, 4U, false);
			this.m_GuildBuffReviewPool.SetupPool(base.transform.Find("Bg/InfoGuild").gameObject, base.transform.Find("Bg/InfoGuild/InfoGuildTpl").gameObject, 3U, false);
			this.m_GuildBuffRecordPool.SetupPool(base.transform.Find("Bg/Log/BuffRecords").gameObject, base.transform.Find("Bg/Log/BuffRecords/LogItem").gameObject, 2U, false);
			this.m_BossMinePool.SetupPool(null, base.transform.FindChild("Bg/PVE/BossTpl/Mine/MineTpl").gameObject, XGuildMineMainDocument.MINE_NUM_MAX, false);
			this.m_BossMinePool.FakeReturnAll();
			int num = 0;
			while ((long)num < (long)((ulong)XGuildMineMainDocument.MINE_NUM_MAX))
			{
				GameObject gameObject = this.m_BossMinePool.FetchGameObject(false);
				gameObject.transform.localPosition = new Vector3((float)(((double)((float)num + 0.5f) - XGuildMineMainDocument.MINE_NUM_MAX / 2.0) * (double)this.m_BossMinePool.TplWidth), 0f, 0f);
				gameObject.name = string.Format("Mine{0}", num);
				num++;
			}
			this.m_BossMinePool.ActualReturnAll(false);
			this.m_BossPool.SetupPool(null, base.transform.FindChild("Bg/PVE/BossTpl").gameObject, XGuildMineMainDocument.BOSS_NUM_MAX, false);
			this.m_BossPool.FakeReturnAll();
			int num2 = 0;
			while ((long)num2 < (long)((ulong)XGuildMineMainDocument.BOSS_NUM_MAX))
			{
				GameObject gameObject2 = this.m_BossPool.FetchGameObject(false);
				Transform transform = base.transform.Find(string.Format("Bg/PVE/Boss{0}", num2 + 1));
				XSingleton<UiUtility>.singleton.AddChild(transform.gameObject, gameObject2);
				this.m_BossTpl[num2] = gameObject2.transform;
				this.m_BossName[num2] = (this.m_BossTpl[num2].FindChild("Name").GetComponent("XUILabel") as IXUILabel);
				this.m_BossSp[num2] = (this.m_BossTpl[num2].FindChild("Boss").GetComponent("XUISprite") as IXUISprite);
				this.m_BossTex[num2] = (this.m_BossTpl[num2].FindChild("Tex").GetComponent("XUITexture") as IXUITexture);
				this.m_BossSelect[num2] = this.m_BossTpl[num2].FindChild("Select");
				this.m_BossLevel[num2] = (this.m_BossTpl[num2].FindChild("Grade").GetComponent("XUILabel") as IXUILabel);
				this.m_NoLook[num2] = this.m_BossTpl[num2].FindChild("NoLook");
				int num3 = 0;
				while ((long)num3 < (long)((ulong)XGuildMineMainDocument.MINE_NUM_MAX))
				{
					this.m_BossMine[num2, num3] = this.m_BossTpl[num2].FindChild(string.Format("Mine/Mine{0}/Mine", num3));
					num3++;
				}
				this.m_BossBuff[num2] = (this.m_BossTpl[num2].FindChild("Buff").GetComponent("XUISprite") as IXUISprite);
				this.m_BossBuffText[num2] = (this.m_BossTpl[num2].FindChild("Buff/T").GetComponent("XUILabel") as IXUILabel);
				num2++;
			}
			this.m_BossPool.ActualReturnAll(false);
		}

		public IXUIButton m_Close;

		public IXUIButton m_Help;

		public IXUIButton m_BtnExplore;

		public IXUIButton m_BtnChallenge;

		public IXUIButton m_BtnExploreAgain;

		public IXUIButton m_BtnWarehouse;

		public IXUIButton m_BtnRank;

		public IXUIButton m_BtnTeam;

		public IXUILabel m_MemberNum;

		public Transform m_PropsFrame;

		public Transform m_RankFrame;

		public IXUISprite m_RoleProtrait;

		public IXUILabel m_RoleName;

		public Transform m_selfBuffIcons;

		public IXUILabel m_TExplore;

		public IXUILabel m_ActivityTimeLabel;

		public IXUILabel m_ActivityTimeDescription;

		public XLeftTimeCounter m_ActivityCDCounter;

		public Transform m_Exploring;

		public IXUILabel m_ExploreTimeLabel;

		public IXUISlider m_ExploreTimeSlider;

		public XLeftTimeCounter m_ExploreCDCounter;

		public IXUITweenTool m_NewFindTween;

		public IXUITweenTool m_BossTween;

		public IXUIScrollView m_RecordScrollView;

		public XUIPool m_BossPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public XUIPool m_BossMinePool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public XUIPool m_BuffTipPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public XUIPool m_GuildBuffReviewPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public XUIPool m_GuildBuffRecordPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public Transform[] m_NoLook = new Transform[XGuildMineMainDocument.BOSS_NUM_MAX];

		public Transform[] m_BossTpl = new Transform[XGuildMineMainDocument.BOSS_NUM_MAX];

		public IXUILabel[] m_BossName = new IXUILabel[XGuildMineMainDocument.BOSS_NUM_MAX];

		public IXUISprite[] m_BossSp = new IXUISprite[XGuildMineMainDocument.BOSS_NUM_MAX];

		public IXUITexture[] m_BossTex = new IXUITexture[XGuildMineMainDocument.BOSS_NUM_MAX];

		public Transform[] m_BossSelect = new Transform[XGuildMineMainDocument.BOSS_NUM_MAX];

		public IXUILabel[] m_BossLevel = new IXUILabel[XGuildMineMainDocument.BOSS_NUM_MAX];

		public Transform[,] m_BossMine = new Transform[(int)XGuildMineMainDocument.BOSS_NUM_MAX, (int)XGuildMineMainDocument.MINE_NUM_MAX];

		public IXUISprite[] m_BossBuff = new IXUISprite[XGuildMineMainDocument.BOSS_NUM_MAX];

		public IXUILabel[] m_BossBuffText = new IXUILabel[XGuildMineMainDocument.BOSS_NUM_MAX];
	}
}
