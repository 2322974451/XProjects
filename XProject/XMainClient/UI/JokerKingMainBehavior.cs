using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class JokerKingMainBehavior : DlgBehaviourBase
	{

		private void Awake()
		{
			this.m_Close = (base.transform.FindChild("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_BtnGo = (base.transform.FindChild("Bg/Btn_Go").GetComponent("XUIButton") as IXUIButton);
			this.m_BtnRankReward = (base.transform.FindChild("Bg/BtnRankReward").GetComponent("XUIButton") as IXUIButton);
			this.m_BtnDisable = (base.transform.FindChild("Bg/Btn_Disable").GetComponent("XUIButton") as IXUIButton);
			this.m_info = (base.transform.FindChild("Bg/Info").GetComponent("XUILabel") as IXUILabel);
			this.m_RankList = base.transform.FindChild("Bg/RankList");
			this.m_ScrollView = (base.transform.FindChild("Bg/RankList/ScrollView").GetComponent("XUIScrollView") as IXUIScrollView);
			this.m_WrapContent = (base.transform.FindChild("Bg/RankList/ScrollView/WrapContent").GetComponent("XUIWrapContent") as IXUIWrapContent);
			this.m_IntroText = (base.transform.FindChild("Bg/help/Intro/Text").GetComponent("XUILabel") as IXUILabel);
			this.m_Reward = base.transform.FindChild("Bg/help/Intro/Reward");
			Transform transform = base.transform.FindChild("Bg/help/Intro/Reward/item");
			this.m_RewardPool.SetupPool(this.m_Reward.gameObject, transform.gameObject, 5U, true);
			this.m_Matching = base.transform.FindChild("Bg/Matching");
			this.m_BtnRankSprite = (base.transform.FindChild("Bg/RankList/Mask").GetComponent("XUISprite") as IXUISprite);
			this.m_LabelSymbol = (base.transform.FindChild("Bg/Btn_Go/Go").GetComponent("XUILabelSymbol") as IXUILabelSymbol);
		}

		public IXUIButton m_Close;

		public IXUIButton m_BtnRankReward;

		public IXUIButton m_BtnGo;

		public IXUIButton m_BtnDisable;

		public IXUILabelSymbol m_LabelSymbol;

		public IXUILabel m_info;

		public Transform m_Matching;

		public IXUISprite m_BtnRankSprite;

		public Transform m_RankList;

		public IXUIScrollView m_ScrollView;

		public IXUIWrapContent m_WrapContent;

		public IXUILabel m_IntroText;

		public Transform m_Reward;

		public XUIPool m_RewardPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);
	}
}
