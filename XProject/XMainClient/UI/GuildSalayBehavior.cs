using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class GuildSalayBehavior : DlgBehaviourBase
	{

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

		public Transform m_Root;

		public Transform m_Right;

		public Transform m_Empty;

		public IXUIButton m_Close;

		public IXUILabel m_thisWeekScore;

		public IXUITexture m_thisWeekGrade;

		public GuildScoreInfo m_BottomInfo = new GuildScoreInfo();

		public GuildScoreInfo m_LeftInfo = new GuildScoreInfo();

		public GuildScoreInfo m_UpInfo = new GuildScoreInfo();

		public GuildScoreInfo m_RightInfo = new GuildScoreInfo();

		public IXRadarMap m_radarMap;

		public IXUILabel m_LastWeekScore;

		public IXUITexture m_LastWeekGrade;

		public IXUILabel m_LastScoreLabel;

		public IXUILabel m_GuildLevel;

		public IXUILabel m_GuildPosition;

		public IXUILabel m_TitleLabel;

		public IXUIScrollView m_RewardScrollView;

		public IXUIWrapContent m_WrapContent;

		public IXUIButton m_GetButton;

		public IXUILabel m_GetLabel;

		public IXUILabel m_CanNot;

		public IXUILabel m_ShowNextReward;

		public Transform m_DropView;

		public IXUIScrollView m_DropScrollView;

		public IXUIWrapContent m_DropWrapContent;

		public IXUISprite m_DropClose;

		public IXUILabel[] topPlayers = new IXUILabel[5];
	}
}
