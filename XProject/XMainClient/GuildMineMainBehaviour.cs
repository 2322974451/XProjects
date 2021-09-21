using System;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000C1C RID: 3100
	internal class GuildMineMainBehaviour : DlgBehaviourBase
	{
		// Token: 0x0600AFEC RID: 45036 RVA: 0x00216DE4 File Offset: 0x00214FE4
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

		// Token: 0x0400432D RID: 17197
		public IXUIButton m_Close;

		// Token: 0x0400432E RID: 17198
		public IXUIButton m_Help;

		// Token: 0x0400432F RID: 17199
		public IXUIButton m_BtnExplore;

		// Token: 0x04004330 RID: 17200
		public IXUIButton m_BtnChallenge;

		// Token: 0x04004331 RID: 17201
		public IXUIButton m_BtnExploreAgain;

		// Token: 0x04004332 RID: 17202
		public IXUIButton m_BtnWarehouse;

		// Token: 0x04004333 RID: 17203
		public IXUIButton m_BtnRank;

		// Token: 0x04004334 RID: 17204
		public IXUIButton m_BtnTeam;

		// Token: 0x04004335 RID: 17205
		public IXUILabel m_MemberNum;

		// Token: 0x04004336 RID: 17206
		public Transform m_PropsFrame;

		// Token: 0x04004337 RID: 17207
		public Transform m_RankFrame;

		// Token: 0x04004338 RID: 17208
		public IXUISprite m_RoleProtrait;

		// Token: 0x04004339 RID: 17209
		public IXUILabel m_RoleName;

		// Token: 0x0400433A RID: 17210
		public Transform m_selfBuffIcons;

		// Token: 0x0400433B RID: 17211
		public IXUILabel m_TExplore;

		// Token: 0x0400433C RID: 17212
		public IXUILabel m_ActivityTimeLabel;

		// Token: 0x0400433D RID: 17213
		public IXUILabel m_ActivityTimeDescription;

		// Token: 0x0400433E RID: 17214
		public XLeftTimeCounter m_ActivityCDCounter;

		// Token: 0x0400433F RID: 17215
		public Transform m_Exploring;

		// Token: 0x04004340 RID: 17216
		public IXUILabel m_ExploreTimeLabel;

		// Token: 0x04004341 RID: 17217
		public IXUISlider m_ExploreTimeSlider;

		// Token: 0x04004342 RID: 17218
		public XLeftTimeCounter m_ExploreCDCounter;

		// Token: 0x04004343 RID: 17219
		public IXUITweenTool m_NewFindTween;

		// Token: 0x04004344 RID: 17220
		public IXUITweenTool m_BossTween;

		// Token: 0x04004345 RID: 17221
		public IXUIScrollView m_RecordScrollView;

		// Token: 0x04004346 RID: 17222
		public XUIPool m_BossPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04004347 RID: 17223
		public XUIPool m_BossMinePool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04004348 RID: 17224
		public XUIPool m_BuffTipPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04004349 RID: 17225
		public XUIPool m_GuildBuffReviewPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x0400434A RID: 17226
		public XUIPool m_GuildBuffRecordPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x0400434B RID: 17227
		public Transform[] m_NoLook = new Transform[XGuildMineMainDocument.BOSS_NUM_MAX];

		// Token: 0x0400434C RID: 17228
		public Transform[] m_BossTpl = new Transform[XGuildMineMainDocument.BOSS_NUM_MAX];

		// Token: 0x0400434D RID: 17229
		public IXUILabel[] m_BossName = new IXUILabel[XGuildMineMainDocument.BOSS_NUM_MAX];

		// Token: 0x0400434E RID: 17230
		public IXUISprite[] m_BossSp = new IXUISprite[XGuildMineMainDocument.BOSS_NUM_MAX];

		// Token: 0x0400434F RID: 17231
		public IXUITexture[] m_BossTex = new IXUITexture[XGuildMineMainDocument.BOSS_NUM_MAX];

		// Token: 0x04004350 RID: 17232
		public Transform[] m_BossSelect = new Transform[XGuildMineMainDocument.BOSS_NUM_MAX];

		// Token: 0x04004351 RID: 17233
		public IXUILabel[] m_BossLevel = new IXUILabel[XGuildMineMainDocument.BOSS_NUM_MAX];

		// Token: 0x04004352 RID: 17234
		public Transform[,] m_BossMine = new Transform[(int)XGuildMineMainDocument.BOSS_NUM_MAX, (int)XGuildMineMainDocument.MINE_NUM_MAX];

		// Token: 0x04004353 RID: 17235
		public IXUISprite[] m_BossBuff = new IXUISprite[XGuildMineMainDocument.BOSS_NUM_MAX];

		// Token: 0x04004354 RID: 17236
		public IXUILabel[] m_BossBuffText = new IXUILabel[XGuildMineMainDocument.BOSS_NUM_MAX];
	}
}
