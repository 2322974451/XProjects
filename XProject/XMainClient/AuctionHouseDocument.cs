using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020008D0 RID: 2256
	internal class AuctionHouseDocument : XDocComponent
	{
		// Token: 0x17002AA4 RID: 10916
		// (get) Token: 0x06008871 RID: 34929 RVA: 0x0011A85C File Offset: 0x00118A5C
		public override uint ID
		{
			get
			{
				return AuctionHouseDocument.uuID;
			}
		}

		// Token: 0x17002AA5 RID: 10917
		// (get) Token: 0x06008872 RID: 34930 RVA: 0x0011A874 File Offset: 0x00118A74
		public GuildAuctReward GuildAuctRewardReader
		{
			get
			{
				return AuctionHouseDocument._guildAuctRewardReader;
			}
		}

		// Token: 0x17002AA6 RID: 10918
		// (get) Token: 0x06008873 RID: 34931 RVA: 0x0011A88C File Offset: 0x00118A8C
		public List<GASaleItem> ItemList
		{
			get
			{
				return this._itemList;
			}
		}

		// Token: 0x17002AA7 RID: 10919
		// (get) Token: 0x06008874 RID: 34932 RVA: 0x0011A8A4 File Offset: 0x00118AA4
		public List<GASaleHistory> HistoryList
		{
			get
			{
				return this._historyList;
			}
		}

		// Token: 0x06008875 RID: 34933 RVA: 0x0011A8BC File Offset: 0x00118ABC
		public static void Execute(OnLoadedCallback callback = null)
		{
			AuctionHouseDocument.AsyncLoader.AddTask("Table/GuildAuctReward", AuctionHouseDocument._guildAuctRewardReader, false);
			AuctionHouseDocument.AsyncLoader.Execute(callback);
		}

		// Token: 0x06008876 RID: 34934 RVA: 0x0011A8E1 File Offset: 0x00118AE1
		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
			this.GuildSaleTime = XSingleton<XGlobalConfig>.singleton.GetInt("GuildAuctGuildSaleTime");
			this.PublicityTime = XSingleton<XGlobalConfig>.singleton.GetInt("GuildAuctGuildItemPublicityTime");
		}

		// Token: 0x06008877 RID: 34935 RVA: 0x0011A918 File Offset: 0x00118B18
		public void QueryGuildTypeList(int type)
		{
			RpcC2M_GuildAuctReqAll rpcC2M_GuildAuctReqAll = new RpcC2M_GuildAuctReqAll();
			rpcC2M_GuildAuctReqAll.oArg.reqtype = GuildAuctReqType.GART_ACT_TYPE;
			rpcC2M_GuildAuctReqAll.oArg.acttype = type;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_GuildAuctReqAll);
		}

		// Token: 0x06008878 RID: 34936 RVA: 0x0011A954 File Offset: 0x00118B54
		public void QueryWorldTypeList(int type)
		{
			RpcC2M_GuildAuctReqAll rpcC2M_GuildAuctReqAll = new RpcC2M_GuildAuctReqAll();
			rpcC2M_GuildAuctReqAll.oArg.reqtype = GuildAuctReqType.GART_ITEM_TYPE;
			rpcC2M_GuildAuctReqAll.oArg.itemtype = type;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_GuildAuctReqAll);
		}

		// Token: 0x06008879 RID: 34937 RVA: 0x0011A990 File Offset: 0x00118B90
		public void QueryAuctionItem(ulong uid, uint curPrice, int actType)
		{
			RpcC2M_GuildAuctReqAll rpcC2M_GuildAuctReqAll = new RpcC2M_GuildAuctReqAll();
			rpcC2M_GuildAuctReqAll.oArg.reqtype = GuildAuctReqType.GART_BUY_AUCT;
			rpcC2M_GuildAuctReqAll.oArg.uid = uid;
			rpcC2M_GuildAuctReqAll.oArg.curauctprice = curPrice;
			rpcC2M_GuildAuctReqAll.oArg.acttype = actType;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_GuildAuctReqAll);
		}

		// Token: 0x0600887A RID: 34938 RVA: 0x0011A9E4 File Offset: 0x00118BE4
		public void QueryBuyItem(ulong uid, int actType)
		{
			RpcC2M_GuildAuctReqAll rpcC2M_GuildAuctReqAll = new RpcC2M_GuildAuctReqAll();
			rpcC2M_GuildAuctReqAll.oArg.reqtype = GuildAuctReqType.GART_BUY_NOW;
			rpcC2M_GuildAuctReqAll.oArg.uid = uid;
			rpcC2M_GuildAuctReqAll.oArg.acttype = actType;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_GuildAuctReqAll);
		}

		// Token: 0x0600887B RID: 34939 RVA: 0x0011AA2C File Offset: 0x00118C2C
		public void QueryAuctionHistory(bool guild)
		{
			RpcC2M_GuildAuctReqAll rpcC2M_GuildAuctReqAll = new RpcC2M_GuildAuctReqAll();
			if (guild)
			{
				rpcC2M_GuildAuctReqAll.oArg.reqtype = GuildAuctReqType.GART_AUCT_GUILD_HISTORY;
			}
			else
			{
				rpcC2M_GuildAuctReqAll.oArg.reqtype = GuildAuctReqType.GART_AUCT_WORLD_HISTORY;
			}
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_GuildAuctReqAll);
		}

		// Token: 0x0600887C RID: 34940 RVA: 0x0011AA70 File Offset: 0x00118C70
		public void OnServerReturn(GuildAuctReqArg arg, GuildAuctReqRes data)
		{
			switch (arg.reqtype)
			{
			case GuildAuctReqType.GART_ACT_TYPE:
			case GuildAuctReqType.GART_ITEM_TYPE:
			{
				this.MySpoils = data.profit;
				this._itemList.Clear();
				this.ReqTime = -1;
				for (int i = 0; i < data.saleitems.Count; i++)
				{
					bool flag = !data.saleitems[i].display;
					if (!flag)
					{
						bool flag2 = this.ReqTime == -1 || (ulong)data.saleitems[i].lefttime < (ulong)((long)this.ReqTime);
						if (flag2)
						{
							this.ReqTime = (int)data.saleitems[i].lefttime;
						}
						else
						{
							int num = this.PublicityTime - this.GuildSaleTime + (int)data.saleitems[i].lefttime;
							bool flag3 = arg.reqtype == GuildAuctReqType.GART_ACT_TYPE && num > 0 && num < this.ReqTime;
							if (flag3)
							{
								this.ReqTime = num;
							}
						}
						GASaleItem gasaleItem = new GASaleItem();
						gasaleItem.uid = data.saleitems[i].uid;
						gasaleItem.acttype = data.saleitems[i].acttype;
						gasaleItem.itemid = data.saleitems[i].itemid;
						gasaleItem.auctroleid = data.saleitems[i].auctroleid;
						gasaleItem.curauctprice = data.saleitems[i].curauctprice;
						gasaleItem.maxprice = data.saleitems[i].maxprice;
						gasaleItem.lefttime = data.saleitems[i].lefttime;
						this._itemList.Add(gasaleItem);
					}
				}
				bool flag4 = this.ReqTime != -1 && this.ReqTime < 2;
				if (flag4)
				{
					this.ReqTime = 2;
				}
				bool flag5 = arg.reqtype == GuildAuctReqType.GART_ACT_TYPE;
				if (flag5)
				{
					bool flag6 = arg.acttype == 0;
					if (flag6)
					{
						this.GuildActID.Clear();
						HashSet<int> hashSet = HashPool<int>.Get();
						for (int j = 0; j < data.saleitems.Count; j++)
						{
							bool flag7 = !hashSet.Contains(data.saleitems[j].acttype);
							if (flag7)
							{
								hashSet.Add(data.saleitems[j].acttype);
								this.GuildActID.Add(data.saleitems[j].acttype);
							}
						}
						HashPool<int>.Release(hashSet);
					}
				}
				break;
			}
			case GuildAuctReqType.GART_BUY_AUCT:
			case GuildAuctReqType.GART_BUY_NOW:
				this.MySpoils = data.profit;
				for (int k = 0; k < this._itemList.Count; k++)
				{
					bool flag8 = this._itemList[k].uid == arg.uid;
					if (flag8)
					{
						bool flag9 = arg.reqtype == GuildAuctReqType.GART_BUY_AUCT;
						if (flag9)
						{
							bool flag10 = data.errorcode == ErrorCode.ERR_SUCCESS;
							if (flag10)
							{
								this._itemList[k].curauctprice = data.curauctprice;
								this._itemList[k].auctroleid = XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID;
							}
							else
							{
								bool flag11 = data.errorcode == ErrorCode.ERR_AUCT_ITEMSALED;
								if (flag11)
								{
									this._itemList.RemoveAt(k);
								}
								else
								{
									bool flag12 = data.errorcode == ErrorCode.ERR_AUCT_PRICECHAGE;
									if (flag12)
									{
										this._itemList[k].curauctprice = data.curauctprice;
									}
								}
							}
						}
						else
						{
							bool flag13 = data.errorcode == ErrorCode.ERR_SUCCESS;
							if (flag13)
							{
								this._itemList.RemoveAt(k);
							}
							else
							{
								bool flag14 = data.errorcode == ErrorCode.ERR_AUCT_ITEMSALED;
								if (flag14)
								{
									this._itemList.RemoveAt(k);
								}
							}
						}
					}
				}
				break;
			case GuildAuctReqType.GART_AUCT_GUILD_HISTORY:
			case GuildAuctReqType.GART_AUCT_WORLD_HISTORY:
				this._historyList.Clear();
				for (int l = 0; l < data.salehistorys.Count; l++)
				{
					GASaleHistory gasaleHistory = new GASaleHistory();
					gasaleHistory.acttype = data.salehistorys[l].acttype;
					gasaleHistory.saletime = data.salehistorys[l].saletime;
					gasaleHistory.itemid = data.salehistorys[l].itemid;
					gasaleHistory.saleprice = data.salehistorys[l].saleprice;
					gasaleHistory.auctresult = data.salehistorys[l].auctresult;
					this._historyList.Add(gasaleHistory);
				}
				this._historyList.Sort(new Comparison<GASaleHistory>(this.Compare));
				break;
			}
			this.DataState = arg.reqtype;
			bool flag15 = DlgBase<AuctionView, AuctionBehaviour>.singleton.IsVisible();
			if (flag15)
			{
				DlgBase<AuctionView, AuctionBehaviour>.singleton.RefreshData();
			}
		}

		// Token: 0x0600887D RID: 34941 RVA: 0x0011AFB4 File Offset: 0x001191B4
		public void QueryRefreshUI()
		{
			bool flag = DlgBase<AuctionView, AuctionBehaviour>.singleton.IsVisible();
			if (flag)
			{
				bool flag2 = this.LastReq < 100;
				if (flag2)
				{
					this.QueryGuildTypeList(this.LastReq);
				}
				else
				{
					this.QueryWorldTypeList(this.LastReq - 100);
				}
			}
		}

		// Token: 0x0600887E RID: 34942 RVA: 0x0011B004 File Offset: 0x00119204
		public void QueryRefreshGuildUI(int actType)
		{
			bool flag = !DlgBase<AuctionView, AuctionBehaviour>.singleton.IsVisible();
			if (!flag)
			{
				bool flag2 = this.LastReq == actType || this.LastReq == 0;
				if (flag2)
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("AuctionHouseTimeFreshTips"), "fece00");
					this.QueryRefreshUI();
				}
			}
		}

		// Token: 0x0600887F RID: 34943 RVA: 0x0011B064 File Offset: 0x00119264
		public List<GuildAuctReward.RowData> GetGuildAuctReward(AuctionActType actType)
		{
			List<GuildAuctReward.RowData> list = new List<GuildAuctReward.RowData>();
			for (int i = 0; i < AuctionHouseDocument._guildAuctRewardReader.Table.Length; i++)
			{
				GuildAuctReward.RowData rowData = AuctionHouseDocument._guildAuctRewardReader.Table[i];
				bool flag = (AuctionActType)rowData.ActType == actType;
				if (flag)
				{
					list.Add(rowData);
				}
			}
			return list;
		}

		// Token: 0x06008880 RID: 34944 RVA: 0x0011B0C4 File Offset: 0x001192C4
		private int Compare(GASaleHistory x, GASaleHistory y)
		{
			return (int)(y.saletime - x.saletime);
		}

		// Token: 0x06008881 RID: 34945 RVA: 0x0011B0E3 File Offset: 0x001192E3
		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
			this.QueryRefreshUI();
		}

		// Token: 0x04002B1E RID: 11038
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("AuctionHouseDocument");

		// Token: 0x04002B1F RID: 11039
		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		// Token: 0x04002B20 RID: 11040
		public List<int> GuildActID = new List<int>();

		// Token: 0x04002B21 RID: 11041
		public GuildAuctReqType DataState;

		// Token: 0x04002B22 RID: 11042
		private static GuildAuctReward _guildAuctRewardReader = new GuildAuctReward();

		// Token: 0x04002B23 RID: 11043
		private List<GASaleItem> _itemList = new List<GASaleItem>();

		// Token: 0x04002B24 RID: 11044
		private List<GASaleHistory> _historyList = new List<GASaleHistory>();

		// Token: 0x04002B25 RID: 11045
		public uint MySpoils = 0U;

		// Token: 0x04002B26 RID: 11046
		public int LastReq = 0;

		// Token: 0x04002B27 RID: 11047
		public int ReqTime;

		// Token: 0x04002B28 RID: 11048
		public int GuildSaleTime;

		// Token: 0x04002B29 RID: 11049
		public int PublicityTime;

		// Token: 0x04002B2A RID: 11050
		public bool ResetScrollView = false;
	}
}
