using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x02001920 RID: 6432
	internal class DungeonSelectBehaviour : DlgBehaviourBase
	{
		// Token: 0x06010D90 RID: 69008 RVA: 0x00441F00 File Offset: 0x00440100
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

		// Token: 0x04007BAB RID: 31659
		public IXUIButton m_Close;

		// Token: 0x04007BAC RID: 31660
		public IXUISprite m_Normal;

		// Token: 0x04007BAD RID: 31661
		public IXUISprite m_Hard;

		// Token: 0x04007BAE RID: 31662
		public IXUICheckBox m_cbNormal;

		// Token: 0x04007BAF RID: 31663
		public IXUICheckBox m_cbHard;

		// Token: 0x04007BB0 RID: 31664
		public GameObject m_NormalRedpoint;

		// Token: 0x04007BB1 RID: 31665
		public GameObject m_HardRedpoint;

		// Token: 0x04007BB2 RID: 31666
		public GameObject m_NormalBg;

		// Token: 0x04007BB3 RID: 31667
		public GameObject m_HardBg;

		// Token: 0x04007BB4 RID: 31668
		public BoxCollider m_hardBox;

		// Token: 0x04007BB5 RID: 31669
		public BoxCollider m_normalBox;

		// Token: 0x04007BB6 RID: 31670
		public IXUISprite m_LevelBg;

		// Token: 0x04007BB7 RID: 31671
		public IXUITweenTool m_LevelTween;

		// Token: 0x04007BB8 RID: 31672
		public XUIPool m_SceneFramePool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04007BB9 RID: 31673
		public XUIPool m_ScenePool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04007BBA RID: 31674
		public IXUILabel m_Rank;

		// Token: 0x04007BBB RID: 31675
		public IXUIProgress m_RankProgress;

		// Token: 0x04007BBC RID: 31676
		public XUIPool m_RankBox = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04007BBD RID: 31677
		public GameObject m_BoxFrame;

		// Token: 0x04007BBE RID: 31678
		public IXUISprite m_BoxFrameBg;

		// Token: 0x04007BBF RID: 31679
		public GameObject m_BoxChest;

		// Token: 0x04007BC0 RID: 31680
		public IXUILabel m_BoxStar;

		// Token: 0x04007BC1 RID: 31681
		public XUIPool m_BoxRewardPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04007BC2 RID: 31682
		public IXUIButton m_BoxFetch;

		// Token: 0x04007BC3 RID: 31683
		public GameObject m_BoxRedPoint;

		// Token: 0x04007BC4 RID: 31684
		public GameObject m_SceneDetail;

		// Token: 0x04007BC5 RID: 31685
		public GameObject m_SceneNormal;

		// Token: 0x04007BC6 RID: 31686
		public GameObject m_SceneHard;

		// Token: 0x04007BC7 RID: 31687
		public IXUILabel m_SceneName;

		// Token: 0x04007BC8 RID: 31688
		public IXUIButton m_SceneClose;

		// Token: 0x04007BC9 RID: 31689
		public IXUILabel[] m_SceneStarCond = new IXUILabel[3];

		// Token: 0x04007BCA RID: 31690
		public IXUISprite[] m_SceneStar = new IXUISprite[3];

		// Token: 0x04007BCB RID: 31691
		public XUIPool m_SceneDropPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04007BCC RID: 31692
		public IXUILabel m_SceneHint;

		// Token: 0x04007BCD RID: 31693
		public IXUILabel m_SceneMyPPT;

		// Token: 0x04007BCE RID: 31694
		public IXUILabel m_SceneRecommendPPT;

		// Token: 0x04007BCF RID: 31695
		public IXUILabel m_SweepPPT;

		// Token: 0x04007BD0 RID: 31696
		public GameObject m_SweepPPTName;

		// Token: 0x04007BD1 RID: 31697
		public IXUILabel m_SweepTicketLab;

		// Token: 0x04007BD2 RID: 31698
		public IXUISprite m_addTicketSpr;

		// Token: 0x04007BD3 RID: 31699
		public GameObject m_SweepTicketGo;

		// Token: 0x04007BD4 RID: 31700
		public IXUIButton m_SceneGoBattle;

		// Token: 0x04007BD5 RID: 31701
		public IXUIButton m_SceneSoloBattle;

		// Token: 0x04007BD6 RID: 31702
		public IXUIButton m_SceneTeamBattle;

		// Token: 0x04007BD7 RID: 31703
		public IXUILabelSymbol m_SceneSoloBattleCost;

		// Token: 0x04007BD8 RID: 31704
		public IXUILabelSymbol m_SceneTeamBattleCost;

		// Token: 0x04007BD9 RID: 31705
		public IXUIButton m_SceneQuick1;

		// Token: 0x04007BDA RID: 31706
		public IXUIButton m_SceneQuick10;

		// Token: 0x04007BDB RID: 31707
		public IXUILabel m_SceneQuick10Lab;

		// Token: 0x04007BDC RID: 31708
		public IXUILabel m_DropExpLab;

		// Token: 0x04007BDD RID: 31709
		public IXUILabel m_DropExpLab1;

		// Token: 0x04007BDE RID: 31710
		public GameObject m_SceneFirstSSS;

		// Token: 0x04007BDF RID: 31711
		public IXUILabelSymbol m_SceneFirstSSSReward;

		// Token: 0x04007BE0 RID: 31712
		public IXUILabelSymbol m_Cost;

		// Token: 0x04007BE1 RID: 31713
		public IXUILabel m_SceneRecommendHint;

		// Token: 0x04007BE2 RID: 31714
		public Vector3 m_SceneTeamBattlePos;

		// Token: 0x04007BE3 RID: 31715
		public IXUIButton m_Left;

		// Token: 0x04007BE4 RID: 31716
		public IXUIButton m_Right;

		// Token: 0x04007BE5 RID: 31717
		public IXUITweenTool m_MainHint;

		// Token: 0x04007BE6 RID: 31718
		public IXUILabel m_MainHintText;

		// Token: 0x04007BE7 RID: 31719
		public GameObject m_HardLeftCountGo0;

		// Token: 0x04007BE8 RID: 31720
		public GameObject m_HardLeftCountGo1;

		// Token: 0x04007BE9 RID: 31721
		public IXUILabel m_HardLeftCount0;

		// Token: 0x04007BEA RID: 31722
		public IXUILabel m_HardLeftCount1;

		// Token: 0x04007BEB RID: 31723
		public IXUISprite m_BtnAddHardLeftCount0;

		// Token: 0x04007BEC RID: 31724
		public IXUISprite m_BtnAddHardLeftCount1;

		// Token: 0x04007BED RID: 31725
		public IXUISprite m_PrerogativeSpr;

		// Token: 0x04007BEE RID: 31726
		public IXUILabel m_PrerogativeLab;

		// Token: 0x04007BEF RID: 31727
		public IXUISprite m_PrerogativeBg;

		// Token: 0x04007BF0 RID: 31728
		public IXUIButton m_ShopBtn;
	}
}
