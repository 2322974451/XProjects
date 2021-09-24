using System;
using System.Collections.Generic;
using System.Text;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class CardCollectView : DlgBase<CardCollectView, CardCollectBehaviour>
	{

		public CardTotalHandler TotalHandler
		{
			get
			{
				return this.m_CardTotalHandler;
			}
		}

		public XCardShopHandler ShopHandler
		{
			get
			{
				return this.m_CardShopHandler;
			}
		}

		public CardPage CurPage
		{
			get
			{
				bool flag = this.m_uiStack.Count == 0;
				CardPage result;
				if (flag)
				{
					result = CardPage.None;
				}
				else
				{
					result = this.m_uiStack.Peek();
				}
				return result;
			}
		}

		public override string fileName
		{
			get
			{
				return "GameSystem/CardCollectDlg";
			}
		}

		public override int layer
		{
			get
			{
				return 1;
			}
		}

		public override int group
		{
			get
			{
				return 1;
			}
		}

		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		public override bool hideMainMenu
		{
			get
			{
				return true;
			}
		}

		public override bool fullscreenui
		{
			get
			{
				return true;
			}
		}

		public override bool pushstack
		{
			get
			{
				return true;
			}
		}

		public override int sysid
		{
			get
			{
				return XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_CardCollect);
			}
		}

		protected override void Init()
		{
			this.shopdoc = XDocuments.GetSpecificDocument<XNormalShopDocument>(XNormalShopDocument.uuID);
			this.doc = XDocuments.GetSpecificDocument<XCardCollectDocument>(XCardCollectDocument.uuID);
			this.doc.View = this;
			DlgHandlerBase.EnsureCreate<XCardShopHandler>(ref this.m_CardShopHandler, base.uiBehaviour.m_CardShopFrame.gameObject, null, true);
			DlgHandlerBase.EnsureCreate<CardTotalHandler>(ref this.m_CardTotalHandler, base.uiBehaviour.m_CardTotalFrame.gameObject, null, true);
			DlgHandlerBase.EnsureCreate<QualityFilterHandler>(ref this.qualityFilter, base.uiBehaviour.m_FilterPanel.gameObject, null, true);
			this.qualityFilter.Set(CardCollectView.QualityMask, new QualityFilterCallback(this._OnFilterOK));
		}

		protected void _OnFilterOK(int mask)
		{
			CardCollectView.QualityMask = mask;
			List<uint> list = new List<uint>();
			int num = 1;
			for (int i = 1; i <= 5; i++)
			{
				num <<= 1;
				bool flag = (num & mask) != 0;
				if (flag)
				{
					list.Add((uint)i);
				}
			}
			this.doc.ReqAutoBreak(list);
		}

		public override void RegisterEvent()
		{
			base.uiBehaviour.m_CardGroupListClose.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this._OnCardGroupListCloseClick));
			base.uiBehaviour.m_DeckClose.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnDeckCloseClick));
			base.uiBehaviour.m_DeckHelp.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnHelpBtnClicked));
			base.uiBehaviour.m_DetailClose.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnDetailCloseClick));
			base.uiBehaviour.m_DeckUnlock.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnUpStarClick));
			base.uiBehaviour.m_RewardClose.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this._OnRewardCloseClick));
			base.uiBehaviour.m_ResolveClose.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this._OnResolveCloseClick));
			base.uiBehaviour.m_GetRewardClose.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this._OnGetRewardCloseClick));
			base.uiBehaviour.m_ResolveOK.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this._OnResolveOKClick));
			base.uiBehaviour.m_ResolveNumSub.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this._OnResolveNumSubClick));
			base.uiBehaviour.m_ResolveNumAdd.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this._OnResolveNumAddClick));
			base.uiBehaviour.m_OpenCardList.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this._OnOpenCardListClick));
			base.uiBehaviour.m_WrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this._OnGroupListItemUpdated));
		}

		private void _OnCardGroupListCloseClick(IXUISprite iSp)
		{
			this.SetVisibleWithAnimation(false, null);
		}

		private void _OnOpenDeckClicked(IXUISprite iSp)
		{
			this.doc.Select((uint)iSp.ID);
		}

		private bool _OnDeckCloseClick(IXUIButton go)
		{
			this.CloseCurPage(CardPage.Deck);
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

		private void _OnOpenCardListClick(IXUISprite iSp)
		{
			this.ShowPage(CardPage.CardAll, true);
		}

		public void OnOpenDetailClick(IXUISprite iSp)
		{
			this.CurCardID = (int)iSp.ID;
			this.ShowPage(CardPage.CardDetail, true);
		}

		private bool _OnDetailCloseClick(IXUIButton go)
		{
			this.CloseCurPage(CardPage.CardDetail);
			base.uiBehaviour.m_CardDetail.gameObject.SetActive(false);
			return true;
		}

		private bool _OnUpStarClick(IXUIButton go)
		{
			this.doc.ReqUpStar();
			return true;
		}

		private void _OnOpenCardShopClick(IXUISprite iSp)
		{
			this.ShowPage(CardPage.CardShop, true);
		}

		protected override void OnShow()
		{
			base.OnShow();
			base.Alloc3DAvatarPool("CardCollectView");
			base.uiBehaviour.m_CardGroupList.gameObject.SetActive(false);
			base.uiBehaviour.m_Deck.gameObject.SetActive(false);
			base.uiBehaviour.m_CardTotalFrame.gameObject.SetActive(false);
			base.uiBehaviour.m_CardDetail.gameObject.SetActive(false);
			base.uiBehaviour.m_CardShopFrame.gameObject.SetActive(false);
			base.uiBehaviour.m_ResolvePanel.gameObject.SetActive(false);
			this.qualityFilter.SetVisible(false);
			this.ShowPage(CardPage.Deck, true);
		}

		public void UnloadFx(XFx fx)
		{
			bool flag = fx != null;
			if (flag)
			{
				XSingleton<XFxMgr>.singleton.DestroyFx(fx, true);
				fx = null;
			}
		}

		protected override void OnHide()
		{
			this.UnloadFx(this._StarUpFx);
			base.Return3DAvatarPool();
			this.CloseCurPage(CardPage.ALL);
			base.OnHide();
		}

		public override void StackRefresh()
		{
			base.StackRefresh();
			base.Alloc3DAvatarPool("CardCollectView");
		}

		protected override void OnUnload()
		{
			base.Return3DAvatarPool();
			DlgHandlerBase.EnsureUnload<XCardShopHandler>(ref this.m_CardShopHandler);
			DlgHandlerBase.EnsureUnload<CardTotalHandler>(ref this.m_CardTotalHandler);
			DlgHandlerBase.EnsureUnload<QualityFilterHandler>(ref this.qualityFilter);
			this.doc.View = null;
			this.CloseCurPage(CardPage.ALL);
			base.OnUnload();
		}

		public void CloseCurPage(CardPage closePage)
		{
			bool flag = closePage == CardPage.ALL;
			if (flag)
			{
				this.m_uiStack.Clear();
				this.CurCardID = 0;
				this.CurShopID = 0;
				XSingleton<X3DAvatarMgr>.singleton.DestroyDummy(this.m_dummPool, this._CardDummy);
				this._CardDummy = null;
				base.uiBehaviour.m_DetailPic.SetTexturePath("");
			}
			else
			{
				bool flag2 = this.m_uiStack.Count != 0;
				if (flag2)
				{
					bool flag3 = this.CurPage == closePage;
					if (flag3)
					{
						bool flag4 = this.CurPage == CardPage.CardDetail;
						if (flag4)
						{
							this.CurCardID = 0;
							XSingleton<X3DAvatarMgr>.singleton.DestroyDummy(this.m_dummPool, this._CardDummy);
							this._CardDummy = null;
							base.uiBehaviour.m_DetailPic.SetTexturePath("");
						}
						bool flag5 = this.CurPage == CardPage.CardShop;
						if (flag5)
						{
							this.CurShopID = 0;
						}
						this.m_uiStack.Pop();
						bool flag6 = this.CurPage > CardPage.None;
						if (flag6)
						{
							this.ShowPage(this.CurPage, false);
						}
					}
					else
					{
						XSingleton<XDebug>.singleton.AddErrorLog(string.Concat(new object[]
						{
							"CurPage:",
							this.CurPage,
							" ClosePage:",
							closePage
						}), null, null, null, null, null);
						this.CloseCurPage(CardPage.ALL);
						this.SetVisibleWithAnimation(false, null);
					}
				}
			}
		}

		public void ShowPage(CardPage page, bool IsPush = true)
		{
			if (IsPush)
			{
				this.m_uiStack.Push(page);
			}
			switch (page)
			{
			case CardPage.CardGroupList:
				base.uiBehaviour.m_CardGroupList.gameObject.SetActive(true);
				this.OldRefreshShowCardGroupList();
				break;
			case CardPage.Deck:
				base.uiBehaviour.m_Deck.gameObject.SetActive(true);
				this.RefreshShowDeck(IsPush);
				break;
			case CardPage.CardAll:
				base.uiBehaviour.m_CardTotalFrame.gameObject.SetActive(true);
				this.m_CardTotalHandler.ShowHandler(IsPush);
				break;
			case CardPage.CardDetail:
			{
				bool flag = this.CurCardID != 0;
				if (flag)
				{
					base.uiBehaviour.m_CardDetail.gameObject.SetActive(true);
					this.RefreshDetail();
				}
				break;
			}
			case CardPage.CardShop:
				base.uiBehaviour.m_CardShopFrame.gameObject.SetActive(true);
				this.m_CardShopHandler.ShowHandler(this.CurShopID, IsPush);
				break;
			}
		}

		public void OldRefreshShowCardGroupList()
		{
			bool flag = this.CurPage != CardPage.CardGroupList;
			if (!flag)
			{
				this.doc.RefreshCardGroupListShow();
				base.uiBehaviour.m_OldDeckPool.FakeReturnAll();
				for (int i = 1; i <= XCardCollectDocument.GroupMax; i++)
				{
					GameObject gameObject = base.uiBehaviour.m_OldDeckPool.FetchGameObject(false);
					gameObject.SetActive((long)i <= (long)((ulong)this.doc.CurShowGroup));
					IXUISprite ixuisprite = gameObject.GetComponent("XUISprite") as IXUISprite;
					float num = (float)ixuisprite.spriteWidth;
					gameObject.transform.localPosition = new Vector3(num * (float)(i - 1), 0f, 0f);
					IXUILabel ixuilabel = gameObject.transform.Find("Lock").GetComponent("XUILabel") as IXUILabel;
					CardsGroupList.RowData cardGroup = XCardCollectDocument.GetCardGroup((uint)i);
					bool flag2 = (long)i <= (long)((ulong)this.doc.CurOpenGroup);
					if (flag2)
					{
						ixuilabel.gameObject.SetActive(false);
					}
					else
					{
						ixuilabel.gameObject.SetActive(true);
						ixuilabel.SetText(string.Format(XSingleton<XStringTable>.singleton.GetString("DECK_UNLOCK"), cardGroup.OpenLevel));
					}
					IXUILabel ixuilabel2 = gameObject.transform.Find("Introduction").GetComponent("XUILabel") as IXUILabel;
					ixuilabel2.SetText(cardGroup.Detail);
					IXUILabel ixuilabel3 = gameObject.transform.Find("Num").GetComponent("XUILabel") as IXUILabel;
					XDeck xdeck = this.doc.CardsGroupInfo[i];
					ixuilabel3.SetText(string.Format("{0}/{1}", xdeck.ActionNum, xdeck.combDic.size));
					ixuisprite.ID = (ulong)((long)i);
					ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this._OnOpenDeckClicked));
				}
				base.uiBehaviour.m_OldDeckPool.ActualReturnAll(false);
				StringBuilder stringBuilder = new StringBuilder();
				int num2 = 0;
				for (int j = 0; j < this.AttrSort.Length; j++)
				{
					uint num3 = this.AttrSort[j];
					uint attrValue;
					bool flag3 = this.doc.AttrSum.TryGetValue(num3, out attrValue);
					if (flag3)
					{
						bool flag4 = num2 != 0;
						if (flag4)
						{
							stringBuilder.Append("  ");
						}
						stringBuilder.Append(string.Format("{0}{1}", XAttributeCommon.GetAttrStr((int)num3), XAttributeCommon.GetAttrValueStr(num3, attrValue, true)));
						this.doc.AttrSum.RemoveKey(num3);
						num2++;
					}
				}
				for (int k = 0; k < this.doc.AttrSum.size; k++)
				{
					uint attrid = this.doc.AttrSum.BufferKeys[k];
					uint attrValue2 = this.doc.AttrSum.BufferValues[k];
					bool flag5 = num2 != 0;
					if (flag5)
					{
						stringBuilder.Append("  ");
					}
					stringBuilder.Append(string.Format("{0}{1}", XAttributeCommon.GetAttrStr((int)attrid), XAttributeCommon.GetAttrValueStr(attrid, attrValue2, true)));
					num2++;
				}
				for (int l = 0; l < this.doc.AttrSum.size; l++)
				{
					uint attrid2 = this.doc.AttrSum.BufferKeys[l];
					uint attrValue3 = this.doc.AttrSum.BufferValues[l];
					bool flag6 = l != 0;
					if (flag6)
					{
						stringBuilder.Append("  ");
					}
					stringBuilder.Append(string.Format("{0}{1}", XAttributeCommon.GetAttrStr((int)attrid2), XAttributeCommon.GetAttrValueStr(attrid2, attrValue3, true)));
				}
				string value = stringBuilder.ToString();
				bool flag7 = string.IsNullOrEmpty(value);
				if (flag7)
				{
					base.uiBehaviour.m_OldSumAttribute.SetText(XSingleton<XStringTable>.singleton.GetString("NONE"));
				}
				else
				{
					base.uiBehaviour.m_OldSumAttribute.SetText(stringBuilder.ToString());
				}
			}
		}

		public void RefreshShowCardGroupList(bool bResetPosition = false)
		{
			this.doc.RefreshCardGroupListShow();
			base.uiBehaviour.m_DeckPool.FakeReturnAll();
			for (int i = 1; i <= XCardCollectDocument.GroupMax; i++)
			{
				this.doc.CardsGroupInfo[i].RefreshRedPoint();
				GameObject gameObject = base.uiBehaviour.m_DeckPool.FetchGameObject(false);
				gameObject.SetActive((long)i <= (long)((ulong)this.doc.CurShowGroup));
				gameObject.transform.localPosition = new Vector3(0f, (float)(-(float)base.uiBehaviour.m_DeckPool.TplHeight * (i - 1)), 0f) + base.uiBehaviour.m_DeckPool.TplPos;
				CardsGroupList.RowData cardGroup = XCardCollectDocument.GetCardGroup((uint)i);
				XDeck xdeck = this.doc.CardsGroupInfo[i];
				Transform transform = gameObject.transform.Find("Normal");
				Transform transform2 = gameObject.transform.Find("Selected");
				Transform transform3 = gameObject.transform.Find("Lock");
				IXUISprite ixuisprite = gameObject.transform.Find("Pic").GetComponent("XUISprite") as IXUISprite;
				ixuisprite.SetSprite(cardGroup.ShowUp);
				transform2.gameObject.SetActive(this.doc.CurSelectGroup == i);
				Transform transform4 = gameObject.transform.Find("RedPoint");
				transform4.gameObject.SetActive(false);
				bool flag = (long)i <= (long)((ulong)this.doc.CurOpenGroup);
				if (flag)
				{
					transform.gameObject.SetActive(true);
					IXUILabel ixuilabel = transform.Find("Name").GetComponent("XUILabel") as IXUILabel;
					ixuilabel.SetText(cardGroup.GroupName);
					IXUILabel ixuilabel2 = transform.Find("Describe").GetComponent("XUILabel") as IXUILabel;
					ixuilabel2.SetText(cardGroup.Detail);
					IXUILabel ixuilabel3 = transform.Find("Num").GetComponent("XUILabel") as IXUILabel;
					ixuilabel3.SetText(string.Format("{0}/{1}", xdeck.ActionNum, xdeck.combDic.size));
					IXUISprite ixuisprite2 = gameObject.GetComponent("XUISprite") as IXUISprite;
					ixuisprite2.ID = (ulong)((long)i);
					ixuisprite2.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this._OnOpenDeckClicked));
					transform3.gameObject.SetActive(false);
					transform4.gameObject.SetActive(this.doc.CardsGroupInfo[i].redPoint);
				}
				else
				{
					transform.gameObject.SetActive(false);
					transform3.gameObject.SetActive(true);
					IXUILabel ixuilabel4 = gameObject.transform.Find("Lock/OpenLevel").GetComponent("XUILabel") as IXUILabel;
					ixuilabel4.SetText(string.Format(XSingleton<XStringTable>.singleton.GetString("DECK_UNLOCK"), cardGroup.OpenLevel));
					IXUISprite ixuisprite3 = gameObject.transform.Find("Lock/Block").GetComponent("XUISprite") as IXUISprite;
					ixuisprite3.ID = (ulong)cardGroup.OpenLevel;
					ixuisprite3.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this._OnDeckBlockClick));
				}
				int num = 0;
				while ((long)num < (long)((ulong)CardCollectView.STAR_MAX))
				{
					Transform transform5 = gameObject.transform.Find(string.Format("star{0}", num));
					transform5.gameObject.SetActive(num < xdeck.StarLevelMAX);
					transform5.Find("On").gameObject.SetActive(num < xdeck.CurStarLevel);
					num++;
				}
			}
			base.uiBehaviour.m_DeckPool.ActualReturnAll(false);
			StringBuilder stringBuilder = new StringBuilder();
			int num2 = 0;
			for (int j = 0; j < this.AttrSort.Length; j++)
			{
				uint num3 = this.AttrSort[j];
				uint attrValue;
				bool flag2 = this.doc.AttrSum.TryGetValue(num3, out attrValue);
				if (flag2)
				{
					bool flag3 = num2 != 0;
					if (flag3)
					{
						stringBuilder.Append("\n");
					}
					stringBuilder.Append(string.Format("{0}{1}", XAttributeCommon.GetAttrStr((int)num3), XAttributeCommon.GetAttrValueStr(num3, attrValue, true)));
					num2++;
				}
			}
			string value = stringBuilder.ToString();
			bool flag4 = string.IsNullOrEmpty(value);
			if (flag4)
			{
				base.uiBehaviour.m_SumAttribute.SetText(XSingleton<XStringTable>.singleton.GetString("NONE"));
			}
			else
			{
				base.uiBehaviour.m_SumAttribute.SetText(stringBuilder.ToString());
			}
			if (bResetPosition)
			{
				base.uiBehaviour.m_DeckScrollView.ResetPosition();
			}
		}

		public void RefreshShowDeck(bool bResetPosition = false)
		{
			bool flag = this.CurPage != CardPage.Deck;
			if (!flag)
			{
				this.RefreshShowCardGroupList(bResetPosition);
				XDeck curDeck = this.doc.CurDeck;
				XSingleton<XDebug>.singleton.AddGreenLog("star:" + curDeck.CurStarLevel, null, null, null, null, null);
				base.uiBehaviour.m_ActivatedNum.SetText(string.Format("{0}/{1}", curDeck.ActionNum, curDeck.combDic.size));
				base.uiBehaviour.m_Title.SetText(curDeck.Name);
				StringBuilder stringBuilder = new StringBuilder();
				for (int i = 0; i < curDeck.AttrBase.Count; i++)
				{
					uint id = curDeck.AttrBase[i].id;
					uint num = curDeck.AttrBase[i].num;
					bool flag2 = i != 0;
					if (flag2)
					{
						stringBuilder.Append("\n");
					}
					stringBuilder.Append(string.Format("{0}{1}", XAttributeCommon.GetAttrStr((int)id), XAttributeCommon.GetAttrValueStr(id, num, true)));
				}
				for (int j = 0; j < curDeck.AttrPer.Count; j++)
				{
					uint id2 = curDeck.AttrPer[j].id;
					uint num2 = curDeck.AttrPer[j].num;
					stringBuilder.Append(string.Format("\n{0}{1}", XAttributeCommon.GetAttrStr((int)id2), XAttributeCommon.GetAttrValueStr(id2, num2, true)));
				}
				string value = stringBuilder.ToString();
				bool flag3 = string.IsNullOrEmpty(value);
				if (flag3)
				{
					base.uiBehaviour.m_DeckAttribute.SetText(XSingleton<XStringTable>.singleton.GetString("NONE"));
				}
				else
				{
					base.uiBehaviour.m_DeckAttribute.SetText(stringBuilder.ToString());
				}
				base.uiBehaviour.m_NumRewardPool.FakeReturnAll();
				int num3 = 0;
				while ((long)num3 < (long)((ulong)XDeck.DECK_PER_REWARD_COUNT_MAX))
				{
					GameObject gameObject = base.uiBehaviour.m_NumRewardPool.FetchGameObject(false);
					IXUISprite ixuisprite = gameObject.GetComponent("XUISprite") as IXUISprite;
					float num4 = (float)ixuisprite.spriteWidth;
					gameObject.transform.localPosition = new Vector3(num4 * (float)num3, 0f, 0f);
					IXUILabel ixuilabel = gameObject.transform.Find("ActiveNum").GetComponent("XUILabel") as IXUILabel;
					Transform transform = gameObject.transform.Find("Active");
					bool flag4 = num3 < curDeck.ActionNumReward[curDeck.CurStarLevel].Count;
					if (flag4)
					{
						ixuilabel.SetText(string.Format(XSingleton<XStringTable>.singleton.GetString("CATD_ATTRIBUTE_REWARD"), curDeck.ActionNumReward[curDeck.CurStarLevel][num3].FireCounts));
						transform.gameObject.SetActive((long)curDeck.ActionNum >= (long)((ulong)curDeck.ActionNumReward[curDeck.CurStarLevel][num3].FireCounts));
					}
					else
					{
						ixuilabel.SetText("");
					}
					IXUISprite ixuisprite2 = gameObject.transform.Find("NoActive").GetComponent("XUISprite") as IXUISprite;
					ixuisprite2.ID = (ulong)((long)num3);
					ixuisprite2.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this._OnOpenRewardTipsClick));
					num3++;
				}
				base.uiBehaviour.m_NumRewardPool.ActualReturnAll(false);
				this.CurShopID = this.doc.CurSelectGroup;
				base.uiBehaviour.m_OpenCardShop.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this._OnOpenCardShopClick));
				base.uiBehaviour.m_ActionNumRewardTips.gameObject.SetActive(false);
				base.uiBehaviour.m_GetActionNumReward.gameObject.SetActive(false);
				CardsGroupList.RowData cardGroup = XCardCollectDocument.GetCardGroup((uint)this.doc.CurSelectGroup);
				base.uiBehaviour.m_GoRisk.ID = (ulong)cardGroup.MapID;
				base.uiBehaviour.m_GoRisk.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this._OnGoRiskClick));
				base.uiBehaviour.m_DeckLock.gameObject.SetActive(curDeck.ActionNum == curDeck.combDic.size);
				bool flag5 = curDeck.CurStarLevel < curDeck.StarLevelMAX;
				if (flag5)
				{
					bool flag6 = XSingleton<XAttributeMgr>.singleton.XPlayerData.Level < cardGroup.BreakLevel[curDeck.CurStarLevel];
					if (flag6)
					{
						base.uiBehaviour.m_DeckUnlock.gameObject.SetActive(false);
						base.uiBehaviour.m_DeckLabel.gameObject.SetActive(true);
						base.uiBehaviour.m_DeckLabel.SetText(string.Format(XSingleton<XStringTable>.singleton.GetString("CATD_UNLOCK_TIPS"), cardGroup.BreakLevel[curDeck.CurStarLevel]));
					}
					else
					{
						base.uiBehaviour.m_DeckUnlock.gameObject.SetActive(true);
						base.uiBehaviour.m_DeckLabel.gameObject.SetActive(false);
					}
				}
				else
				{
					base.uiBehaviour.m_DeckLock.gameObject.SetActive(false);
				}
				this.RefreshList(bResetPosition);
			}
		}

		private void _OnOpenRewardTipsClick(IXUISprite iSp)
		{
			base.uiBehaviour.m_ActionNumRewardTips.gameObject.SetActive(true);
			int index = (int)iSp.ID;
			bool flag = (long)this.doc.CurDeck.ActionNum < (long)((ulong)this.doc.CurDeck.ActionNumReward[this.doc.CurDeck.CurStarLevel][index].FireCounts);
			if (flag)
			{
				base.uiBehaviour.m_RewardActive.gameObject.SetActive(false);
				base.uiBehaviour.m_RewardNoActive.gameObject.SetActive(true);
				base.uiBehaviour.m_RewardNeedNum.SetText(this.doc.CurDeck.ActionNumReward[this.doc.CurDeck.CurStarLevel][index].FireCounts.ToString());
			}
			else
			{
				base.uiBehaviour.m_RewardActive.gameObject.SetActive(true);
				base.uiBehaviour.m_RewardNoActive.gameObject.SetActive(false);
			}
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < this.doc.CurDeck.ActionNumReward[this.doc.CurDeck.CurStarLevel][index].Promote.Count; i++)
			{
				uint attrid = this.doc.CurDeck.ActionNumReward[this.doc.CurDeck.CurStarLevel][index].Promote[i, 0];
				uint attrValue = this.doc.CurDeck.ActionNumReward[this.doc.CurDeck.CurStarLevel][index].Promote[i, 1];
				bool flag2 = i != 0;
				if (flag2)
				{
					stringBuilder.Append("\n");
				}
				stringBuilder.Append(string.Format("{0}{1}", XAttributeCommon.GetAttrStr((int)attrid), XAttributeCommon.GetAttrValueStr(attrid, attrValue, true)));
			}
			base.uiBehaviour.m_RewardAttribute.SetText(stringBuilder.ToString());
		}

		public void ShowGetReward(int index)
		{
			XSingleton<XFxMgr>.singleton.CreateAndPlay("Effects/FX_Particle/UIfx/UI_yh", DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.uiBehaviour.m_FxFirework.transform, Vector3.zero, Vector3.one, 1f, true, 5f, true);
			XSingleton<XAudioMgr>.singleton.PlayUISound("Audio/UI/UI_Gethorse", true, AudioChannel.Action);
			base.uiBehaviour.m_GetActionNumReward.gameObject.SetActive(true);
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < this.doc.CurDeck.ActionNumReward[this.doc.CurDeck.CurStarLevel][index].Promote.Count; i++)
			{
				uint attrid = this.doc.CurDeck.ActionNumReward[this.doc.CurDeck.CurStarLevel][index].Promote[i, 0];
				uint attrValue = this.doc.CurDeck.ActionNumReward[this.doc.CurDeck.CurStarLevel][index].Promote[i, 1];
				bool flag = i != 0;
				if (flag)
				{
					stringBuilder.Append("\n");
				}
				stringBuilder.Append(string.Format("{0}{1}", XAttributeCommon.GetAttrStr((int)attrid), XAttributeCommon.GetAttrValueStr(attrid, attrValue, true)));
			}
			base.uiBehaviour.m_GetRewardAttribute.SetText(stringBuilder.ToString());
		}

		public void RefreshList(bool bResetPosition = true)
		{
			int size = this.doc.CardsGroupInfo[this.doc.CurSelectGroup].combDic.size;
			base.uiBehaviour.m_WrapContent.SetContentCount(size, false);
			if (bResetPosition)
			{
				base.uiBehaviour.m_GroupScrollView.ResetPosition();
			}
			else
			{
				base.uiBehaviour.m_WrapContent.RefreshAllVisibleContents();
			}
		}

		private void _OnGroupListItemUpdated(Transform t, int index)
		{
			bool flag = index < 0;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddErrorLog("index:" + index, null, null, null, null, null);
			}
			else
			{
				XDeck xdeck = this.doc.CardsGroupInfo[this.doc.CurSelectGroup];
				XCardCombination showCardsGroupInfo = xdeck.GetShowCardsGroupInfo(index);
				CardsGroup.RowData data = showCardsGroupInfo.data;
				IXUILabel ixuilabel = t.Find("Name").GetComponent("XUILabel") as IXUILabel;
				ixuilabel.SetText(data.TeamName);
				IXUILabel ixuilabel2 = t.Find("MemberName").GetComponent("XUILabel") as IXUILabel;
				int curStarLevel = this.doc.CurDeck.CurStarLevel;
				int num = -1;
				bool flag2 = false;
				bool flag3 = curStarLevel < showCardsGroupInfo.starPostion.Count;
				if (flag3)
				{
					num = showCardsGroupInfo.starPostion[curStarLevel];
				}
				else
				{
					flag2 = true;
					XSingleton<XDebug>.singleton.AddErrorLog(string.Concat(new object[]
					{
						"TeamId:",
						data.TeamId,
						" StarFireCondition Error\nstar:",
						curStarLevel
					}), null, null, null, null, null);
				}
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.Append("(");
				int num2 = 0;
				while ((long)num2 < (long)((ulong)XDeck.GROUP_NEED_CARD_MAX))
				{
					Transform transform = t.Find(string.Format("Item/item{0}", num2));
					bool flag4 = !flag2 && (long)num2 < (long)((ulong)data.StarFireCondition[num, 0]);
					if (flag4)
					{
						transform.gameObject.SetActive(true);
						int num3 = (int)data.StarFireCondition[num + num2 + 1, 0];
						int num4 = (int)data.StarFireCondition[num + num2 + 1, 1];
						ulong itemCount = XBagDocument.BagDoc.GetItemCount(num3);
						ItemList.RowData itemConf = XBagDocument.GetItemConf(num3);
						XItemDrawerMgr.Param.MaxItemCount = num4;
						XItemDrawerMgr.Param.NumColor = new Color?((itemCount >= (ulong)((long)num4)) ? Color.white : Color.red);
						XItemDrawerMgr.Param.MaxShowNum = 99;
						XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(transform.gameObject, num3, (int)itemCount, true);
						IXUISprite ixuisprite = transform.Find("Icon").GetComponent("XUISprite") as IXUISprite;
						ixuisprite.ID = (ulong)((long)num3);
						ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnOpenDetailClick));
						IXUISprite ixuisprite2 = transform.Find("Icon/Icon").GetComponent("XUISprite") as IXUISprite;
						ixuisprite2.SetColor(((long)this.doc.GetCardCount(num3) < (long)((ulong)data.StarFireCondition[num + num2 + 1, 1])) ? Color.black : Color.white);
						bool flag5 = itemConf != null;
						if (flag5)
						{
							bool flag6 = num2 != 0;
							if (flag6)
							{
								stringBuilder.Append("、");
							}
							stringBuilder.Append(itemConf.ItemName[0]);
						}
					}
					else
					{
						transform.gameObject.SetActive(false);
					}
					num2++;
				}
				stringBuilder.Append(")");
				ixuilabel2.SetText(stringBuilder.ToString());
				IXUISprite ixuisprite3 = t.Find("Activate").GetComponent("XUISprite") as IXUISprite;
				IXUISprite ixuisprite4 = t.Find("InActivate").GetComponent("XUISprite") as IXUISprite;
				IXUISprite ixuisprite5 = t.Find("Activated").GetComponent("XUISprite") as IXUISprite;
				ixuisprite3.gameObject.SetActive(xdeck.GetShowCardsGroupInfo(index).status == CardCombinationStatus.CanActive);
				ixuisprite4.gameObject.SetActive(xdeck.GetShowCardsGroupInfo(index).status == CardCombinationStatus.NoCanActive);
				ixuisprite5.gameObject.SetActive(xdeck.GetShowCardsGroupInfo(index).status == CardCombinationStatus.Activated);
				ixuisprite3.ID = (ulong)xdeck.GetShowCardsGroupInfo(index).data.TeamId;
				ixuisprite3.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this._OnActiveClick));
				ixuisprite4.ID = (ulong)xdeck.GetShowCardsGroupInfo(index).data.TeamId;
				ixuisprite4.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this._OnNoActiveClick));
				uint teamId = xdeck.GetShowCardsGroupInfo(index).data.TeamId;
				IXUILabel ixuilabel3 = t.Find("Attribute").GetComponent("XUILabel") as IXUILabel;
				SeqListRef<uint> cardGroupAttribute = XCardCollectDocument.GetCardGroupAttribute(teamId);
				StringBuilder stringBuilder2 = new StringBuilder();
				uint attrid = cardGroupAttribute[xdeck.CurStarLevel, 0];
				uint attrValue = cardGroupAttribute[xdeck.CurStarLevel, 1];
				stringBuilder2.Append(string.Format("{0}{1}", XAttributeCommon.GetAttrStr((int)attrid), XAttributeCommon.GetAttrValueStr(attrid, attrValue, true)));
				ixuilabel3.SetText(stringBuilder2.ToString());
			}
		}

		public void RefreshDetail()
		{
			bool flag = this.CurPage != CardPage.CardDetail;
			if (!flag)
			{
				bool flag2 = base.uiBehaviour == null;
				if (!flag2)
				{
					CardsList.RowData cards = XCardCollectDocument.GetCards((uint)this.CurCardID);
					bool flag3 = cards == null;
					if (!flag3)
					{
						base.uiBehaviour.m_DetailName.SetText(cards.CardName);
						base.uiBehaviour.m_DetailStory.SetText(cards.Description);
						ItemList.RowData itemConf = XBagDocument.GetItemConf((int)cards.CardId);
						bool flag4 = itemConf != null;
						if (flag4)
						{
							string texPath = this.GetTexPath((int)itemConf.ItemQuality);
							base.uiBehaviour.m_DetailPic.SetTexturePath(texPath);
						}
						uint avatar = cards.Avatar;
						this._CardDummy = XSingleton<X3DAvatarMgr>.singleton.CreateCommonEntityDummy(this.m_dummPool, avatar, this.m_uiBehaviour.m_Snapshot, this._CardDummy, 1f);
						this.RefreshCardNum();
						int num = 0;
						int num2 = 0;
						base.uiBehaviour.m_DetailGroupPool.FakeReturnAll();
						for (int i = 1; i < this.doc.CardsGroupInfo.Count; i++)
						{
							XDeck xdeck = this.doc.CardsGroupInfo[i];
							int curStarLevel = xdeck.CurStarLevel;
							for (int j = 0; j < xdeck.combDic.BufferValues.Count; j++)
							{
								XCardCombination xcardCombination = xdeck.combDic.BufferValues[j];
								bool flag5 = curStarLevel >= xcardCombination.starPostion.Count;
								if (flag5)
								{
									XSingleton<XDebug>.singleton.AddErrorLog(string.Concat(new object[]
									{
										"TeamId:",
										xcardCombination.data.TeamId,
										" StarFireCondition Error\nstar:",
										curStarLevel
									}), null, null, null, null, null);
								}
								else
								{
									int num3 = xcardCombination.starPostion[curStarLevel];
									int num4 = 0;
									while ((long)num4 < (long)((ulong)xcardCombination.data.StarFireCondition[num3, 0]))
									{
										bool flag6 = this.CurCardID == (int)xcardCombination.data.StarFireCondition[num3 + num4 + 1, 0];
										if (flag6)
										{
											GameObject gameObject = base.uiBehaviour.m_DetailGroupPool.FetchGameObject(false);
											IXUISprite ixuisprite = gameObject.transform.GetComponent("XUISprite") as IXUISprite;
											int spriteHeight = ixuisprite.spriteHeight;
											gameObject.transform.localPosition = new Vector3(0f, (float)(-(float)spriteHeight * num2), 0f);
											num2++;
											bool flag7 = xcardCombination.status == CardCombinationStatus.Activated;
											IXUILabel ixuilabel;
											if (flag7)
											{
												num++;
												ixuilabel = (gameObject.transform.Find("on").GetComponent("XUILabel") as IXUILabel);
												ixuilabel.gameObject.SetActive(true);
												gameObject.transform.Find("off").gameObject.SetActive(false);
											}
											else
											{
												ixuilabel = (gameObject.transform.Find("off").GetComponent("XUILabel") as IXUILabel);
												ixuilabel.gameObject.SetActive(true);
												gameObject.transform.Find("on").gameObject.SetActive(false);
											}
											ixuilabel.SetText(xcardCombination.data.TeamName);
											break;
										}
										num4++;
									}
								}
							}
						}
						base.uiBehaviour.m_DetailGroupPool.ActualReturnAll(false);
						base.uiBehaviour.m_DetailActiveNum.SetText(string.Format("{0}/{1}", num, num2));
						base.uiBehaviour.m_DetailGroupScrollView.ResetPosition();
						base.uiBehaviour.m_OldGoRisk.ID = (ulong)cards.MapID;
						base.uiBehaviour.m_OldGoRisk.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this._OnGoRiskClick));
						ShopTable.RowData dataByShopId = XNormalShopDocument.GetDataByShopId((uint)this.CurCardID);
						bool flag8 = dataByShopId == null;
						if (flag8)
						{
							base.uiBehaviour.m_GoShop.gameObject.SetActive(false);
						}
						else
						{
							base.uiBehaviour.m_GoShop.gameObject.SetActive(true);
							this.CurShopID = (int)(dataByShopId.Type - this.shopdoc.GetShopId(XSysDefine.XSys_Mall_Card1) + 1U);
							base.uiBehaviour.m_GoShop.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this._OnOpenCardShopClick));
						}
					}
				}
			}
		}

		private void _OnActiveClick(IXUISprite iSp)
		{
			this.doc.ReqActive((uint)iSp.ID);
		}

		private void _OnNoActiveClick(IXUISprite iSp)
		{
			XSingleton<UiUtility>.singleton.ShowSystemTip(XSingleton<XStringTable>.singleton.GetString("ATLAS_CARD_NOT_ENOUGH"), "fece00");
		}

		public void RefreshCardNum()
		{
			bool flag = this.CurPage != CardPage.CardDetail;
			if (!flag)
			{
				int cardCount = this.doc.GetCardCount(this.CurCardID);
				base.uiBehaviour.m_DetailNum.SetText(cardCount.ToString());
				base.uiBehaviour.m_DetailBuy.ID = (ulong)((long)this.CurCardID);
				base.uiBehaviour.m_DetailBuy.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this._OnBuyClick));
				base.uiBehaviour.m_DetailResolve.ID = (ulong)((long)this.CurCardID);
				base.uiBehaviour.m_DetailResolve.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this._OnResolveClick));
			}
		}

		private void _OnRewardCloseClick(IXUISprite go)
		{
			base.uiBehaviour.m_ActionNumRewardTips.gameObject.SetActive(false);
		}

		private void _OnGetRewardCloseClick(IXUISprite go)
		{
			base.uiBehaviour.m_GetActionNumReward.gameObject.SetActive(false);
		}

		private void _OnResolveCloseClick(IXUISprite go)
		{
			base.uiBehaviour.m_ResolvePanel.gameObject.SetActive(false);
		}

		private void _OnResolveClick(IXUISprite iSp)
		{
			int cardCount = this.doc.GetCardCount(this.CurCardID);
			bool flag = cardCount == 0;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(XSingleton<XStringTable>.singleton.GetString("CARD_NOT_ENOUGH"), "fece00");
			}
			else
			{
				bool flag2 = !DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.GetTempTip(XTempTipDefine.OD_CARD_RESOLVE_TIP);
				if (flag2)
				{
					XSingleton<UiUtility>.singleton.ShowModalDialog(XSingleton<UiUtility>.singleton.ReplaceReturn(XSingleton<XStringTable>.singleton.GetString("CARD_RESOLVE_TIP")), XStringDefineProxy.GetString("CARD_COMMON_OK"), XStringDefineProxy.GetString("CARD_COMMON_CANCEL"), new ButtonClickEventHandler(this._OpenResolve), null, false, XTempTipDefine.OD_CARD_RESOLVE_TIP, 50);
				}
				else
				{
					this._OpenResolve(null);
				}
			}
		}

		private bool _OpenResolve(IXUIButton btn)
		{
			base.uiBehaviour.m_ResolvePanel.gameObject.SetActive(true);
			base.uiBehaviour.m_ResolveNum.SetText("1");
			this.RefreshResolveGetItem();
			XSingleton<UiUtility>.singleton.CloseModalDlg();
			return true;
		}

		private void _OnBuyClick(IXUISprite iSp)
		{
			XNormalShopDocument specificDocument = XDocuments.GetSpecificDocument<XNormalShopDocument>(XNormalShopDocument.uuID);
			XSysDefine sys = XSysDefine.XSys_Mall_Card1 + this.CurShopID - 1;
			specificDocument.ReqGoodsList(sys);
		}

		public void SingleShop(XNormalShopGoods goods)
		{
			this.CurGoods = goods;
			this.ShopHandler.RefreshChipNum();
			ItemList.RowData itemConf = XBagDocument.GetItemConf(this.CurCardID);
			XSingleton<UiUtility>.singleton.ShowModalDialog(string.Format(XSingleton<UiUtility>.singleton.ReplaceReturn(XSingleton<XStringTable>.singleton.GetString("CATD_BUY")), this.CurGoods.priceValue, itemConf.ItemName[0], this.ShopHandler.money), XStringDefineProxy.GetString("COMMON_OK"), XStringDefineProxy.GetString("COMMON_CANCEL"), new ButtonClickEventHandler(this._OnBuyOK));
		}

		private bool _OnBuyOK(IXUIButton iSp)
		{
			ItemList.RowData itemConf = XBagDocument.GetItemConf(this.CurCardID);
			bool flag = this.ShopHandler.money >= this.CurGoods.priceValue;
			if (flag)
			{
				XNormalShopDocument specificDocument = XDocuments.GetSpecificDocument<XNormalShopDocument>(XNormalShopDocument.uuID);
				specificDocument.DoBuyItem(this.CurGoods, 1U);
			}
			else
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(XSingleton<XStringTable>.singleton.GetString("CARD_BUY_INSUFFICIENT"), "fece00");
			}
			XSingleton<UiUtility>.singleton.CloseModalDlg();
			return true;
		}

		private void _OnResolveNumAddClick(IXUISprite iSp)
		{
			int num = int.Parse(base.uiBehaviour.m_ResolveNum.GetText());
			int num2 = int.Parse(base.uiBehaviour.m_DetailNum.GetText());
			bool flag = num < num2;
			if (flag)
			{
				num++;
			}
			else
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(string.Format(XSingleton<XStringTable>.singleton.GetString("CARD_COUNT_MAX"), new object[0]), "fece00");
			}
			base.uiBehaviour.m_ResolveNum.SetText(num.ToString());
			this.RefreshResolveGetItem();
		}

		private void _OnResolveNumSubClick(IXUISprite iSp)
		{
			int num = int.Parse(base.uiBehaviour.m_ResolveNum.GetText());
			bool flag = num > 1;
			if (flag)
			{
				num--;
			}
			else
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(string.Format(XSingleton<XStringTable>.singleton.GetString("CARD_COUNT_MIN"), new object[0]), "fece00");
			}
			base.uiBehaviour.m_ResolveNum.SetText(num.ToString());
			this.RefreshResolveGetItem();
		}

		private void _OnResolveOKClick(IXUISprite iSp)
		{
			int num = int.Parse(base.uiBehaviour.m_ResolveNum.GetText());
			this.doc.ReqBreak(this.CurCardID, num);
			base.uiBehaviour.m_ResolvePanel.gameObject.SetActive(false);
		}

		private void RefreshResolveGetItem()
		{
			int num = int.Parse(base.uiBehaviour.m_ResolveNum.GetText());
			ItemList.RowData itemConf = XBagDocument.GetItemConf(this.CurCardID);
			IXUISprite ixuisprite = base.uiBehaviour.m_ResolveGetItem.Find("Icon").GetComponent("XUISprite") as IXUISprite;
			ixuisprite.SetSprite(XBagDocument.GetItemSmallIcon(int.Parse(XSingleton<XGlobalConfig>.singleton.GetValue("CardChip")), 0U));
			IXUILabel ixuilabel = base.uiBehaviour.m_ResolveGetItem.Find("Num").GetComponent("XUILabel") as IXUILabel;
			ixuilabel.SetText(((long)((ulong)itemConf.Decompose[0, 1] * (ulong)((long)num))).ToString());
		}

		private void _OnGoRiskClick(IXUISprite iSp)
		{
			DlgBase<CardCollectView, CardCollectBehaviour>.singleton.SetVisible(false, true);
			DlgBase<SuperRiskDlg, SuperRiskDlgBehaviour>.singleton.Show(true, (int)iSp.ID);
		}

		private void _OnDeckBlockClick(IXUISprite iSp)
		{
			XSingleton<UiUtility>.singleton.ShowSystemTip(string.Format(XSingleton<XStringTable>.singleton.GetString("DECK_UNLOCK"), iSp.ID), "fece00");
		}

		private string GetTexPath(int quality)
		{
			bool flag = quality == 1;
			string result;
			if (flag)
			{
				result = "atlas/UI/common/Pic/Tex_Card_Green";
			}
			else
			{
				bool flag2 = quality == 2;
				if (flag2)
				{
					result = "atlas/UI/common/Pic/Tex_Card_Blue";
				}
				else
				{
					bool flag3 = quality == 3;
					if (flag3)
					{
						result = "atlas/UI/common/Pic/Tex_Card_Orange";
					}
					else
					{
						bool flag4 = quality == 4;
						if (flag4)
						{
							result = "atlas/UI/common/Pic/Tex_Card_Purple";
						}
						else
						{
							bool flag5 = quality == 5;
							if (flag5)
							{
								result = "atlas/UI/common/Pic/Tex_Card_Red";
							}
							else
							{
								XSingleton<XDebug>.singleton.AddErrorLog("quality : " + quality + " No Find", null, null, null, null, null);
								result = null;
							}
						}
					}
				}
			}
			return result;
		}

		private bool OnHelpBtnClicked(IXUIButton btn)
		{
			DlgBase<XCommonHelpTipView, XCommonHelpTipBehaviour>.singleton.ShowHelp(XSysDefine.XSys_CardCollect);
			return true;
		}

		public void PlayLevelUpFx()
		{
			bool flag = !DlgBase<CardCollectView, CardCollectBehaviour>.singleton.IsVisible();
			if (!flag)
			{
				bool flag2 = this._StarUpFx != null;
				if (flag2)
				{
					XSingleton<XFxMgr>.singleton.DestroyFx(this._StarUpFx, true);
				}
				this._StarUpFx = XSingleton<XFxMgr>.singleton.CreateAndPlay("Effects/FX_Particle/UIfx/UI_tupochenggong", base.uiBehaviour.m_Fx, Vector3.zero, Vector3.one, 1f, true, 7f, true);
			}
		}

		private XCardCollectDocument doc = null;

		private XNormalShopDocument shopdoc = null;

		private CardTotalHandler m_CardTotalHandler;

		private XCardShopHandler m_CardShopHandler;

		public static readonly uint STAR_MAX = 5U;

		public QualityFilterHandler qualityFilter;

		private static int QualityMask = 63;

		private uint[] AttrSort = new uint[]
		{
			(uint)XFastEnumIntEqualityComparer<XAttributeDefine>.ToInt(XAttributeDefine.XAttr_PhysicalAtk_Basic),
			(uint)XFastEnumIntEqualityComparer<XAttributeDefine>.ToInt(XAttributeDefine.XAttr_MagicAtk_Basic),
			(uint)XFastEnumIntEqualityComparer<XAttributeDefine>.ToInt(XAttributeDefine.XAttr_PhysicalDef_Basic),
			(uint)XFastEnumIntEqualityComparer<XAttributeDefine>.ToInt(XAttributeDefine.XAttr_MagicDef_Basic),
			(uint)XFastEnumIntEqualityComparer<XAttributeDefine>.ToInt(XAttributeDefine.XAttr_MaxHP_Basic)
		};

		private XDummy _CardDummy = null;

		private Stack<CardPage> m_uiStack = new Stack<CardPage>();

		public int CurCardID = 0;

		public int CurShopID = 0;

		private XFx _StarUpFx;

		private XNormalShopGoods CurGoods;
	}
}
