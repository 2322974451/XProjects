using System;
using KKSG;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000D3F RID: 3391
	internal class XNormalShopGoods
	{
		// Token: 0x0600BBEA RID: 48106 RVA: 0x0026B16C File Offset: 0x0026936C
		public void UpdateData(ShopItem data)
		{
			this.item = XBagDocument.MakeXItem(data.Item);
			ShopTable.RowData dataById = XNormalShopDocument.GetDataById((uint)data.Item.uid);
			bool flag = dataById != null;
			if (flag)
			{
				this.priceType = (int)dataById.ConsumeItem[0];
				this.priceValue = (int)dataById.ConsumeItem[1];
				this.soldNum = (int)data.dailybuycount;
				this.totalSoldNum = (int)data.buycount;
				this.weeklyBuyCount = data.weekbuycount;
				this.needLevel = (int)dataById.LevelCondition;
				this.SetLevelCondition(dataById.Type, (uint)dataById.LevelCondition);
			}
		}

		// Token: 0x0600BBEB RID: 48107 RVA: 0x0026B210 File Offset: 0x00269410
		public static XNormalShopGoods MakeGoodsFromData(ShopItem data)
		{
			XNormalShopGoods xnormalShopGoods = new XNormalShopGoods();
			xnormalShopGoods.UpdateData(data);
			return xnormalShopGoods;
		}

		// Token: 0x0600BBEC RID: 48108 RVA: 0x0026B234 File Offset: 0x00269434
		public void UpdateData(PartnerShopItemClient data)
		{
			ShopTable.RowData dataById = XNormalShopDocument.GetDataById(data.id);
			bool flag = dataById == null;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddErrorLog("not find this shopItem,shopid is :" + data.id, null, null, null, null, null);
			}
			else
			{
				ItemList.RowData itemConf = XBagDocument.GetItemConf((int)dataById.ItemId);
				bool flag2 = itemConf == null;
				if (flag2)
				{
					XSingleton<XDebug>.singleton.AddErrorLog("not find this item,shopid is :" + data.id, "itemid is :" + dataById.ItemId, null, null, null, null);
				}
				else
				{
					bool flag3 = itemConf.ItemType == 1;
					int itemID;
					if (flag3)
					{
						itemID = XBagDocument.ConvertTemplate(itemConf);
					}
					else
					{
						itemID = itemConf.ItemID;
					}
					this.item = XBagDocument.MakeXItem(itemID, dataById.IsNotBind);
					this.item.uid = (ulong)data.id;
					this.item.itemCount = 0;
					this.priceType = (int)dataById.ConsumeItem[0];
					this.priceValue = (int)dataById.ConsumeItem[1];
					this.soldNum = (int)data.buy_count;
					this.totalSoldNum = (int)dataById.DailyCountCondition;
					this.weeklyBuyCount = (uint)dataById.WeekCountCondition;
					this.needLevel = (int)dataById.LevelCondition;
					this.SetLevelCondition(dataById.Type, (uint)dataById.LevelCondition);
				}
			}
		}

		// Token: 0x0600BBED RID: 48109 RVA: 0x0026B390 File Offset: 0x00269590
		public void UpdateData(DragonGuildShopItemClient data)
		{
			ShopTable.RowData dataById = XNormalShopDocument.GetDataById(data.id);
			bool flag = dataById == null;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddErrorLog("not find this shopItem,shopid is :" + data.id, null, null, null, null, null);
			}
			else
			{
				ItemList.RowData itemConf = XBagDocument.GetItemConf((int)dataById.ItemId);
				bool flag2 = itemConf == null;
				if (flag2)
				{
					XSingleton<XDebug>.singleton.AddErrorLog("not find this item,shopid is :" + data.id, "itemid is :" + dataById.ItemId, null, null, null, null);
				}
				else
				{
					bool flag3 = itemConf.ItemType == 1;
					int itemID;
					if (flag3)
					{
						itemID = XBagDocument.ConvertTemplate(itemConf);
					}
					else
					{
						itemID = itemConf.ItemID;
					}
					this.item = XBagDocument.MakeXItem(itemID, dataById.IsNotBind);
					this.item.uid = (ulong)data.id;
					this.item.itemCount = 0;
					this.priceType = (int)dataById.ConsumeItem[0];
					this.priceValue = (int)dataById.ConsumeItem[1];
					this.soldNum = (int)data.buy_count;
					this.totalSoldNum = (int)dataById.DailyCountCondition;
					this.weeklyBuyCount = (uint)dataById.WeekCountCondition;
					this.needLevel = (int)dataById.LevelCondition;
					this.SetLevelCondition(dataById.Type, (uint)dataById.LevelCondition);
				}
			}
		}

		// Token: 0x0600BBEE RID: 48110 RVA: 0x0026B4EC File Offset: 0x002696EC
		public static XNormalShopGoods MakeGoodsFromData(PartnerShopItemClient data)
		{
			XNormalShopGoods xnormalShopGoods = new XNormalShopGoods();
			xnormalShopGoods.UpdateData(data);
			return xnormalShopGoods;
		}

		// Token: 0x0600BBEF RID: 48111 RVA: 0x0026B510 File Offset: 0x00269710
		public static XNormalShopGoods MakeGoodsFromData(DragonGuildShopItemClient data)
		{
			XNormalShopGoods xnormalShopGoods = new XNormalShopGoods();
			xnormalShopGoods.UpdateData(data);
			return xnormalShopGoods;
		}

		// Token: 0x0600BBF0 RID: 48112 RVA: 0x0026B534 File Offset: 0x00269734
		private void SetLevelCondition(uint type, uint level)
		{
			bool flag = type == 20U;
			if (flag)
			{
				this.isLevelEnough = (XPartnerDocument.Doc.CurPartnerLevel >= level);
			}
			else
			{
				this.isLevelEnough = (XSingleton<XAttributeMgr>.singleton.XPlayerData.Level >= level);
			}
		}

		// Token: 0x04004C36 RID: 19510
		public XItem item;

		// Token: 0x04004C37 RID: 19511
		public int priceType;

		// Token: 0x04004C38 RID: 19512
		public int priceValue;

		// Token: 0x04004C39 RID: 19513
		public int soldNum;

		// Token: 0x04004C3A RID: 19514
		public int totalSoldNum;

		// Token: 0x04004C3B RID: 19515
		public int needLevel;

		// Token: 0x04004C3C RID: 19516
		public bool isLevelEnough;

		// Token: 0x04004C3D RID: 19517
		public uint weeklyBuyCount;
	}
}
