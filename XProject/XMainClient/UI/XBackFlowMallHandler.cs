using System;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x020016CF RID: 5839
	[Hotfix]
	internal class XBackFlowMallHandler : DlgHandlerBase
	{
		// Token: 0x1700373B RID: 14139
		// (get) Token: 0x0600F0D7 RID: 61655 RVA: 0x003510C0 File Offset: 0x0034F2C0
		protected override string FileName
		{
			get
			{
				return "Hall/BfMallHandler";
			}
		}

		// Token: 0x0600F0D8 RID: 61656 RVA: 0x003510D8 File Offset: 0x0034F2D8
		protected override void Init()
		{
			base.Init();
			Transform transform = base.PanelObject.transform.Find("ShopItemList/Grid/ShopItemTpl");
			this.m_ItemPool.SetupPool(transform.parent.gameObject, transform.gameObject, 6U, false);
			this.m_RefreshBtn = (base.PanelObject.transform.Find("BtnRefresh").GetComponent("XUIButton") as IXUIButton);
			this.m_ShopItemList = (base.PanelObject.transform.Find("ShopItemList/Grid").GetComponent("XUIList") as IXUIList);
			this.m_CloseTip = (base.PanelObject.transform.Find("Title").GetComponent("XUILabel") as IXUILabel);
			this.m_ResetdTip = (base.PanelObject.transform.Find("Tip").GetComponent("XUILabel") as IXUILabel);
			this.m_LeftTimes = (base.PanelObject.transform.Find("Times").GetComponent("XUILabel") as IXUILabel);
		}

		// Token: 0x0600F0D9 RID: 61657 RVA: 0x003511F4 File Offset: 0x0034F3F4
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_RefreshBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnRefreshBtnClicked));
		}

		// Token: 0x0600F0DA RID: 61658 RVA: 0x00351218 File Offset: 0x0034F418
		private bool OnRefreshBtnClicked(IXUIButton sp)
		{
			XBackFlowDocument.Doc.SendBackFlowActivityOperation(BackFlowActOp.BackFlowAct_ShopUpdate, 0U);
			return true;
		}

		// Token: 0x0600F0DB RID: 61659 RVA: 0x00351238 File Offset: 0x0034F438
		protected override void OnShow()
		{
			base.OnShow();
			XBackFlowDocument.Doc.SendBackFlowActivityOperation(BackFlowActOp.BackFlowAct_ShopData, 0U);
			this.m_ResetdTip.SetText(XStringDefineProxy.GetString("BackFlowShopResetTip"));
		}

		// Token: 0x0600F0DC RID: 61660 RVA: 0x00351265 File Offset: 0x0034F465
		protected override void OnHide()
		{
			base.OnHide();
			XSingleton<XTimerMgr>.singleton.KillTimer(this._CDToken);
		}

		// Token: 0x0600F0DD RID: 61661 RVA: 0x00351280 File Offset: 0x0034F480
		public override void RefreshData()
		{
			bool flag = XBackFlowDocument.Doc.BackflowShopData == null;
			if (!flag)
			{
				this.m_ItemPool.FakeReturnAll();
				for (int i = 0; i < XBackFlowDocument.Doc.BackflowShopData.goods.Count; i++)
				{
					GameObject gameObject = this.m_ItemPool.FetchGameObject(false);
					gameObject.transform.parent = this.m_ShopItemList.gameObject.transform;
					gameObject.transform.localScale = Vector3.one;
					this.SetShopItemInfo(gameObject, XBackFlowDocument.Doc.BackflowShopData.goods[i]);
				}
				this.m_ShopItemList.Refresh();
				this.m_ItemPool.ActualReturnAll(false);
				int @int = XSingleton<XGlobalConfig>.singleton.GetInt("BackFlowShopFreshCount");
				this.m_LeftTimes.SetText(string.Format("{0}/{1}", XBackFlowDocument.Doc.BackflowShopData.freshCount, @int));
				this.currLeftTime = (int)XBackFlowDocument.Doc.ShopLeftTime;
				this.SetCloseLeftTime();
			}
		}

		// Token: 0x0600F0DE RID: 61662 RVA: 0x003513A0 File Offset: 0x0034F5A0
		private void SetCloseLeftTime()
		{
			XSingleton<XTimerMgr>.singleton.KillTimer(this._CDToken);
			bool flag = this.currLeftTime > 0;
			if (flag)
			{
				bool flag2 = this.currLeftTime >= 43200;
				string arg;
				if (flag2)
				{
					arg = XSingleton<UiUtility>.singleton.TimeDuarationFormatString(this.currLeftTime, 4);
				}
				else
				{
					arg = XSingleton<UiUtility>.singleton.TimeDuarationFormatString(this.currLeftTime, 5);
				}
				this._CDToken = XSingleton<XTimerMgr>.singleton.SetTimer(1f, new XTimerMgr.ElapsedEventHandler(this.LeftTimeUpdate), null);
				this.m_CloseTip.SetText(string.Format(XStringDefineProxy.GetString("BackFlowShopCloseTime"), arg));
			}
			this.m_CloseTip.SetVisible(this.currLeftTime > 0);
		}

		// Token: 0x0600F0DF RID: 61663 RVA: 0x0035145B File Offset: 0x0034F65B
		private void LeftTimeUpdate(object o)
		{
			this.currLeftTime--;
			this.SetCloseLeftTime();
		}

		// Token: 0x0600F0E0 RID: 61664 RVA: 0x00351474 File Offset: 0x0034F674
		private void SetShopItemInfo(GameObject shopItem, BackFlowShopGood goodsInfo)
		{
			BackflowShop.RowData byGoodID = XBackFlowDocument.BackflowShopTable.GetByGoodID(goodsInfo.GoodID);
			bool flag = byGoodID == null;
			if (!flag)
			{
				this.SetQualityBorder(shopItem, byGoodID.Quality);
				GameObject gameObject = shopItem.transform.Find("Item").gameObject;
				XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(gameObject, (int)byGoodID.ItemID, (int)byGoodID.ItemCount, true);
				IXUISprite ixuisprite = gameObject.transform.FindChild("Icon").GetComponent("XUISprite") as IXUISprite;
				ixuisprite.ID = (ulong)byGoodID.ItemID;
				ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(XSingleton<UiUtility>.singleton.OnItemClick));
				IXUIButton ixuibutton = shopItem.transform.Find("BtnBuy").GetComponent("XUIButton") as IXUIButton;
				ixuibutton.gameObject.SetActive(!goodsInfo.IsBuy);
				ixuibutton.ID = (ulong)goodsInfo.GoodID;
				ixuibutton.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnBuyBtnClicked));
				string itemSmallIcon = XBagDocument.GetItemSmallIcon((int)byGoodID.CostType, 0U);
				IXUISprite ixuisprite2 = ixuibutton.gameObject.transform.Find("MoneyCost/Icon").GetComponent("XUISprite") as IXUISprite;
				ixuisprite2.SetSprite(itemSmallIcon);
				IXUILabel ixuilabel = ixuibutton.gameObject.transform.Find("MoneyCost").GetComponent("XUILabel") as IXUILabel;
				ixuilabel.SetText(byGoodID.CostNum.ToString());
				GameObject gameObject2 = shopItem.transform.Find("Empty").gameObject;
				gameObject2.SetActive(goodsInfo.IsBuy);
				GameObject gameObject3 = shopItem.transform.Find("limit").gameObject;
				gameObject3.SetActive(byGoodID.Discount > 0U && byGoodID.Discount != 100U && !goodsInfo.IsBuy);
				IXUILabel ixuilabel2 = shopItem.transform.Find("limit/num").GetComponent("XUILabel") as IXUILabel;
				ixuilabel2.SetText((byGoodID.Discount / 10f).ToString());
			}
		}

		// Token: 0x0600F0E1 RID: 61665 RVA: 0x0035169C File Offset: 0x0034F89C
		private void SetQualityBorder(GameObject shopItem, uint quality)
		{
			for (int i = 0; i <= 5; i++)
			{
				string text = string.Format("Quality{0}", i);
				Transform transform = shopItem.transform.Find(text);
				bool flag = transform != null;
				if (flag)
				{
					transform.gameObject.SetActive((long)i == (long)((ulong)quality));
				}
			}
		}

		// Token: 0x0600F0E2 RID: 61666 RVA: 0x00351700 File Offset: 0x0034F900
		private bool OnBuyBtnClicked(IXUIButton btn)
		{
			BackflowShop.RowData byGoodID = XBackFlowDocument.BackflowShopTable.GetByGoodID((uint)btn.ID);
			bool flag = byGoodID == null;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetVisible(false, true);
				DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.uiBehaviour.m_OKButton.ID = btn.ID;
				ItemList.RowData itemConf = XBagDocument.GetItemConf((int)byGoodID.ItemID);
				bool flag2 = itemConf == null;
				if (flag2)
				{
					result = false;
				}
				else
				{
					string text = XSingleton<UiUtility>.singleton.ChooseProfString(itemConf.ItemName, 0U);
					string message = string.Format(XStringDefineProxy.GetString("BackFlowShopBuyTip", new object[]
					{
						byGoodID.ItemCount,
						text
					}), new object[0]);
					XSingleton<UiUtility>.singleton.ShowModalDialog(message, new ButtonClickEventHandler(this.OnClickOKBtn));
					result = true;
				}
			}
			return result;
		}

		// Token: 0x0600F0E3 RID: 61667 RVA: 0x003517D4 File Offset: 0x0034F9D4
		private bool OnClickOKBtn(IXUIButton btn)
		{
			XBackFlowDocument.Doc.SendBackFlowActivityOperation(BackFlowActOp.BackFlowAct_ShopBuy, (uint)btn.ID);
			DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetVisible(false, true);
			return true;
		}

		// Token: 0x040066C5 RID: 26309
		private XUIPool m_ItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x040066C6 RID: 26310
		private IXUIList m_ShopItemList;

		// Token: 0x040066C7 RID: 26311
		private IXUIButton m_RefreshBtn;

		// Token: 0x040066C8 RID: 26312
		private IXUILabel m_CloseTip;

		// Token: 0x040066C9 RID: 26313
		private IXUILabel m_ResetdTip;

		// Token: 0x040066CA RID: 26314
		private IXUILabel m_LeftTimes;

		// Token: 0x040066CB RID: 26315
		private int currLeftTime;

		// Token: 0x040066CC RID: 26316
		private uint _CDToken = 0U;
	}
}
