using System;
using KKSG;
using UILib;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XPurchaseView : DlgBase<XPurchaseView, XPurchaseBehaviour>
	{

		public override string fileName
		{
			get
			{
				return "Common/QuickPurchase";
			}
		}

		public override int group
		{
			get
			{
				return 2;
			}
		}

		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		public override bool isHideTutorial
		{
			get
			{
				return true;
			}
		}

		protected override void Init()
		{
			this._doc = XDocuments.GetSpecificDocument<XPurchaseDocument>(XPurchaseDocument.uuID);
			this._doc.PurchaseView = this;
		}

		public override void RegisterEvent()
		{
			base.uiBehaviour.m_QuickBuyDiamond.ID = 1UL;
			base.uiBehaviour.m_QuickBuyDiamond.RegisterClickEventHandler(new ButtonClickEventHandler(this.DoPurchaseDiamond));
			base.uiBehaviour.m_QuickBuyDiamond10.ID = 10UL;
			base.uiBehaviour.m_QuickBuyDiamond10.RegisterClickEventHandler(new ButtonClickEventHandler(this.DoPurchaseDiamond));
			base.uiBehaviour.m_QuickBuyDragonCoin.RegisterClickEventHandler(new ButtonClickEventHandler(this.DoPurchageDC));
			base.uiBehaviour.m_QuitBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseClicked));
		}

		protected override void OnUnload()
		{
			this._doc = null;
			base.OnUnload();
		}

		public bool OnCloseClicked(IXUIButton sp)
		{
			bool flag = this.nextRecoverTimer > 0U;
			if (flag)
			{
				XSingleton<XTimerMgr>.singleton.KillTimer(this.nextRecoverTimer);
				this.nextRecoverTimer = 0U;
			}
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

		public void Refresh()
		{
		}

		public void ReceiveFatigueTime(PtcG2C_FatigueRecoverTimeNotify times)
		{
			XPurchaseView._fatigueTime.timeleft = times.Data.timeleft;
			XPurchaseView._fatigueTime.fatigueid = times.Data.fatigueID;
			XPurchaseView._fatigueTime.updatetime = DateTime.Now;
		}

		public void ShowBorad(int itemid)
		{
			if (itemid != 1)
			{
				switch (itemid)
				{
				case 6:
				case 7:
				case 9:
					this.ShowBorad((ItemEnum)itemid);
					return;
				case 11:
					DlgBase<DragonGuildLivenessDlg, DragonGuildLivenessBehaviour>.singleton.SetVisible(true, true);
					return;
				}
				XSingleton<UiUtility>.singleton.ShowItemAccess(itemid, null);
			}
			else
			{
				bool flag = XSingleton<XGame>.singleton.CurrentStage.Stage == EXStage.Hall;
				if (flag)
				{
					DlgBase<XWelfareView, XWelfareBehaviour>.singleton.Show(XSysDefine.XSys_Welfare_MoneyTree);
				}
			}
		}

		public void ShowBorad(ItemEnum type)
		{
			if (type != ItemEnum.GOLD)
			{
				if (type != ItemEnum.DIAMOND)
				{
					this.SetVisibleWithAnimation(true, null);
					this._showItem = type;
					this.SetupPanel();
					this.RefreshBoard();
					bool flag = this._showItem == ItemEnum.FATIGUE;
					if (flag)
					{
						bool flag2 = this.nextRecoverTimer > 0U;
						if (flag2)
						{
							XSingleton<XTimerMgr>.singleton.KillTimer(this.nextRecoverTimer);
						}
						this.nextRecoverTimer = XSingleton<XTimerMgr>.singleton.SetTimer(1f, new XTimerMgr.ElapsedEventHandler(this.UpdateTimer), null);
					}
				}
				else
				{
					DlgBase<GameMallDlg, TabDlgBehaviour>.singleton.ShowPurchase(ItemEnum.DIAMOND);
				}
			}
			else
			{
				DlgBase<XWelfareView, XWelfareBehaviour>.singleton.Show(XSysDefine.XSys_Welfare_MoneyTree);
			}
		}

		public void RefreshBoard()
		{
			int level = (int)XSingleton<XAttributeMgr>.singleton.XPlayerData.Level;
			XRechargeDocument specificDocument = XDocuments.GetSpecificDocument<XRechargeDocument>(XRechargeDocument.uuID);
			int vipLevel = (int)specificDocument.VipLevel;
			XPurchaseInfo purchaseInfo = this._doc.GetPurchaseInfo(level, vipLevel, this._showItem);
			base.uiBehaviour.m_BuyNum.InputText = XLabelSymbolHelper.FormatCostWithIcon(purchaseInfo.GetCount, this._showItem);
			bool flag = this._showItem == ItemEnum.DRAGON_COIN;
			if (flag)
			{
				base.uiBehaviour.m_QuickBuyCost.InputText = XLabelSymbolHelper.FormatCostWithIcon(purchaseInfo.diamondCost, ItemEnum.DIAMOND);
			}
			else
			{
				base.uiBehaviour.m_QuickBuyCost.InputText = XLabelSymbolHelper.FormatCostWithIcon(purchaseInfo.dragoncoinCost, ItemEnum.DRAGON_COIN);
			}
		}

		protected void SetupPanel()
		{
			bool flag = this._showItem == ItemEnum.VIRTUAL_ITEM_MAX;
			if (!flag)
			{
				base.uiBehaviour.m_Time.gameObject.SetActive(false);
				base.uiBehaviour.m_BuyNumError.gameObject.SetActive(false);
				ItemEnum showItem = this._showItem;
				if (showItem != ItemEnum.GOLD)
				{
					if (showItem != ItemEnum.FATIGUE)
					{
						if (showItem == ItemEnum.DRAGON_COIN)
						{
							base.uiBehaviour.m_Title.SetText(XStringDefineProxy.GetString("PURCHASEDC"));
							base.uiBehaviour.m_QuickBuyDiamond.gameObject.SetActive(true);
							base.uiBehaviour.m_QuickBuyDiamond10.gameObject.SetActive(true);
							base.uiBehaviour.m_QuickBuyDragonCoin.gameObject.SetActive(false);
							base.uiBehaviour.m_Tips.SetText(XStringDefineProxy.GetString("Quick_Purchase_Tips2"));
						}
					}
					else
					{
						base.uiBehaviour.m_Title.SetText(XStringDefineProxy.GetString("PURCHASEFAT"));
						base.uiBehaviour.m_QuickBuyDiamond.gameObject.SetActive(false);
						base.uiBehaviour.m_QuickBuyDiamond10.gameObject.SetActive(false);
						base.uiBehaviour.m_QuickBuyDragonCoin.gameObject.SetActive(true);
						base.uiBehaviour.m_Tips.SetText(XStringDefineProxy.GetString("Quick_Purchase_Tips3"));
					}
				}
				else
				{
					base.uiBehaviour.m_Title.SetText(XStringDefineProxy.GetString("PURCHASEGOLD"));
					base.uiBehaviour.m_QuickBuyDiamond.gameObject.SetActive(false);
					base.uiBehaviour.m_QuickBuyDiamond10.gameObject.SetActive(false);
					base.uiBehaviour.m_QuickBuyDragonCoin.gameObject.SetActive(true);
					base.uiBehaviour.m_Tips.SetText(XStringDefineProxy.GetString("Quick_Purchase_Tips1"));
				}
			}
		}

		public void ShowErrorCode(ErrorCode err)
		{
			bool flag = base.uiBehaviour != null && base.uiBehaviour.m_BuyNum != null;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString(err), "fece00");
			}
		}

		public string FormatTime(uint time)
		{
			bool flag = time >= 3600U;
			string result;
			if (flag)
			{
				result = string.Format(string.Format("{0:D2}:{1:D2}:{2:D2}", (int)(time / 3600U), (int)(time % 3600U / 60U), time % 60U), new object[0]);
			}
			else
			{
				result = string.Format(string.Format("{0:D2}:{1:D2}", (int)(time % 3600U / 60U), time % 60U), new object[0]);
			}
			return result;
		}

		public uint GetTimeLeft(ItemEnum itemid)
		{
			uint num = 0U;
			for (int i = 0; i < XPurchaseView._fatigueTime.fatigueid.Count; i++)
			{
				bool flag = XPurchaseView._fatigueTime.fatigueid[i] == (uint)this._showItem;
				if (flag)
				{
					num = XPurchaseView._fatigueTime.timeleft[i] / 1000U;
				}
			}
			double totalSeconds = (DateTime.Now - XPurchaseView._fatigueTime.updatetime).TotalSeconds;
			num -= (uint)totalSeconds;
			return (num > 0U) ? num : 0U;
		}

		public void UpdateTimer(object param)
		{
			uint num = 0U;
			for (int i = 0; i < XPurchaseView._fatigueTime.fatigueid.Count; i++)
			{
				bool flag = XPurchaseView._fatigueTime.fatigueid[i] == (uint)this._showItem;
				if (flag)
				{
					num = XPurchaseView._fatigueTime.timeleft[i];
				}
			}
			bool flag2 = num == 0U;
			if (flag2)
			{
				base.uiBehaviour.m_Time.SetText("");
			}
			else
			{
				double totalSeconds = (DateTime.Now - XPurchaseView._fatigueTime.updatetime).TotalSeconds;
				num -= (uint)totalSeconds;
				bool flag3 = num <= 0U;
				if (flag3)
				{
					base.uiBehaviour.m_Time.SetText("");
				}
				else
				{
					base.uiBehaviour.m_Time.SetText("");
					bool flag4 = this.nextRecoverTimer > 0U;
					if (flag4)
					{
						XSingleton<XTimerMgr>.singleton.KillTimer(this.nextRecoverTimer);
					}
					this.nextRecoverTimer = XSingleton<XTimerMgr>.singleton.SetTimer(1f, new XTimerMgr.ElapsedEventHandler(this.UpdateTimer), null);
				}
			}
		}

		public bool DoPurchaseDiamond(IXUIButton sp)
		{
			this._doc.CommonQuickBuy(this._showItem, ItemEnum.DIAMOND, (uint)sp.ID);
			return true;
		}

		public bool DoPurchageDC(IXUIButton sp)
		{
			bool flag = this._showItem == ItemEnum.FATIGUE;
			if (flag)
			{
				int level = (int)XSingleton<XAttributeMgr>.singleton.XPlayerData.Level;
				XRechargeDocument specificDocument = XDocuments.GetSpecificDocument<XRechargeDocument>(XRechargeDocument.uuID);
				int vipLevel = (int)specificDocument.VipLevel;
				XPurchaseInfo purchaseInfo = this._doc.GetPurchaseInfo(level, vipLevel, ItemEnum.FATIGUE);
				int num = (int)XBagDocument.BagDoc.GetVirtualItemCount(ItemEnum.FATIGUE);
				bool flag2 = num + purchaseInfo.GetCount > int.Parse(XSingleton<XGlobalConfig>.singleton.GetValue("MaxFatigue"));
				if (flag2)
				{
					XSingleton<UiUtility>.singleton.ShowFatigueSureDlg(new ButtonClickEventHandler(this.GetFatigueSure));
					return true;
				}
			}
			this._doc.CommonQuickBuy(this._showItem, ItemEnum.DRAGON_COIN, 1U);
			return true;
		}

		public bool GetFatigueSure(IXUIButton btn)
		{
			this._doc.CommonQuickBuy(this._showItem, ItemEnum.DRAGON_COIN, 1U);
			DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetVisible(false, true);
			return true;
		}

		public void ReqQuickCommonPurchase(ItemEnum itemEnum = ItemEnum.FATIGUE)
		{
			this.ReqQuickCommonPurchase(XFastEnumIntEqualityComparer<ItemEnum>.ToInt(itemEnum));
		}

		public void ReqQuickCommonPurchase(int itemid)
		{
			this.ShowBorad(itemid);
		}

		public void UpdatePlayerBuyInfo(BuyGoldFatInfo buyInfo)
		{
			bool flag = this._doc == null;
			if (!flag)
			{
				this._doc.InitPurchaseInfo(buyInfo);
				this.RefreshBoard();
			}
		}

		private XPurchaseDocument _doc = null;

		private uint nextRecoverTimer = 0U;

		public static FatigueRecoverTime _fatigueTime = new FatigueRecoverTime();

		public ItemEnum _showItem = ItemEnum.VIRTUAL_ITEM_MAX;
	}
}
