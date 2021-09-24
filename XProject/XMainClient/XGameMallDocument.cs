using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XGameMallDocument : XDocComponent
	{

		public override uint ID
		{
			get
			{
				return XGameMallDocument.uuID;
			}
		}

		public bool isNewVIP
		{
			get
			{
				return this.hotGoods.Count > 0;
			}
		}

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

		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
			bool flag = DlgBase<GameMallDlg, TabDlgBehaviour>.singleton.IsVisible();
			if (flag)
			{
				this.SendQueryItems(DlgBase<GameMallDlg, TabDlgBehaviour>.singleton.mallType);
			}
		}

		public static void Execute(OnLoadedCallback callback = null)
		{
			XGameMallDocument.AsyncLoader.AddTask("Table/IBShop", XGameMallDocument._IBShopTable, false);
			XGameMallDocument.AsyncLoader.Execute(callback);
		}

		public override void OnAttachToHost(XObject host)
		{
			this.ShopSystems.Clear();
			List<int> intList = XSingleton<XGlobalConfig>.singleton.GetIntList("ShopShowingIconList");
			for (int i = 0; i < intList.Count; i++)
			{
				this.ShopSystems.Add((XSysDefine)intList[i]);
			}
		}

		public void SendQueryItems(MallType type)
		{
			RpcC2G_QueryIBItem rpcC2G_QueryIBItem = new RpcC2G_QueryIBItem();
			rpcC2G_QueryIBItem.oArg.type = (uint)this.GetCoinItemid();
			rpcC2G_QueryIBItem.oArg.subtype = (uint)type;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_QueryIBItem);
		}

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

		public void OnResBuyItem(IBBuyItemReq oArg, IBBuyItemRes res)
		{
			uint goodsid = oArg.goodsid;
			uint itemid = XGameMallDocument._IBShopTable.GetByid(goodsid).itemid;
			ItemList.RowData itemConf = XBagDocument.GetItemConf((int)itemid);
			string text = XSingleton<UiUtility>.singleton.ChooseProfString(itemConf.ItemName, 0U);
			this.SendQueryItems(DlgBase<GameMallDlg, TabDlgBehaviour>.singleton.mallType);
		}

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

		private int ChangeLimtSort(CIBShop limit)
		{
			return (limit.sinfo.nlimittime > 0U) ? 1 : 0;
		}

		private int ChangeDiscount(CIBShop discount)
		{
			return (int)((discount.row.discount == 0U) ? 100U : discount.row.discount);
		}

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

		public ShopTypeTable.RowData GetShopTypeData(XSysDefine shop)
		{
			XNormalShopDocument specificDocument = XDocuments.GetSpecificDocument<XNormalShopDocument>(XNormalShopDocument.uuID);
			return specificDocument.GetShopTypeData(shop);
		}

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

		public void SendQueryGiftItems(uint type)
		{
			RpcC2M_IbGiftHistReq rpcC2M_IbGiftHistReq = new RpcC2M_IbGiftHistReq();
			rpcC2M_IbGiftHistReq.oArg.type = type;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_IbGiftHistReq);
		}

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

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("XGameMallDocument");

		private static IBShop _IBShopTable = new IBShop();

		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		public int currItemID = 0;

		public bool isNewWeekly = true;

		public List<uint> hotGoods = new List<uint>();

		public List<uint> tabNews = new List<uint>();

		public List<XSysDefine> shopRedPoint = new List<XSysDefine>();

		public bool vipTabshow = false;

		public bool presentStatus = true;

		public bool isBuying = false;

		public bool isQuerying = false;

		public List<IBGiftHistItem> presentList;

		public List<IBGiftHistItem> recvList;

		public List<CIBShop> mallItemlist = new List<CIBShop>();

		public List<CUIIBShop> mallItemUIList = new List<CUIIBShop>();

		public List<XSysDefine> ShopSystems = new List<XSysDefine>();
	}
}
