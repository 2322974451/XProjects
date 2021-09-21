using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000EF8 RID: 3832
	internal class XNormalShopView : DlgHandlerBase
	{
		// Token: 0x0600CB57 RID: 52055 RVA: 0x002E514C File Offset: 0x002E334C
		protected override void Init()
		{
			base.Init();
			this._doc = XDocuments.GetSpecificDocument<XNormalShopDocument>(XNormalShopDocument.uuID);
			this.m_ShopItemPool.SetupPool(base.PanelObject.transform.FindChild("Panel").gameObject, base.PanelObject.transform.FindChild("Panel/ShopItemTpl").gameObject, 6U, false);
			this.m_ScrollView = (base.PanelObject.transform.FindChild("Panel").GetComponent("XUIScrollView") as IXUIScrollView);
			this.m_RefreshBtn = (base.PanelObject.transform.FindChild("RefreshInfo/BtnRefresh").GetComponent("XUIButton") as IXUIButton);
			this.m_RefreshBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnRefreshShop));
			this.m_RefreshLabel = (base.PanelObject.transform.FindChild("RefreshInfo/RefreshLabel").GetComponent("XUILabel") as IXUILabel);
			this.m_partnerInfoGo = base.PanelObject.transform.FindChild("PartnerInfo").gameObject;
			this.m_refreshBtn = (this.m_partnerInfoGo.transform.FindChild("RecordBtn").GetComponent("XUIButton") as IXUIButton);
			this.m_refreshBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickrRecordBtn));
			this.m_refreshTipLab = (this.m_partnerInfoGo.transform.FindChild("Tips").GetComponent("XUILabel") as IXUILabel);
			this.m_refreshTipLab.SetText(XSingleton<XStringTable>.singleton.GetString("PartnerShopRefreshTip"));
			DlgHandlerBase.EnsureCreate<PartnerShopRecordsHandler>(ref this.m_partnerShopRecordsHandler, base.PanelObject.transform, false, this);
			DlgHandlerBase.EnsureCreate<DragonGuildShopRecordsHandler>(ref this.m_dragonguildShopRecordsHandler, base.PanelObject.transform, false, this);
		}

		// Token: 0x0600CB58 RID: 52056 RVA: 0x002E5322 File Offset: 0x002E3522
		protected override void OnShow()
		{
			base.OnShow();
			this.OnRefreshData();
		}

		// Token: 0x0600CB59 RID: 52057 RVA: 0x002E5333 File Offset: 0x002E3533
		public override void OnUnload()
		{
			DlgHandlerBase.EnsureUnload<PartnerShopRecordsHandler>(ref this.m_partnerShopRecordsHandler);
			DlgHandlerBase.EnsureUnload<DragonGuildShopRecordsHandler>(ref this.m_dragonguildShopRecordsHandler);
			base.OnUnload();
		}

		// Token: 0x0600CB5A RID: 52058 RVA: 0x002E5358 File Offset: 0x002E3558
		public override void StackRefresh()
		{
			bool flag = this._doc != null;
			if (flag)
			{
				this._doc.ReqGoodsList(this.m_SysShop);
			}
		}

		// Token: 0x0600CB5B RID: 52059 RVA: 0x002E5385 File Offset: 0x002E3585
		public override void LeaveStackTop()
		{
			base.LeaveStackTop();
		}

		// Token: 0x0600CB5C RID: 52060 RVA: 0x002E538F File Offset: 0x002E358F
		public void SetShopType(XSysDefine sys)
		{
			this.m_SysShop = sys;
		}

		// Token: 0x0600CB5D RID: 52061 RVA: 0x002E539C File Offset: 0x002E359C
		public void OnRefreshData()
		{
			this._doc.ReqGoodsList(this.m_SysShop);
			this.m_RefreshLabel.SetText(XSingleton<XStringTable>.singleton.GetString("PartnerShopRefreshTip"));
			this.m_partnerInfoGo.gameObject.SetActive(this.m_SysShop == XSysDefine.XSys_Mall_Partner || this.m_SysShop == XSysDefine.XSys_DragonGuildShop);
			this.m_refreshBtn.ID = (ulong)((long)this.m_SysShop);
			this.RefreshShopInfo();
		}

		// Token: 0x0600CB5E RID: 52062 RVA: 0x002E541F File Offset: 0x002E361F
		public void SetRefreshedTime(int times)
		{
			this.m_RefreshedTime = times;
		}

		// Token: 0x0600CB5F RID: 52063 RVA: 0x002E542C File Offset: 0x002E362C
		private void RefreshShopInfo()
		{
			ShopTypeTable.RowData shopTypeData = this._doc.GetShopTypeData(this.m_SysShop);
			string text = "";
			bool flag = shopTypeData != null;
			if (flag)
			{
				bool flag2 = shopTypeData.ShopCycle == null || shopTypeData.ShopCycle.Length == 0;
				if (flag2)
				{
					this.m_RefreshLabel.SetText("");
				}
				else
				{
					bool flag3 = shopTypeData.ShopCycle.Length == 1 && shopTypeData.ShopCycle[0] == 0U;
					if (flag3)
					{
						this.m_RefreshLabel.SetText("");
					}
					else
					{
						for (int i = 0; i < shopTypeData.ShopCycle.Length; i++)
						{
							int num = (int)(shopTypeData.ShopCycle[i] / 100U);
							int num2 = (int)(shopTypeData.ShopCycle[i] % 100U);
							bool flag4 = i != shopTypeData.ShopCycle.Length - 1;
							if (flag4)
							{
								text += string.Format("{0:D2}:{1:D2}", num, num2);
							}
							else
							{
								text += string.Format("{0:D2}:{1:D2}", num, num2);
							}
						}
						this.m_RefreshLabel.SetText(string.Format(XStringDefineProxy.GetString("SHOP_REFRESH_TIME"), text));
					}
				}
				bool flag5 = shopTypeData.RefreshCost.Count == 0;
				if (flag5)
				{
					this.m_RefreshBtn.SetVisible(false);
				}
				else
				{
					this.m_RefreshBtn.SetVisible(true);
				}
			}
			else
			{
				this.m_RefreshBtn.SetVisible(false);
			}
			this.m_ShopItemPool.ReturnAll(false);
			DlgBase<MallSystemDlg, MallSystemBehaviour>.singleton.SetSys = this.m_SysShop;
			XMainInterfaceDocument specificDocument = XDocuments.GetSpecificDocument<XMainInterfaceDocument>(XMainInterfaceDocument.uuID);
			specificDocument.OnTopUIRefreshed(DlgBase<MallSystemDlg, MallSystemBehaviour>.singleton);
		}

		// Token: 0x0600CB60 RID: 52064 RVA: 0x002E55F0 File Offset: 0x002E37F0
		public void RefreshGoodsList()
		{
			List<XNormalShopGoods> goodsList = this._doc.GoodsList;
			this.m_ShopItemPool.ReturnAll(false);
			this.m_ShopItemList.Clear();
			int num = 0;
			for (int i = 0; i < goodsList.Count; i++)
			{
				XNormalShopGoods xnormalShopGoods = goodsList[i];
				ShopTable.RowData dataById = XNormalShopDocument.GetDataById((uint)xnormalShopGoods.item.uid);
				bool flag = this.CheckGoodsShowing(dataById);
				if (flag)
				{
					GameObject showProductGo = this.GetShowProductGo();
					IXUIButton ixuibutton = showProductGo.transform.FindChild("BtnBuy").GetComponent("XUIButton") as IXUIButton;
					IXUISprite ixuisprite = showProductGo.transform.FindChild("Item/Icon").GetComponent("XUISprite") as IXUISprite;
					ixuibutton.ID = (ulong)((long)i);
					ixuisprite.ID = (ulong)((long)i);
					ixuibutton.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnItemBuyClicked));
					ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnItemIconClicked));
					ixuibutton.SetAudioClip("");
					this.UpdateGoodsInfo(xnormalShopGoods, showProductGo);
					showProductGo.transform.localPosition = new Vector3(this.m_ShopItemPool.TplPos.x + (float)(num % 2 * this.m_ShopItemPool.TplWidth), this.m_ShopItemPool.TplPos.y - (float)(num / 2 * this.m_ShopItemPool.TplHeight), this.m_ShopItemPool.TplPos.z);
					num++;
				}
			}
			this.m_ScrollView.ResetPosition();
		}

		// Token: 0x0600CB61 RID: 52065 RVA: 0x002E5788 File Offset: 0x002E3988
		protected virtual bool CheckGoodsShowing(ShopTable.RowData shopGoods)
		{
			bool flag = shopGoods == null;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				bool flag2 = this.m_SysShop != XSysDefine.XSys_Mall_Partner;
				if (flag2)
				{
					bool flag3 = shopGoods.LevelShow[0] != 0U || shopGoods.LevelShow[1] > 0U;
					if (flag3)
					{
						bool flag4 = XSingleton<XAttributeMgr>.singleton.XPlayerData.Level < shopGoods.LevelShow[0] || XSingleton<XAttributeMgr>.singleton.XPlayerData.Level > shopGoods.LevelShow[1];
						if (flag4)
						{
							return false;
						}
					}
				}
				result = true;
			}
			return result;
		}

		// Token: 0x0600CB62 RID: 52066 RVA: 0x002E5830 File Offset: 0x002E3A30
		private GameObject GetShowProductGo()
		{
			GameObject gameObject = this.m_ShopItemPool.FetchGameObject(false);
			this.m_ShopItemList.Add(gameObject);
			return gameObject;
		}

		// Token: 0x0600CB63 RID: 52067 RVA: 0x002E5860 File Offset: 0x002E3A60
		private void UpdateGoodsInfo(XNormalShopGoods goods, GameObject shopItem)
		{
			XSingleton<XItemDrawerMgr>.singleton.DrawItem(shopItem.transform.FindChild("Item").gameObject, goods.item);
			IXUILabel ixuilabel = shopItem.transform.FindChild("MoneyCost").GetComponent("XUILabel") as IXUILabel;
			IXUISprite ixuisprite = shopItem.transform.FindChild("MoneyCost/Icon").GetComponent("XUISprite") as IXUISprite;
			IXUISprite ixuisprite2 = shopItem.transform.FindChild("Cover").GetComponent("XUISprite") as IXUISprite;
			IXUIButton ixuibutton = shopItem.transform.FindChild("BtnBuy").GetComponent("XUIButton") as IXUIButton;
			IXUISprite ixuisprite3 = shopItem.transform.GetComponent("XUISprite") as IXUISprite;
			ixuisprite3.ID = goods.item.uid;
			IXUISprite ixuisprite4 = shopItem.transform.FindChild("Item/limit").GetComponent("XUISprite") as IXUISprite;
			IXUILabel ixuilabel2 = shopItem.transform.FindChild("Item/limit/num").GetComponent("XUILabel") as IXUILabel;
			IXUISprite ixuisprite5 = shopItem.transform.FindChild("sale").GetComponent("XUISprite") as IXUISprite;
			ixuisprite5.SetVisible(false);
			IXUILabel ixuilabel3 = shopItem.transform.FindChild("sale/T").GetComponent("XUILabel") as IXUILabel;
			IXUISprite ixuisprite6 = shopItem.transform.FindChild("sale2").GetComponent("XUISprite") as IXUISprite;
			ixuisprite6.SetVisible(false);
			IXUISprite ixuisprite7 = shopItem.transform.FindChild("sale3").GetComponent("XUISprite") as IXUISprite;
			ixuisprite7.SetVisible(false);
			IXUISprite ixuisprite8 = shopItem.transform.FindChild("Item/limit1").GetComponent("XUISprite") as IXUISprite;
			ixuisprite8.SetVisible(false);
			IXUILabel ixuilabel4 = shopItem.transform.FindChild("Item/limit1/num").GetComponent("XUILabel") as IXUILabel;
			IXUILabel ixuilabel5 = shopItem.transform.FindChild("T1").GetComponent("XUILabel") as IXUILabel;
			ixuilabel5.SetVisible(false);
			IXUILabel ixuilabel6 = shopItem.transform.FindChild("T2").GetComponent("XUILabel") as IXUILabel;
			ixuilabel6.SetVisible(false);
			IXUILabel ixuilabel7 = shopItem.transform.FindChild("T3").GetComponent("XUILabel") as IXUILabel;
			ixuilabel7.SetVisible(false);
			ShopTable.RowData dataById = XNormalShopDocument.GetDataById((uint)goods.item.uid);
			ixuilabel.SetText(goods.priceValue.ToString());
			bool flag = dataById.Benefit[0] == 1U;
			if (flag)
			{
				ixuisprite6.SetVisible(true);
			}
			else
			{
				bool flag2 = dataById.Benefit[0] == 2U;
				if (flag2)
				{
					ixuisprite8.SetVisible(true);
					ixuilabel5.SetVisible(true);
					ixuilabel5.SetText("[s]" + goods.priceValue.ToString());
					uint num = dataById.Benefit[1];
					bool flag3 = num % 10U == 0U;
					if (flag3)
					{
						num = dataById.Benefit[1] / 10U;
					}
					ixuilabel4.SetText("[b]" + num.ToString());
					ixuilabel.SetText(((int)((long)goods.priceValue * (long)((ulong)dataById.Benefit[1])) / 100).ToString());
				}
			}
			ShopTable.RowData dataById2 = XNormalShopDocument.GetDataById((uint)goods.item.uid);
			uint dailyCountCondition = (uint)dataById2.DailyCountCondition;
			int weekCountCondition = (int)dataById2.WeekCountCondition;
			int num2 = 0;
			bool flag4 = dataById2.CountCondition > 0U;
			if (flag4)
			{
				num2 = goods.totalSoldNum;
			}
			else
			{
				bool flag5 = dailyCountCondition > 0U;
				if (flag5)
				{
					num2 = goods.soldNum;
				}
				else
				{
					bool flag6 = weekCountCondition != 0;
					if (flag6)
					{
						num2 = (int)goods.weeklyBuyCount;
					}
				}
			}
			int countCondition = (int)dataById2.CountCondition;
			bool flag7 = dailyCountCondition == 0U && countCondition == 0 && weekCountCondition == 0;
			if (flag7)
			{
				ixuisprite4.SetVisible(false);
				ixuisprite2.SetVisible(false);
				ixuibutton.SetEnable(true, false);
			}
			else
			{
				bool flag8 = countCondition != 0;
				if (flag8)
				{
					bool flag9 = num2 >= countCondition;
					if (flag9)
					{
						ixuibutton.SetEnable(false, false);
						ixuisprite2.SetVisible(true);
					}
					else
					{
						ixuibutton.SetEnable(true, false);
						ixuisprite2.SetVisible(false);
					}
				}
				else
				{
					bool flag10 = dailyCountCondition != 0U && (long)num2 >= (long)((ulong)dailyCountCondition);
					if (flag10)
					{
						ixuibutton.SetEnable(false, false);
						ixuisprite2.SetVisible(true);
					}
					else
					{
						bool flag11 = weekCountCondition != 0 && num2 >= weekCountCondition;
						if (flag11)
						{
							ixuibutton.SetEnable(false, false);
							ixuisprite2.SetVisible(false);
						}
						else
						{
							ixuibutton.SetEnable(true, false);
							ixuisprite2.SetVisible(false);
						}
					}
				}
				ixuisprite4.SetVisible(false);
				ixuilabel2.SetVisible(false);
				ixuilabel6.SetVisible(true);
				bool flag12 = countCondition != 0;
				if (flag12)
				{
					ixuilabel6.SetText(string.Format(XStringDefineProxy.GetString("SHOP_TOTAL_CAN_BUY"), ((countCondition - num2 > 0) ? (countCondition - num2) : 0).ToString()));
				}
				else
				{
					bool flag13 = dailyCountCondition > 0U;
					if (flag13)
					{
						ixuilabel6.SetText(string.Format(XStringDefineProxy.GetString("SHOP_TODAY_CAN_BUY"), ((long)(((ulong)dailyCountCondition - (ulong)((long)num2) > 0UL) ? ((ulong)dailyCountCondition - (ulong)((long)num2)) : 0UL)).ToString()));
					}
					else
					{
						bool flag14 = weekCountCondition != 0;
						if (flag14)
						{
							ixuilabel6.SetText(string.Format(XStringDefineProxy.GetString("SHOP_Weekly_CAN_BUY"), ((weekCountCondition - num2 > 0) ? (weekCountCondition - num2) : 0).ToString()));
						}
					}
				}
			}
			string itemSmallIcon = XBagDocument.GetItemSmallIcon(goods.priceType, 0U);
			ixuisprite.SetSprite(itemSmallIcon);
		}

		// Token: 0x0600CB64 RID: 52068 RVA: 0x002E5E38 File Offset: 0x002E4038
		private void OnItemIconClicked(IXUISprite iSp)
		{
			List<XNormalShopGoods> goodsList = this._doc.GoodsList;
			bool flag = goodsList.Count <= (int)iSp.ID;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddErrorLog("goodsList.Count <= (int)iSp.ID", null, null, null, null, null);
			}
			else
			{
				XNormalShopGoods xnormalShopGoods = goodsList[(int)iSp.ID];
				XItem mainItem = XBagDocument.MakeXItem(xnormalShopGoods.item.itemID, false);
				XSingleton<UiUtility>.singleton.ShowTooltipDialogWithSearchingCompare(mainItem, iSp, false, 0U);
			}
		}

		// Token: 0x0600CB65 RID: 52069 RVA: 0x002E5EB0 File Offset: 0x002E40B0
		public void UpdateShopItemInfo(XNormalShopGoods item)
		{
			for (int i = 0; i < this.m_ShopItemList.Count; i++)
			{
				IXUISprite ixuisprite = this.m_ShopItemList[i].transform.GetComponent("XUISprite") as IXUISprite;
				bool flag = ixuisprite.ID == item.item.uid;
				if (flag)
				{
					this.UpdateGoodsInfo(item, this.m_ShopItemList[i]);
					break;
				}
			}
		}

		// Token: 0x0600CB66 RID: 52070 RVA: 0x002E5F2C File Offset: 0x002E412C
		private bool OnItemBuyClicked(IXUIButton btn)
		{
			this._doc.ReqBuyPanel((int)btn.ID);
			return true;
		}

		// Token: 0x0600CB67 RID: 52071 RVA: 0x002E5F54 File Offset: 0x002E4154
		private uint GetRefreshCost()
		{
			ShopTypeTable.RowData shopTypeData = this._doc.GetShopTypeData(this.m_SysShop);
			bool flag = shopTypeData == null;
			uint result;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddErrorLog(string.Format("ShopTypeTable not find this systenId = {0}", this.m_SysShop), null, null, null, null, null);
				result = 0U;
			}
			else
			{
				uint rereshCount = this._doc.RereshCount;
				bool flag2 = (ulong)rereshCount < (ulong)((long)shopTypeData.RefreshCost.Count);
				if (flag2)
				{
					result = shopTypeData.RefreshCost[(int)rereshCount, 1];
				}
				else
				{
					result = shopTypeData.RefreshCost[shopTypeData.RefreshCost.Count - 1, 1];
				}
			}
			return result;
		}

		// Token: 0x0600CB68 RID: 52072 RVA: 0x002E5FF8 File Offset: 0x002E41F8
		private string GetMoneyName()
		{
			ShopTypeTable.RowData shopTypeData = this._doc.GetShopTypeData(this.m_SysShop);
			bool flag = shopTypeData == null;
			string result;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddErrorLog(string.Format("ShopTypeTable not find this systenId = {0}", this.m_SysShop), null, null, null, null, null);
				result = "";
			}
			else
			{
				bool flag2 = (ulong)this._doc.RereshCount < (ulong)((long)shopTypeData.RefreshCost.Count);
				uint itemID;
				if (flag2)
				{
					itemID = shopTypeData.RefreshCost[(int)this._doc.RereshCount, 0];
				}
				else
				{
					itemID = shopTypeData.RefreshCost[shopTypeData.RefreshCost.Count - 1, 0];
				}
				ItemList.RowData itemConf = XBagDocument.GetItemConf((int)itemID);
				result = itemConf.ItemName[0];
			}
			return result;
		}

		// Token: 0x0600CB69 RID: 52073 RVA: 0x002E60BC File Offset: 0x002E42BC
		private bool OnRefreshShop(IXUIButton btn)
		{
			string label = string.Format(XStringDefineProxy.GetString("NORMALSHOP_REFRESH"), this.GetRefreshCost().ToString(), this.GetMoneyName());
			XSingleton<UiUtility>.singleton.ShowModalDialog(label, XStringDefineProxy.GetString("COMMON_OK"), XStringDefineProxy.GetString("COMMON_CANCEL"), new ButtonClickEventHandler(this.DoRefreshShop));
			return true;
		}

		// Token: 0x0600CB6A RID: 52074 RVA: 0x002E6120 File Offset: 0x002E4320
		private bool OnClickrRecordBtn(IXUIButton btn)
		{
			XSysDefine xsysDefine = (XSysDefine)btn.ID;
			XSysDefine xsysDefine2 = xsysDefine;
			bool result;
			if (xsysDefine2 != XSysDefine.XSys_Mall_Partner)
			{
				if (xsysDefine2 != XSysDefine.XSys_DragonGuildShop)
				{
					XSingleton<XDebug>.singleton.AddErrorLog("ThisButton is not correct init", null, null, null, null, null);
					result = false;
				}
				else
				{
					this.m_dragonguildShopRecordsHandler.SetVisible(true);
					result = true;
				}
			}
			else
			{
				this.m_partnerShopRecordsHandler.SetVisible(true);
				result = true;
			}
			return result;
		}

		// Token: 0x0600CB6B RID: 52075 RVA: 0x002E6188 File Offset: 0x002E4388
		private bool DoRefreshShop(IXUIButton btn)
		{
			bool flag = !this._doc.IsMoneyOrItemEnough(7, (int)this.GetRefreshCost());
			bool result;
			if (flag)
			{
				this._doc.ProcessItemOrMoneyNotEnough(7);
				result = false;
			}
			else
			{
				RpcC2G_QueryShopItem rpcC2G_QueryShopItem = new RpcC2G_QueryShopItem();
				rpcC2G_QueryShopItem.oArg.isrefresh = true;
				rpcC2G_QueryShopItem.oArg.type = this._doc.GetShopId(this.m_SysShop);
				XSingleton<XClientNetwork>.singleton.Send(rpcC2G_QueryShopItem);
				XSingleton<UiUtility>.singleton.CloseModalDlg();
				result = true;
			}
			return result;
		}

		// Token: 0x0600CB6C RID: 52076 RVA: 0x002E6210 File Offset: 0x002E4410
		protected override void OnHide()
		{
			bool flag = DlgBase<HomeFishingDlg, HomeFishingBehaviour>.singleton.IsVisible();
			if (flag)
			{
				DlgBase<HomeFishingDlg, HomeFishingBehaviour>.singleton.Refresh(false);
				DlgBase<XChatSmallView, XChatSmallBehaviour>.singleton.SetVisible(true, true);
			}
			XNormalShopDocument.ShopDoc.ToSelectShopItemID = 0UL;
			base.OnHide();
		}

		// Token: 0x040059EE RID: 23022
		protected XUIPool m_ShopItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x040059EF RID: 23023
		protected List<GameObject> m_ShopItemList = new List<GameObject>();

		// Token: 0x040059F0 RID: 23024
		private XNormalShopDocument _doc = null;

		// Token: 0x040059F1 RID: 23025
		public XSysDefine m_SysShop = XSysDefine.XSys_Mall_Mall;

		// Token: 0x040059F2 RID: 23026
		public IXUIScrollView m_ScrollView;

		// Token: 0x040059F3 RID: 23027
		private IXUIButton m_RefreshBtn;

		// Token: 0x040059F4 RID: 23028
		private int m_RefreshedTime = 0;

		// Token: 0x040059F5 RID: 23029
		private IXUILabel m_RefreshLabel;

		// Token: 0x040059F6 RID: 23030
		private GameObject m_partnerInfoGo;

		// Token: 0x040059F7 RID: 23031
		private IXUIButton m_refreshBtn;

		// Token: 0x040059F8 RID: 23032
		private IXUILabel m_refreshTipLab;

		// Token: 0x040059F9 RID: 23033
		private PartnerShopRecordsHandler m_partnerShopRecordsHandler;

		// Token: 0x040059FA RID: 23034
		private DragonGuildShopRecordsHandler m_dragonguildShopRecordsHandler;
	}
}
