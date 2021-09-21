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
	// Token: 0x02000BFD RID: 3069
	internal class CardCollectView : DlgBase<CardCollectView, CardCollectBehaviour>
	{
		// Token: 0x170030B9 RID: 12473
		// (get) Token: 0x0600AE5E RID: 44638 RVA: 0x0020B3F0 File Offset: 0x002095F0
		public CardTotalHandler TotalHandler
		{
			get
			{
				return this.m_CardTotalHandler;
			}
		}

		// Token: 0x170030BA RID: 12474
		// (get) Token: 0x0600AE5F RID: 44639 RVA: 0x0020B408 File Offset: 0x00209608
		public XCardShopHandler ShopHandler
		{
			get
			{
				return this.m_CardShopHandler;
			}
		}

		// Token: 0x170030BB RID: 12475
		// (get) Token: 0x0600AE60 RID: 44640 RVA: 0x0020B420 File Offset: 0x00209620
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

		// Token: 0x170030BC RID: 12476
		// (get) Token: 0x0600AE61 RID: 44641 RVA: 0x0020B454 File Offset: 0x00209654
		public override string fileName
		{
			get
			{
				return "GameSystem/CardCollectDlg";
			}
		}

		// Token: 0x170030BD RID: 12477
		// (get) Token: 0x0600AE62 RID: 44642 RVA: 0x0020B46C File Offset: 0x0020966C
		public override int layer
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x170030BE RID: 12478
		// (get) Token: 0x0600AE63 RID: 44643 RVA: 0x0020B480 File Offset: 0x00209680
		public override int group
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x170030BF RID: 12479
		// (get) Token: 0x0600AE64 RID: 44644 RVA: 0x0020B494 File Offset: 0x00209694
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x170030C0 RID: 12480
		// (get) Token: 0x0600AE65 RID: 44645 RVA: 0x0020B4A8 File Offset: 0x002096A8
		public override bool hideMainMenu
		{
			get
			{
				return true;
			}
		}

		// Token: 0x170030C1 RID: 12481
		// (get) Token: 0x0600AE66 RID: 44646 RVA: 0x0020B4BC File Offset: 0x002096BC
		public override bool fullscreenui
		{
			get
			{
				return true;
			}
		}

		// Token: 0x170030C2 RID: 12482
		// (get) Token: 0x0600AE67 RID: 44647 RVA: 0x0020B4D0 File Offset: 0x002096D0
		public override bool pushstack
		{
			get
			{
				return true;
			}
		}

		// Token: 0x170030C3 RID: 12483
		// (get) Token: 0x0600AE68 RID: 44648 RVA: 0x0020B4E4 File Offset: 0x002096E4
		public override int sysid
		{
			get
			{
				return XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_CardCollect);
			}
		}

		// Token: 0x0600AE69 RID: 44649 RVA: 0x0020B500 File Offset: 0x00209700
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

		// Token: 0x0600AE6A RID: 44650 RVA: 0x0020B5B4 File Offset: 0x002097B4
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

		// Token: 0x0600AE6B RID: 44651 RVA: 0x0020B60C File Offset: 0x0020980C
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

		// Token: 0x0600AE6C RID: 44652 RVA: 0x0020B793 File Offset: 0x00209993
		private void _OnCardGroupListCloseClick(IXUISprite iSp)
		{
			this.SetVisibleWithAnimation(false, null);
		}

		// Token: 0x0600AE6D RID: 44653 RVA: 0x0020B79F File Offset: 0x0020999F
		private void _OnOpenDeckClicked(IXUISprite iSp)
		{
			this.doc.Select((uint)iSp.ID);
		}

		// Token: 0x0600AE6E RID: 44654 RVA: 0x0020B7B8 File Offset: 0x002099B8
		private bool _OnDeckCloseClick(IXUIButton go)
		{
			this.CloseCurPage(CardPage.Deck);
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

		// Token: 0x0600AE6F RID: 44655 RVA: 0x0020B7DC File Offset: 0x002099DC
		private void _OnOpenCardListClick(IXUISprite iSp)
		{
			this.ShowPage(CardPage.CardAll, true);
		}

		// Token: 0x0600AE70 RID: 44656 RVA: 0x0020B7E8 File Offset: 0x002099E8
		public void OnOpenDetailClick(IXUISprite iSp)
		{
			this.CurCardID = (int)iSp.ID;
			this.ShowPage(CardPage.CardDetail, true);
		}

		// Token: 0x0600AE71 RID: 44657 RVA: 0x0020B804 File Offset: 0x00209A04
		private bool _OnDetailCloseClick(IXUIButton go)
		{
			this.CloseCurPage(CardPage.CardDetail);
			base.uiBehaviour.m_CardDetail.gameObject.SetActive(false);
			return true;
		}

		// Token: 0x0600AE72 RID: 44658 RVA: 0x0020B838 File Offset: 0x00209A38
		private bool _OnUpStarClick(IXUIButton go)
		{
			this.doc.ReqUpStar();
			return true;
		}

		// Token: 0x0600AE73 RID: 44659 RVA: 0x0020B857 File Offset: 0x00209A57
		private void _OnOpenCardShopClick(IXUISprite iSp)
		{
			this.ShowPage(CardPage.CardShop, true);
		}

		// Token: 0x0600AE74 RID: 44660 RVA: 0x0020B864 File Offset: 0x00209A64
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

		// Token: 0x0600AE75 RID: 44661 RVA: 0x0020B928 File Offset: 0x00209B28
		public void UnloadFx(XFx fx)
		{
			bool flag = fx != null;
			if (flag)
			{
				XSingleton<XFxMgr>.singleton.DestroyFx(fx, true);
				fx = null;
			}
		}

		// Token: 0x0600AE76 RID: 44662 RVA: 0x0020B950 File Offset: 0x00209B50
		protected override void OnHide()
		{
			this.UnloadFx(this._StarUpFx);
			base.Return3DAvatarPool();
			this.CloseCurPage(CardPage.ALL);
			base.OnHide();
		}

		// Token: 0x0600AE77 RID: 44663 RVA: 0x0020B976 File Offset: 0x00209B76
		public override void StackRefresh()
		{
			base.StackRefresh();
			base.Alloc3DAvatarPool("CardCollectView");
		}

		// Token: 0x0600AE78 RID: 44664 RVA: 0x0020B98C File Offset: 0x00209B8C
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

		// Token: 0x0600AE79 RID: 44665 RVA: 0x0020B9E4 File Offset: 0x00209BE4
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

		// Token: 0x0600AE7A RID: 44666 RVA: 0x0020BB5C File Offset: 0x00209D5C
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

		// Token: 0x0600AE7B RID: 44667 RVA: 0x0020BC74 File Offset: 0x00209E74
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

		// Token: 0x0600AE7C RID: 44668 RVA: 0x0020C0BC File Offset: 0x0020A2BC
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

		// Token: 0x0600AE7D RID: 44669 RVA: 0x0020C5B8 File Offset: 0x0020A7B8
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

		// Token: 0x0600AE7E RID: 44670 RVA: 0x0020CB24 File Offset: 0x0020AD24
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

		// Token: 0x0600AE7F RID: 44671 RVA: 0x0020CD58 File Offset: 0x0020AF58
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

		// Token: 0x0600AE80 RID: 44672 RVA: 0x0020CEDC File Offset: 0x0020B0DC
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

		// Token: 0x0600AE81 RID: 44673 RVA: 0x0020CF4C File Offset: 0x0020B14C
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

		// Token: 0x0600AE82 RID: 44674 RVA: 0x0020D428 File Offset: 0x0020B628
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

		// Token: 0x0600AE83 RID: 44675 RVA: 0x0020D8CA File Offset: 0x0020BACA
		private void _OnActiveClick(IXUISprite iSp)
		{
			this.doc.ReqActive((uint)iSp.ID);
		}

		// Token: 0x0600AE84 RID: 44676 RVA: 0x0020D8E0 File Offset: 0x0020BAE0
		private void _OnNoActiveClick(IXUISprite iSp)
		{
			XSingleton<UiUtility>.singleton.ShowSystemTip(XSingleton<XStringTable>.singleton.GetString("ATLAS_CARD_NOT_ENOUGH"), "fece00");
		}

		// Token: 0x0600AE85 RID: 44677 RVA: 0x0020D904 File Offset: 0x0020BB04
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

		// Token: 0x0600AE86 RID: 44678 RVA: 0x0020D9BB File Offset: 0x0020BBBB
		private void _OnRewardCloseClick(IXUISprite go)
		{
			base.uiBehaviour.m_ActionNumRewardTips.gameObject.SetActive(false);
		}

		// Token: 0x0600AE87 RID: 44679 RVA: 0x0020D9D5 File Offset: 0x0020BBD5
		private void _OnGetRewardCloseClick(IXUISprite go)
		{
			base.uiBehaviour.m_GetActionNumReward.gameObject.SetActive(false);
		}

		// Token: 0x0600AE88 RID: 44680 RVA: 0x0020D9EF File Offset: 0x0020BBEF
		private void _OnResolveCloseClick(IXUISprite go)
		{
			base.uiBehaviour.m_ResolvePanel.gameObject.SetActive(false);
		}

		// Token: 0x0600AE89 RID: 44681 RVA: 0x0020DA0C File Offset: 0x0020BC0C
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

		// Token: 0x0600AE8A RID: 44682 RVA: 0x0020DAC0 File Offset: 0x0020BCC0
		private bool _OpenResolve(IXUIButton btn)
		{
			base.uiBehaviour.m_ResolvePanel.gameObject.SetActive(true);
			base.uiBehaviour.m_ResolveNum.SetText("1");
			this.RefreshResolveGetItem();
			XSingleton<UiUtility>.singleton.CloseModalDlg();
			return true;
		}

		// Token: 0x0600AE8B RID: 44683 RVA: 0x0020DB14 File Offset: 0x0020BD14
		private void _OnBuyClick(IXUISprite iSp)
		{
			XNormalShopDocument specificDocument = XDocuments.GetSpecificDocument<XNormalShopDocument>(XNormalShopDocument.uuID);
			XSysDefine sys = XSysDefine.XSys_Mall_Card1 + this.CurShopID - 1;
			specificDocument.ReqGoodsList(sys);
		}

		// Token: 0x0600AE8C RID: 44684 RVA: 0x0020DB44 File Offset: 0x0020BD44
		public void SingleShop(XNormalShopGoods goods)
		{
			this.CurGoods = goods;
			this.ShopHandler.RefreshChipNum();
			ItemList.RowData itemConf = XBagDocument.GetItemConf(this.CurCardID);
			XSingleton<UiUtility>.singleton.ShowModalDialog(string.Format(XSingleton<UiUtility>.singleton.ReplaceReturn(XSingleton<XStringTable>.singleton.GetString("CATD_BUY")), this.CurGoods.priceValue, itemConf.ItemName[0], this.ShopHandler.money), XStringDefineProxy.GetString("COMMON_OK"), XStringDefineProxy.GetString("COMMON_CANCEL"), new ButtonClickEventHandler(this._OnBuyOK));
		}

		// Token: 0x0600AE8D RID: 44685 RVA: 0x0020DBE4 File Offset: 0x0020BDE4
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

		// Token: 0x0600AE8E RID: 44686 RVA: 0x0020DC6C File Offset: 0x0020BE6C
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

		// Token: 0x0600AE8F RID: 44687 RVA: 0x0020DD04 File Offset: 0x0020BF04
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

		// Token: 0x0600AE90 RID: 44688 RVA: 0x0020DD84 File Offset: 0x0020BF84
		private void _OnResolveOKClick(IXUISprite iSp)
		{
			int num = int.Parse(base.uiBehaviour.m_ResolveNum.GetText());
			this.doc.ReqBreak(this.CurCardID, num);
			base.uiBehaviour.m_ResolvePanel.gameObject.SetActive(false);
		}

		// Token: 0x0600AE91 RID: 44689 RVA: 0x0020DDD4 File Offset: 0x0020BFD4
		private void RefreshResolveGetItem()
		{
			int num = int.Parse(base.uiBehaviour.m_ResolveNum.GetText());
			ItemList.RowData itemConf = XBagDocument.GetItemConf(this.CurCardID);
			IXUISprite ixuisprite = base.uiBehaviour.m_ResolveGetItem.Find("Icon").GetComponent("XUISprite") as IXUISprite;
			ixuisprite.SetSprite(XBagDocument.GetItemSmallIcon(int.Parse(XSingleton<XGlobalConfig>.singleton.GetValue("CardChip")), 0U));
			IXUILabel ixuilabel = base.uiBehaviour.m_ResolveGetItem.Find("Num").GetComponent("XUILabel") as IXUILabel;
			ixuilabel.SetText(((long)((ulong)itemConf.Decompose[0, 1] * (ulong)((long)num))).ToString());
		}

		// Token: 0x0600AE92 RID: 44690 RVA: 0x0020DE90 File Offset: 0x0020C090
		private void _OnGoRiskClick(IXUISprite iSp)
		{
			DlgBase<CardCollectView, CardCollectBehaviour>.singleton.SetVisible(false, true);
			DlgBase<SuperRiskDlg, SuperRiskDlgBehaviour>.singleton.Show(true, (int)iSp.ID);
		}

		// Token: 0x0600AE93 RID: 44691 RVA: 0x0020DEB3 File Offset: 0x0020C0B3
		private void _OnDeckBlockClick(IXUISprite iSp)
		{
			XSingleton<UiUtility>.singleton.ShowSystemTip(string.Format(XSingleton<XStringTable>.singleton.GetString("DECK_UNLOCK"), iSp.ID), "fece00");
		}

		// Token: 0x0600AE94 RID: 44692 RVA: 0x0020DEE8 File Offset: 0x0020C0E8
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

		// Token: 0x0600AE95 RID: 44693 RVA: 0x0020DF7C File Offset: 0x0020C17C
		private bool OnHelpBtnClicked(IXUIButton btn)
		{
			DlgBase<XCommonHelpTipView, XCommonHelpTipBehaviour>.singleton.ShowHelp(XSysDefine.XSys_CardCollect);
			return true;
		}

		// Token: 0x0600AE96 RID: 44694 RVA: 0x0020DF9C File Offset: 0x0020C19C
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

		// Token: 0x0400424E RID: 16974
		private XCardCollectDocument doc = null;

		// Token: 0x0400424F RID: 16975
		private XNormalShopDocument shopdoc = null;

		// Token: 0x04004250 RID: 16976
		private CardTotalHandler m_CardTotalHandler;

		// Token: 0x04004251 RID: 16977
		private XCardShopHandler m_CardShopHandler;

		// Token: 0x04004252 RID: 16978
		public static readonly uint STAR_MAX = 5U;

		// Token: 0x04004253 RID: 16979
		public QualityFilterHandler qualityFilter;

		// Token: 0x04004254 RID: 16980
		private static int QualityMask = 63;

		// Token: 0x04004255 RID: 16981
		private uint[] AttrSort = new uint[]
		{
			(uint)XFastEnumIntEqualityComparer<XAttributeDefine>.ToInt(XAttributeDefine.XAttr_PhysicalAtk_Basic),
			(uint)XFastEnumIntEqualityComparer<XAttributeDefine>.ToInt(XAttributeDefine.XAttr_MagicAtk_Basic),
			(uint)XFastEnumIntEqualityComparer<XAttributeDefine>.ToInt(XAttributeDefine.XAttr_PhysicalDef_Basic),
			(uint)XFastEnumIntEqualityComparer<XAttributeDefine>.ToInt(XAttributeDefine.XAttr_MagicDef_Basic),
			(uint)XFastEnumIntEqualityComparer<XAttributeDefine>.ToInt(XAttributeDefine.XAttr_MaxHP_Basic)
		};

		// Token: 0x04004256 RID: 16982
		private XDummy _CardDummy = null;

		// Token: 0x04004257 RID: 16983
		private Stack<CardPage> m_uiStack = new Stack<CardPage>();

		// Token: 0x04004258 RID: 16984
		public int CurCardID = 0;

		// Token: 0x04004259 RID: 16985
		public int CurShopID = 0;

		// Token: 0x0400425A RID: 16986
		private XFx _StarUpFx;

		// Token: 0x0400425B RID: 16987
		private XNormalShopGoods CurGoods;
	}
}
