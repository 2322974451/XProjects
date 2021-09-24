using System;
using KKSG;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XNormalShopGoods
	{

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

		public static XNormalShopGoods MakeGoodsFromData(ShopItem data)
		{
			XNormalShopGoods xnormalShopGoods = new XNormalShopGoods();
			xnormalShopGoods.UpdateData(data);
			return xnormalShopGoods;
		}

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

		public static XNormalShopGoods MakeGoodsFromData(PartnerShopItemClient data)
		{
			XNormalShopGoods xnormalShopGoods = new XNormalShopGoods();
			xnormalShopGoods.UpdateData(data);
			return xnormalShopGoods;
		}

		public static XNormalShopGoods MakeGoodsFromData(DragonGuildShopItemClient data)
		{
			XNormalShopGoods xnormalShopGoods = new XNormalShopGoods();
			xnormalShopGoods.UpdateData(data);
			return xnormalShopGoods;
		}

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

		public XItem item;

		public int priceType;

		public int priceValue;

		public int soldNum;

		public int totalSoldNum;

		public int needLevel;

		public bool isLevelEnough;

		public uint weeklyBuyCount;
	}
}
