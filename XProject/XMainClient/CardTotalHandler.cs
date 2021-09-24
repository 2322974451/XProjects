using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class CardTotalHandler : DlgHandlerBase
	{

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

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnCloseClicked));
			this.m_AutoResolve.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this._OnAutoResolveClicked));
		}

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

		public override void OnUnload()
		{
			base.OnUnload();
			this.doc = null;
		}

		protected override void OnShow()
		{
		}

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

		public static readonly int LINE_ITEM_NUM = 7;

		private XCardCollectDocument doc;

		private IXUIButton m_Close;

		private IXUISprite m_AutoResolve;

		private Transform[] quality = new Transform[6];

		private Transform item;

		private XUIPool m_qualityItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		private XUIPool[] m_ItemPool = new XUIPool[6];

		private Transform CardPanel;

		private IXUIScrollView m_CardPanelScrollView;
	}
}
