using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020008CE RID: 2254
	internal class AuctionDocument : XDocComponent
	{
		// Token: 0x17002A99 RID: 10905
		// (get) Token: 0x06008830 RID: 34864 RVA: 0x001193E0 File Offset: 0x001175E0
		public override uint ID
		{
			get
			{
				return AuctionDocument.uuID;
			}
		}

		// Token: 0x06008831 RID: 34865 RVA: 0x001193F8 File Offset: 0x001175F8
		public static void Execute(OnLoadedCallback callback = null)
		{
			AuctionDocument.AsyncLoader.AddTask("Table/AuctionList", AuctionDocument._auction_type_list, false);
			AuctionDocument.AsyncLoader.AddTask("Table/AuctionDiscount", AuctionDocument.m_auctionDiscountTable, false);
			AuctionDocument.AsyncLoader.Execute(callback);
			AuctionDocument.m_NodeChildren.Clear();
			AuctionDocument.m_auctionTypeParent.Clear();
			AuctionDocument.m_auctionDiscounts.Clear();
		}

		// Token: 0x06008832 RID: 34866 RVA: 0x00119460 File Offset: 0x00117660
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

		// Token: 0x06008833 RID: 34867 RVA: 0x0011967C File Offset: 0x0011787C
		public static bool TryGetAuctionTypeParentID(int typeid, out int parentTypeID)
		{
			return AuctionDocument.m_auctionTypeParent.TryGetValue(typeid, out parentTypeID);
		}

		// Token: 0x06008834 RID: 34868 RVA: 0x0011969C File Offset: 0x0011789C
		public static bool TryGetChildren(int preType, out List<int> list)
		{
			return AuctionDocument.m_NodeChildren.TryGetValue(preType, out list);
		}

		// Token: 0x06008835 RID: 34869 RVA: 0x001196BC File Offset: 0x001178BC
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

		// Token: 0x06008836 RID: 34870 RVA: 0x00119714 File Offset: 0x00117914
		public static T MakeAuctionItem<T>(ulong uid, uint price, Item KKSGItem) where T : AuctionItem, new()
		{
			T t = Activator.CreateInstance<T>();
			t.itemData = XBagDocument.MakeXItem(KKSGItem);
			t.uid = uid;
			t.perprice = price;
			return t;
		}

		// Token: 0x17002A9A RID: 10906
		// (get) Token: 0x06008838 RID: 34872 RVA: 0x0011975F File Offset: 0x0011795F
		// (set) Token: 0x06008837 RID: 34871 RVA: 0x00119756 File Offset: 0x00117956
		public uint NextOutoRefreshTime { get; set; }

		// Token: 0x17002A9B RID: 10907
		// (get) Token: 0x06008839 RID: 34873 RVA: 0x00119768 File Offset: 0x00117968
		// (set) Token: 0x0600883A RID: 34874 RVA: 0x00119780 File Offset: 0x00117980
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

		// Token: 0x17002A9C RID: 10908
		// (get) Token: 0x0600883B RID: 34875 RVA: 0x0011978C File Offset: 0x0011798C
		public uint FreeRefreshCount
		{
			get
			{
				return this.m_freeRefreshCount;
			}
		}

		// Token: 0x17002A9D RID: 10909
		// (get) Token: 0x0600883D RID: 34877 RVA: 0x001197AD File Offset: 0x001179AD
		// (set) Token: 0x0600883C RID: 34876 RVA: 0x001197A4 File Offset: 0x001179A4
		public AuctionBillStyle CurrentSelectStyle { get; set; }

		// Token: 0x17002A9E RID: 10910
		// (get) Token: 0x0600883F RID: 34879 RVA: 0x001197BE File Offset: 0x001179BE
		// (set) Token: 0x0600883E RID: 34878 RVA: 0x001197B5 File Offset: 0x001179B5
		public XItem CurrentSelectXItem { get; set; }

		// Token: 0x17002A9F RID: 10911
		// (get) Token: 0x06008841 RID: 34881 RVA: 0x001197CF File Offset: 0x001179CF
		// (set) Token: 0x06008840 RID: 34880 RVA: 0x001197C6 File Offset: 0x001179C6
		public ulong CurrentSelectCurUid { get; set; }

		// Token: 0x17002AA0 RID: 10912
		// (get) Token: 0x06008843 RID: 34883 RVA: 0x001197E4 File Offset: 0x001179E4
		// (set) Token: 0x06008842 RID: 34882 RVA: 0x001197D7 File Offset: 0x001179D7
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

		// Token: 0x17002AA1 RID: 10913
		// (get) Token: 0x06008844 RID: 34884 RVA: 0x001197FC File Offset: 0x001179FC
		public bool ShowItemData
		{
			get
			{
				return this.m_showItemData;
			}
		}

		// Token: 0x06008845 RID: 34885 RVA: 0x00119814 File Offset: 0x00117A14
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

		// Token: 0x06008846 RID: 34886 RVA: 0x0011985F File Offset: 0x00117A5F
		protected override void EventSubscribe()
		{
			base.EventSubscribe();
			base.RegisterEvent(XEventDefine.XEvent_ItemChangeFinished, new XComponent.XEventHandler(this.OnVirtualItemChanged));
			base.RegisterEvent(XEventDefine.XEvent_VirtualItemChanged, new XComponent.XEventHandler(this.OnVirtualItemChanged));
		}

		// Token: 0x06008847 RID: 34887 RVA: 0x00119894 File Offset: 0x00117A94
		private bool OnVirtualItemChanged(XEventArgs e)
		{
			AuctionHouseDocument specificDocument = XDocuments.GetSpecificDocument<AuctionHouseDocument>(AuctionHouseDocument.uuID);
			specificDocument.DataState = GuildAuctReqType.GART_AUCT_GUILD_HISTORY;
			this.RefreshView();
			return true;
		}

		// Token: 0x17002AA2 RID: 10914
		// (get) Token: 0x06008848 RID: 34888 RVA: 0x001198C0 File Offset: 0x00117AC0
		public AuctionTypeList AuctionTypeList
		{
			get
			{
				return AuctionDocument._auction_type_list;
			}
		}

		// Token: 0x06008849 RID: 34889 RVA: 0x001198D8 File Offset: 0x00117AD8
		public List<XItem> GetItemList()
		{
			return XSingleton<XGame>.singleton.Doc.XBagDoc.GetNotBindItemsByType(-1);
		}

		// Token: 0x0600884A RID: 34890 RVA: 0x00119900 File Offset: 0x00117B00
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

		// Token: 0x0600884B RID: 34891 RVA: 0x00119938 File Offset: 0x00117B38
		public uint GetAuctionBriefCount(uint itemid)
		{
			uint result;
			this.TryGetAuctionBriefCount(itemid, out result);
			return result;
		}

		// Token: 0x0600884C RID: 34892 RVA: 0x00119958 File Offset: 0x00117B58
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

		// Token: 0x0600884D RID: 34893 RVA: 0x001199B4 File Offset: 0x00117BB4
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

		// Token: 0x0600884E RID: 34894 RVA: 0x001199E4 File Offset: 0x00117BE4
		public bool TryGetAuctionBriefReferPrice(uint itemid, out uint referPrice)
		{
			return this.m_aucItemReferPrices.TryGetValue(itemid, out referPrice);
		}

		// Token: 0x0600884F RID: 34895 RVA: 0x00119A04 File Offset: 0x00117C04
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

		// Token: 0x06008850 RID: 34896 RVA: 0x00119A40 File Offset: 0x00117C40
		public void RequestAuctionAllItemBrief()
		{
			this.SendAuctionRequest(AuctionAllReqType.ART_ALLITEMBRIEF, 0U, 0UL, 0U, 0U, 0UL, 0UL, false);
		}

		// Token: 0x06008851 RID: 34897 RVA: 0x00119A60 File Offset: 0x00117C60
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

		// Token: 0x06008852 RID: 34898 RVA: 0x00119B1C File Offset: 0x00117D1C
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

		// Token: 0x06008853 RID: 34899 RVA: 0x00119BC0 File Offset: 0x00117DC0
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

		// Token: 0x06008854 RID: 34900 RVA: 0x00119C18 File Offset: 0x00117E18
		public void RequestAuctionQuitSale(ulong aucuid)
		{
			this.SendAuctionRequest(AuctionAllReqType.ART_QUITSALE, 0U, 0UL, 0U, 0U, 0UL, aucuid, false);
		}

		// Token: 0x06008855 RID: 34901 RVA: 0x00119C38 File Offset: 0x00117E38
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

		// Token: 0x06008856 RID: 34902 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public void RequestAuctionReSale(ulong aucuid, uint price)
		{
		}

		// Token: 0x06008857 RID: 34903 RVA: 0x00119D37 File Offset: 0x00117F37
		public void SetSendAuctionState(bool state = false)
		{
			this.m_sendAuctionState = state;
		}

		// Token: 0x06008858 RID: 34904 RVA: 0x00119D44 File Offset: 0x00117F44
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

		// Token: 0x06008859 RID: 34905 RVA: 0x00119DA0 File Offset: 0x00117FA0
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

		// Token: 0x0600885A RID: 34906 RVA: 0x00119E20 File Offset: 0x00118020
		public List<AuctionItem> GetOverlapItems()
		{
			this.m_showItemData = false;
			return this.m_curSelectItems;
		}

		// Token: 0x0600885B RID: 34907 RVA: 0x00119E40 File Offset: 0x00118040
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

		// Token: 0x0600885C RID: 34908 RVA: 0x00119EDC File Offset: 0x001180DC
		public void RequestAuctionMySale()
		{
			this.SendAuctionRequest(AuctionAllReqType.ART_MYSALE, 0U, 0UL, 0U, 0U, 0UL, 0UL, false);
		}

		// Token: 0x0600885D RID: 34909 RVA: 0x00119EFC File Offset: 0x001180FC
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

		// Token: 0x0600885E RID: 34910 RVA: 0x00119F78 File Offset: 0x00118178
		public void RequestAuctionPriceRecommend(ulong uid, XItem item, AuctionBillStyle style)
		{
			this.CurrentSelectXItem = item;
			this.CurrentSelectStyle = style;
			this.CurrentSelectCurUid = uid;
			this.SendAuctionRequest(AuctionAllReqType.ART_TRADE_PRICE, (uint)item.itemID, 0UL, 0U, 0U, 0UL, 0UL, false);
		}

		// Token: 0x17002AA3 RID: 10915
		// (get) Token: 0x0600885F RID: 34911 RVA: 0x00119FB8 File Offset: 0x001181B8
		public List<AuctionSaleItem> AuctionOnLineSaleList
		{
			get
			{
				return this.m_onLineSaleItems;
			}
		}

		// Token: 0x06008860 RID: 34912 RVA: 0x00119FD0 File Offset: 0x001181D0
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

		// Token: 0x06008861 RID: 34913 RVA: 0x0011A044 File Offset: 0x00118244
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

		// Token: 0x06008862 RID: 34914 RVA: 0x0011A0C0 File Offset: 0x001182C0
		public void RequestAuctionBuy(ulong overlapid, uint itemid, uint itemCount)
		{
			this.SendAuctionRequest(AuctionAllReqType.ART_BUY, itemid, 0UL, itemCount, 0U, overlapid, 0UL, false);
		}

		// Token: 0x06008863 RID: 34915 RVA: 0x0011A0E0 File Offset: 0x001182E0
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

		// Token: 0x06008864 RID: 34916 RVA: 0x0011A158 File Offset: 0x00118358
		public void RequestAuctionAuto()
		{
			this.SendAuctionRequest(AuctionAllReqType.ART_REFRESH_AUTO, 0U, 0UL, 0U, 0U, 0UL, 0UL, false);
		}

		// Token: 0x06008865 RID: 34917 RVA: 0x0011A17C File Offset: 0x0011837C
		private bool RequestSureAuctionRefresh()
		{
			this.SendAuctionRequest(AuctionAllReqType.ART_REFRESH_PAY, 0U, 0UL, 0U, 0U, 0UL, 0UL, false);
			XSingleton<UiUtility>.singleton.CloseModalDlg();
			return false;
		}

		// Token: 0x06008866 RID: 34918 RVA: 0x0011A1B0 File Offset: 0x001183B0
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

		// Token: 0x06008867 RID: 34919 RVA: 0x0011A254 File Offset: 0x00118454
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

		// Token: 0x06008868 RID: 34920 RVA: 0x0011A2B8 File Offset: 0x001184B8
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

		// Token: 0x06008869 RID: 34921 RVA: 0x0011A314 File Offset: 0x00118514
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

		// Token: 0x0600886A RID: 34922 RVA: 0x0011A5E8 File Offset: 0x001187E8
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

		// Token: 0x0600886B RID: 34923 RVA: 0x0011A62C File Offset: 0x0011882C
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

		// Token: 0x0600886C RID: 34924 RVA: 0x0011A6E1 File Offset: 0x001188E1
		private void ShowDailog(string message, ButtonClickEventHandler handler)
		{
			XSingleton<UiUtility>.singleton.ShowModalDialog(message, XStringDefineProxy.GetString("COMMON_OK"), XStringDefineProxy.GetString("COMMON_CANCEL"), handler);
		}

		// Token: 0x0600886D RID: 34925 RVA: 0x0011A708 File Offset: 0x00118908
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

		// Token: 0x0600886E RID: 34926 RVA: 0x0011A750 File Offset: 0x00118950
		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
			this.m_sendAuctionState = false;
			bool flag = DlgBase<AuctionView, AuctionBehaviour>.singleton.IsVisible();
			if (flag)
			{
				this.RequestAuctionAllItemBrief();
			}
		}

		// Token: 0x04002B03 RID: 11011
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("AuctionDocument");

		// Token: 0x04002B04 RID: 11012
		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		// Token: 0x04002B05 RID: 11013
		private static AuctionTypeList _auction_type_list = new AuctionTypeList();

		// Token: 0x04002B06 RID: 11014
		private static AuctionDiscountTable m_auctionDiscountTable = new AuctionDiscountTable();

		// Token: 0x04002B07 RID: 11015
		private static Dictionary<int, List<int>> m_NodeChildren = new Dictionary<int, List<int>>();

		// Token: 0x04002B08 RID: 11016
		private static Dictionary<uint, Dictionary<uint, float>> m_auctionDiscounts = new Dictionary<uint, Dictionary<uint, float>>();

		// Token: 0x04002B09 RID: 11017
		private static Dictionary<int, int> m_auctionTypeParent = new Dictionary<int, int>();

		// Token: 0x04002B0A RID: 11018
		private Dictionary<uint, AuctItemBrief> m_aucItemBriefs = new Dictionary<uint, AuctItemBrief>();

		// Token: 0x04002B0B RID: 11019
		private Dictionary<uint, uint> m_aucItemReferPrices = new Dictionary<uint, uint>();

		// Token: 0x04002B0C RID: 11020
		private List<AuctionItem> m_curSelectItems = new List<AuctionItem>();

		// Token: 0x04002B0D RID: 11021
		private List<AuctionSaleItem> m_onLineSaleItems = new List<AuctionSaleItem>();

		// Token: 0x04002B0E RID: 11022
		private bool m_showItemData = false;

		// Token: 0x04002B0F RID: 11023
		private uint m_freeRefreshCount = 5U;

		// Token: 0x04002B10 RID: 11024
		private bool m_CurrentSelectRefresh = false;

		// Token: 0x04002B11 RID: 11025
		private double m_NextFreeRefreshTime = 0.0;

		// Token: 0x04002B16 RID: 11030
		private Dictionary<AuctionAllReqType, bool> m_rpcState = new Dictionary<AuctionAllReqType, bool>();

		// Token: 0x04002B17 RID: 11031
		private bool m_sendAuctionState = false;

		// Token: 0x04002B18 RID: 11032
		private uint _tempNumber = 0U;
	}
}
