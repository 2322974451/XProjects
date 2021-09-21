using System;
using KKSG;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020009D8 RID: 2520
	internal class XPurchaseDocument : XDocComponent
	{
		// Token: 0x17002DD5 RID: 11733
		// (get) Token: 0x06009959 RID: 39257 RVA: 0x0017E908 File Offset: 0x0017CB08
		public override uint ID
		{
			get
			{
				return XPurchaseDocument.uuID;
			}
		}

		// Token: 0x0600995A RID: 39258 RVA: 0x0017E920 File Offset: 0x0017CB20
		public static void Execute(OnLoadedCallback callback = null)
		{
			XPurchaseDocument.AsyncLoader.AddTask("Table/BuyFatigue", XPurchaseDocument._BuyFatigureTable, false);
			XPurchaseDocument.AsyncLoader.AddTask("Table/BuyGold", XPurchaseDocument._BuyGoldTable, false);
			XPurchaseDocument.AsyncLoader.AddTask("Table/BuyDragonCoin", XPurchaseDocument._BuyDragonCoinTable, false);
			XPurchaseDocument.AsyncLoader.Execute(callback);
		}

		// Token: 0x0600995B RID: 39259 RVA: 0x0017E97C File Offset: 0x0017CB7C
		public void InitPurchaseInfo(BuyGoldFatInfo info)
		{
			bool flag = info != null;
			if (flag)
			{
				XPurchaseDocument._buyInfo.day = info.day;
				XPurchaseDocument._buyInfo.BuyGoldCount = info.BuyGoldCount;
				XPurchaseDocument._buyInfo.BuyFatigueCount.Clear();
				XPurchaseDocument._buyInfo.BuyDragonCoinCount = info.BuyDragonCount;
				foreach (int item in info.BuyFatigueCount)
				{
					XPurchaseDocument._buyInfo.BuyFatigueCount.Add(item);
				}
			}
			else
			{
				XPurchaseDocument._buyInfo.BuyGoldCount = 0;
				XPurchaseDocument._buyInfo.BuyDragonCoinCount = 0;
				XPurchaseDocument._buyInfo.day = 0U;
				XPurchaseDocument._buyInfo.BuyFatigueCount.Clear();
			}
		}

		// Token: 0x0600995C RID: 39260 RVA: 0x0017EA60 File Offset: 0x0017CC60
		public XPurchaseInfo GetPurchaseInfo(int level, int vip, ItemEnum type)
		{
			bool flag = type == ItemEnum.GOLD;
			if (flag)
			{
				XRechargeDocument specificDocument = XDocuments.GetSpecificDocument<XRechargeDocument>(XRechargeDocument.uuID);
				this.myPurchaseInfo.totalBuyNum = specificDocument.VIPReader.Table[vip].BuyGoldTimes;
				int num = XPurchaseDocument._buyInfo.BuyGoldCount;
				BuyGoldTable.RowData rowData = XPurchaseDocument._BuyGoldTable.Table[level - 1];
				this.myPurchaseInfo.curBuyNum = XPurchaseDocument._buyInfo.BuyGoldCount;
				this.myPurchaseInfo.GetCount = (int)rowData.Gold;
				this.myPurchaseInfo.fatigue = XPurchaseDocument._buyInfo.BuyFatigueCount;
				bool flag2 = rowData.DragonCoinCost != null;
				if (flag2)
				{
					bool flag3 = num >= rowData.DragonCoinCost.Length;
					if (flag3)
					{
						this.myPurchaseInfo.dragoncoinCost = rowData.DragonCoinCost[rowData.DragonCoinCost.Length - 1];
						this.myPurchaseInfo.diamondCost = rowData.DiamondCost[rowData.DiamondCost.Length - 1];
					}
					else
					{
						this.myPurchaseInfo.dragoncoinCost = rowData.DragonCoinCost[num];
						this.myPurchaseInfo.diamondCost = rowData.DiamondCost[num];
					}
				}
				else
				{
					XSingleton<XDebug>.singleton.AddErrorLog("data.DragonCoinCost null", null, null, null, null, null);
				}
			}
			else
			{
				bool flag4 = type == ItemEnum.FATIGUE;
				if (flag4)
				{
					XRechargeDocument specificDocument2 = XDocuments.GetSpecificDocument<XRechargeDocument>(XRechargeDocument.uuID);
					this.myPurchaseInfo.totalBuyNum = specificDocument2.VIPReader.Table[vip].BuyFatigueTimes;
					int num = 0;
					for (int i = 0; i < XPurchaseDocument._buyInfo.BuyFatigueCount.Count; i += 2)
					{
						bool flag5 = XPurchaseDocument._buyInfo.BuyFatigueCount[i] == (int)type;
						if (flag5)
						{
							num = XPurchaseDocument._buyInfo.BuyFatigueCount[i + 1];
						}
					}
					int num2 = 0;
					for (int j = 0; j < XPurchaseDocument._BuyFatigureTable.Table.Length; j++)
					{
						bool flag6 = XPurchaseDocument._BuyFatigureTable.Table[j].FatigueID == (int)type;
						if (flag6)
						{
							num2 = j;
						}
					}
					this.myPurchaseInfo.curBuyNum = num;
					this.myPurchaseInfo.GetCount = XPurchaseDocument._BuyFatigureTable.Table[num2].Value;
					bool flag7 = XPurchaseDocument._BuyFatigureTable.Table[num2].DragonCoinCost != null;
					if (flag7)
					{
						bool flag8 = num >= XPurchaseDocument._BuyFatigureTable.Table[num2].DragonCoinCost.Length;
						if (flag8)
						{
							this.myPurchaseInfo.dragoncoinCost = XPurchaseDocument._BuyFatigureTable.Table[num2].DragonCoinCost[XPurchaseDocument._BuyFatigureTable.Table[num2].DragonCoinCost.Length - 1];
							this.myPurchaseInfo.diamondCost = XPurchaseDocument._BuyFatigureTable.Table[num2].DiamondCost[XPurchaseDocument._BuyFatigureTable.Table[num2].DiamondCost.Length - 1];
						}
						else
						{
							this.myPurchaseInfo.dragoncoinCost = XPurchaseDocument._BuyFatigureTable.Table[num2].DragonCoinCost[num];
							this.myPurchaseInfo.diamondCost = XPurchaseDocument._BuyFatigureTable.Table[num2].DiamondCost[num];
						}
					}
					else
					{
						XSingleton<XDebug>.singleton.AddErrorLog("DragonCoinCost null", null, null, null, null, null);
					}
				}
				else
				{
					bool flag9 = type == ItemEnum.DRAGON_COIN;
					if (flag9)
					{
						XRechargeDocument specificDocument3 = XDocuments.GetSpecificDocument<XRechargeDocument>(XRechargeDocument.uuID);
						this.myPurchaseInfo.totalBuyNum = specificDocument3.VIPReader.Table[vip].BuyDragonCoinTimes;
						int num = XPurchaseDocument._buyInfo.BuyDragonCoinCount;
						BuyDragonCoin.RowData rowData2 = XPurchaseDocument._BuyDragonCoinTable.Table[level - 1];
						this.myPurchaseInfo.curBuyNum = XPurchaseDocument._buyInfo.BuyDragonCoinCount;
						this.myPurchaseInfo.GetCount = (int)rowData2.DragonCoin;
						bool flag10 = rowData2.DiamondCost != null;
						if (flag10)
						{
							bool flag11 = num >= rowData2.DiamondCost.Length;
							if (flag11)
							{
								this.myPurchaseInfo.diamondCost = rowData2.DiamondCost[rowData2.DiamondCost.Length - 1];
							}
							else
							{
								this.myPurchaseInfo.diamondCost = rowData2.DiamondCost[num];
							}
						}
					}
				}
			}
			return this.myPurchaseInfo;
		}

		// Token: 0x0600995D RID: 39261 RVA: 0x0017EE8C File Offset: 0x0017D08C
		public void CommonQuickBuy(ItemEnum itemid, ItemEnum useItem, uint count = 1U)
		{
			RpcC2G_BuyGoldAndFatigue rpcC2G_BuyGoldAndFatigue = new RpcC2G_BuyGoldAndFatigue();
			rpcC2G_BuyGoldAndFatigue.oArg.fatigueID = (uint)itemid;
			rpcC2G_BuyGoldAndFatigue.oArg.count = count;
			bool flag = itemid == ItemEnum.GOLD && useItem == ItemEnum.DIAMOND;
			if (flag)
			{
				rpcC2G_BuyGoldAndFatigue.oArg.type = buyextype.DIAMONE_BUY_GOLD;
			}
			else
			{
				bool flag2 = itemid == ItemEnum.GOLD && useItem == ItemEnum.DRAGON_COIN;
				if (flag2)
				{
					rpcC2G_BuyGoldAndFatigue.oArg.type = buyextype.DRAGONCOIN_BUY_GOLD;
				}
				else
				{
					bool flag3 = itemid == ItemEnum.FATIGUE && useItem == ItemEnum.DIAMOND;
					if (flag3)
					{
						rpcC2G_BuyGoldAndFatigue.oArg.type = buyextype.DIAMOND_BUY_FATIGUE;
					}
					else
					{
						bool flag4 = itemid == ItemEnum.FATIGUE && useItem == ItemEnum.DRAGON_COIN;
						if (flag4)
						{
							rpcC2G_BuyGoldAndFatigue.oArg.type = buyextype.DRAGON_BUY_FATIGUE;
						}
						else
						{
							bool flag5 = itemid == ItemEnum.DRAGON_COIN && useItem == ItemEnum.DIAMOND;
							if (flag5)
							{
								rpcC2G_BuyGoldAndFatigue.oArg.type = buyextype.DIAMONE_BUY_DRAGONCOIN;
							}
							else
							{
								bool flag6 = itemid == ItemEnum.CHAT_LANNIAO && useItem == ItemEnum.DRAGON_COIN;
								if (flag6)
								{
									rpcC2G_BuyGoldAndFatigue.oArg.type = buyextype.DRAGONCOIN_BUY_BLUEBIRD;
								}
							}
						}
					}
				}
			}
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_BuyGoldAndFatigue);
		}

		// Token: 0x0600995E RID: 39262 RVA: 0x0017EF94 File Offset: 0x0017D194
		public void CommonQuickBuyRandom(ItemEnum itemid, ItemEnum usrItem, uint count)
		{
			RpcC2G_BuyGoldAndFatigue rpcC2G_BuyGoldAndFatigue = new RpcC2G_BuyGoldAndFatigue();
			rpcC2G_BuyGoldAndFatigue.oArg.fatigueID = (uint)XFastEnumIntEqualityComparer<ItemEnum>.ToInt(itemid);
			rpcC2G_BuyGoldAndFatigue.oArg.count = count;
			bool flag = itemid == ItemEnum.DRAGON_COIN && usrItem == ItemEnum.DIAMOND;
			if (flag)
			{
				rpcC2G_BuyGoldAndFatigue.oArg.type = buyextype.DIAMOND_EXCHANGE_DRAGONCOIN;
			}
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_BuyGoldAndFatigue);
		}

		// Token: 0x0600995F RID: 39263 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		// Token: 0x0400349C RID: 13468
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("XPurchaseDocument");

		// Token: 0x0400349D RID: 13469
		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		// Token: 0x0400349E RID: 13470
		private static BuyFatigueTable _BuyFatigureTable = new BuyFatigueTable();

		// Token: 0x0400349F RID: 13471
		private static BuyGoldTable _BuyGoldTable = new BuyGoldTable();

		// Token: 0x040034A0 RID: 13472
		public XPurchaseInfo myPurchaseInfo = new XPurchaseInfo();

		// Token: 0x040034A1 RID: 13473
		public XPurchaseView PurchaseView;

		// Token: 0x040034A2 RID: 13474
		private static BuyDragonCoin _BuyDragonCoinTable = new BuyDragonCoin();

		// Token: 0x040034A3 RID: 13475
		public static PurchaseInfo _buyInfo = new PurchaseInfo();
	}
}
