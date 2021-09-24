using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class DungeonSelectBehaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			this.m_Close = (base.transform.FindChild("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_Normal = (base.transform.FindChild("Bg/Normal").GetComponent("XUISprite") as IXUISprite);
			this.m_Hard = (base.transform.FindChild("Bg/Hard").GetComponent("XUISprite") as IXUISprite);
			this.m_NormalRedpoint = base.transform.FindChild("Bg/Normal/RedPoint").gameObject;
			this.m_HardRedpoint = base.transform.FindChild("Bg/Hard/RedPoint").gameObject;
			this.m_cbNormal = (this.m_Normal.gameObject.GetComponent("XUICheckBox") as IXUICheckBox);
			this.m_cbHard = (this.m_Hard.gameObject.GetComponent("XUICheckBox") as IXUICheckBox);
			this.m_normalBox = base.transform.FindChild("Bg/Normal").GetComponent<BoxCollider>();
			this.m_hardBox = base.transform.FindChild("Bg/Hard").GetComponent<BoxCollider>();
			Transform transform = base.transform.FindChild("Bg/PlayTween");
			this.m_LevelTween = (transform.GetComponent("XUIPlayTween") as IXUITweenTool);
			this.m_LevelBg = (transform.GetComponent("XUISprite") as IXUISprite);
			Transform transform2 = base.transform.FindChild("Bg/PlayTween/LevelFramePanel/LevelFrame/LevelTpl");
			this.m_ScenePool.SetupPool(transform.FindChild("LevelFramePanel").gameObject, transform2.gameObject, 20U, false);
			transform2 = base.transform.FindChild("Bg/PlayTween/LevelFramePanel/LevelFrame");
			this.m_SceneFramePool.SetupPool(transform2.parent.gameObject, transform2.gameObject, 3U, false);
			this.m_NormalBg = base.transform.FindChild("Bg/NormalBg").gameObject;
			this.m_HardBg = base.transform.FindChild("Bg/HardBg").gameObject;
			this.m_Rank = (base.transform.FindChild("Bg/StarBar/Text").GetComponent("XUILabel") as IXUILabel);
			this.m_RankProgress = (base.transform.FindChild("Bg/StarBar").GetComponent("XUIProgress") as IXUIProgress);
			transform2 = base.transform.FindChild("Bg/StarBar/Reward");
			this.m_RankBox.SetupPool(transform2.parent.gameObject, transform2.gameObject, 3U, false);
			this.m_BoxFrame = base.transform.FindChild("Bg/BoxFrame").gameObject;
			this.m_BoxFrame.SetActive(false);
			this.m_BoxFrameBg = (base.transform.FindChild("Bg/BoxFrame/Bg").GetComponent("XUISprite") as IXUISprite);
			this.m_BoxChest = base.transform.FindChild("Bg/BoxFrame/T1").gameObject;
			this.m_BoxStar = (base.transform.FindChild("Bg/BoxFrame/Text").GetComponent("XUILabel") as IXUILabel);
			transform2 = base.transform.FindChild("Bg/BoxFrame/DropFrame/ItemTpl");
			this.m_BoxRewardPool.SetupPool(transform2.parent.gameObject, transform2.gameObject, 10U, false);
			this.m_BoxFetch = (base.transform.FindChild("Bg/BoxFrame/Fetch").GetComponent("XUIButton") as IXUIButton);
			this.m_BoxRedPoint = base.transform.FindChild("Bg/BoxFrame/RedPoint").gameObject;
			this.m_SceneDetail = base.transform.FindChild("Bg/DetailFrame").gameObject;
			this.m_SceneDetail.gameObject.SetActive(false);
			this.m_SceneNormal = this.m_SceneDetail.transform.FindChild("Normal").gameObject;
			this.m_SceneHard = this.m_SceneDetail.transform.FindChild("Hard").gameObject;
			this.m_SceneName = (this.m_SceneDetail.transform.FindChild("Name").GetComponent("XUILabel") as IXUILabel);
			this.m_SceneClose = (this.m_SceneDetail.transform.FindChild("Close").GetComponent("XUIButton") as IXUIButton);
			for (int i = 0; i < 3; i++)
			{
				this.m_SceneStarCond[i] = (this.m_SceneDetail.transform.FindChild("Name/Star" + (i + 1) + "/Desc").GetComponent("XUILabel") as IXUILabel);
				this.m_SceneStar[i] = (this.m_SceneDetail.transform.FindChild("Name/Star" + (i + 1)).GetComponent("XUISprite") as IXUISprite);
			}
			transform2 = this.m_SceneDetail.transform.FindChild("DropFrame/Panel/Grid/ItemTpl");
			this.m_SceneDropPool.SetupPool(transform2.parent.gameObject, transform2.gameObject, 10U, false);
			this.m_DropExpLab = (this.m_SceneDetail.transform.FindChild("DropFrame/ResouceDrop/Label").GetComponent("XUILabel") as IXUILabel);
			this.m_DropExpLab1 = (this.m_SceneDetail.transform.FindChild("DropFrame/ResouceDrop1/Label").GetComponent("XUILabel") as IXUILabel);
			transform2 = this.m_SceneDetail.transform.FindChild("Bg");
			this.m_SceneHint = (transform2.FindChild("Hint").GetComponent("XUILabel") as IXUILabel);
			this.m_SceneMyPPT = (transform2.FindChild("MyPPT").GetComponent("XUILabel") as IXUILabel);
			this.m_SceneRecommendPPT = (transform2.FindChild("RecommendPPT").GetComponent("XUILabel") as IXUILabel);
			this.m_SweepPPT = (transform2.FindChild("SweepPPT").GetComponent("XUILabel") as IXUILabel);
			this.m_SweepPPTName = this.m_SceneDetail.transform.FindChild("P/T4").gameObject;
			this.m_SweepTicketGo = transform2.FindChild("SweepQuantity").gameObject;
			this.m_SweepTicketLab = (this.m_SweepTicketGo.transform.GetComponent("XUILabel") as IXUILabel);
			this.m_addTicketSpr = (this.m_SweepTicketGo.transform.FindChild("BtnAdd").GetComponent("XUISprite") as IXUISprite);
			this.m_SceneGoBattle = (transform2.FindChild("GoBattle").GetComponent("XUIButton") as IXUIButton);
			this.m_SceneSoloBattle = (transform2.FindChild("GoAloneBattle").GetComponent("XUIButton") as IXUIButton);
			this.m_SceneSoloBattleCost = (transform2.FindChild("GoAloneBattle/Cost").GetComponent("XUILabelSymbol") as IXUILabelSymbol);
			this.m_SceneTeamBattle = (transform2.FindChild("GoTeamBattle").GetComponent("XUIButton") as IXUIButton);
			this.m_SceneTeamBattleCost = (transform2.FindChild("GoTeamBattle/Cost").GetComponent("XUILabelSymbol") as IXUILabelSymbol);
			this.m_SceneTeamBattlePos = this.m_SceneTeamBattle.gameObject.transform.localPosition;
			this.m_SceneQuick1 = (transform2.FindChild("Quick1").GetComponent("XUIButton") as IXUIButton);
			this.m_SceneQuick10 = (transform2.FindChild("Quick10").GetComponent("XUIButton") as IXUIButton);
			this.m_SceneQuick10Lab = (transform2.FindChild("Quick10/T1").GetComponent("XUILabel") as IXUILabel);
			this.m_Cost = (transform2.FindChild("GoBattle/Cost").GetComponent("XUILabelSymbol") as IXUILabelSymbol);
			this.m_SceneFirstSSS = transform2.FindChild("First3Star").gameObject;
			this.m_SceneFirstSSSReward = (this.m_SceneFirstSSS.transform.FindChild("Num").GetComponent("XUILabelSymbol") as IXUILabelSymbol);
			this.m_SceneRecommendHint = (base.transform.FindChild("Bg/DetailFrame/Tj").GetComponent("XUILabel") as IXUILabel);
			this.m_Left = (base.transform.FindChild("Bg/Left").GetComponent("XUIButton") as IXUIButton);
			this.m_Right = (base.transform.FindChild("Bg/Right").GetComponent("XUIButton") as IXUIButton);
			this.m_MainHint = (base.transform.FindChild("Bg/MainHint").GetComponent("XUIPlayTween") as IXUITweenTool);
			this.m_MainHintText = (base.transform.FindChild("Bg/MainHint").GetComponent("XUILabel") as IXUILabel);
			this.m_HardLeftCountGo0 = base.transform.Find("Bg/HardLeftCount").gameObject;
			this.m_HardLeftCountGo1 = base.transform.Find("Bg/DetailFrame/HardLeftCount").gameObject;
			this.m_PrerogativeBg = (this.m_HardLeftCountGo0.transform.Find("tq/p").GetComponent("XUISprite") as IXUISprite);
			this.m_PrerogativeSpr = (this.m_HardLeftCountGo0.transform.Find("tq").GetComponent("XUISprite") as IXUISprite);
			this.m_PrerogativeLab = (this.m_HardLeftCountGo0.transform.Find("tq/t").GetComponent("XUILabel") as IXUILabel);
			this.m_HardLeftCount0 = (this.m_HardLeftCountGo0.transform.Find("Value").GetComponent("XUILabel") as IXUILabel);
			this.m_HardLeftCount1 = (this.m_HardLeftCountGo1.transform.Find("Value").GetComponent("XUILabel") as IXUILabel);
			this.m_BtnAddHardLeftCount0 = (this.m_HardLeftCountGo0.transform.Find("BtnAdd").GetComponent("XUISprite") as IXUISprite);
			this.m_BtnAddHardLeftCount1 = (this.m_HardLeftCountGo1.transform.Find("BtnAdd").GetComponent("XUISprite") as IXUISprite);
			this.m_MainHint.gameObject.SetActive(false);
			this.m_ShopBtn = (base.transform.Find("Bg/BtnShop").GetComponent("XUIButton") as IXUIButton);
		}

		public IXUIButton m_Close;

		public IXUISprite m_Normal;

		public IXUISprite m_Hard;

		public IXUICheckBox m_cbNormal;

		public IXUICheckBox m_cbHard;

		public GameObject m_NormalRedpoint;

		public GameObject m_HardRedpoint;

		public GameObject m_NormalBg;

		public GameObject m_HardBg;

		public BoxCollider m_hardBox;

		public BoxCollider m_normalBox;

		public IXUISprite m_LevelBg;

		public IXUITweenTool m_LevelTween;

		public XUIPool m_SceneFramePool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public XUIPool m_ScenePool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public IXUILabel m_Rank;

		public IXUIProgress m_RankProgress;

		public XUIPool m_RankBox = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public GameObject m_BoxFrame;

		public IXUISprite m_BoxFrameBg;

		public GameObject m_BoxChest;

		public IXUILabel m_BoxStar;

		public XUIPool m_BoxRewardPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public IXUIButton m_BoxFetch;

		public GameObject m_BoxRedPoint;

		public GameObject m_SceneDetail;

		public GameObject m_SceneNormal;

		public GameObject m_SceneHard;

		public IXUILabel m_SceneName;

		public IXUIButton m_SceneClose;

		public IXUILabel[] m_SceneStarCond = new IXUILabel[3];

		public IXUISprite[] m_SceneStar = new IXUISprite[3];

		public XUIPool m_SceneDropPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public IXUILabel m_SceneHint;

		public IXUILabel m_SceneMyPPT;

		public IXUILabel m_SceneRecommendPPT;

		public IXUILabel m_SweepPPT;

		public GameObject m_SweepPPTName;

		public IXUILabel m_SweepTicketLab;

		public IXUISprite m_addTicketSpr;

		public GameObject m_SweepTicketGo;

		public IXUIButton m_SceneGoBattle;

		public IXUIButton m_SceneSoloBattle;

		public IXUIButton m_SceneTeamBattle;

		public IXUILabelSymbol m_SceneSoloBattleCost;

		public IXUILabelSymbol m_SceneTeamBattleCost;

		public IXUIButton m_SceneQuick1;

		public IXUIButton m_SceneQuick10;

		public IXUILabel m_SceneQuick10Lab;

		public IXUILabel m_DropExpLab;

		public IXUILabel m_DropExpLab1;

		public GameObject m_SceneFirstSSS;

		public IXUILabelSymbol m_SceneFirstSSSReward;

		public IXUILabelSymbol m_Cost;

		public IXUILabel m_SceneRecommendHint;

		public Vector3 m_SceneTeamBattlePos;

		public IXUIButton m_Left;

		public IXUIButton m_Right;

		public IXUITweenTool m_MainHint;

		public IXUILabel m_MainHintText;

		public GameObject m_HardLeftCountGo0;

		public GameObject m_HardLeftCountGo1;

		public IXUILabel m_HardLeftCount0;

		public IXUILabel m_HardLeftCount1;

		public IXUISprite m_BtnAddHardLeftCount0;

		public IXUISprite m_BtnAddHardLeftCount1;

		public IXUISprite m_PrerogativeSpr;

		public IXUILabel m_PrerogativeLab;

		public IXUISprite m_PrerogativeBg;

		public IXUIButton m_ShopBtn;
	}
}
