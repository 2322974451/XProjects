using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XQualifyingBehaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			this.m_Bg = base.transform.FindChild("Bg");
			this.m_Close = (this.m_Bg.FindChild("Close").GetComponent("XUIButton") as IXUIButton);
			this.m_Help = (this.m_Bg.FindChild("Help").GetComponent("XUIButton") as IXUIButton);
			this.m_BattleRecordFrame = this.m_Bg.FindChild("BattleRecordFrame").gameObject;
			Transform transform = this.m_Bg.FindChild("Bg/Tabs/TabTpl");
			this.m_TabPool.SetupPool(transform.parent.gameObject, transform.gameObject, 2U, false);
			this.m_UnOpen2V2 = (this.m_Bg.FindChild("Bg/2V2UnOpen").GetComponent("XUISprite") as IXUISprite);
			Transform transform2 = this.m_Bg.FindChild("Bg/BtnList");
			this.m_ShopBtn = (transform2.FindChild("ShopBtn").GetComponent("XUIButton") as IXUIButton);
			this.m_RankBtn = (transform2.FindChild("RankBtn").GetComponent("XUIButton") as IXUIButton);
			this.m_BattleRecordBtn = (transform2.FindChild("BattleRecordBtn").GetComponent("XUIButton") as IXUIButton);
			this.m_TrainBtn = (transform2.FindChild("TrainingBtn").GetComponent("XUIButton") as IXUIButton);
			this.m_PointRewardBtn = (transform2.Find("PointRewardBtn").GetComponent("XUITexture") as IXUITexture);
			this.m_PointRewardRedPoint = transform2.FindChild("PointRewardBtn/RedPoint");
			this.m_RankRewardBtn = (transform2.FindChild("RankRewardBtn").GetComponent("XUIButton") as IXUIButton);
			this.m_Match1V1Btn = (transform2.FindChild("Match1V1Btn").GetComponent("XUIButton") as IXUIButton);
			this.m_Match1V1BtnLabel = (transform2.FindChild("Match1V1Btn/Text").GetComponent("XUILabel") as IXUILabel);
			this.m_Match2V2Btn = (transform2.FindChild("Match2V2Btn").GetComponent("XUIButton") as IXUIButton);
			this.m_Match2V2BtnLabel = (transform2.FindChild("Match2V2Btn/Text").GetComponent("XUILabel") as IXUILabel);
			this.m_TeamBtn = (transform2.FindChild("TeamBtn").GetComponent("XUIButton") as IXUIButton);
			this.m_Message = this.m_Bg.FindChild("Bg/Message");
			this.m_TotalRecords = (this.m_Message.FindChild("Records/TotalRecords/Num").GetComponent("XUILabel") as IXUILabel);
			this.m_WinRecord = (this.m_Message.FindChild("Records/Win/Num").GetComponent("XUILabel") as IXUILabel);
			this.m_LoseRecord = (this.m_Message.FindChild("Records/Lose/Num").GetComponent("XUILabel") as IXUILabel);
			this.m_WinRate = (this.m_Message.FindChild("Records/Rate/Num").GetComponent("XUILabel") as IXUILabel);
			this.m_CurrentRank = (this.m_Message.FindChild("CurrentRank/Num").GetComponent("XUILabel") as IXUILabel);
			this.m_RankEndTips = (this.m_Message.FindChild("Tip").GetComponent("XUILabel") as IXUILabel);
			this.m_ChallengeFrame = this.m_Bg.FindChild("Bg/ChallengeFrame");
			this.m_Tier = (this.m_ChallengeFrame.Find("Tier").GetComponent("XUITexture") as IXUITexture);
			this.m_WinOfPoint = (this.m_ChallengeFrame.FindChild("WinOfPoint/Num").GetComponent("XUILabel") as IXUILabel);
			this.m_ChallengeTip = (this.m_ChallengeFrame.FindChild("Tip").GetComponent("XUILabelSymbol") as IXUILabelSymbol);
			this.m_ChallengeTipText = (this.m_ChallengeTip.gameObject.transform.Find("T").GetComponent("XUILabel") as IXUILabel);
			this.m_FxFireworkGo = this.m_ChallengeFrame.FindChild("m_FxFirework").gameObject;
			this.m_FxFireworkGo.SetActive(false);
			this.m_RankWindow = new XQualifyingRankWindow(this.m_Bg.FindChild("RankFrame").gameObject);
			this.m_RankRewardWindow = new XQualifyingRankRewardWindow(this.m_Bg.FindChild("RankRewardFrame").gameObject);
			this.m_PointRewardWindow = new XQualifyingPointRewardWindow(this.m_Bg.FindChild("PointRewardFrame").gameObject);
		}

		public IXUIButton m_Close;

		public IXUIButton m_Help;

		public XUIPool m_TabPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public IXUISprite m_UnOpen2V2;

		public Transform m_Bg;

		public IXUIButton m_ShopBtn;

		public IXUIButton m_RankBtn;

		public IXUIButton m_BattleRecordBtn;

		public IXUIButton m_TrainBtn;

		public IXUITexture m_PointRewardBtn;

		public Transform m_PointRewardRedPoint;

		public IXUIButton m_RankRewardBtn;

		public IXUIButton m_Match1V1Btn;

		public IXUILabel m_Match1V1BtnLabel;

		public IXUIButton m_Match2V2Btn;

		public IXUILabel m_Match2V2BtnLabel;

		public IXUIButton m_TeamBtn;

		public Transform m_Message;

		public IXUILabel m_TotalRecords;

		public IXUILabel m_WinRecord;

		public IXUILabel m_LoseRecord;

		public IXUILabel m_WinRate;

		public IXUILabel m_CurrentRank;

		public IXUILabel m_RankEndTips;

		public Transform m_ChallengeFrame;

		public IXUITexture m_Tier;

		public IXUILabel m_WinOfPoint;

		public XNumberTween m_NumberTween;

		public IXUILabelSymbol m_ChallengeTip;

		public IXUILabel m_ChallengeTipText;

		public GameObject m_FxFireworkGo;

		public XUIPool m_RankTabPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public IXUICheckBox m_RankTypeAll;

		public XQualifyingRankWindow m_RankWindow;

		public XQualifyingRankRewardWindow m_RankRewardWindow;

		public XQualifyingPointRewardWindow m_PointRewardWindow;

		public GameObject m_BattleRecordFrame;
	}
}
