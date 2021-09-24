using System;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	[Hotfix]
	internal class XBackFlowMallHandler : DlgHandlerBase
	{

		protected override string FileName
		{
			get
			{
				return "Hall/BfMallHandler";
			}
		}

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

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_RefreshBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnRefreshBtnClicked));
		}

		private bool OnRefreshBtnClicked(IXUIButton sp)
		{
			XBackFlowDocument.Doc.SendBackFlowActivityOperation(BackFlowActOp.BackFlowAct_ShopUpdate, 0U);
			return true;
		}

		protected override void OnShow()
		{
			base.OnShow();
			XBackFlowDocument.Doc.SendBackFlowActivityOperation(BackFlowActOp.BackFlowAct_ShopData, 0U);
			this.m_ResetdTip.SetText(XStringDefineProxy.GetString("BackFlowShopResetTip"));
		}

		protected override void OnHide()
		{
			base.OnHide();
			XSingleton<XTimerMgr>.singleton.KillTimer(this._CDToken);
		}

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

		private void LeftTimeUpdate(object o)
		{
			this.currLeftTime--;
			this.SetCloseLeftTime();
		}

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

		private bool OnClickOKBtn(IXUIButton btn)
		{
			XBackFlowDocument.Doc.SendBackFlowActivityOperation(BackFlowActOp.BackFlowAct_ShopBuy, (uint)btn.ID);
			DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetVisible(false, true);
			return true;
		}

		private XUIPool m_ItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		private IXUIList m_ShopItemList;

		private IXUIButton m_RefreshBtn;

		private IXUILabel m_CloseTip;

		private IXUILabel m_ResetdTip;

		private IXUILabel m_LeftTimes;

		private int currLeftTime;

		private uint _CDToken = 0U;
	}
}
