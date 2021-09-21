using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x0200176E RID: 5998
	internal class GuildSalayBehavior : DlgBehaviourBase
	{
		// Token: 0x0600F7A1 RID: 63393 RVA: 0x00386954 File Offset: 0x00384B54
		private void Awake()
		{
			this.m_Root = base.transform.FindChild("Bg");
			this.m_Right = base.transform.FindChild("Bg/frame/Right");
			this.m_Empty = base.transform.FindChild("Bg/frame/Empty");
			this.m_Close = (base.transform.FindChild("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_thisWeekGrade = (base.transform.FindChild("Bg/frame/Left/Score/Grade").GetComponent("XUITexture") as IXUITexture);
			this.m_thisWeekScore = (base.transform.FindChild("Bg/frame/Left/Score/ScoreValue").GetComponent("XUILabel") as IXUILabel);
			this.m_BottomInfo.Init(base.transform.FindChild("Bg/frame/Left/Bottom"), 0);
			this.m_LeftInfo.Init(base.transform.FindChild("Bg/frame/Left/Left"), 1);
			this.m_UpInfo.Init(base.transform.FindChild("Bg/frame/Left/Up"), 2);
			this.m_RightInfo.Init(base.transform.FindChild("Bg/frame/Left/Right"), 3);
			this.m_radarMap = (base.transform.FindChild("Bg/frame/Left/RadarMap/RadarMap").GetComponent("XRadarMap") as IXRadarMap);
			this.m_WrapContent = (base.transform.FindChild("Bg/frame/Right/CanGet/ScrollView/Reward").GetComponent("XUIWrapContent") as IXUIWrapContent);
			this.m_RewardScrollView = (base.transform.FindChild("Bg/frame/Right/CanGet/ScrollView").GetComponent("XUIScrollView") as IXUIScrollView);
			this.m_LastWeekGrade = (base.transform.FindChild("Bg/frame/Right/Score/Grade").GetComponent("XUITexture") as IXUITexture);
			this.m_LastWeekScore = (base.transform.FindChild("Bg/frame/Right/Score/ScoreValue").GetComponent("XUILabel") as IXUILabel);
			this.m_LastScoreLabel = (base.transform.FindChild("Bg/frame/Right/Score/Last").GetComponent("XUILabel") as IXUILabel);
			this.m_TitleLabel = (base.transform.FindChild("Bg/frame/Right/Score/Title").GetComponent("XUILabel") as IXUILabel);
			this.m_GuildLevel = (base.transform.FindChild("Bg/frame/Right/Level/Value").GetComponent("XUILabel") as IXUILabel);
			this.m_GuildPosition = (base.transform.FindChild("Bg/frame/Right/CanGet/Position/Value").GetComponent("XUILabel") as IXUILabel);
			this.m_GetButton = (base.transform.FindChild("Bg/frame/Right/CanGet/Get").GetComponent("XUIButton") as IXUIButton);
			this.m_GetLabel = (base.transform.FindChild("Bg/frame/Right/CanGet/Get/Label").GetComponent("XUILabel") as IXUILabel);
			this.m_CanNot = (base.transform.FindChild("Bg/frame/Right/CanNot").GetComponent("XUILabel") as IXUILabel);
			this.m_ShowNextReward = (base.transform.FindChild("Bg/frame/Right/Score/t").GetComponent("XUILabel") as IXUILabel);
			this.m_DropView = base.transform.FindChild("Bg/BoxFrame");
			this.m_DropScrollView = (this.m_DropView.FindChild("ScrollView").GetComponent("XUIScrollView") as IXUIScrollView);
			this.m_DropWrapContent = (this.m_DropView.FindChild("ScrollView/DropFrame").GetComponent("XUIWrapContent") as IXUIWrapContent);
			this.m_DropClose = (this.m_DropView.FindChild("Close").GetComponent("XUISprite") as IXUISprite);
			for (int i = 0; i < this.topPlayers.Length; i++)
			{
				this.topPlayers[i] = (base.transform.Find(XSingleton<XCommon>.singleton.StringCombine("Bg/frame/Right/p5/player", i.ToString())).GetComponent("XUILabel") as IXUILabel);
				this.topPlayers[i].SetText("");
			}
		}

		// Token: 0x04006BDD RID: 27613
		public Transform m_Root;

		// Token: 0x04006BDE RID: 27614
		public Transform m_Right;

		// Token: 0x04006BDF RID: 27615
		public Transform m_Empty;

		// Token: 0x04006BE0 RID: 27616
		public IXUIButton m_Close;

		// Token: 0x04006BE1 RID: 27617
		public IXUILabel m_thisWeekScore;

		// Token: 0x04006BE2 RID: 27618
		public IXUITexture m_thisWeekGrade;

		// Token: 0x04006BE3 RID: 27619
		public GuildScoreInfo m_BottomInfo = new GuildScoreInfo();

		// Token: 0x04006BE4 RID: 27620
		public GuildScoreInfo m_LeftInfo = new GuildScoreInfo();

		// Token: 0x04006BE5 RID: 27621
		public GuildScoreInfo m_UpInfo = new GuildScoreInfo();

		// Token: 0x04006BE6 RID: 27622
		public GuildScoreInfo m_RightInfo = new GuildScoreInfo();

		// Token: 0x04006BE7 RID: 27623
		public IXRadarMap m_radarMap;

		// Token: 0x04006BE8 RID: 27624
		public IXUILabel m_LastWeekScore;

		// Token: 0x04006BE9 RID: 27625
		public IXUITexture m_LastWeekGrade;

		// Token: 0x04006BEA RID: 27626
		public IXUILabel m_LastScoreLabel;

		// Token: 0x04006BEB RID: 27627
		public IXUILabel m_GuildLevel;

		// Token: 0x04006BEC RID: 27628
		public IXUILabel m_GuildPosition;

		// Token: 0x04006BED RID: 27629
		public IXUILabel m_TitleLabel;

		// Token: 0x04006BEE RID: 27630
		public IXUIScrollView m_RewardScrollView;

		// Token: 0x04006BEF RID: 27631
		public IXUIWrapContent m_WrapContent;

		// Token: 0x04006BF0 RID: 27632
		public IXUIButton m_GetButton;

		// Token: 0x04006BF1 RID: 27633
		public IXUILabel m_GetLabel;

		// Token: 0x04006BF2 RID: 27634
		public IXUILabel m_CanNot;

		// Token: 0x04006BF3 RID: 27635
		public IXUILabel m_ShowNextReward;

		// Token: 0x04006BF4 RID: 27636
		public Transform m_DropView;

		// Token: 0x04006BF5 RID: 27637
		public IXUIScrollView m_DropScrollView;

		// Token: 0x04006BF6 RID: 27638
		public IXUIWrapContent m_DropWrapContent;

		// Token: 0x04006BF7 RID: 27639
		public IXUISprite m_DropClose;

		// Token: 0x04006BF8 RID: 27640
		public IXUILabel[] topPlayers = new IXUILabel[5];
	}
}
