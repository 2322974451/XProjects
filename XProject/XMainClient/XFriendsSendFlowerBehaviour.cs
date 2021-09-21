using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000E32 RID: 3634
	internal class XFriendsSendFlowerBehaviour : DlgBehaviourBase
	{
		// Token: 0x0600C341 RID: 49985 RVA: 0x002A3934 File Offset: 0x002A1B34
		private void Awake()
		{
			this.m_Close = (base.transform.Find("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_PlayerImage = (base.transform.Find("Bg/info/head").GetComponent("XUISprite") as IXUISprite);
			this.m_AddFriends = (base.transform.Find("Bg/info/addfriend").GetComponent("XUIButton") as IXUIButton);
			this.m_Chat = (base.transform.Find("Bg/info/chat").GetComponent("XUIButton") as IXUIButton);
			this.m_FlowerTotalNum = (base.transform.Find("Bg/totalnum").GetComponent("XUILabel") as IXUILabel);
			this.m_FlowerWeekNum = (base.transform.Find("Bg/weeklynum").GetComponent("XUILabel") as IXUILabel);
			this.m_FlowerRankNum = (base.transform.Find("Bg/weeklyranknum").GetComponent("XUILabel") as IXUILabel);
			this.m_PlayerName = (base.transform.Find("Bg/titleback/name").GetComponent("XUILabel") as IXUILabel);
			this.m_GiveFatigueNum2 = (base.transform.Find("Bg/SendBoard/send3/Sprite/fatiguenum2").GetComponent("XUILabel") as IXUILabel);
			this.m_SendTimes = (base.transform.Find("Bg/SendBoard/times").GetComponent("XUILabel") as IXUILabel);
			this.m_SendOne = (base.transform.Find("Bg/SendBoard/send1/Sprite/change").GetComponent("XUIButton") as IXUIButton);
			this.m_SendNine = (base.transform.Find("Bg/SendBoard/send2/Sprite/change").GetComponent("XUIButton") as IXUIButton);
			this.m_SendNN = (base.transform.Find("Bg/SendBoard/send3/Sprite/change").GetComponent("XUIButton") as IXUIButton);
			this.m_SendOne.ID = 1UL;
			this.m_SendNine.ID = 9UL;
			this.m_SendNN.ID = 99UL;
			for (int i = 1; i <= 3; i++)
			{
				IXUISprite item = base.transform.Find("Bg/rank/rank" + i.ToString() + "/head").GetComponent("XUISprite") as IXUISprite;
				IXUILabel item2 = base.transform.Find("Bg/rank/rank" + i.ToString() + "/name").GetComponent("XUILabel") as IXUILabel;
				IXUILabel item3 = base.transform.Find("Bg/rank/rank" + i.ToString() + "/num").GetComponent("XUILabel") as IXUILabel;
				IXUISprite item4 = base.transform.Find("Bg/rank/rank" + i.ToString()).GetComponent("XUISprite") as IXUISprite;
				IXUILabel item5 = base.transform.Find("Bg/SendBoard/send" + i.ToString() + "/Sprite/fatiguenum").GetComponent("XUILabel") as IXUILabel;
				IXUILabel item6 = base.transform.Find("Bg/SendBoard/send" + i.ToString() + "/Sprite/coinnum").GetComponent("XUILabel") as IXUILabel;
				IXUILabel item7 = base.transform.Find("Bg/SendBoard/send" + i.ToString() + "/Sprite/change/flowernum").GetComponent("XUILabel") as IXUILabel;
				IXUIButton item8 = base.transform.Find("Bg/SendBoard/send" + i.ToString() + "/Sprite/change").GetComponent("XUIButton") as IXUIButton;
				IXUISprite item9 = base.transform.Find("Bg/SendBoard/send" + i.ToString() + "/Sprite/change/Sprite").GetComponent("XUISprite") as IXUISprite;
				IXUISprite item10 = base.transform.Find("Bg/SendBoard/send" + i.ToString() + "/Sprite/iconreward").GetComponent("XUISprite") as IXUISprite;
				IXUISprite item11 = base.transform.Find("Bg/SendBoard/send" + i.ToString() + "/Sprite/iconcost").GetComponent("XUISprite") as IXUISprite;
				this.m_RankBoard.Add(item4);
				this.m_RankSprite.Add(item);
				this.m_RankName.Add(item2);
				this.m_RankNum.Add(item3);
				this.m_GiveFatigueNum.Add(item5);
				this.m_CostMoneyNum.Add(item6);
				this.m_GiveFlowerNum.Add(item7);
				this.m_SendButton.Add(item8);
				this.m_SendFlowerSp.Add(item9);
				this.m_CostSprite.Add(item11);
				this.m_RewardSprite.Add(item10);
			}
			GameObject gameObject = base.transform.FindChild("Bg/back/scrollteam").gameObject;
			GameObject gameObject2 = base.transform.FindChild("Bg/back/scrollteam/template").gameObject;
			this.m_FlowerMsgPool.SetupPool(gameObject, gameObject2, 10U, false);
			this.m_FlowerMineMsgPool.SetupPool(base.transform.FindChild("Bg/backMine/scrollteam").gameObject, base.transform.FindChild("Bg/backMine/scrollteam/template").gameObject, 10U, false);
			this.m_SendBoard = (base.transform.FindChild("Bg/SendBoard").GetComponent("XUISprite") as IXUISprite);
			this.m_InfoOther = (base.transform.FindChild("Bg/back").GetComponent("XUISprite") as IXUISprite);
			this.m_InfoMine = (base.transform.FindChild("Bg/backMine").GetComponent("XUISprite") as IXUISprite);
		}

		// Token: 0x04005443 RID: 21571
		public const int TOTAL_RANK_NUM = 3;

		// Token: 0x04005444 RID: 21572
		public IXUIButton m_Close;

		// Token: 0x04005445 RID: 21573
		public IXUISprite m_PlayerImage;

		// Token: 0x04005446 RID: 21574
		public IXUIButton m_AddFriends;

		// Token: 0x04005447 RID: 21575
		public IXUIButton m_Chat;

		// Token: 0x04005448 RID: 21576
		public IXUILabel m_FlowerTotalNum;

		// Token: 0x04005449 RID: 21577
		public IXUILabel m_FlowerWeekNum;

		// Token: 0x0400544A RID: 21578
		public IXUILabel m_FlowerRankNum;

		// Token: 0x0400544B RID: 21579
		public IXUILabel m_PlayerName;

		// Token: 0x0400544C RID: 21580
		public IXUILabel m_SendTimes;

		// Token: 0x0400544D RID: 21581
		public IXUIButton m_SendOne;

		// Token: 0x0400544E RID: 21582
		public IXUIButton m_SendNine;

		// Token: 0x0400544F RID: 21583
		public IXUIButton m_SendNN;

		// Token: 0x04005450 RID: 21584
		public List<IXUISprite> m_RankBoard = new List<IXUISprite>();

		// Token: 0x04005451 RID: 21585
		public List<IXUISprite> m_RankSprite = new List<IXUISprite>();

		// Token: 0x04005452 RID: 21586
		public List<IXUILabel> m_RankName = new List<IXUILabel>();

		// Token: 0x04005453 RID: 21587
		public List<IXUILabel> m_RankNum = new List<IXUILabel>();

		// Token: 0x04005454 RID: 21588
		public List<IXUILabel> m_GiveFatigueNum = new List<IXUILabel>();

		// Token: 0x04005455 RID: 21589
		public List<IXUILabel> m_CostMoneyNum = new List<IXUILabel>();

		// Token: 0x04005456 RID: 21590
		public List<IXUILabel> m_GiveFlowerNum = new List<IXUILabel>();

		// Token: 0x04005457 RID: 21591
		public List<IXUISprite> m_CostSprite = new List<IXUISprite>();

		// Token: 0x04005458 RID: 21592
		public List<IXUISprite> m_RewardSprite = new List<IXUISprite>();

		// Token: 0x04005459 RID: 21593
		public List<IXUIButton> m_SendButton = new List<IXUIButton>();

		// Token: 0x0400545A RID: 21594
		public List<IXUISprite> m_SendFlowerSp = new List<IXUISprite>();

		// Token: 0x0400545B RID: 21595
		public XUIPool m_FlowerMsgPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x0400545C RID: 21596
		public XUIPool m_FlowerMineMsgPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x0400545D RID: 21597
		public IXUILabel m_GiveFatigueNum2;

		// Token: 0x0400545E RID: 21598
		public IXUISprite m_SendBoard;

		// Token: 0x0400545F RID: 21599
		public IXUISprite m_InfoOther;

		// Token: 0x04005460 RID: 21600
		public IXUISprite m_InfoMine;
	}
}
