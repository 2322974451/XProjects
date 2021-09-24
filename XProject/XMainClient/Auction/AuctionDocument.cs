using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class AuctionDocument : XDocComponent
	{

		public override uint ID
		{
			get
			{
				return AuctionDocument.uuID;
			}
		}

		public static void Execute(OnLoadedCallback callback = null)
		{
			AuctionDocument.AsyncLoader.AddTask("Table/AuctionList", AuctionDocument._auction_type_list, false);
			AuctionDocument.AsyncLoader.AddTask("Table/AuctionDiscount", AuctionDocument.m_auctionDiscountTable, false);
			AuctionDocument.AsyncLoader.Execute(callback);
			AuctionDocument.m_NodeChildren.Clear();
			AuctionDocument.m_auctionTypeParent.Clear();
			AuctionDocument.m_auctionDiscounts.Clear();
		}

		public static void OnTableLoaded()
		{
			AuctionDocument.m_auctionTypeParent.Clear();
			int i = 0;
			int num = AuctionDocument._auction_type_list.Table.Length;
			while (i < num)
			{
				bool flag = !AuctionDocument.m_auctionTypeParent.ContainsKey(AuctionDocument._auction_type_list.Table[i].id);
				if (flag)
				{
					AuctionDocument.m_auctionTypeParent.Add(AuctionDocument._auction_type_list.Table[i].id, AuctionDocument._auction_type_list.Table[i].pretype);
				}
				bool flag2 = AuctionDocument._auction_type_list.Table[i].pretype == 0;
				if (!flag2)
				{
					List<int> list;
					bool flag3 = !AuctionDocument.m_NodeChildren.TryGetValue(AuctionDocument._auction_type_list.Table[i].pretype, out list);
					if (flag3)
					{
						list = new List<int>();
						AuctionDocument.m_NodeChildren.Add(AuctionDocument._auction_type_list.Table[i].pretype, list);
					}
					list.Add(AuctionDocument._auction_type_list.Table[i].id);
				}
				i++;
			}
			AuctionDocument.m_auctionDiscounts.Clear();
			i = 0;
			num = AuctionDocument.m_auctionDiscountTable.Table.Length;
			while (i < num)
			{
				Dictionary<uint, float> dictionary;
				bool flag4 = !AuctionDocument.m_auctionDiscounts.TryGetValue(AuctionDocument.m_auctionDiscountTable.Table[i].Type, out dictionary);
				if (flag4)
				{
					dictionary = new Dictionary<uint, float>();
					AuctionDocument.m_auctionDiscounts.Add(AuctionDocument.m_auctionDiscountTable.Table[i].Type, dictionary);
				}
				bool flag5 = !dictionary.ContainsKey(AuctionDocument.m_auctionDiscountTable.Table[i].Group);
				if (flag5)
				{
					dictionary.Add(AuctionDocument.m_auctionDiscountTable.Table[i].Group, AuctionDocument.m_auctionDiscountTable.Table[i].Discount);
				}
				else
				{
					XSingleton<XDebug>.singleton.AddErrorLog("Has exsit group  in levelSeal!", AuctionDocument.m_auctionDiscountTable.Table[i].Type.ToString(), AuctionDocument.m_auctionDiscountTable.Table[i].Group.ToString(), null, null, null);
				}
				i++;
			}
		}

		public static bool TryGetAuctionTypeParentID(int typeid, out int parentTypeID)
		{
			return AuctionDocument.m_auctionTypeParent.TryGetValue(typeid, out parentTypeID);
		}

		public static bool TryGetChildren(int preType, out List<int> list)
		{
			return AuctionDocument.m_NodeChildren.TryGetValue(preType, out list);
		}

		public static float GetDiscount(uint group)
		{
			XLevelSealDocument specificDocument = XDocuments.GetSpecificDocument<XLevelSealDocument>(XLevelSealDocument.uuID);
			uint sealType = specificDocument.SealType;
			float num = 1f;
			Dictionary<uint, float> dictionary;
			bool flag = AuctionDocument.m_auctionDiscounts.TryGetValue(sealType, out dictionary) && dictionary.TryGetValue(group, out num);
			float result;
			if (flag)
			{
				result = num;
			}
			else
			{
				result = 1f;
			}
			return result;
		}

		public static T MakeAuctionItem<T>(ulong uid, uint price, Item KKSGItem) where T : AuctionItem, new()
		{
			T t = Activator.CreateInstance<T>();
			t.itemData = XBagDocument.MakeXItem(KKSGItem);
			t.uid = uid;
			t.perprice = price;
			return t;
		}

		public uint NextOutoRefreshTime { get; set; }

		public double NextFreeRefreshTime
		{
			get
			{
				return this.m_NextFreeRefreshTime;
			}
			set
			{
				this.m_NextFreeRefreshTime = value;
			}
		}

		public uint FreeRefreshCount
		{
			get
			{
				return this.m_freeRefreshCount;
			}
		}

		public AuctionBillStyle CurrentSelectStyle { get; set; }

		public XItem CurrentSelectXItem { get; set; }

		public ulong CurrentSelectCurUid { get; set; }

		public bool CurrentSelectRefresh
		{
			get
			{
				return this.m_CurrentSelectRefresh;
			}
			set
			{
				this.m_CurrentSelectRefresh = value;
			}
		}

		public bool ShowItemData
		{
			get
			{
				return this.m_showItemData;
			}
		}

		public override void Update(float fDeltaT)
		{
			base.Update(fDeltaT);
			bool flag = this.m_NextFreeRefreshTime > 0.0;
			if (flag)
			{
				this.m_NextFreeRefreshTime -= (double)fDeltaT;
			}
			else
			{
				this.m_NextFreeRefreshTime = 0.0;
			}
		}

		protected override void EventSubscribe()
		{
			base.EventSubscribe();
			base.RegisterEvent(XEventDefine.XEvent_ItemChangeFinished, new XComponent.XEventHandler(this.OnVirtualItemChanged));
			base.RegisterEvent(XEventDefine.XEvent_VirtualItemChanged, new XComponent.XEventHandler(this.OnVirtualItemChanged));
		}

		private bool OnVirtualItemChanged(XEventArgs e)
		{
			AuctionHouseDocument specificDocument = XDocuments.GetSpecificDocument<AuctionHouseDocument>(AuctionHouseDocument.uuID);
			specificDocument.DataState = GuildAuctReqType.GART_AUCT_GUILD_HISTORY;
			this.RefreshView();
			return true;
		}

		public AuctionTypeList AuctionTypeList
		{
			get
			{
				return AuctionDocument._auction_type_list;
			}
		}

		public List<XItem> GetItemList()
		{
			return XSingleton<XGame>.singleton.Doc.XBagDoc.GetNotBindItemsByType(-1);
		}

		public bool TryGetAuctionBriefCount(uint itemid, out uint count)
		{
			count = 0U;
			AuctItemBrief auctItemBrief;
			bool flag = this.m_aucItemBriefs.TryGetValue(itemid, out auctItemBrief);
			bool result;
			if (flag)
			{
				count = auctItemBrief.count;
				result = true;
			}
			else
			{
				result = false;
			}
			return result;
		}

		public uint GetAuctionBriefCount(uint itemid)
		{
			uint result;
			this.TryGetAuctionBriefCount(itemid, out result);
			return result;
		}

		public bool SubAuctionBrief(uint itemid, uint count)
		{
			AuctItemBrief auctItemBrief;
			bool flag = this.m_aucItemBriefs.TryGetValue(itemid, out auctItemBrief);
			bool result;
			if (flag)
			{
				bool flag2 = auctItemBrief.count > count;
				if (flag2)
				{
					auctItemBrief.count -= count;
				}
				else
				{
					auctItemBrief.count = 0U;
				}
				result = (auctItemBrief.count > 0U);
			}
			else
			{
				result = false;
			}
			return result;
		}

		public bool SetAuctionBrief(uint itemid, uint count)
		{
			AuctItemBrief auctItemBrief;
			bool flag = this.m_aucItemBriefs.TryGetValue(itemid, out auctItemBrief);
			if (flag)
			{
				auctItemBrief.count = count;
			}
			return false;
		}

		public bool TryGetAuctionBriefReferPrice(uint itemid, out uint referPrice)
		{
			return this.m_aucItemReferPrices.TryGetValue(itemid, out referPrice);
		}

		public void SetAuctionBriefReferPrice(uint itemid, uint referPrice)
		{
			bool flag = this.m_aucItemReferPrices.ContainsKey(itemid);
			if (flag)
			{
				this.m_aucItemReferPrices[itemid] = referPrice;
			}
			else
			{
				this.m_aucItemReferPrices.Add(itemid, referPrice);
			}
		}

		public void RequestAuctionAllItemBrief()
		{
			this.SendAuctionRequest(AuctionAllReqType.ART_ALLITEMBRIEF, 0U, 0UL, 0U, 0U, 0UL, 0UL, false);
		}

		public void ResponseAuctionAllItemBrief(AuctionAllReqRes res)
		{
			this.NextOutoRefreshTime = res.autorefreshlefttime;
			this.m_NextFreeRefreshTime = res.freerefreshlefttime;
			List<AuctItemBrief> itembrief = res.itembrief;
			this.m_aucItemBriefs.Clear();
			int i = 0;
			int count = itembrief.Count;
			while (i < count)
			{
				bool flag = this.m_aucItemBriefs.ContainsKey(itembrief[i].itemid);
				if (flag)
				{
					XSingleton<XDebug>.singleton.AddErrorLog("Auction ItemBrief has the same id : ", itembrief[i].itemid.ToString(), null, null, null, null);
				}
				else
				{
					this.m_aucItemBriefs.Add(itembrief[i].itemid, itembrief[i]);
				}
				i++;
			}
		}

		public void RequestAuctionSale(ulong uid, uint itemid, uint itemCount, uint price, bool isTransure = false)
		{
			XRechargeDocument specificDocument = XDocuments.GetSpecificDocument<XRechargeDocument>(XRechargeDocument.uuID);
			uint num = specificDocument.GetCurrentVipPermissions().AuctionOnSaleMax;
			XWelfareDocument specificDocument2 = XDocuments.GetSpecificDocument<XWelfareDocument>(XWelfareDocument.uuID);
			bool flag = specificDocument2.IsOwnMemberPrivilege(MemberPrivilege.KingdomPrivilege_Court);
			if (flag)
			{
				num += (uint)specificDocument2.GetMemberPrivilegeConfig(MemberPrivilege.KingdomPrivilege_Court).AuctionCount;
			}
			bool flag2 = (ulong)num <= (ulong)((long)this.m_onLineSaleItems.Count);
			if (flag2)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("AUCTION_PUTAWAY_FULL"), "fece00");
			}
			else
			{
				bool flag3 = this.CheckGoldFull();
				if (flag3)
				{
					this.SendAuctionRequest(AuctionAllReqType.ART_REQSALE, itemid, uid, itemCount, price, 0UL, 0UL, isTransure);
				}
			}
		}

		public bool CheckGoldFull()
		{
			ulong itemCount = XBagDocument.BagDoc.GetItemCount(XFastEnumIntEqualityComparer<ItemEnum>.ToInt(ItemEnum.GOLD));
			ulong num = ulong.Parse(XSingleton<XGlobalConfig>.singleton.GetValue("AuctOnSaleCostGold"));
			bool flag = itemCount < num;
			bool result;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowErrorCode(ErrorCode.ERR_LACKCOIN);
				result = false;
			}
			else
			{
				result = true;
			}
			return result;
		}

		public void RequestAuctionQuitSale(ulong aucuid)
		{
			this.SendAuctionRequest(AuctionAllReqType.ART_QUITSALE, 0U, 0UL, 0U, 0U, 0UL, aucuid, false);
		}

		public void RequestAcutionReSale(ulong auctuid, uint price)
		{
			XRechargeDocument specificDocument = XDocuments.GetSpecificDocument<XRechargeDocument>(XRechargeDocument.uuID);
			uint num = specificDocument.GetCurrentVipPermissions().AuctionOnSaleMax;
			XWelfareDocument specificDocument2 = XDocuments.GetSpecificDocument<XWelfareDocument>(XWelfareDocument.uuID);
			bool flag = specificDocument2.IsOwnMemberPrivilege(MemberPrivilege.KingdomPrivilege_Court);
			if (flag)
			{
				num += (uint)specificDocument2.GetMemberPrivilegeConfig(MemberPrivilege.KingdomPrivilege_Court).AuctionCount;
			}
			int num2 = 0;
			int i = 0;
			int count = this.m_onLineSaleItems.Count;
			while (i < count)
			{
				bool isOutTime = this.m_onLineSaleItems[i].isOutTime;
				if (!isOutTime)
				{
					num2++;
				}
				i++;
			}
			bool flag2 = (ulong)num <= (ulong)((long)num2);
			if (flag2)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("AUCTION_PUTAWAY_FULL"), "fece00");
			}
			else
			{
				bool flag3 = this.CheckGoldFull();
				if (flag3)
				{
					this.SendAuctionRequest(AuctionAllReqType.ART_RESALE, 0U, 0UL, 0U, price, 0UL, auctuid, false);
				}
			}
			bool flag4 = this.CheckGoldFull();
			if (flag4)
			{
				this.SendAuctionRequest(AuctionAllReqType.ART_RESALE, 0U, 0UL, 0U, price, 0UL, auctuid, false);
			}
		}

		public void RequestAuctionReSale(ulong aucuid, uint price)
		{
		}

		public void SetSendAuctionState(bool state = false)
		{
			this.m_sendAuctionState = state;
		}

		public bool RequestAuctionItemData(uint itemid)
		{
			uint num;
			bool flag = this.TryGetAuctionBriefCount(itemid, out num) && num > 0U;
			bool result;
			if (flag)
			{
				this.SendAuctionRequest(AuctionAllReqType.ART_ITEMDATA, itemid, 0UL, 0U, 0U, 0UL, 0UL, false);
				result = true;
			}
			else
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("AUCTION_NOT_PURCHASE"), "fece00");
				result = false;
			}
			return result;
		}

		public void ResponseAuctionOverlapDatas(List<AuctOverlapData> list)
		{
			this.m_curSelectItems.Clear();
			int i = 0;
			int count = list.Count;
			while (i < count)
			{
				this.m_curSelectItems.Add(AuctionDocument.MakeAuctionItem<AuctionItem>(list[i].overlapid, list[i].perprice, list[i].itemdata));
				i++;
			}
			this.m_curSelectItems.Sort(new Comparison<AuctionItem>(this.SortCompare));
		}

		public List<AuctionItem> GetOverlapItems()
		{
			this.m_showItemData = false;
			return this.m_curSelectItems;
		}

		public void SubOverlapItem(ulong auctuid, uint count)
		{
			int i = 0;
			int count2 = this.m_curSelectItems.Count;
			while (i < count2)
			{
				bool flag = this.m_curSelectItems[i].uid == auctuid;
				if (flag)
				{
					bool flag2 = (long)this.m_curSelectItems[i].itemData.itemCount > (long)((ulong)count);
					if (flag2)
					{
						this.m_curSelectItems[i].itemData.itemCount -= (int)count;
					}
					else
					{
						this.m_curSelectItems.RemoveAt(i);
					}
					break;
				}
				i++;
			}
		}

		public void RequestAuctionMySale()
		{
			this.SendAuctionRequest(AuctionAllReqType.ART_MYSALE, 0U, 0UL, 0U, 0U, 0UL, 0UL, false);
		}

		public void ResponseAuctionSaleData(List<AuctionSaleData> list)
		{
			this.m_onLineSaleItems.Clear();
			int i = 0;
			int count = list.Count;
			while (i < count)
			{
				AuctionSaleItem auctionSaleItem = AuctionDocument.MakeAuctionItem<AuctionSaleItem>(list[i].uid, list[i].perprice, list[i].itemdata);
				auctionSaleItem.duelefttime = list[i].duelefttime;
				this.m_onLineSaleItems.Add(auctionSaleItem);
				i++;
			}
		}

		public void RequestAuctionPriceRecommend(ulong uid, XItem item, AuctionBillStyle style)
		{
			this.CurrentSelectXItem = item;
			this.CurrentSelectStyle = style;
			this.CurrentSelectCurUid = uid;
			this.SendAuctionRequest(AuctionAllReqType.ART_TRADE_PRICE, (uint)item.itemID, 0UL, 0U, 0U, 0UL, 0UL, false);
		}

		public List<AuctionSaleItem> AuctionOnLineSaleList
		{
			get
			{
				return this.m_onLineSaleItems;
			}
		}

		public bool TryGetAuctionSalePrice(ulong uid, out uint price)
		{
			bool flag = uid > 0UL;
			if (flag)
			{
				int i = 0;
				int count = this.m_onLineSaleItems.Count;
				while (i < count)
				{
					bool flag2 = this.m_onLineSaleItems[i].uid == uid;
					if (flag2)
					{
						price = this.m_onLineSaleItems[i].perprice;
						return true;
					}
					i++;
				}
			}
			price = 0U;
			return false;
		}

		public bool TryGetAuctionSaleItemID(ulong uid, out int itemid)
		{
			bool flag = uid > 0UL;
			if (flag)
			{
				int i = 0;
				int count = this.m_onLineSaleItems.Count;
				while (i < count)
				{
					bool flag2 = this.m_onLineSaleItems[i].uid == uid;
					if (flag2)
					{
						itemid = this.m_onLineSaleItems[i].itemData.itemID;
						return true;
					}
					i++;
				}
			}
			itemid = 0;
			return false;
		}

		public void RequestAuctionBuy(ulong overlapid, uint itemid, uint itemCount)
		{
			this.SendAuctionRequest(AuctionAllReqType.ART_BUY, itemid, 0UL, itemCount, 0U, overlapid, 0UL, false);
		}

		public void RequestAuctionRefresh()
		{
			bool flag = this.NextFreeRefreshTime > 0.0;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("AUCTION_FREE_REFRESH_MESSAGE", new object[]
				{
					XSingleton<UiUtility>.singleton.TimeDuarationFormatString((int)this.NextFreeRefreshTime, 5)
				}), "fece00");
			}
			else
			{
				this.CurrentSelectRefresh = true;
				this.SendAuctionRequest(AuctionAllReqType.ART_REFRESH_FREE, 0U, 0UL, 0U, 0U, 0UL, 0UL, false);
			}
		}

		public void RequestAuctionAuto()
		{
			this.SendAuctionRequest(AuctionAllReqType.ART_REFRESH_AUTO, 0U, 0UL, 0U, 0U, 0UL, 0UL, false);
		}

		private bool RequestSureAuctionRefresh()
		{
			this.SendAuctionRequest(AuctionAllReqType.ART_REFRESH_PAY, 0U, 0UL, 0U, 0U, 0UL, 0UL, false);
			XSingleton<UiUtility>.singleton.CloseModalDlg();
			return false;
		}

		private void SendAuctionRequest(AuctionAllReqType reqtype, uint itemID = 0U, ulong uid = 0UL, uint itemCount = 0U, uint perperce = 0U, ulong overlapid = 0UL, ulong auctuid = 0UL, bool isTreasuse = false)
		{
			bool sendAuctionState = this.m_sendAuctionState;
			if (!sendAuctionState)
			{
				RpcC2M_AuctionAllReq rpcC2M_AuctionAllReq = new RpcC2M_AuctionAllReq();
				rpcC2M_AuctionAllReq.oArg.reqtype = reqtype;
				rpcC2M_AuctionAllReq.oArg.itemid = itemID;
				rpcC2M_AuctionAllReq.oArg.itemuniqueid = uid;
				rpcC2M_AuctionAllReq.oArg.itemcount = itemCount;
				rpcC2M_AuctionAllReq.oArg.perprice = perperce;
				rpcC2M_AuctionAllReq.oArg.overlapid = overlapid;
				rpcC2M_AuctionAllReq.oArg.auctuid = auctuid;
				rpcC2M_AuctionAllReq.oArg.istreasure = isTreasuse;
				XSingleton<XClientNetwork>.singleton.Send(rpcC2M_AuctionAllReq);
				this.m_sendAuctionState = true;
			}
		}

		private int SortCompare(AuctionItem item1, AuctionItem item2)
		{
			XItem itemData = item1.itemData;
			XItem itemData2 = item2.itemData;
			bool flag = itemData.Treasure == itemData2.Treasure;
			int result;
			if (flag)
			{
				result = (int)(item1.perprice - item2.perprice);
			}
			else
			{
				bool treasure = itemData.Treasure;
				if (treasure)
				{
					result = -1;
				}
				else
				{
					bool treasure2 = itemData2.Treasure;
					if (treasure2)
					{
						result = 1;
					}
					else
					{
						result = 0;
					}
				}
			}
			return result;
		}

		public string GetItemName(ulong aucuid)
		{
			string result = "";
			int itemID;
			bool flag = this.TryGetAuctionSaleItemID(aucuid, out itemID);
			if (flag)
			{
				ItemList.RowData itemConf = XBagDocument.GetItemConf(itemID);
				bool flag2 = itemConf != null && itemConf.ItemName != null && itemConf.ItemName.Length != 0;
				if (flag2)
				{
					result = itemConf.ItemName[0];
				}
			}
			return result;
		}

		public void ReceiveAuctionResponse(AuctionAllReqArg oArg, AuctionAllReqRes oRes)
		{
			this.m_sendAuctionState = false;
			bool flag = oRes.errcode > ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				bool flag2 = oRes.errcode == ErrorCode.ERR_AUCT_ITEM_LESS;
				if (flag2)
				{
					this.m_showItemData = this.SetAuctionBrief(oArg.itemid, oRes.itemleftcount);
					this.RefreshView();
				}
				else
				{
					bool flag3 = oRes.errcode == ErrorCode.ERR_AUCT_AUTOREFRESH_TIME;
					if (flag3)
					{
						this.NextOutoRefreshTime = oRes.autorefreshlefttime;
						this.NextFreeRefreshTime = oRes.freerefreshlefttime;
						this.RefreshView();
					}
				}
				XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.errcode, "fece00");
			}
			else
			{
				switch (oArg.reqtype)
				{
				case AuctionAllReqType.ART_REQSALE:
					this.RequestAuctionMySale();
					XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("AUCTION_PUTAWAY_SUCCESS", new object[]
					{
						XSingleton<XGlobalConfig>.singleton.GetValue("AuctOnSaleDay")
					}), "fece00");
					break;
				case AuctionAllReqType.ART_QUITSALE:
					XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("AUCTION_QUITSALE", new object[]
					{
						this.GetItemName(oArg.auctuid)
					}), "fece00");
					this.RequestAuctionMySale();
					break;
				case AuctionAllReqType.ART_RESALE:
					this.RequestAuctionMySale();
					XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("AUCTION_REPUAWAY_SUCCESS", new object[]
					{
						XSingleton<XGlobalConfig>.singleton.GetValue("AuctOnSaleDay")
					}), "fece00");
					break;
				case AuctionAllReqType.ART_ALLITEMBRIEF:
					this.ResponseAuctionAllItemBrief(oRes);
					this.m_freeRefreshCount = oRes.leftfreerefreshcount;
					this.RefreshView();
					break;
				case AuctionAllReqType.ART_ITEMDATA:
				{
					this.SetAuctionBrief(oArg.itemid, oRes.itemleftcount);
					this.ResponseAuctionOverlapDatas(oRes.overlapdata);
					bool flag4 = oRes.itemleftcount > 0U;
					if (flag4)
					{
						this.m_showItemData = true;
					}
					else
					{
						this.m_showItemData = false;
						XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("AUCTION_SELL_FINISH"), "fece00");
					}
					this.RefreshView();
					break;
				}
				case AuctionAllReqType.ART_MYSALE:
					this.ResponseAuctionSaleData(oRes.saledata);
					this.RefreshView();
					break;
				case AuctionAllReqType.ART_BUY:
					XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("AUCTION_BUY_SUCCESS"), "fece00");
					this.SubOverlapItem(oArg.overlapid, oArg.itemcount);
					this.m_showItemData = this.SubAuctionBrief(oArg.itemid, oArg.itemcount);
					this.RefreshView();
					break;
				case AuctionAllReqType.ART_REFRESH_FREE:
					this.RequestAuctionAllItemBrief();
					break;
				case AuctionAllReqType.ART_REFRESH_PAY:
				case AuctionAllReqType.ART_REFRESH_AUTO:
					this.RequestAuctionAllItemBrief();
					break;
				case AuctionAllReqType.ART_TRADE_PRICE:
					this.SetAuctionBriefReferPrice(oArg.itemid, oRes.tradeprice);
					DlgBase<AuctionBillView, AuctionBillBehaviour>.singleton.Set(this.CurrentSelectXItem, this.CurrentSelectStyle, this.CurrentSelectCurUid);
					break;
				}
			}
		}

		private void RefreshView()
		{
			bool flag = DlgBase<AuctionView, AuctionBehaviour>.singleton.IsVisible();
			if (flag)
			{
				DlgBase<AuctionView, AuctionBehaviour>.singleton.RefreshData();
			}
			bool flag2 = DlgBase<AuctionPurchaseView, AuctionPurchaseBehaviour>.singleton.IsVisible();
			if (flag2)
			{
				DlgBase<AuctionPurchaseView, AuctionPurchaseBehaviour>.singleton.OnVirtuelRefresh();
			}
		}

		public bool TryDragonCoinFull(ulong usr, ulong has)
		{
			bool flag = has < usr;
			bool result;
			if (flag)
			{
				ulong itemCount = XBagDocument.BagDoc.GetItemCount(XFastEnumIntEqualityComparer<ItemEnum>.ToInt(ItemEnum.DIAMOND));
				bool flag2 = itemCount < usr - has;
				if (flag2)
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(ErrorCode.ERR_TEAMBUY_DRAGONCOIN_LESS, "fece00");
				}
				else
				{
					ulong num = usr - has;
					this._tempNumber = (uint)num;
					string @string = XStringDefineProxy.GetString("AUCTION_DRAGON_COIN_UNFULL", new object[]
					{
						XLabelSymbolHelper.FormatCostWithIcon((int)usr, ItemEnum.DRAGON_COIN),
						XLabelSymbolHelper.FormatCostWithIcon((int)num, ItemEnum.DIAMOND),
						XLabelSymbolHelper.FormatCostWithIcon((int)num, ItemEnum.DRAGON_COIN)
					});
					this.ShowDailog(@string, new ButtonClickEventHandler(this.OnSwapDragonCoin));
				}
				result = false;
			}
			else
			{
				result = true;
			}
			return result;
		}

		private void ShowDailog(string message, ButtonClickEventHandler handler)
		{
			XSingleton<UiUtility>.singleton.ShowModalDialog(message, XStringDefineProxy.GetString("COMMON_OK"), XStringDefineProxy.GetString("COMMON_CANCEL"), handler);
		}

		private bool OnSwapDragonCoin(IXUIButton btn)
		{
			XSingleton<UiUtility>.singleton.CloseModalDlg();
			bool flag = this._tempNumber > 0U;
			if (flag)
			{
				XPurchaseDocument specificDocument = XDocuments.GetSpecificDocument<XPurchaseDocument>(XPurchaseDocument.uuID);
				specificDocument.CommonQuickBuyRandom(ItemEnum.DRAGON_COIN, ItemEnum.DIAMOND, this._tempNumber);
			}
			return true;
		}

		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
			this.m_sendAuctionState = false;
			bool flag = DlgBase<AuctionView, AuctionBehaviour>.singleton.IsVisible();
			if (flag)
			{
				this.RequestAuctionAllItemBrief();
			}
		}

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("AuctionDocument");

		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		private static AuctionTypeList _auction_type_list = new AuctionTypeList();

		private static AuctionDiscountTable m_auctionDiscountTable = new AuctionDiscountTable();

		private static Dictionary<int, List<int>> m_NodeChildren = new Dictionary<int, List<int>>();

		private static Dictionary<uint, Dictionary<uint, float>> m_auctionDiscounts = new Dictionary<uint, Dictionary<uint, float>>();

		private static Dictionary<int, int> m_auctionTypeParent = new Dictionary<int, int>();

		private Dictionary<uint, AuctItemBrief> m_aucItemBriefs = new Dictionary<uint, AuctItemBrief>();

		private Dictionary<uint, uint> m_aucItemReferPrices = new Dictionary<uint, uint>();

		private List<AuctionItem> m_curSelectItems = new List<AuctionItem>();

		private List<AuctionSaleItem> m_onLineSaleItems = new List<AuctionSaleItem>();

		private bool m_showItemData = false;

		private uint m_freeRefreshCount = 5U;

		private bool m_CurrentSelectRefresh = false;

		private double m_NextFreeRefreshTime = 0.0;

		private Dictionary<AuctionAllReqType, bool> m_rpcState = new Dictionary<AuctionAllReqType, bool>();

		private bool m_sendAuctionState = false;

		private uint _tempNumber = 0U;
	}
}
