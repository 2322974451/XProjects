using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000BB1 RID: 2993
	internal class CardTotalHandler : DlgHandlerBase
	{
		// Token: 0x0600AB7F RID: 43903 RVA: 0x001F4DFC File Offset: 0x001F2FFC
		protected override void Init()
		{
			base.Init();
			this.doc = XDocuments.GetSpecificDocument<XCardCollectDocument>(XCardCollectDocument.uuID);
			this.m_Close = (base.PanelObject.transform.Find("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_AutoResolve = (base.PanelObject.transform.Find("Bg/AutoResolve").GetComponent("XUISprite") as IXUISprite);
			this.CardPanel = base.PanelObject.transform.Find("Bg/Panel");
			this.m_CardPanelScrollView = (base.PanelObject.transform.Find("Bg/Panel").GetComponent("XUIScrollView") as IXUIScrollView);
			this.doc.IsCardDirty = true;
			this.item = this.CardPanel.transform.Find("Item");
			this.m_qualityItemPool.SetupPool(null, this.item.gameObject, 5U, false);
			this.m_qualityItemPool.FakeReturnAll();
			for (int i = 1; i <= 5; i++)
			{
				GameObject gameObject = this.m_qualityItemPool.FetchGameObject(false);
				gameObject.name = "item";
				Transform transform = gameObject.transform.Find("ItemTpl");
				this.quality[i] = this.CardPanel.transform.Find(string.Format("Quality{0}", i));
				XSingleton<UiUtility>.singleton.AddChild(this.quality[i], gameObject.transform);
				IXUISprite ixuisprite = this.quality[i].GetComponent("XUISprite") as IXUISprite;
				gameObject.transform.localPosition = new Vector3(0f, (float)(-(float)ixuisprite.spriteHeight), 0f);
				this.m_ItemPool[i] = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);
				this.m_ItemPool[i].SetupPool(null, transform.gameObject, 5U, false);
			}
			this.m_qualityItemPool.ActualReturnAll(true);
		}

		// Token: 0x0600AB80 RID: 43904 RVA: 0x001F5005 File Offset: 0x001F3205
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnCloseClicked));
			this.m_AutoResolve.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this._OnAutoResolveClicked));
		}

		// Token: 0x0600AB81 RID: 43905 RVA: 0x001F5040 File Offset: 0x001F3240
		private bool _OnCloseClicked(IXUIButton go)
		{
			base.PanelObject.SetActive(false);
			bool flag = DlgBase<CardCollectView, CardCollectBehaviour>.singleton.IsVisible();
			if (flag)
			{
				this.doc.View.CloseCurPage(CardPage.CardAll);
			}
			return true;
		}

		// Token: 0x0600AB82 RID: 43906 RVA: 0x001F5080 File Offset: 0x001F3280
		private void _OnAutoResolveClicked(IXUISprite iSp)
		{
			bool flag = !DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.GetTempTip(XTempTipDefine.OD_CARD_RESOLVE_TIP);
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowModalDialog(XSingleton<UiUtility>.singleton.ReplaceReturn(XSingleton<XStringTable>.singleton.GetString("CARD_RESOLVE_TIP")), XStringDefineProxy.GetString("CARD_COMMON_OK"), XStringDefineProxy.GetString("CARD_COMMON_CANCEL"), new ButtonClickEventHandler(this._OpenAutoResolve), null, false, XTempTipDefine.OD_CARD_RESOLVE_TIP, 50);
			}
			else
			{
				this._OpenAutoResolve(null);
			}
		}

		// Token: 0x0600AB83 RID: 43907 RVA: 0x001F50F8 File Offset: 0x001F32F8
		private bool _OpenAutoResolve(IXUIButton btn)
		{
			bool flag = this.doc.View != null;
			if (flag)
			{
				this.doc.View.qualityFilter.SetVisible(true);
			}
			XSingleton<UiUtility>.singleton.CloseModalDlg();
			return true;
		}

		// Token: 0x0600AB84 RID: 43908 RVA: 0x001F513F File Offset: 0x001F333F
		public override void OnUnload()
		{
			base.OnUnload();
			this.doc = null;
		}

		// Token: 0x0600AB85 RID: 43909 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		protected override void OnShow()
		{
		}

		// Token: 0x0600AB86 RID: 43910 RVA: 0x001F5150 File Offset: 0x001F3350
		public void ShowHandler(bool bResetPosition = false)
		{
			base.PanelObject.SetActive(true);
			List<List<CardsList.RowData>> list = new List<List<CardsList.RowData>>();
			for (int i = 0; i <= 5; i++)
			{
				List<CardsList.RowData> list2 = new List<CardsList.RowData>();
				list.Add(list2);
			}
			for (int j = 0; j < this.doc.CurDeck.CardList.Count; j++)
			{
				uint cardId = this.doc.CurDeck.CardList[j].CardId;
				CardsList.RowData cards = XCardCollectDocument.GetCards(cardId);
				ItemList.RowData itemConf = XBagDocument.GetItemConf((int)cardId);
				list[(int)itemConf.ItemQuality].Add(cards);
			}
			float num = 0f;
			IXUISprite ixuisprite = this.item.Find("ItemTpl").GetComponent("XUISprite") as IXUISprite;
			int spriteWidth = ixuisprite.spriteWidth;
			int spriteHeight = ixuisprite.spriteHeight;
			this.m_qualityItemPool.FakeReturnAll();
			for (int k = 5; k >= 1; k--)
			{
				GameObject gameObject = this.m_qualityItemPool.FetchGameObject(false);
				Transform transform = gameObject.transform.Find("ItemTpl");
				this.quality[k].localPosition = new Vector3(0f, num, 0f);
				IXUISprite ixuisprite2 = this.quality[k].GetComponent("XUISprite") as IXUISprite;
				this.m_ItemPool[k].FakeReturnAll();
				int num2 = -1;
				for (int l = 0; l < list[k].Count; l++)
				{
					bool flag = l % CardTotalHandler.LINE_ITEM_NUM == 0;
					if (flag)
					{
						num2++;
					}
					GameObject gameObject2 = this.m_ItemPool[k].FetchGameObject(false);
					int cardCount = this.doc.GetCardCount((int)list[k][l].CardId);
					XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(gameObject2, (int)list[k][l].CardId, cardCount, false);
					IXUISprite ixuisprite3 = gameObject2.transform.Find("Icon").GetComponent("XUISprite") as IXUISprite;
					ixuisprite3.ID = (ulong)list[k][l].CardId;
					ixuisprite3.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(DlgBase<CardCollectView, CardCollectBehaviour>.singleton.OnOpenDetailClick));
					IXUILabel ixuilabel = gameObject2.transform.Find("Num").GetComponent("XUILabel") as IXUILabel;
					ixuilabel.gameObject.SetActive(cardCount != 0);
					ixuilabel.SetText(cardCount.ToString());
					int num3 = l % CardTotalHandler.LINE_ITEM_NUM;
					gameObject2.transform.localPosition = new Vector3((float)(spriteWidth * num3), (float)(-(float)spriteHeight * num2), 0f);
				}
				this.m_ItemPool[k].ActualReturnAll(true);
				num -= (float)(spriteHeight * (num2 + 1) + ixuisprite2.spriteHeight);
			}
			this.m_qualityItemPool.ActualReturnAll(true);
			if (bResetPosition)
			{
				this.m_CardPanelScrollView.ResetPosition();
			}
		}

		// Token: 0x04004041 RID: 16449
		public static readonly int LINE_ITEM_NUM = 7;

		// Token: 0x04004042 RID: 16450
		private XCardCollectDocument doc;

		// Token: 0x04004043 RID: 16451
		private IXUIButton m_Close;

		// Token: 0x04004044 RID: 16452
		private IXUISprite m_AutoResolve;

		// Token: 0x04004045 RID: 16453
		private Transform[] quality = new Transform[6];

		// Token: 0x04004046 RID: 16454
		private Transform item;

		// Token: 0x04004047 RID: 16455
		private XUIPool m_qualityItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04004048 RID: 16456
		private XUIPool[] m_ItemPool = new XUIPool[6];

		// Token: 0x04004049 RID: 16457
		private Transform CardPanel;

		// Token: 0x0400404A RID: 16458
		private IXUIScrollView m_CardPanelScrollView;
	}
}
