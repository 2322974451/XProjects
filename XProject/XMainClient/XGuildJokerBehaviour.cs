using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000E42 RID: 3650
	internal class XGuildJokerBehaviour : DlgBehaviourBase
	{
		// Token: 0x0600C410 RID: 50192 RVA: 0x002AB884 File Offset: 0x002A9A84
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

		// Token: 0x04005521 RID: 21793
		public IXUIButton m_Close;

		// Token: 0x04005522 RID: 21794
		public IXUIButton m_Help;

		// Token: 0x04005523 RID: 21795
		public IXUIButton m_ReCharge;

		// Token: 0x04005524 RID: 21796
		public IXUIButton m_AddCoin;

		// Token: 0x04005525 RID: 21797
		public Transform[] m_CardPos = new Transform[5];

		// Token: 0x04005526 RID: 21798
		public Transform m_CardBag;

		// Token: 0x04005527 RID: 21799
		public Transform[,] m_Card = new Transform[4, 13];

		// Token: 0x04005528 RID: 21800
		public IXUILabel m_GameCount;

		// Token: 0x04005529 RID: 21801
		public IXUILabel m_ChangeCount;

		// Token: 0x0400552A RID: 21802
		public IXUIButton m_StartGame;

		// Token: 0x0400552B RID: 21803
		public Transform m_CurrentRewardTransfrom;

		// Token: 0x0400552C RID: 21804
		public IXUILabelSymbol m_CurrentReward;

		// Token: 0x0400552D RID: 21805
		public IXUILabel m_JokerLabel;

		// Token: 0x0400552E RID: 21806
		public Transform m_Rule;

		// Token: 0x0400552F RID: 21807
		public XUIPool m_RuleItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04005530 RID: 21808
		public IXUIScrollView m_RuleScrollView;

		// Token: 0x04005531 RID: 21809
		public IXUIButton m_RuleClose;

		// Token: 0x04005532 RID: 21810
		public IXUILabel m_ButtonTip;

		// Token: 0x04005533 RID: 21811
		public IXUILabel m_BestPlayerName;

		// Token: 0x04005534 RID: 21812
		public IXUILabel[] m_BestCardNum1 = new IXUILabel[5];

		// Token: 0x04005535 RID: 21813
		public IXUILabel[] m_BestCardNum2 = new IXUILabel[5];

		// Token: 0x04005536 RID: 21814
		public IXUISprite[] m_BestCardColor = new IXUISprite[5];

		// Token: 0x04005537 RID: 21815
		public Transform m_FireWorks;

		// Token: 0x04005538 RID: 21816
		public IXUITexture m_JokerPic;

		// Token: 0x04005539 RID: 21817
		public Transform m_GameTip;
	}
}
