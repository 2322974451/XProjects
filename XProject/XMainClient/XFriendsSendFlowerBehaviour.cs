using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XFriendsSendFlowerBehaviour : DlgBehaviourBase
	{

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

		public const int TOTAL_RANK_NUM = 3;

		public IXUIButton m_Close;

		public IXUISprite m_PlayerImage;

		public IXUIButton m_AddFriends;

		public IXUIButton m_Chat;

		public IXUILabel m_FlowerTotalNum;

		public IXUILabel m_FlowerWeekNum;

		public IXUILabel m_FlowerRankNum;

		public IXUILabel m_PlayerName;

		public IXUILabel m_SendTimes;

		public IXUIButton m_SendOne;

		public IXUIButton m_SendNine;

		public IXUIButton m_SendNN;

		public List<IXUISprite> m_RankBoard = new List<IXUISprite>();

		public List<IXUISprite> m_RankSprite = new List<IXUISprite>();

		public List<IXUILabel> m_RankName = new List<IXUILabel>();

		public List<IXUILabel> m_RankNum = new List<IXUILabel>();

		public List<IXUILabel> m_GiveFatigueNum = new List<IXUILabel>();

		public List<IXUILabel> m_CostMoneyNum = new List<IXUILabel>();

		public List<IXUILabel> m_GiveFlowerNum = new List<IXUILabel>();

		public List<IXUISprite> m_CostSprite = new List<IXUISprite>();

		public List<IXUISprite> m_RewardSprite = new List<IXUISprite>();

		public List<IXUIButton> m_SendButton = new List<IXUIButton>();

		public List<IXUISprite> m_SendFlowerSp = new List<IXUISprite>();

		public XUIPool m_FlowerMsgPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public XUIPool m_FlowerMineMsgPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public IXUILabel m_GiveFatigueNum2;

		public IXUISprite m_SendBoard;

		public IXUISprite m_InfoOther;

		public IXUISprite m_InfoMine;
	}
}
