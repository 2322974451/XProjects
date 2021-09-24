using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XGuildJokerBehaviour : DlgBehaviourBase
	{

		protected void Awake()
		{
			this.m_Close = (base.transform.FindChild("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_Help = (base.transform.FindChild("Bg/Help").GetComponent("XUIButton") as IXUIButton);
			this.m_ReCharge = (base.transform.FindChild("Bg/InfoFrame/InfoDC").GetComponent("XUIButton") as IXUIButton);
			this.m_AddCoin = (base.transform.FindChild("Bg/InfoFrame/InfoGold").GetComponent("XUIButton") as IXUIButton);
			for (int i = 0; i < 5; i++)
			{
				this.m_CardPos[i] = base.transform.FindChild(string.Format("Bg/CardPoint/Card{0}Pos", i + 1));
				this.m_CardPos[i].gameObject.SetActive(false);
			}
			this.m_CardBag = base.transform.FindChild("Bg/CardPoint/CardBag");
			this.m_GameCount = (base.transform.FindChild("Bg/GameCount/Num").GetComponent("XUILabel") as IXUILabel);
			this.m_ChangeCount = (base.transform.FindChild("Bg/FreeChangeCount/Num").GetComponent("XUILabel") as IXUILabel);
			this.m_StartGame = (base.transform.FindChild("Bg/Button").GetComponent("XUIButton") as IXUIButton);
			this.m_CurrentRewardTransfrom = base.transform.FindChild("Bg/CurrentReward");
			this.m_CurrentReward = (base.transform.FindChild("Bg/CurrentReward/Text").GetComponent("XUILabelSymbol") as IXUILabelSymbol);
			this.m_JokerLabel = (base.transform.FindChild("Bg/Talk/Text").GetComponent("XUILabel") as IXUILabel);
			this.m_Rule = base.transform.FindChild("Bg/Rule");
			Transform transform = this.m_Rule.FindChild("Bg/RulePanel/Item");
			this.m_RuleItemPool.SetupPool(transform.parent.gameObject, transform.gameObject, 20U, false);
			this.m_RuleClose = (this.m_Rule.FindChild("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_RuleScrollView = (this.m_Rule.FindChild("Bg/RulePanel").GetComponent("XUIScrollView") as IXUIScrollView);
			this.m_ButtonTip = (base.transform.FindChild("Bg/Button/Tip").GetComponent("XUILabel") as IXUILabel);
			this.m_BestPlayerName = (base.transform.FindChild("Bg/TodayBest/Name").GetComponent("XUILabel") as IXUILabel);
			for (int j = 0; j < 5; j++)
			{
				this.m_BestCardColor[j] = (base.transform.FindChild(string.Format("Bg/TodayBest/Name/Card{0}/Color", j + 1)).GetComponent("XUISprite") as IXUISprite);
				this.m_BestCardNum1[j] = (base.transform.FindChild(string.Format("Bg/TodayBest/Name/Card{0}/Num1", j + 1)).GetComponent("XUILabel") as IXUILabel);
				this.m_BestCardNum2[j] = (base.transform.FindChild(string.Format("Bg/TodayBest/Name/Card{0}/Num2", j + 1)).GetComponent("XUILabel") as IXUILabel);
			}
			this.m_FireWorks = base.transform.FindChild("Bg/FireWorks");
			this.m_JokerPic = (base.transform.FindChild("Bg/Joker").GetComponent("XUITexture") as IXUITexture);
			this.m_GameTip = base.transform.FindChild("Bg/GameTip");
		}

		public IXUIButton m_Close;

		public IXUIButton m_Help;

		public IXUIButton m_ReCharge;

		public IXUIButton m_AddCoin;

		public Transform[] m_CardPos = new Transform[5];

		public Transform m_CardBag;

		public Transform[,] m_Card = new Transform[4, 13];

		public IXUILabel m_GameCount;

		public IXUILabel m_ChangeCount;

		public IXUIButton m_StartGame;

		public Transform m_CurrentRewardTransfrom;

		public IXUILabelSymbol m_CurrentReward;

		public IXUILabel m_JokerLabel;

		public Transform m_Rule;

		public XUIPool m_RuleItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public IXUIScrollView m_RuleScrollView;

		public IXUIButton m_RuleClose;

		public IXUILabel m_ButtonTip;

		public IXUILabel m_BestPlayerName;

		public IXUILabel[] m_BestCardNum1 = new IXUILabel[5];

		public IXUILabel[] m_BestCardNum2 = new IXUILabel[5];

		public IXUISprite[] m_BestCardColor = new IXUISprite[5];

		public Transform m_FireWorks;

		public IXUITexture m_JokerPic;

		public Transform m_GameTip;
	}
}
