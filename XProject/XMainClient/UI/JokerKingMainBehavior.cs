using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x02001764 RID: 5988
	internal class JokerKingMainBehavior : DlgBehaviourBase
	{
		// Token: 0x0600F73C RID: 63292 RVA: 0x003835F4 File Offset: 0x003817F4
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

		// Token: 0x04006B81 RID: 27521
		public IXUIButton m_Close;

		// Token: 0x04006B82 RID: 27522
		public IXUIButton m_BtnRankReward;

		// Token: 0x04006B83 RID: 27523
		public IXUIButton m_BtnGo;

		// Token: 0x04006B84 RID: 27524
		public IXUIButton m_BtnDisable;

		// Token: 0x04006B85 RID: 27525
		public IXUILabelSymbol m_LabelSymbol;

		// Token: 0x04006B86 RID: 27526
		public IXUILabel m_info;

		// Token: 0x04006B87 RID: 27527
		public Transform m_Matching;

		// Token: 0x04006B88 RID: 27528
		public IXUISprite m_BtnRankSprite;

		// Token: 0x04006B89 RID: 27529
		public Transform m_RankList;

		// Token: 0x04006B8A RID: 27530
		public IXUIScrollView m_ScrollView;

		// Token: 0x04006B8B RID: 27531
		public IXUIWrapContent m_WrapContent;

		// Token: 0x04006B8C RID: 27532
		public IXUILabel m_IntroText;

		// Token: 0x04006B8D RID: 27533
		public Transform m_Reward;

		// Token: 0x04006B8E RID: 27534
		public XUIPool m_RewardPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);
	}
}
