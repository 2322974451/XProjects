using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XNormalShopDocument : XDocComponent
	{

		public override uint ID
		{
			get
			{
				return XNormalShopDocument.uuID;
			}
		}

		public static XNormalShopDocument ShopDoc
		{
			get
			{
				return XDocuments.GetSpecificDocument<XNormalShopDocument>(XNormalShopDocument.uuID);
			}
		}

		public List<XNormalShopGoods> GoodsList
		{
			get
			{
				return this.m_goodsList;
			}
		}

		public XNormalShopView View
		{
			get
			{
				return (!this.IsTabShop(this.m_curSysType)) ? DlgBase<MallSystemDlg, MallSystemBehaviour>.singleton._NormalShopView : DlgBase<MallSystemDlg, MallSystemBehaviour>.singleton._TabCategoryHandler;
			}
		}

		public XShopPurchaseView PurchaseView
		{
			get
			{
				return this._purchase;
			}
			set
			{
				this._purchase = value;
			}
		}

		public uint RereshCount
		{
			get
			{
				return this._refresh_count;
			}
		}

		public static void Execute(OnLoadedCallback callback = null)
		{
			XNormalShopDocument.AsyncLoader.AddTask("Table/ShopType", XNormalShopDocument._shoptable, false);
			XNormalShopDocument.AsyncLoader.AddTask("Table/Shop", XNormalShopDocument._shop, false);
			XNormalShopDocument.AsyncLoader.Execute(null);
		}

		protected override void EventSubscribe()
		{
			base.EventSubscribe();
		}

		public override void OnDetachFromHost()
		{
			this.isRedPointSend = false;
		}

		public override void OnEnterSceneFinally()
		{
			base.OnEnterSceneFinally();
			bool flag = XSingleton<XGame>.singleton.CurrentStage.Stage == EXStage.Hall && !this.isRedPointSend;
			if (flag)
			{
				this.ReqGoodsList(XSysDefine.XSys_Mall_Honer);
				this.isRedPointSend = true;
			}
		}

		public List<int> GetTabListOfShop(XSysDefine sys)
		{
			List<int> list = new List<int>();
			uint shopId = this.GetShopId(sys);
			for (int i = 0; i < XNormalShopDocument._shop.Table.Length; i++)
			{
				bool flag = XNormalShopDocument._shop.Table[i].Type == shopId && !list.Contains((int)XNormalShopDocument._shop.Table[i].ShopItemType);
				if (flag)
				{
					list.Add((int)XNormalShopDocument._shop.Table[i].ShopItemType);
				}
			}
			return list;
		}

		public static uint GetLimitNumByShopId(uint shopid)
		{
			for (int i = 0; i < XNormalShopDocument._shop.Table.Length; i++)
			{
				bool flag = XNormalShopDocument._shop.Table[i].ID == shopid;
				if (flag)
				{
					return (uint)XNormalShopDocument._shop.Table[i].DailyCountCondition;
				}
			}
			return 0U;
		}

		public static ShopTable.RowData GetDataByShopId(uint shopid)
		{
			for (int i = 0; i < XNormalShopDocument._shop.Table.Length; i++)
			{
				bool flag = XNormalShopDocument._shop.Table[i].ItemId == shopid;
				if (flag)
				{
					return XNormalShopDocument._shop.Table[i];
				}
			}
			return null;
		}

		public static ShopTable.RowData GetDataById(uint id)
		{
			for (int i = 0; i < XNormalShopDocument._shop.Table.Length; i++)
			{
				bool flag = XNormalShopDocument._shop.Table[i].ID == id;
				if (flag)
				{
					return XNormalShopDocument._shop.Table[i];
				}
			}
			return null;
		}

		public static ShopTable.RowData GetDataByItemId(uint id)
		{
			for (int i = 0; i < XNormalShopDocument._shop.Table.Length; i++)
			{
				bool flag = XNormalShopDocument._shop.Table[i].ItemId == id;
				if (flag)
				{
					return XNormalShopDocument._shop.Table[i];
				}
			}
			return null;
		}

		public uint GetShopId(XSysDefine shop)
		{
			ShopTypeTable.RowData shopTypeData = this.GetShopTypeData(shop);
			bool flag = shopTypeData == null;
			uint result;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddErrorLog(string.Format("ShopTypeTable not find this SysId = {0}", shop), null, null, null, null, null);
				result = 0U;
			}
			else
			{
				result = shopTypeData.ShopID;
			}
			return result;
		}

		public int GetShopViewDefaultTab()
		{
			int result = 0;
			bool flag = this.ToSelectShopItemID > 0UL;
			if (flag)
			{
				ShopTable.RowData dataByItemId = XNormalShopDocument.GetDataByItemId((uint)this.ToSelectShopItemID);
				bool flag2 = dataByItemId != null;
				if (flag2)
				{
					return (int)dataByItemId.ShopItemType;
				}
			}
			return result;
		}

		public bool CanBuyPreciousShopItem()
		{
			for (int i = 0; i < this.m_goodsList.Count; i++)
			{
				XNormalShopGoods xnormalShopGoods = this.m_goodsList[i];
				ShopTable.RowData dataById = XNormalShopDocument.GetDataById((uint)xnormalShopGoods.item.uid);
				bool flag = dataById != null && dataById.IsPrecious;
				if (flag)
				{
					uint dailyCountCondition = (uint)dataById.DailyCountCondition;
					int weekCountCondition = (int)dataById.WeekCountCondition;
					int num = 0;
					bool flag2 = dataById.CountCondition > 0U;
					if (flag2)
					{
						num = xnormalShopGoods.totalSoldNum;
					}
					else
					{
						bool flag3 = dailyCountCondition > 0U;
						if (flag3)
						{
							num = xnormalShopGoods.soldNum;
						}
						else
						{
							bool flag4 = weekCountCondition != 0;
							if (flag4)
							{
								num = (int)xnormalShopGoods.weeklyBuyCount;
							}
						}
					}
					int countCondition = (int)dataById.CountCondition;
					bool flag5 = dailyCountCondition == 0U && countCondition == 0 && weekCountCondition == 0;
					if (!flag5)
					{
						bool flag6 = countCondition != 0;
						bool result;
						if (flag6)
						{
							bool flag7 = num >= countCondition;
							if (flag7)
							{
								goto IL_111;
							}
							result = true;
						}
						else
						{
							bool flag8 = dailyCountCondition != 0U && (long)num >= (long)((ulong)dailyCountCondition);
							if (flag8)
							{
								goto IL_111;
							}
							bool flag9 = weekCountCondition != 0 && num >= weekCountCondition;
							if (flag9)
							{
								goto IL_111;
							}
							result = true;
						}
						return result;
					}
				}
				IL_111:;
			}
			return false;
		}

		public List<List<uint>> GetShopItemByPlayLevelAndShopType(XSysDefine shop)
		{
			List<uint> item = new List<uint>();
			List<uint> item2 = new List<uint>();
			List<uint> item3 = new List<uint>();
			List<List<uint>> list = new List<List<uint>>
			{
				item,
				item2,
				item3
			};
			uint shopId = this.GetShopId(shop);
			bool flag = shopId > 0U;
			if (flag)
			{
				for (int i = 0; i < XNormalShopDocument._shop.Table.Length; i++)
				{
					ShopTable.RowData rowData = XNormalShopDocument._shop.Table[i];
					bool flag2 = rowData.Type == shopId && XSingleton<XAttributeMgr>.singleton.XPlayerData.Level >= rowData.LevelShow[0] && XSingleton<XAttributeMgr>.singleton.XPlayerData.Level <= rowData.LevelShow[1] && rowData.ShopItemCategory >= 1U && rowData.ShopItemCategory <= 3U;
					if (flag2)
					{
						bool flag3 = !list[(int)(rowData.ShopItemCategory - 1U)].Contains(rowData.ItemId);
						if (flag3)
						{
							list[(int)(rowData.ShopItemCategory - 1U)].Add(rowData.ItemId);
						}
					}
				}
			}
			return list;
		}

		public ShopTypeTable.RowData GetShopTypeData(XSysDefine shop)
		{
			return XNormalShopDocument._shoptable.GetBySystemId((uint)XFastEnumIntEqualityComparer<XSysDefine>.ToInt(shop));
		}

		public void ReqGoodsList(XSysDefine sys)
		{
			this.m_curSysType = sys;
			bool flag = sys != XSysDefine.XSys_Mall_Partner && sys != XSysDefine.XSys_DragonGuildShop;
			if (flag)
			{
				RpcC2G_QueryShopItem rpcC2G_QueryShopItem = new RpcC2G_QueryShopItem();
				ShopTypeTable.RowData shopTypeData = this.GetShopTypeData(sys);
				bool flag2 = shopTypeData != null;
				if (flag2)
				{
					rpcC2G_QueryShopItem.oArg.type = shopTypeData.ShopID;
					rpcC2G_QueryShopItem.oArg.isrefresh = false;
				}
				else
				{
					XSingleton<XDebug>.singleton.AddErrorLog("ShopTypeTable not find this sytemId = " + sys, null, null, null, null, null);
				}
				XSingleton<XClientNetwork>.singleton.Send(rpcC2G_QueryShopItem);
			}
			else
			{
				bool flag3 = sys == XSysDefine.XSys_Mall_Partner;
				if (flag3)
				{
					RpcC2M_GetPartnerShop rpc = new RpcC2M_GetPartnerShop();
					XSingleton<XClientNetwork>.singleton.Send(rpc);
				}
				else
				{
					bool flag4 = sys == XSysDefine.XSys_DragonGuildShop;
					if (flag4)
					{
						RpcC2M_GetDragonGuildShop rpc2 = new RpcC2M_GetDragonGuildShop();
						XSingleton<XClientNetwork>.singleton.Send(rpc2);
					}
				}
			}
		}

		public void OnGetGoodsList(QueryShopItemArg oArg, QueryShopItemRes oRes)
		{
			this._refresh_count = oRes.refreshcount;
			this.SetGoodsList(oRes.ShopItem, oArg.type, oRes.cooklevel);
			ShopTypeTable.RowData shopTypeData = this.GetShopTypeData(XSysDefine.XSys_Mall_Card1);
			ShopTypeTable.RowData shopTypeData2 = this.GetShopTypeData(XSysDefine.XSys_Mall_Card2);
			ShopTypeTable.RowData shopTypeData3 = this.GetShopTypeData(XSysDefine.XSys_Mall_Card3);
			ShopTypeTable.RowData shopTypeData4 = this.GetShopTypeData(XSysDefine.XSys_Mall_Card4);
			bool flag = (shopTypeData != null && oArg.type == shopTypeData.ShopID) || (shopTypeData2 != null && oArg.type == shopTypeData2.ShopID) || (shopTypeData3 != null && oArg.type == shopTypeData3.ShopID) || (shopTypeData4 != null && oArg.type == shopTypeData4.ShopID);
			if (flag)
			{
				bool flag2 = DlgBase<CardCollectView, CardCollectBehaviour>.singleton.ShopHandler != null;
				if (flag2)
				{
					DlgBase<CardCollectView, CardCollectBehaviour>.singleton.ShopHandler.SetCardShop(this.GoodsList);
				}
			}
		}

		public bool IsTabShop(XSysDefine sys)
		{
			bool result = false;
			ShopTypeTable.RowData shopTypeData = this.GetShopTypeData(sys);
			bool flag = shopTypeData != null && shopTypeData.IsHasTab == 1;
			if (flag)
			{
				result = true;
			}
			return result;
		}

		public bool IsShop(XSysDefine sys)
		{
			return this.GetShopTypeData(sys) != null;
		}

		public void OnGetGoodsList(GetPartnerShopArg oArg, GetPartnerShopRes oRes)
		{
			bool flag = oRes == null;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(ErrorCode.ERR_FAILED, "fece00");
			}
			else
			{
				this._refresh_count = 0U;
				this.SetGoodsList(oRes.item);
			}
		}

		public void OnGetGoodsList(GetDragonGuildShopArg oArg, GetDragonGuildShopRes oRes)
		{
			bool flag = oRes == null;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(ErrorCode.ERR_FAILED, "fece00");
			}
			else
			{
				this._refresh_count = 0U;
				this.SetGoodsList(oRes.items);
			}
		}

		public void ReqBuy(int index)
		{
			bool flag = index >= this.m_goodsList.Count;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddErrorLog("Item index out of range. ", index.ToString(), null, null, null, null);
			}
			else
			{
				XNormalShopGoods xnormalShopGoods = this.m_goodsList[index];
				ShopTable.RowData dataById = XNormalShopDocument.GetDataById((uint)xnormalShopGoods.item.uid);
				uint itemnum = (dataById == null) ? 1U : dataById.ItemOverlap;
				this.DoBuyItem(xnormalShopGoods, itemnum);
			}
		}

		public void DoBuyItem(XNormalShopGoods goods, uint itemnum)
		{
			bool flag = this.m_curSysType != XSysDefine.XSys_Mall_Partner && this.m_curSysType != XSysDefine.XSys_DragonGuildShop;
			if (flag)
			{
				RpcC2G_BuyShopItem rpcC2G_BuyShopItem = new RpcC2G_BuyShopItem();
				rpcC2G_BuyShopItem.oArg.ItemUniqueId = goods.item.uid;
				rpcC2G_BuyShopItem.oArg.count = itemnum;
				XSingleton<XClientNetwork>.singleton.Send(rpcC2G_BuyShopItem);
			}
			else
			{
				bool flag2 = this.m_curSysType == XSysDefine.XSys_Mall_Partner;
				if (flag2)
				{
					RpcC2M_BuyPartnerShopItem rpcC2M_BuyPartnerShopItem = new RpcC2M_BuyPartnerShopItem();
					rpcC2M_BuyPartnerShopItem.oArg.count = itemnum;
					rpcC2M_BuyPartnerShopItem.oArg.id = (uint)goods.item.uid;
					XSingleton<XClientNetwork>.singleton.Send(rpcC2M_BuyPartnerShopItem);
				}
				else
				{
					bool flag3 = this.m_curSysType == XSysDefine.XSys_DragonGuildShop;
					if (flag3)
					{
						RpcC2M_BuyDragonGuildShopItem rpcC2M_BuyDragonGuildShopItem = new RpcC2M_BuyDragonGuildShopItem();
						rpcC2M_BuyDragonGuildShopItem.oArg.count = itemnum;
						rpcC2M_BuyDragonGuildShopItem.oArg.id = (uint)goods.item.uid;
						XSingleton<XClientNetwork>.singleton.Send(rpcC2M_BuyDragonGuildShopItem);
					}
				}
			}
		}

		public void ReqBuyPanel(int index)
		{
			XNormalShopGoods goods = this.m_goodsList[index];
			DlgBase<MallSystemDlg, MallSystemBehaviour>.singleton.PurchaseView.OnBuyItem(goods);
		}

		public void OnGetBuy(BuyShopItemArg oArg, BuyShopItemRes oRes)
		{
			bool flag = oRes.ErrorCode > ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				for (int i = 0; i < this.m_goodsList.Count; i++)
				{
					bool flag2 = this.m_goodsList[i].item.uid == oArg.ItemUniqueId;
					if (flag2)
					{
						ShopTable.RowData dataById = XNormalShopDocument.GetDataById((uint)this.m_goodsList[i].item.uid);
						ItemList.RowData itemConf = XBagDocument.GetItemConf((int)dataById.ConsumeItem[0]);
						bool flag3 = dataById != null && itemConf != null;
						if (flag3)
						{
							bool flag4 = oRes.ErrorCode == ErrorCode.ERR_SHOP_LEVELLIMIT;
							if (flag4)
							{
								XSingleton<UiUtility>.singleton.ShowSystemTip(string.Format(XStringDefineProxy.GetString(oRes.ErrorCode), dataById.LevelCondition), "fece00");
								return;
							}
							bool flag5 = oRes.ErrorCode == ErrorCode.ERR_ITEM_NOT_ENOUGH;
							if (flag5)
							{
								string itemQualityRGB = XSingleton<UiUtility>.singleton.GetItemQualityRGB((int)itemConf.ItemQuality);
								string arg = string.Concat(new string[]
								{
									"[",
									itemQualityRGB,
									"]",
									itemConf.ItemName[0],
									"[-]"
								});
								XSingleton<UiUtility>.singleton.ShowSystemTip(string.Format(XStringDefineProxy.GetString("ERR_NOT_ENOUGH"), arg), "fece00");
								return;
							}
						}
					}
				}
				XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.ErrorCode, "fece00");
			}
			else
			{
				this.RefreshShopData(oArg.ItemUniqueId, oArg.count);
				bool flag6 = DlgBase<CardCollectView, CardCollectBehaviour>.singleton.CurPage == CardPage.CardShop && DlgBase<CardCollectView, CardCollectBehaviour>.singleton.ShopHandler != null;
				if (flag6)
				{
					DlgBase<CardCollectView, CardCollectBehaviour>.singleton.ShopHandler.RefreshChipNum();
				}
			}
		}

		public void OnGetBuy(BuyPartnerShopItemArg oArg, BuyPartnerShopItemRes oRes)
		{
			bool flag = oRes == null;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(ErrorCode.ERR_FAILED, "fece00");
			}
			else
			{
				bool flag2 = oRes.result > ErrorCode.ERR_SUCCESS;
				if (flag2)
				{
					ErrorCode result = oRes.result;
					if (result != ErrorCode.ERR_PARTNER_LN_NOT_ENOUGH)
					{
						if (result - ErrorCode.ERR_PARTNER_ITEM_NOT_FOUND > 2)
						{
							XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.result, "fece00");
						}
						else
						{
							this.ReqGoodsList(XSysDefine.XSys_Mall_Partner);
							XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.result, "fece00");
						}
					}
					else
					{
						ShopTable.RowData dataById = XNormalShopDocument.GetDataById(oArg.id);
						bool flag3 = dataById != null;
						if (flag3)
						{
							XSingleton<UiUtility>.singleton.ShowSystemTip(string.Format(XSingleton<XStringTable>.singleton.GetString("ERR_PARTNER_LEVEL_NOT_ENOUGH"), dataById.LevelCondition), "fece00");
						}
					}
				}
				else
				{
					this.RefreshShopData((ulong)oArg.id, oArg.count);
				}
			}
		}

		public void OnGetBuy(BuyDragonGuildShopItemArg oArg, BuyDragonGuildShopItemRes oRes)
		{
			bool flag = oRes == null;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(ErrorCode.ERR_FAILED, "fece00");
			}
			else
			{
				bool flag2 = oRes.result > ErrorCode.ERR_SUCCESS;
				if (flag2)
				{
					ErrorCode result = oRes.result;
					if (result != ErrorCode.ERR_PARTNER_LN_NOT_ENOUGH)
					{
						if (result - ErrorCode.ERR_PARTNER_ITEM_NOT_FOUND > 2)
						{
							XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.result, "fece00");
						}
						else
						{
							this.ReqGoodsList(XSysDefine.XSys_DragonGuildShop);
							XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.result, "fece00");
						}
					}
					else
					{
						ShopTable.RowData dataById = XNormalShopDocument.GetDataById(oArg.id);
						bool flag3 = dataById != null;
						if (flag3)
						{
							XSingleton<UiUtility>.singleton.ShowSystemTip(string.Format(XSingleton<XStringTable>.singleton.GetString("ERR_PARTNER_LEVEL_NOT_ENOUGH"), dataById.LevelCondition), "fece00");
						}
					}
				}
				else
				{
					this.RefreshShopData((ulong)oArg.id, oArg.count);
				}
			}
		}

		private void RefreshShopData(ulong uid, uint count)
		{
			for (int i = 0; i < this.m_goodsList.Count; i++)
			{
				bool flag = this.m_goodsList[i].item.uid == uid;
				if (flag)
				{
					this.m_goodsList[i].soldNum += (int)count;
					this.m_goodsList[i].totalSoldNum += (int)count;
					this.m_goodsList[i].weeklyBuyCount += count;
					bool flag2 = this.View != null && this.View.IsVisible();
					if (flag2)
					{
						this.View.UpdateShopItemInfo(this.m_goodsList[i]);
					}
					this.RefreshYyMallView();
					break;
				}
			}
		}

		private void SetGoodsList(List<ShopItem> goodsList, uint type = 0U, uint cooklevel = 0U)
		{
			this.m_goodsList.Clear();
			int num = 0;
			bool flag = goodsList != null;
			if (flag)
			{
				ShopTypeTable.RowData shopTypeData = this.GetShopTypeData(XSysDefine.XSys_Mall_Home);
				foreach (ShopItem shopItem in goodsList)
				{
					bool flag2 = shopTypeData != null && shopTypeData.ShopID == type;
					if (flag2)
					{
						ShopTable.RowData dataById = XNormalShopDocument.GetDataById((uint)shopItem.Item.uid);
						bool flag3 = cooklevel < (uint)dataById.CookLevel;
						if (flag3)
						{
							continue;
						}
					}
					this.m_goodsList.Add(XNormalShopGoods.MakeGoodsFromData(shopItem));
					num++;
				}
			}
			this.RefreshYyMallView();
			bool flag4 = this.View != null && this.View.IsVisible();
			if (flag4)
			{
				this.View.RefreshGoodsList();
			}
			else
			{
				ShopTypeTable.RowData shopTypeData2 = this.GetShopTypeData(XSysDefine.XSys_Mall_Honer);
				bool flag5 = shopTypeData2 != null && shopTypeData2.ShopID == type;
				if (flag5)
				{
					foreach (ShopItem shopItem2 in goodsList)
					{
						ShopTable.RowData dataById2 = XNormalShopDocument.GetDataById((uint)shopItem2.Item.uid);
						bool flag6 = shopItem2.Item.uid == XNormalShopDocument.HONER_BOX_ID && dataById2 != null;
						if (flag6)
						{
							bool flag7 = XBagDocument.BagDoc.GetItemCount(XFastEnumIntEqualityComparer<ItemEnum>.ToInt(ItemEnum.HORNOR_POINT)) >= XNormalShopDocument.HONER_POINT_SHOW_REDPOINT && (uint)dataById2.DailyCountCondition - shopItem2.dailybuycount > 0U;
							if (flag7)
							{
								XGameMallDocument specificDocument = XDocuments.GetSpecificDocument<XGameMallDocument>(XGameMallDocument.uuID);
								specificDocument.RefreshShopRedPoint(XSysDefine.XSys_Mall_Honer, true);
							}
						}
					}
				}
			}
		}

		private void RefreshYyMallView()
		{
			bool flag = DlgBase<XWelfareView, XWelfareBehaviour>.singleton.IsVisible();
			if (flag)
			{
				DlgHandlerBase dlgHandlerBase;
				DlgBase<XWelfareView, XWelfareBehaviour>.singleton.m_AllHandlers.TryGetValue(XSysDefine.XSys_Welfare_YyMall, out dlgHandlerBase);
				bool flag2 = dlgHandlerBase != null && dlgHandlerBase.IsVisible();
				if (flag2)
				{
					dlgHandlerBase.RefreshData();
				}
			}
		}

		private void SetGoodsList(List<PartnerShopItemClient> goodsList)
		{
			this.m_goodsList.Clear();
			bool flag = goodsList != null;
			if (flag)
			{
				foreach (PartnerShopItemClient data in goodsList)
				{
					this.m_goodsList.Add(XNormalShopGoods.MakeGoodsFromData(data));
				}
			}
			bool flag2 = this.View != null && this.View.IsVisible();
			if (flag2)
			{
				this.View.RefreshGoodsList();
			}
		}

		private void SetGoodsList(List<DragonGuildShopItemClient> goodsList)
		{
			this.m_goodsList.Clear();
			bool flag = goodsList != null;
			if (flag)
			{
				foreach (DragonGuildShopItemClient data in goodsList)
				{
					this.m_goodsList.Add(XNormalShopGoods.MakeGoodsFromData(data));
				}
			}
			bool flag2 = this.View != null && this.View.IsVisible();
			if (flag2)
			{
				this.View.RefreshGoodsList();
			}
		}

		private void SelectDefaultShopItem()
		{
			bool flag = this.ToSelectShopItemID > 0UL && this.m_goodsList.Count > 0;
			if (flag)
			{
				int num = -1;
				for (int i = 0; i < this.m_goodsList.Count; i++)
				{
					bool flag2 = this.m_goodsList[i].item.itemID == (int)this.ToSelectShopItemID;
					if (flag2)
					{
						num = i;
						break;
					}
				}
				bool flag3 = num >= 0;
				if (flag3)
				{
					XNormalShopGoods value = this.m_goodsList[num];
					for (int j = num - 1; j >= 0; j--)
					{
						this.m_goodsList[j + 1] = this.m_goodsList[j];
					}
					this.m_goodsList[0] = value;
				}
			}
		}

		protected bool OnVirtualItemChanged(XEventArgs args)
		{
			XVirtualItemChangedEventArgs xvirtualItemChangedEventArgs = args as XVirtualItemChangedEventArgs;
			bool flag = DlgBase<MallSystemDlg, MallSystemBehaviour>.singleton.IsLoaded() && DlgBase<MallSystemDlg, MallSystemBehaviour>.singleton.IsVisible();
			if (flag)
			{
				DlgBase<MallSystemDlg, MallSystemBehaviour>.singleton.OnVirtualItemChanged(xvirtualItemChangedEventArgs.e, xvirtualItemChangedEventArgs.newValue);
			}
			return true;
		}

		protected bool OnItemNumChanged(XEventArgs args)
		{
			XItemNumChangedEventArgs xitemNumChangedEventArgs = args as XItemNumChangedEventArgs;
			bool flag = DlgBase<MallSystemDlg, MallSystemBehaviour>.singleton.IsLoaded() && DlgBase<MallSystemDlg, MallSystemBehaviour>.singleton.IsVisible();
			if (flag)
			{
				DlgBase<MallSystemDlg, MallSystemBehaviour>.singleton.OnItemCountChanged(xitemNumChangedEventArgs.item.itemID, xitemNumChangedEventArgs.item.itemCount);
			}
			return true;
		}

		protected bool OnAddItem(XEventArgs args)
		{
			XAddItemEventArgs xaddItemEventArgs = args as XAddItemEventArgs;
			bool flag = DlgBase<MallSystemDlg, MallSystemBehaviour>.singleton.IsLoaded() && DlgBase<MallSystemDlg, MallSystemBehaviour>.singleton.IsVisible();
			if (flag)
			{
				for (int i = 0; i < xaddItemEventArgs.items.Count; i++)
				{
					DlgBase<MallSystemDlg, MallSystemBehaviour>.singleton.OnItemCountChanged(xaddItemEventArgs.items[i].itemID, xaddItemEventArgs.items[i].itemCount);
				}
			}
			return true;
		}

		protected bool OnRemoveItem(XEventArgs args)
		{
			XRemoveItemEventArgs xremoveItemEventArgs = args as XRemoveItemEventArgs;
			bool flag = DlgBase<MallSystemDlg, MallSystemBehaviour>.singleton.IsLoaded() && DlgBase<MallSystemDlg, MallSystemBehaviour>.singleton.IsVisible();
			if (flag)
			{
				for (int i = 0; i < xremoveItemEventArgs.ids.Count; i++)
				{
					DlgBase<MallSystemDlg, MallSystemBehaviour>.singleton.OnItemCountChanged(xremoveItemEventArgs.ids[i], 0);
				}
			}
			return true;
		}

		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		public bool IsShopAvailable(XSysDefine sys)
		{
			bool flag = !XSingleton<XGameSysMgr>.singleton.IsSystemOpened(sys);
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				int hour = DateTime.Now.Hour;
				int minute = DateTime.Now.Minute;
				bool flag2 = false;
				ShopTypeTable.RowData shopTypeData = this.GetShopTypeData(sys);
				bool flag3 = shopTypeData != null;
				if (flag3)
				{
					for (int i = 0; i < shopTypeData.ShopOpen.Count; i++)
					{
						int num = hour * 100 + minute;
						bool flag4 = (long)num >= (long)((ulong)shopTypeData.ShopOpen[i, 0]) && (long)num <= (long)((ulong)shopTypeData.ShopOpen[i, 1]);
						if (flag4)
						{
							flag2 = true;
						}
					}
				}
				result = flag2;
			}
			return result;
		}

		public bool IsExchangeMoney(int itemid)
		{
			return itemid == 1 || itemid == 7 || itemid == 88;
		}

		public bool IsMoneyOrItemEnough(int itemid, int reqnum)
		{
			ulong itemCount = XSingleton<XGame>.singleton.Doc.XBagDoc.GetItemCount(itemid);
			bool flag = reqnum > (int)itemCount;
			return !flag;
		}

		public void ProcessItemOrMoneyNotEnough(int itemid)
		{
			ItemList.RowData itemConf = XBagDocument.GetItemConf(itemid);
			bool flag = itemConf != null;
			if (flag)
			{
				string itemQualityRGB = XSingleton<UiUtility>.singleton.GetItemQualityRGB((int)itemConf.ItemQuality);
				string arg = string.Concat(new string[]
				{
					"[",
					itemQualityRGB,
					"]",
					itemConf.ItemName[0],
					"[-]"
				});
				XSingleton<UiUtility>.singleton.ShowSystemTip(string.Format(XStringDefineProxy.GetString("ERR_NOT_ENOUGH"), arg), "fece00");
			}
			bool flag2 = itemid == 88;
			if (flag2)
			{
				XSingleton<UiUtility>.singleton.ShowItemAccess(itemid, null);
			}
			else
			{
				DlgBase<XPurchaseView, XPurchaseBehaviour>.singleton.ShowBorad((ItemEnum)itemid);
			}
		}

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("NormalShopDocument");

		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		private List<XNormalShopGoods> m_goodsList = new List<XNormalShopGoods>();

		private XShopPurchaseView _purchase = null;

		private static ShopTypeTable _shoptable = new ShopTypeTable();

		private static ShopTable _shop = new ShopTable();

		private uint _refresh_count = 0U;

		private bool isRedPointSend = false;

		private static ulong HONER_BOX_ID = 301UL;

		private static ulong HONER_POINT_SHOW_REDPOINT = 150UL;

		public ulong ToSelectShopItemID = 0UL;

		private XSysDefine m_curSysType = XSysDefine.XSys_None;
	}
}
