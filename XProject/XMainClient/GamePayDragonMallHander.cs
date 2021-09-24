using System;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class GamePayDragonMallHander : DlgHandlerBase
	{

		protected override void Init()
		{
			this._doc = XDocuments.GetSpecificDocument<XPurchaseDocument>(XPurchaseDocument.uuID);
			this.m_QuickBuyDiamond = (base.transform.Find("bg/BuyFrame/UseDiamond").GetComponent("XUIButton") as IXUIButton);
			this.m_QuickBuyDragonCoin = (base.transform.Find("bg/BuyFrame/UseDragonCoin").GetComponent("XUIButton") as IXUIButton);
			this.m_QuickBuyCost = (base.transform.Find("bg/BuyFrame/num2").GetComponent("XUILabelSymbol") as IXUILabelSymbol);
			this.m_Tips = (base.transform.Find("bg/BuyFrame/tips").GetComponent("XUILabel") as IXUILabel);
			this.m_Title = (base.transform.Find("bg/BuyFrame/title").GetComponent("XUILabel") as IXUILabel);
			this.m_BuyNumLeft = (base.transform.Find("bg/BuyFrame/timesleft").GetComponent("XUILabel") as IXUILabel);
			this.m_BuyNum = (base.transform.Find("bg/BuyFrame/num1").GetComponent("XUILabelSymbol") as IXUILabelSymbol);
			this.m_BuyNumError = (base.transform.Find("bg/BuyFrame/error").GetComponent("XUILabel") as IXUILabel);
			this.m_Time = (base.transform.Find("bg/BuyFrame/time").GetComponent("XUILabel") as IXUILabel);
		}

		public override void RegisterEvent()
		{
			this.m_QuickBuyDiamond.RegisterClickEventHandler(new ButtonClickEventHandler(this.DoPurchaseDiamond));
			this.m_QuickBuyDragonCoin.RegisterClickEventHandler(new ButtonClickEventHandler(this.DoPurchageDC));
		}

		public void ReceiveFatigueTime(PtcG2C_FatigueRecoverTimeNotify times)
		{
			GamePayDragonMallHander._fatigueTime.timeleft = times.Data.timeleft;
			GamePayDragonMallHander._fatigueTime.fatigueid = times.Data.fatigueID;
			GamePayDragonMallHander._fatigueTime.updatetime = DateTime.Now;
		}

		protected override void OnShow()
		{
			base.OnShow();
			this.ShowBorad(DlgBase<GameMallDlg, TabDlgBehaviour>.singleton.item);
		}

		public void ShowBorad(ItemEnum type)
		{
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

		public void RefreshBoard()
		{
			int level = (int)XSingleton<XAttributeMgr>.singleton.XPlayerData.Level;
			XRechargeDocument specificDocument = XDocuments.GetSpecificDocument<XRechargeDocument>(XRechargeDocument.uuID);
			int vipLevel = (int)specificDocument.VipLevel;
			XPurchaseInfo purchaseInfo = this._doc.GetPurchaseInfo(level, vipLevel, this._showItem);
			this.m_BuyNumLeft.SetText(XStringDefineProxy.GetString("SYS_PURCHASE_TIMES") + (purchaseInfo.totalBuyNum - purchaseInfo.curBuyNum).ToString() + "/" + purchaseInfo.totalBuyNum.ToString());
			this.m_BuyNum.InputText = XLabelSymbolHelper.FormatCostWithIcon(purchaseInfo.GetCount, this._showItem);
			bool flag = this._showItem == ItemEnum.DRAGON_COIN;
			if (flag)
			{
				this.m_QuickBuyCost.InputText = XLabelSymbolHelper.FormatCostWithIcon(purchaseInfo.diamondCost, ItemEnum.DIAMOND);
			}
			else
			{
				this.m_QuickBuyCost.InputText = XLabelSymbolHelper.FormatCostWithIcon(purchaseInfo.dragoncoinCost, ItemEnum.DRAGON_COIN);
			}
		}

		protected void SetupPanel()
		{
			bool flag = this._showItem == ItemEnum.VIRTUAL_ITEM_MAX;
			if (!flag)
			{
				this.m_Time.gameObject.SetActive(false);
				this.m_BuyNumError.gameObject.SetActive(false);
				ItemEnum showItem = this._showItem;
				if (showItem != ItemEnum.GOLD)
				{
					if (showItem != ItemEnum.FATIGUE)
					{
						if (showItem == ItemEnum.DRAGON_COIN)
						{
							this.m_Title.SetText(XStringDefineProxy.GetString("PURCHASEDC"));
							this.m_QuickBuyDiamond.gameObject.SetActive(true);
							this.m_QuickBuyDragonCoin.gameObject.SetActive(false);
							this.m_Tips.SetText(XStringDefineProxy.GetString("Quick_Purchase_Tips2"));
							Vector3 localPosition = this.m_QuickBuyDiamond.gameObject.transform.localPosition;
							this.m_QuickBuyDiamond.gameObject.transform.localPosition = new Vector3(0f, localPosition.y);
						}
					}
					else
					{
						this.m_Title.SetText(XStringDefineProxy.GetString("PURCHASEFAT"));
						this.m_QuickBuyDiamond.gameObject.SetActive(false);
						this.m_QuickBuyDragonCoin.gameObject.SetActive(true);
						this.m_Tips.SetText(XStringDefineProxy.GetString("Quick_Purchase_Tips3"));
						Vector3 localPosition2 = this.m_QuickBuyDiamond.gameObject.transform.localPosition;
						this.m_QuickBuyDragonCoin.gameObject.transform.localPosition = new Vector3(0f, localPosition2.y);
					}
				}
				else
				{
					this.m_Title.SetText(XStringDefineProxy.GetString("PURCHASEGOLD"));
					this.m_QuickBuyDiamond.gameObject.SetActive(false);
					this.m_QuickBuyDragonCoin.gameObject.SetActive(true);
					this.m_Tips.SetText(XStringDefineProxy.GetString("Quick_Purchase_Tips1"));
					Vector3 localPosition3 = this.m_QuickBuyDiamond.gameObject.transform.localPosition;
					this.m_QuickBuyDragonCoin.gameObject.transform.localPosition = new Vector3(0f, localPosition3.y);
				}
			}
		}

		public void ShowErrorCode(ErrorCode err)
		{
			bool flag = this.m_BuyNum != null;
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
			for (int i = 0; i < GamePayDragonMallHander._fatigueTime.fatigueid.Count; i++)
			{
				bool flag = GamePayDragonMallHander._fatigueTime.fatigueid[i] == (uint)this._showItem;
				if (flag)
				{
					num = GamePayDragonMallHander._fatigueTime.timeleft[i] / 1000U;
				}
			}
			double totalSeconds = (DateTime.Now - GamePayDragonMallHander._fatigueTime.updatetime).TotalSeconds;
			num -= (uint)totalSeconds;
			return (num > 0U) ? num : 0U;
		}

		public void UpdateTimer(object param)
		{
			uint num = 0U;
			for (int i = 0; i < GamePayDragonMallHander._fatigueTime.fatigueid.Count; i++)
			{
				bool flag = GamePayDragonMallHander._fatigueTime.fatigueid[i] == (uint)this._showItem;
				if (flag)
				{
					num = GamePayDragonMallHander._fatigueTime.timeleft[i];
				}
			}
			bool flag2 = num == 0U;
			if (flag2)
			{
				this.m_Time.SetText("");
			}
			else
			{
				double totalSeconds = (DateTime.Now - GamePayDragonMallHander._fatigueTime.updatetime).TotalSeconds;
				num -= (uint)totalSeconds;
				bool flag3 = num <= 0U;
				if (flag3)
				{
					this.m_Time.SetText("");
				}
				else
				{
					this.m_Time.SetText("");
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
			this._doc.CommonQuickBuy(this._showItem, ItemEnum.DIAMOND, 1U);
			return true;
		}

		public bool DoPurchageDC(IXUIButton sp)
		{
			this._doc.CommonQuickBuy(this._showItem, ItemEnum.DRAGON_COIN, 1U);
			return true;
		}

		public void ReqQuickCommonPurchase(ItemEnum itemid = ItemEnum.FATIGUE)
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

		public IXUILabel m_Title;

		public IXUILabel m_BuyNumLeft;

		public IXUILabel m_BuyNumError;

		public IXUILabelSymbol m_BuyNum;

		public IXUILabel m_Time;

		public IXUILabel m_Tips;

		public IXUIButton m_QuickBuyDiamond;

		public IXUIButton m_QuickBuyDragonCoin;

		public IXUILabelSymbol m_QuickBuyCost;
	}
}
