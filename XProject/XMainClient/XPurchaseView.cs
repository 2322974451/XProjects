using System;
using KKSG;
using UILib;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000E4E RID: 3662
	internal class XPurchaseView : DlgBase<XPurchaseView, XPurchaseBehaviour>
	{
		// Token: 0x17003462 RID: 13410
		// (get) Token: 0x0600C45D RID: 50269 RVA: 0x002ADCA0 File Offset: 0x002ABEA0
		public override string fileName
		{
			get
			{
				return "Common/QuickPurchase";
			}
		}

		// Token: 0x17003463 RID: 13411
		// (get) Token: 0x0600C45E RID: 50270 RVA: 0x002ADCB8 File Offset: 0x002ABEB8
		public override int group
		{
			get
			{
				return 2;
			}
		}

		// Token: 0x17003464 RID: 13412
		// (get) Token: 0x0600C45F RID: 50271 RVA: 0x002ADCCC File Offset: 0x002ABECC
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17003465 RID: 13413
		// (get) Token: 0x0600C460 RID: 50272 RVA: 0x002ADCE0 File Offset: 0x002ABEE0
		public override bool isHideTutorial
		{
			get
			{
				return true;
			}
		}

		// Token: 0x0600C461 RID: 50273 RVA: 0x002ADCF3 File Offset: 0x002ABEF3
		protected override void Init()
		{
			this._doc = XDocuments.GetSpecificDocument<XPurchaseDocument>(XPurchaseDocument.uuID);
			this._doc.PurchaseView = this;
		}

		// Token: 0x0600C462 RID: 50274 RVA: 0x002ADD14 File Offset: 0x002ABF14
		public override void RegisterEvent()
		{
			base.uiBehaviour.m_QuickBuyDiamond.ID = 1UL;
			base.uiBehaviour.m_QuickBuyDiamond.RegisterClickEventHandler(new ButtonClickEventHandler(this.DoPurchaseDiamond));
			base.uiBehaviour.m_QuickBuyDiamond10.ID = 10UL;
			base.uiBehaviour.m_QuickBuyDiamond10.RegisterClickEventHandler(new ButtonClickEventHandler(this.DoPurchaseDiamond));
			base.uiBehaviour.m_QuickBuyDragonCoin.RegisterClickEventHandler(new ButtonClickEventHandler(this.DoPurchageDC));
			base.uiBehaviour.m_QuitBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseClicked));
		}

		// Token: 0x0600C463 RID: 50275 RVA: 0x002ADDBD File Offset: 0x002ABFBD
		protected override void OnUnload()
		{
			this._doc = null;
			base.OnUnload();
		}

		// Token: 0x0600C464 RID: 50276 RVA: 0x002ADDD0 File Offset: 0x002ABFD0
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

		// Token: 0x0600C465 RID: 50277 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public void Refresh()
		{
		}

		// Token: 0x0600C466 RID: 50278 RVA: 0x002ADE13 File Offset: 0x002AC013
		public void ReceiveFatigueTime(PtcG2C_FatigueRecoverTimeNotify times)
		{
			XPurchaseView._fatigueTime.timeleft = times.Data.timeleft;
			XPurchaseView._fatigueTime.fatigueid = times.Data.fatigueID;
			XPurchaseView._fatigueTime.updatetime = DateTime.Now;
		}

		// Token: 0x0600C467 RID: 50279 RVA: 0x002ADE50 File Offset: 0x002AC050
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

		// Token: 0x0600C468 RID: 50280 RVA: 0x002ADEDC File Offset: 0x002AC0DC
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

		// Token: 0x0600C469 RID: 50281 RVA: 0x002ADF88 File Offset: 0x002AC188
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

		// Token: 0x0600C46A RID: 50282 RVA: 0x002AE03C File Offset: 0x002AC23C
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

		// Token: 0x0600C46B RID: 50283 RVA: 0x002AE230 File Offset: 0x002AC430
		public void ShowErrorCode(ErrorCode err)
		{
			bool flag = base.uiBehaviour != null && base.uiBehaviour.m_BuyNum != null;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString(err), "fece00");
			}
		}

		// Token: 0x0600C46C RID: 50284 RVA: 0x002AE27C File Offset: 0x002AC47C
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

		// Token: 0x0600C46D RID: 50285 RVA: 0x002AE308 File Offset: 0x002AC508
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

		// Token: 0x0600C46E RID: 50286 RVA: 0x002AE3A0 File Offset: 0x002AC5A0
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

		// Token: 0x0600C46F RID: 50287 RVA: 0x002AE4C8 File Offset: 0x002AC6C8
		public bool DoPurchaseDiamond(IXUIButton sp)
		{
			this._doc.CommonQuickBuy(this._showItem, ItemEnum.DIAMOND, (uint)sp.ID);
			return true;
		}

		// Token: 0x0600C470 RID: 50288 RVA: 0x002AE4F8 File Offset: 0x002AC6F8
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

		// Token: 0x0600C471 RID: 50289 RVA: 0x002AE5B8 File Offset: 0x002AC7B8
		public bool GetFatigueSure(IXUIButton btn)
		{
			this._doc.CommonQuickBuy(this._showItem, ItemEnum.DRAGON_COIN, 1U);
			DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetVisible(false, true);
			return true;
		}

		// Token: 0x0600C472 RID: 50290 RVA: 0x002AE5EC File Offset: 0x002AC7EC
		public void ReqQuickCommonPurchase(ItemEnum itemEnum = ItemEnum.FATIGUE)
		{
			this.ReqQuickCommonPurchase(XFastEnumIntEqualityComparer<ItemEnum>.ToInt(itemEnum));
		}

		// Token: 0x0600C473 RID: 50291 RVA: 0x002AE5FC File Offset: 0x002AC7FC
		public void ReqQuickCommonPurchase(int itemid)
		{
			this.ShowBorad(itemid);
		}

		// Token: 0x0600C474 RID: 50292 RVA: 0x002AE608 File Offset: 0x002AC808
		public void UpdatePlayerBuyInfo(BuyGoldFatInfo buyInfo)
		{
			bool flag = this._doc == null;
			if (!flag)
			{
				this._doc.InitPurchaseInfo(buyInfo);
				this.RefreshBoard();
			}
		}

		// Token: 0x0400557B RID: 21883
		private XPurchaseDocument _doc = null;

		// Token: 0x0400557C RID: 21884
		private uint nextRecoverTimer = 0U;

		// Token: 0x0400557D RID: 21885
		public static FatigueRecoverTime _fatigueTime = new FatigueRecoverTime();

		// Token: 0x0400557E RID: 21886
		public ItemEnum _showItem = ItemEnum.VIRTUAL_ITEM_MAX;
	}
}
