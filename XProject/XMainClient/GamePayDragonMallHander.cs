using System;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000BFA RID: 3066
	internal class GamePayDragonMallHander : DlgHandlerBase
	{
		// Token: 0x0600AE4B RID: 44619 RVA: 0x0020A1EC File Offset: 0x002083EC
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

		// Token: 0x0600AE4C RID: 44620 RVA: 0x0020A357 File Offset: 0x00208557
		public override void RegisterEvent()
		{
			this.m_QuickBuyDiamond.RegisterClickEventHandler(new ButtonClickEventHandler(this.DoPurchaseDiamond));
			this.m_QuickBuyDragonCoin.RegisterClickEventHandler(new ButtonClickEventHandler(this.DoPurchageDC));
		}

		// Token: 0x0600AE4D RID: 44621 RVA: 0x0020A38A File Offset: 0x0020858A
		public void ReceiveFatigueTime(PtcG2C_FatigueRecoverTimeNotify times)
		{
			GamePayDragonMallHander._fatigueTime.timeleft = times.Data.timeleft;
			GamePayDragonMallHander._fatigueTime.fatigueid = times.Data.fatigueID;
			GamePayDragonMallHander._fatigueTime.updatetime = DateTime.Now;
		}

		// Token: 0x0600AE4E RID: 44622 RVA: 0x0020A3C6 File Offset: 0x002085C6
		protected override void OnShow()
		{
			base.OnShow();
			this.ShowBorad(DlgBase<GameMallDlg, TabDlgBehaviour>.singleton.item);
		}

		// Token: 0x0600AE4F RID: 44623 RVA: 0x0020A3E4 File Offset: 0x002085E4
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

		// Token: 0x0600AE50 RID: 44624 RVA: 0x0020A458 File Offset: 0x00208658
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

		// Token: 0x0600AE51 RID: 44625 RVA: 0x0020A53C File Offset: 0x0020873C
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

		// Token: 0x0600AE52 RID: 44626 RVA: 0x0020A75C File Offset: 0x0020895C
		public void ShowErrorCode(ErrorCode err)
		{
			bool flag = this.m_BuyNum != null;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString(err), "fece00");
			}
		}

		// Token: 0x0600AE53 RID: 44627 RVA: 0x0020A790 File Offset: 0x00208990
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

		// Token: 0x0600AE54 RID: 44628 RVA: 0x0020A81C File Offset: 0x00208A1C
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

		// Token: 0x0600AE55 RID: 44629 RVA: 0x0020A8B4 File Offset: 0x00208AB4
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

		// Token: 0x0600AE56 RID: 44630 RVA: 0x0020A9D0 File Offset: 0x00208BD0
		public bool DoPurchaseDiamond(IXUIButton sp)
		{
			this._doc.CommonQuickBuy(this._showItem, ItemEnum.DIAMOND, 1U);
			return true;
		}

		// Token: 0x0600AE57 RID: 44631 RVA: 0x0020A9F8 File Offset: 0x00208BF8
		public bool DoPurchageDC(IXUIButton sp)
		{
			this._doc.CommonQuickBuy(this._showItem, ItemEnum.DRAGON_COIN, 1U);
			return true;
		}

		// Token: 0x0600AE58 RID: 44632 RVA: 0x0020AA1F File Offset: 0x00208C1F
		public void ReqQuickCommonPurchase(ItemEnum itemid = ItemEnum.FATIGUE)
		{
			this.ShowBorad(itemid);
		}

		// Token: 0x0600AE59 RID: 44633 RVA: 0x0020AA2C File Offset: 0x00208C2C
		public void UpdatePlayerBuyInfo(BuyGoldFatInfo buyInfo)
		{
			bool flag = this._doc == null;
			if (!flag)
			{
				this._doc.InitPurchaseInfo(buyInfo);
				this.RefreshBoard();
			}
		}

		// Token: 0x040041FF RID: 16895
		private XPurchaseDocument _doc = null;

		// Token: 0x04004200 RID: 16896
		private uint nextRecoverTimer = 0U;

		// Token: 0x04004201 RID: 16897
		public static FatigueRecoverTime _fatigueTime = new FatigueRecoverTime();

		// Token: 0x04004202 RID: 16898
		public ItemEnum _showItem = ItemEnum.VIRTUAL_ITEM_MAX;

		// Token: 0x04004203 RID: 16899
		public IXUILabel m_Title;

		// Token: 0x04004204 RID: 16900
		public IXUILabel m_BuyNumLeft;

		// Token: 0x04004205 RID: 16901
		public IXUILabel m_BuyNumError;

		// Token: 0x04004206 RID: 16902
		public IXUILabelSymbol m_BuyNum;

		// Token: 0x04004207 RID: 16903
		public IXUILabel m_Time;

		// Token: 0x04004208 RID: 16904
		public IXUILabel m_Tips;

		// Token: 0x04004209 RID: 16905
		public IXUIButton m_QuickBuyDiamond;

		// Token: 0x0400420A RID: 16906
		public IXUIButton m_QuickBuyDragonCoin;

		// Token: 0x0400420B RID: 16907
		public IXUILabelSymbol m_QuickBuyCost;
	}
}
