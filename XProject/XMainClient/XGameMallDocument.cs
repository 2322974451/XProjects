using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000FEA RID: 4074
	internal class XGameMallDocument : XDocComponent
	{
		// Token: 0x17003701 RID: 14081
		// (get) Token: 0x0600D3EC RID: 54252 RVA: 0x0031D70C File Offset: 0x0031B90C
		public override uint ID
		{
			get
			{
				return XGameMallDocument.uuID;
			}
		}

		// Token: 0x17003702 RID: 14082
		// (get) Token: 0x0600D3ED RID: 54253 RVA: 0x0031D724 File Offset: 0x0031B924
		public bool isNewVIP
		{
			get
			{
				return this.hotGoods.Count > 0;
			}
		}

		// Token: 0x17003703 RID: 14083
		// (get) Token: 0x0600D3EE RID: 54254 RVA: 0x0031D744 File Offset: 0x0031B944
		public CIBShop currCIBShop
		{
			get
			{
				for (int i = 0; i < this.mallItemlist.Count; i++)
				{
					bool flag = (ulong)this.mallItemlist[i].row.itemid == (ulong)((long)this.currItemID);
					if (flag)
					{
						return this.mallItemlist[i];
					}
				}
				return null;
			}
		}

		// Token: 0x0600D3EF RID: 54255 RVA: 0x0031D7A8 File Offset: 0x0031B9A8
		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
			bool flag = DlgBase<GameMallDlg, TabDlgBehaviour>.singleton.IsVisible();
			if (flag)
			{
				this.SendQueryItems(DlgBase<GameMallDlg, TabDlgBehaviour>.singleton.mallType);
			}
		}

		// Token: 0x0600D3F0 RID: 54256 RVA: 0x0031D7D7 File Offset: 0x0031B9D7
		public static void Execute(OnLoadedCallback callback = null)
		{
			XGameMallDocument.AsyncLoader.AddTask("Table/IBShop", XGameMallDocument._IBShopTable, false);
			XGameMallDocument.AsyncLoader.Execute(callback);
		}

		// Token: 0x0600D3F1 RID: 54257 RVA: 0x0031D7FC File Offset: 0x0031B9FC
		public override void OnAttachToHost(XObject host)
		{
			this.ShopSystems.Clear();
			List<int> intList = XSingleton<XGlobalConfig>.singleton.GetIntList("ShopShowingIconList");
			for (int i = 0; i < intList.Count; i++)
			{
				this.ShopSystems.Add((XSysDefine)intList[i]);
			}
		}

		// Token: 0x0600D3F2 RID: 54258 RVA: 0x0031D850 File Offset: 0x0031BA50
		public void SendQueryItems(MallType type)
		{
			RpcC2G_QueryIBItem rpcC2G_QueryIBItem = new RpcC2G_QueryIBItem();
			rpcC2G_QueryIBItem.oArg.type = (uint)this.GetCoinItemid();
			rpcC2G_QueryIBItem.oArg.subtype = (uint)type;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_QueryIBItem);
		}

		// Token: 0x0600D3F3 RID: 54259 RVA: 0x0031D890 File Offset: 0x0031BA90
		public void RespItems(IBQueryItemReq oArg, IBQueryItemRes oRes)
		{
			uint coinItemid = (uint)this.GetCoinItemid();
			bool flag = coinItemid == oArg.type;
			uint mallType = (uint)DlgBase<GameMallDlg, TabDlgBehaviour>.singleton.mallType;
			this.vipTabshow = oRes.viptab;
			this.tabNews = oRes.newproducts;
			bool flag2 = this.GetCoinItemid() == (int)oArg.type && DlgBase<GameMallDlg, TabDlgBehaviour>.singleton.mallType == (MallType)oArg.subtype;
			if (flag2)
			{
				this.MergeIBShop(oRes.iteminfo, this.GetItemsFromTable());
				bool flag3 = DlgBase<GameMallDlg, TabDlgBehaviour>.singleton.IsVisible();
				if (flag3)
				{
					DlgBase<GameMallDlg, TabDlgBehaviour>.singleton.Refresh();
				}
			}
			else
			{
				XSingleton<XDebug>.singleton.AddLog("mall tab has changed!", null, null, null, null, null, XDebugColor.XDebug_None);
			}
			this.isBuying = false;
		}

		// Token: 0x0600D3F4 RID: 54260 RVA: 0x0031D94C File Offset: 0x0031BB4C
		public void UpdateItemBuyCnt(uint goodsid, uint cnt)
		{
			GameItemsMallHander gameItemsMallHander = DlgBase<GameMallDlg, TabDlgBehaviour>.singleton._gameItemsMallHander;
			GameDescMallHander gameDescMallHander = DlgBase<GameMallDlg, TabDlgBehaviour>.singleton._gameDescMallHander;
			bool flag = gameDescMallHander != null && gameItemsMallHander != null && DlgBase<GameMallDlg, TabDlgBehaviour>.singleton.IsVisible() && this.currCIBShop != null && this.currCIBShop.sinfo != null && goodsid == this.currCIBShop.sinfo.goodsid;
			if (flag)
			{
				for (int i = 0; i < this.mallItemlist.Count; i++)
				{
					bool flag2 = this.mallItemlist[i].sinfo.goodsid == this.currCIBShop.sinfo.goodsid;
					if (flag2)
					{
						this.mallItemlist[i].sinfo.nbuycount = cnt;
						this.mallItemlist[i].finish = this.IsFinish(this.mallItemlist[i].sinfo, this.mallItemlist[i].row);
						gameDescMallHander.Refresh();
						gameItemsMallHander.Refresh();
						break;
					}
				}
			}
		}

		// Token: 0x0600D3F5 RID: 54261 RVA: 0x0031DA6C File Offset: 0x0031BC6C
		public void SendBuyItem(uint goodsid, uint count)
		{
			bool flag = !this.isBuying;
			if (flag)
			{
				this.isBuying = true;
				RpcC2G_BuyIBItem rpcC2G_BuyIBItem = new RpcC2G_BuyIBItem();
				rpcC2G_BuyIBItem.oArg.goodsid = goodsid;
				rpcC2G_BuyIBItem.oArg.count = count;
				XSingleton<XClientNetwork>.singleton.Send(rpcC2G_BuyIBItem);
			}
		}

		// Token: 0x0600D3F6 RID: 54262 RVA: 0x0031DABC File Offset: 0x0031BCBC
		public CIBShop SearchIBShop(int itemid)
		{
			for (int i = 0; i < this.mallItemlist.Count; i++)
			{
				bool flag = (ulong)this.mallItemlist[i].row.itemid == (ulong)((long)itemid);
				if (flag)
				{
					return this.mallItemlist[i];
				}
			}
			return null;
		}

		// Token: 0x0600D3F7 RID: 54263 RVA: 0x0031DB1C File Offset: 0x0031BD1C
		public void OnResBuyItem(IBBuyItemReq oArg, IBBuyItemRes res)
		{
			uint goodsid = oArg.goodsid;
			uint itemid = XGameMallDocument._IBShopTable.GetByid(goodsid).itemid;
			ItemList.RowData itemConf = XBagDocument.GetItemConf((int)itemid);
			string text = XSingleton<UiUtility>.singleton.ChooseProfString(itemConf.ItemName, 0U);
			this.SendQueryItems(DlgBase<GameMallDlg, TabDlgBehaviour>.singleton.mallType);
		}

		// Token: 0x0600D3F8 RID: 54264 RVA: 0x0031DB6C File Offset: 0x0031BD6C
		private void MergeIBShop(List<IBShopItemInfo> server_list, Dictionary<uint, IBShop.RowData> dicTable)
		{
			this.mallItemlist.Clear();
			this.mallItemUIList.Clear();
			for (int i = 0; i < server_list.Count; i++)
			{
				bool flag = dicTable.ContainsKey(server_list[i].goodsid);
				if (flag)
				{
					CIBShop cibshop = new CIBShop();
					cibshop.row = dicTable[server_list[i].goodsid];
					cibshop.sinfo = server_list[i];
					cibshop.finish = this.IsFinish(server_list[i], cibshop.row);
					this.mallItemlist.Add(cibshop);
				}
			}
			this.mallItemlist.Sort(new Comparison<CIBShop>(this.SortData));
			bool flag2 = !this.Search((uint)this.currItemID);
			if (flag2)
			{
				this.currItemID = (int)((this.mallItemlist.Count > 0) ? this.mallItemlist[0].row.itemid : 0U);
			}
			int count = this.mallItemlist.Count;
			for (int j = 0; j < count; j += 2)
			{
				CUIIBShop item = default(CUIIBShop);
				item.item1 = this.mallItemlist[j];
				bool flag3 = this.mallItemlist.Count > j + 1;
				if (flag3)
				{
					item.item2 = this.mallItemlist[j + 1];
				}
				else
				{
					item.item2 = null;
				}
				this.mallItemUIList.Add(item);
			}
		}

		// Token: 0x0600D3F9 RID: 54265 RVA: 0x0031DCF4 File Offset: 0x0031BEF4
		private bool IsFinish(IBShopItemInfo info, IBShop.RowData row)
		{
			bool flag = info.itemid == DlgBase<GameMallDlg, TabDlgBehaviour>.singleton.privilegeID;
			bool result;
			if (flag)
			{
				XWelfareDocument specificDocument = XDocuments.GetSpecificDocument<XWelfareDocument>(XWelfareDocument.uuID);
				float num = 0f;
				bool flag2 = specificDocument.IsOwnMemberPrivilege(MemberPrivilege.KingdomPrivilege_Commerce);
				if (flag2)
				{
					PayMemberTable.RowData memberPrivilegeConfig = specificDocument.GetMemberPrivilegeConfig(MemberPrivilege.KingdomPrivilege_Commerce);
					num = ((memberPrivilegeConfig != null) ? ((float)memberPrivilegeConfig.BuyGreenAgateLimit / 100f) : 0f);
				}
				int num2 = 0;
				PayMemberPrivilege payMemberPrivilege = specificDocument.PayMemberPrivilege;
				bool flag3 = payMemberPrivilege != null;
				if (flag3)
				{
					List<PayPrivilegeShop> usedPrivilegeShop = payMemberPrivilege.usedPrivilegeShop;
					for (int i = 0; i < usedPrivilegeShop.Count; i++)
					{
						bool flag4 = (long)usedPrivilegeShop[i].goodsID == (long)((ulong)info.goodsid);
						if (flag4)
						{
							num2 = usedPrivilegeShop[i].usedCount;
							break;
						}
					}
				}
				result = (info.nlimitcount > 0U && info.nlimitcount + row.buycount * num <= (float)((ulong)info.nbuycount + (ulong)((long)num2)));
			}
			else
			{
				result = (info.nlimitcount > 0U && info.nlimitcount <= info.nbuycount);
			}
			return result;
		}

		// Token: 0x0600D3FA RID: 54266 RVA: 0x0031DE24 File Offset: 0x0031C024
		private Dictionary<uint, IBShop.RowData> GetItemsFromTable()
		{
			Dictionary<uint, IBShop.RowData> dictionary = new Dictionary<uint, IBShop.RowData>();
			IBShop.RowData[] table = XGameMallDocument._IBShopTable.Table;
			for (int i = 0; i < table.Length; i++)
			{
				bool flag = table[i].currencytype == (uint)this.GetCoinItemid() && table[i].type == (uint)DlgBase<GameMallDlg, TabDlgBehaviour>.singleton.mallType;
				if (flag)
				{
					dictionary.Add(table[i].id, table[i]);
				}
			}
			return dictionary;
		}

		// Token: 0x0600D3FB RID: 54267 RVA: 0x0031DEA0 File Offset: 0x0031C0A0
		public void FindItem(int itemid, out uint currency, out uint type)
		{
			currency = (type = 0U);
			IBShop.RowData[] table = XGameMallDocument._IBShopTable.Table;
			for (int i = 0; i < table.Length; i++)
			{
				bool flag = (ulong)table[i].itemid == (ulong)((long)itemid);
				if (flag)
				{
					currency = table[i].currencytype;
					type = table[i].type;
					break;
				}
			}
		}

		// Token: 0x0600D3FC RID: 54268 RVA: 0x0031DF00 File Offset: 0x0031C100
		public uint FindItemPrice(uint itemId, uint currencytype)
		{
			IBShop.RowData[] table = XGameMallDocument._IBShopTable.Table;
			for (int i = 0; i < table.Length; i++)
			{
				bool flag = table[i].itemid == itemId && table[i].currencytype == currencytype;
				if (flag)
				{
					return table[i].currencycount;
				}
			}
			return 0U;
		}

		// Token: 0x0600D3FD RID: 54269 RVA: 0x0031DF60 File Offset: 0x0031C160
		private int ChangeLimtSort(CIBShop limit)
		{
			return (limit.sinfo.nlimittime > 0U) ? 1 : 0;
		}

		// Token: 0x0600D3FE RID: 54270 RVA: 0x0031DF84 File Offset: 0x0031C184
		private int ChangeDiscount(CIBShop discount)
		{
			return (int)((discount.row.discount == 0U) ? 100U : discount.row.discount);
		}

		// Token: 0x0600D3FF RID: 54271 RVA: 0x0031DFB4 File Offset: 0x0031C1B4
		private int ChangeFashion(CIBShop shop)
		{
			ItemList.RowData itemConf = XBagDocument.GetItemConf((int)shop.row.itemid);
			bool flag = itemConf.ItemType == 2 || itemConf.ItemType == 5;
			int result;
			if (flag)
			{
				result = (int)itemConf.ItemType;
			}
			else
			{
				result = 0;
			}
			return result;
		}

		// Token: 0x0600D400 RID: 54272 RVA: 0x0031DFFC File Offset: 0x0031C1FC
		private int SortData(CIBShop x, CIBShop y)
		{
			bool flag = x.row.sortid != y.row.sortid;
			int result;
			if (flag)
			{
				result = x.row.sortid - y.row.sortid;
			}
			else
			{
				result = (int)(x.row.id - y.row.id);
			}
			return result;
		}

		// Token: 0x0600D401 RID: 54273 RVA: 0x0031E060 File Offset: 0x0031C260
		public int GetCoinItemid()
		{
			bool flag = DlgBase<GameMallDlg, TabDlgBehaviour>.singleton.currSys == XSysDefine.XSys_GameMall_Diamond;
			int result;
			if (flag)
			{
				result = XFastEnumIntEqualityComparer<ItemEnum>.ToInt(ItemEnum.DIAMOND);
			}
			else
			{
				bool flag2 = DlgBase<GameMallDlg, TabDlgBehaviour>.singleton.currSys == XSysDefine.XSys_GameMall_Dragon;
				if (flag2)
				{
					result = XFastEnumIntEqualityComparer<ItemEnum>.ToInt(ItemEnum.DRAGON_COIN);
				}
				else
				{
					result = XFastEnumIntEqualityComparer<ItemEnum>.ToInt(ItemEnum.DIAMOND);
				}
			}
			return result;
		}

		// Token: 0x0600D402 RID: 54274 RVA: 0x0031E0B8 File Offset: 0x0031C2B8
		private bool Search(uint itemid)
		{
			bool flag = this.mallItemlist != null;
			if (flag)
			{
				for (int i = 0; i < this.mallItemlist.Count; i++)
				{
					bool flag2 = this.mallItemlist[i].row.itemid == itemid;
					if (flag2)
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x0600D403 RID: 54275 RVA: 0x0031E11C File Offset: 0x0031C31C
		public ShopTypeTable.RowData GetShopTypeData(XSysDefine shop)
		{
			XNormalShopDocument specificDocument = XDocuments.GetSpecificDocument<XNormalShopDocument>(XNormalShopDocument.uuID);
			return specificDocument.GetShopTypeData(shop);
		}

		// Token: 0x0600D404 RID: 54276 RVA: 0x0031E140 File Offset: 0x0031C340
		public void RefreshShopRedPoint(XSysDefine sys, bool isredon)
		{
			List<XSysDefine> list = new List<XSysDefine>(this.ShopSystems);
			bool flag = !list.Contains(sys);
			if (!flag)
			{
				if (isredon)
				{
					bool flag2 = !this.shopRedPoint.Contains(sys);
					if (flag2)
					{
						this.shopRedPoint.Add(sys);
					}
				}
				else
				{
					bool flag3 = this.shopRedPoint.Contains(sys);
					if (flag3)
					{
						this.shopRedPoint.Remove(sys);
					}
				}
				DlgBase<GameMallDlg, TabDlgBehaviour>.singleton.RefreshShopRedPoint();
			}
		}

		// Token: 0x0600D405 RID: 54277 RVA: 0x0031E1C0 File Offset: 0x0031C3C0
		public void SendQueryGiftItems(uint type)
		{
			RpcC2M_IbGiftHistReq rpcC2M_IbGiftHistReq = new RpcC2M_IbGiftHistReq();
			rpcC2M_IbGiftHistReq.oArg.type = type;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_IbGiftHistReq);
		}

		// Token: 0x0600D406 RID: 54278 RVA: 0x0031E1F0 File Offset: 0x0031C3F0
		public void HandleGiftItems(uint type, List<IBGiftHistItem> list)
		{
			bool flag = type == 0U;
			if (flag)
			{
				this.presentList = list;
			}
			else
			{
				this.recvList = list;
			}
			bool flag2 = DlgBase<GiftboxDlg, GiftboxBehaviour>.singleton.IsVisible();
			if (flag2)
			{
				DlgBase<GiftboxDlg, GiftboxBehaviour>.singleton.Refresh();
			}
		}

		// Token: 0x0600D407 RID: 54279 RVA: 0x0031E234 File Offset: 0x0031C434
		public void ClearGiftItems()
		{
			bool flag = this.presentList != null;
			if (flag)
			{
				this.presentList.Clear();
			}
			bool flag2 = this.recvList != null;
			if (flag2)
			{
				this.recvList.Clear();
			}
			this.presentList = null;
			this.recvList = null;
		}

		// Token: 0x0400605B RID: 24667
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("XGameMallDocument");

		// Token: 0x0400605C RID: 24668
		private static IBShop _IBShopTable = new IBShop();

		// Token: 0x0400605D RID: 24669
		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		// Token: 0x0400605E RID: 24670
		public int currItemID = 0;

		// Token: 0x0400605F RID: 24671
		public bool isNewWeekly = true;

		// Token: 0x04006060 RID: 24672
		public List<uint> hotGoods = new List<uint>();

		// Token: 0x04006061 RID: 24673
		public List<uint> tabNews = new List<uint>();

		// Token: 0x04006062 RID: 24674
		public List<XSysDefine> shopRedPoint = new List<XSysDefine>();

		// Token: 0x04006063 RID: 24675
		public bool vipTabshow = false;

		// Token: 0x04006064 RID: 24676
		public bool presentStatus = true;

		// Token: 0x04006065 RID: 24677
		public bool isBuying = false;

		// Token: 0x04006066 RID: 24678
		public bool isQuerying = false;

		// Token: 0x04006067 RID: 24679
		public List<IBGiftHistItem> presentList;

		// Token: 0x04006068 RID: 24680
		public List<IBGiftHistItem> recvList;

		// Token: 0x04006069 RID: 24681
		public List<CIBShop> mallItemlist = new List<CIBShop>();

		// Token: 0x0400606A RID: 24682
		public List<CUIIBShop> mallItemUIList = new List<CUIIBShop>();

		// Token: 0x0400606B RID: 24683
		public List<XSysDefine> ShopSystems = new List<XSysDefine>();
	}
}
