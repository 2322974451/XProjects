using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class CardCollectBehaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			this.m_CardGroupList = base.transform.FindChild("Bg");
			this.m_CardGroupList = base.transform.FindChild("Bg/CardGroupList");
			this.m_CardGroupListClose = (this.m_CardGroupList.FindChild("Bg/Close").GetComponent("XUISprite") as IXUISprite);
			this.m_OldSumAttribute = (this.m_CardGroupList.FindChild("Bg/Attribute").GetComponent("XUILabel") as IXUILabel);
			Transform transform = this.m_CardGroupList.Find("Bg/CardGroupPanle/DeckTpl");
			this.m_OldDeckPool.SetupPool(null, transform.gameObject, (uint)XCardCollectDocument.GroupMax, false);
			this.m_Deck = base.transform.FindChild("Bg/Deck");
			this.m_DeckClose = (this.m_Deck.FindChild("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_DeckHelp = (this.m_Deck.FindChild("Bg/Help").GetComponent("XUIButton") as IXUIButton);
			this.m_DeckAttribute = (this.m_Deck.FindChild("Bg/Attribute").GetComponent("XUILabel") as IXUILabel);
			Transform transform2 = this.m_Deck.Find("Bg/ActionNumReward/NumRewardTpl");
			this.m_NumRewardPool.SetupPool(null, transform2.gameObject, XDeck.DECK_PER_REWARD_COUNT_MAX, false);
			this.m_OpenCardList = (this.m_Deck.FindChild("Bg/OpenCardList").GetComponent("XUISprite") as IXUISprite);
			this.m_OpenCardShop = (this.m_Deck.FindChild("Bg/OpenShop").GetComponent("XUISprite") as IXUISprite);
			this.m_ActivatedNum = (this.m_Deck.FindChild("Bg/Frame/ActivatedNum").GetComponent("XUILabel") as IXUILabel);
			this.m_Title = (this.m_Deck.FindChild("Bg/Frame/Title").GetComponent("XUILabel") as IXUILabel);
			this.m_ActionNumRewardTips = this.m_Deck.FindChild("Bg/ActionNumRewardTips");
			this.m_RewardClose = (this.m_ActionNumRewardTips.FindChild("Close").GetComponent("XUISprite") as IXUISprite);
			this.m_RewardActive = this.m_ActionNumRewardTips.FindChild("Active");
			this.m_RewardNoActive = this.m_ActionNumRewardTips.FindChild("NoActive");
			this.m_RewardNeedNum = (this.m_ActionNumRewardTips.FindChild("NoActive/Num").GetComponent("XUILabel") as IXUILabel);
			this.m_RewardAttribute = (this.m_ActionNumRewardTips.FindChild("Attribute").GetComponent("XUILabel") as IXUILabel);
			this.m_GetActionNumReward = this.m_Deck.FindChild("Bg/GetActionNumReward");
			this.m_GetRewardClose = (this.m_GetActionNumReward.FindChild("Close").GetComponent("XUISprite") as IXUISprite);
			this.m_GetRewardAttribute = (this.m_GetActionNumReward.FindChild("Attribute").GetComponent("XUILabel") as IXUILabel);
			Transform transform3 = this.m_Deck.FindChild("Bg/GroupPanel/WrapContent/GroupTpl/Item/ItemTpl");
			this.m_ItemPool.SetupPool(null, transform3.gameObject, XDeck.GROUP_NEED_CARD_MAX, false);
			this.m_ItemPool.FakeReturnAll();
			int num = 0;
			while ((long)num < (long)((ulong)XDeck.GROUP_NEED_CARD_MAX))
			{
				GameObject gameObject = this.m_ItemPool.FetchGameObject(false);
				gameObject.transform.localPosition = new Vector3((float)(this.m_ItemPool.TplWidth * num), 0f, 0f) + this.m_ItemPool.TplPos;
				num++;
			}
			this.m_ItemPool.ActualReturnAll(false);
			this.m_GroupScrollView = (this.m_Deck.Find("Bg/GroupPanel").GetComponent("XUIScrollView") as IXUIScrollView);
			this.m_WrapContent = (this.m_Deck.Find("Bg/GroupPanel/WrapContent").GetComponent("XUIWrapContent") as IXUIWrapContent);
			this.m_SumAttribute = (this.m_Deck.FindChild("Bg/TotalAttri").GetComponent("XUILabel") as IXUILabel);
			this.m_GoRisk = (this.m_Deck.FindChild("Bg/GoRisk").GetComponent("XUISprite") as IXUISprite);
			this.m_DeckScrollView = (this.m_Deck.Find("Bg/DeckPanel").GetComponent("XUIScrollView") as IXUIScrollView);
			Transform transform4 = this.m_Deck.FindChild("Bg/DeckPanel/DeckTpl");
			Transform transform5 = transform4.FindChild("StarTpl");
			this.m_StarPool.SetupPool(null, transform5.gameObject, CardCollectView.STAR_MAX, false);
			int num2 = 0;
			while ((long)num2 < (long)((ulong)CardCollectView.STAR_MAX))
			{
				GameObject gameObject2 = this.m_StarPool.FetchGameObject(false);
				gameObject2.name = string.Format("star{0}", num2);
				gameObject2.transform.localPosition = new Vector3((float)(this.m_StarPool.TplWidth * num2), 0f, 0f) + this.m_StarPool.TplPos;
				num2++;
			}
			this.m_DeckPool.SetupPool(null, transform4.gameObject, (uint)XCardCollectDocument.GroupMax, false);
			this.m_DeckLock = this.m_Deck.FindChild("Bg/Lock");
			this.m_DeckUnlock = (this.m_DeckLock.FindChild("BtnUnlock").GetComponent("XUIButton") as IXUIButton);
			this.m_DeckLabel = (this.m_DeckLock.FindChild("Label").GetComponent("XUILabel") as IXUILabel);
			this.m_CardTotalFrame = base.transform.FindChild("Bg/CardList");
			this.m_CardDetail = base.transform.FindChild("Bg/Detail");
			this.m_DetailClose = (this.m_CardDetail.FindChild("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			Transform transform6 = this.m_CardDetail.FindChild("Bg/Left");
			this.m_DetailName = (transform6.FindChild("Name").GetComponent("XUILabel") as IXUILabel);
			this.m_DetailStory = (transform6.FindChild("Story").GetComponent("XUILabel") as IXUILabel);
			this.m_DetailPic = (transform6.FindChild("Pic").GetComponent("XUITexture") as IXUITexture);
			this.m_Snapshot = (this.m_CardDetail.FindChild("Bg/Left/Snapshot").GetComponent("UIDummy") as IUIDummy);
			this.m_DetailActiveNum = (this.m_CardDetail.FindChild("Bg/ActiveNum").GetComponent("XUILabel") as IXUILabel);
			this.m_DetailResolve = (this.m_CardDetail.FindChild("Bg/Num/Resolve").GetComponent("XUISprite") as IXUISprite);
			this.m_DetailBuy = (this.m_CardDetail.FindChild("Bg/Num/Buy").GetComponent("XUISprite") as IXUISprite);
			this.m_DetailNum = (this.m_CardDetail.FindChild("Bg/Num/Num").GetComponent("XUILabel") as IXUILabel);
			this.m_OldGoRisk = (this.m_CardDetail.FindChild("Bg/GoRisk").GetComponent("XUISprite") as IXUISprite);
			this.m_GoShop = (this.m_CardDetail.FindChild("Bg/GoShop").GetComponent("XUISprite") as IXUISprite);
			this.m_DetailGroupScrollView = (this.m_CardDetail.Find("Bg/GroupPanel").GetComponent("XUIScrollView") as IXUIScrollView);
			Transform transform7 = this.m_CardDetail.Find("Bg/GroupPanel/GroupTpl");
			this.m_DetailGroupPool.SetupPool(null, transform7.gameObject, 5U, false);
			this.m_CardShopFrame = base.transform.FindChild("Bg/Shop");
			this.m_FilterPanel = base.transform.FindChild("Bg/FilterPanel");
			this.m_ResolvePanel = base.transform.FindChild("Bg/ResolvePanel");
			this.m_ResolveClose = (this.m_ResolvePanel.FindChild("Close").GetComponent("XUISprite") as IXUISprite);
			this.m_ResolveGetItem = this.m_ResolvePanel.FindChild("Item");
			this.m_ResolveOK = (this.m_ResolvePanel.FindChild("OK").GetComponent("XUISprite") as IXUISprite);
			this.m_ResolveNum = (this.m_ResolvePanel.FindChild("Count/Label").GetComponent("XUILabel") as IXUILabel);
			this.m_ResolveNumSub = (this.m_ResolvePanel.FindChild("Count/Sub").GetComponent("XUISprite") as IXUISprite);
			this.m_ResolveNumAdd = (this.m_ResolvePanel.FindChild("Count/Add").GetComponent("XUISprite") as IXUISprite);
			this.m_Fx = base.transform.FindChild("Bg/Fx");
		}

		public Transform m_CardGroupList;

		public Transform m_Deck;

		public Transform m_CardTotalFrame;

		public Transform m_CardDetail;

		public Transform m_CardShopFrame;

		public Transform m_FilterPanel;

		public Transform m_ResolvePanel;

		public IXUILabel m_OldSumAttribute;

		public IXUISprite m_CardGroupListClose;

		public IXUILabel m_DeckAttribute;

		public IXUIButton m_DeckClose;

		public IXUIButton m_DeckHelp;

		public IXUISprite m_OpenCardList;

		public IXUISprite m_OpenCardShop;

		public IXUIWrapContent m_WrapContent;

		public IXUILabel m_ActivatedNum;

		public IXUILabel m_Title;

		public XUIPool m_StarPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public IXUIScrollView m_GroupScrollView;

		public IXUIScrollView m_DeckScrollView;

		public IUIDummy m_Snapshot;

		public IXUILabel m_RewardNeedNum;

		public Transform m_ActionNumRewardTips;

		public IXUISprite m_RewardClose;

		public IXUILabel m_RewardAttribute;

		public Transform m_GetActionNumReward;

		public IXUISprite m_GetRewardClose;

		public IXUILabel m_GetRewardAttribute;

		public IXUILabel m_SumAttribute;

		public IXUISprite m_GoRisk;

		public Transform m_RewardActive;

		public Transform m_RewardNoActive;

		public Transform m_DeckLock;

		public IXUIButton m_DeckUnlock;

		public IXUILabel m_DeckLabel;

		public IXUIButton m_DetailClose;

		public IXUISprite m_DetailResolve;

		public IXUISprite m_DetailBuy;

		public IXUISprite m_OldGoRisk;

		public IXUISprite m_GoShop;

		public IXUILabel m_DetailNum;

		public IXUILabel m_DetailActiveNum;

		public IXUILabel m_DetailName;

		public IXUILabel m_DetailStory;

		public IXUIScrollView m_DetailGroupScrollView;

		public IXUITexture m_DetailPic;

		public Transform m_Fx;

		public IXUISprite m_ResolveClose;

		public Transform m_ResolveGetItem;

		public IXUISprite m_ResolveOK;

		public IXUISprite m_ResolveNumSub;

		public IXUISprite m_ResolveNumAdd;

		public IXUILabel m_ResolveNum;

		public XUIPool m_NumRewardPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public XUIPool m_ItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public XUIPool m_DetailGroupPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public XUIPool m_OldDeckPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public XUIPool m_DeckPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);
	}
}
