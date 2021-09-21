using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000BFB RID: 3067
	internal class CardCollectBehaviour : DlgBehaviourBase
	{
		// Token: 0x0600AE5C RID: 44636 RVA: 0x0020AA88 File Offset: 0x00208C88
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

		// Token: 0x0400420C RID: 16908
		public Transform m_CardGroupList;

		// Token: 0x0400420D RID: 16909
		public Transform m_Deck;

		// Token: 0x0400420E RID: 16910
		public Transform m_CardTotalFrame;

		// Token: 0x0400420F RID: 16911
		public Transform m_CardDetail;

		// Token: 0x04004210 RID: 16912
		public Transform m_CardShopFrame;

		// Token: 0x04004211 RID: 16913
		public Transform m_FilterPanel;

		// Token: 0x04004212 RID: 16914
		public Transform m_ResolvePanel;

		// Token: 0x04004213 RID: 16915
		public IXUILabel m_OldSumAttribute;

		// Token: 0x04004214 RID: 16916
		public IXUISprite m_CardGroupListClose;

		// Token: 0x04004215 RID: 16917
		public IXUILabel m_DeckAttribute;

		// Token: 0x04004216 RID: 16918
		public IXUIButton m_DeckClose;

		// Token: 0x04004217 RID: 16919
		public IXUIButton m_DeckHelp;

		// Token: 0x04004218 RID: 16920
		public IXUISprite m_OpenCardList;

		// Token: 0x04004219 RID: 16921
		public IXUISprite m_OpenCardShop;

		// Token: 0x0400421A RID: 16922
		public IXUIWrapContent m_WrapContent;

		// Token: 0x0400421B RID: 16923
		public IXUILabel m_ActivatedNum;

		// Token: 0x0400421C RID: 16924
		public IXUILabel m_Title;

		// Token: 0x0400421D RID: 16925
		public XUIPool m_StarPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x0400421E RID: 16926
		public IXUIScrollView m_GroupScrollView;

		// Token: 0x0400421F RID: 16927
		public IXUIScrollView m_DeckScrollView;

		// Token: 0x04004220 RID: 16928
		public IUIDummy m_Snapshot;

		// Token: 0x04004221 RID: 16929
		public IXUILabel m_RewardNeedNum;

		// Token: 0x04004222 RID: 16930
		public Transform m_ActionNumRewardTips;

		// Token: 0x04004223 RID: 16931
		public IXUISprite m_RewardClose;

		// Token: 0x04004224 RID: 16932
		public IXUILabel m_RewardAttribute;

		// Token: 0x04004225 RID: 16933
		public Transform m_GetActionNumReward;

		// Token: 0x04004226 RID: 16934
		public IXUISprite m_GetRewardClose;

		// Token: 0x04004227 RID: 16935
		public IXUILabel m_GetRewardAttribute;

		// Token: 0x04004228 RID: 16936
		public IXUILabel m_SumAttribute;

		// Token: 0x04004229 RID: 16937
		public IXUISprite m_GoRisk;

		// Token: 0x0400422A RID: 16938
		public Transform m_RewardActive;

		// Token: 0x0400422B RID: 16939
		public Transform m_RewardNoActive;

		// Token: 0x0400422C RID: 16940
		public Transform m_DeckLock;

		// Token: 0x0400422D RID: 16941
		public IXUIButton m_DeckUnlock;

		// Token: 0x0400422E RID: 16942
		public IXUILabel m_DeckLabel;

		// Token: 0x0400422F RID: 16943
		public IXUIButton m_DetailClose;

		// Token: 0x04004230 RID: 16944
		public IXUISprite m_DetailResolve;

		// Token: 0x04004231 RID: 16945
		public IXUISprite m_DetailBuy;

		// Token: 0x04004232 RID: 16946
		public IXUISprite m_OldGoRisk;

		// Token: 0x04004233 RID: 16947
		public IXUISprite m_GoShop;

		// Token: 0x04004234 RID: 16948
		public IXUILabel m_DetailNum;

		// Token: 0x04004235 RID: 16949
		public IXUILabel m_DetailActiveNum;

		// Token: 0x04004236 RID: 16950
		public IXUILabel m_DetailName;

		// Token: 0x04004237 RID: 16951
		public IXUILabel m_DetailStory;

		// Token: 0x04004238 RID: 16952
		public IXUIScrollView m_DetailGroupScrollView;

		// Token: 0x04004239 RID: 16953
		public IXUITexture m_DetailPic;

		// Token: 0x0400423A RID: 16954
		public Transform m_Fx;

		// Token: 0x0400423B RID: 16955
		public IXUISprite m_ResolveClose;

		// Token: 0x0400423C RID: 16956
		public Transform m_ResolveGetItem;

		// Token: 0x0400423D RID: 16957
		public IXUISprite m_ResolveOK;

		// Token: 0x0400423E RID: 16958
		public IXUISprite m_ResolveNumSub;

		// Token: 0x0400423F RID: 16959
		public IXUISprite m_ResolveNumAdd;

		// Token: 0x04004240 RID: 16960
		public IXUILabel m_ResolveNum;

		// Token: 0x04004241 RID: 16961
		public XUIPool m_NumRewardPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04004242 RID: 16962
		public XUIPool m_ItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04004243 RID: 16963
		public XUIPool m_DetailGroupPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04004244 RID: 16964
		public XUIPool m_OldDeckPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04004245 RID: 16965
		public XUIPool m_DeckPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);
	}
}
