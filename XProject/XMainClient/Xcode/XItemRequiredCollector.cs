using System;
using System.Collections.Generic;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XItemRequiredCollector
	{

		public List<XItemRequired> RequiredItems
		{
			get
			{
				return this.m_RequiredItems;
			}
		}

		public void Init()
		{
			this.InitRequired();
			this.InitOwned();
		}

		public void ReturnNotEnoughItems()
		{
			bool bItemsEnough = this.bItemsEnough;
			if (!bItemsEnough)
			{
				for (int i = 0; i < this.m_RequiredItems.Count; i++)
				{
					XItemRequired xitemRequired = this.m_RequiredItems[i];
					XItemRequired ownedItem = this.GetOwnedItem(xitemRequired.itemID);
					ownedItem.ownedCount += xitemRequired.requiredCount;
				}
			}
		}

		public void InitRequired()
		{
			for (int i = 0; i < this.m_RequiredItems.Count; i++)
			{
				this.m_RequiredItems[i].Recycle();
			}
			this.m_RequiredItems.Clear();
		}

		public void InitOwned()
		{
			for (int i = 0; i < this.m_OwnedItems.Count; i++)
			{
				this.m_OwnedItems[i].Recycle();
			}
			this.m_OwnedItems.Clear();
		}

		public void PreserveOwned(int itemID)
		{
			this.GetOwnedItem(itemID);
		}

		public XItemRequired GetRequiredItem(uint itemid, ulong itemcount, float param = 1f)
		{
			ItemList.RowData itemConf = XBagDocument.GetItemConf((int)itemid);
			bool flag = itemConf == null;
			XItemRequired result;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddErrorLog("Cant find required item id ", itemid.ToString(), null, null, null, null);
				result = null;
			}
			else
			{
				XItemRequired data = XDataPool<XItemRequired>.GetData();
				this.m_RequiredItems.Add(data);
				data.itemID = (int)itemid;
				data.requiredCount = (ulong)(itemcount * param);
				XItemRequired ownedItem = this.GetOwnedItem(data.itemID);
				data.ownedCount = ownedItem.ownedCount;
				ownedItem.ownedCount -= data.requiredCount;
				result = data;
			}
			return result;
		}

		public void GetRequiredItems(ref SeqListRef<uint> tableData, float param = 1f)
		{
			for (int i = 0; i < tableData.Count; i++)
			{
				this.GetRequiredItem(tableData[i, 0], (ulong)tableData[i, 1], param);
			}
		}

		public void Merge()
		{
			Dictionary<int, XItemRequired> dictionary = new Dictionary<int, XItemRequired>();
			for (int i = 0; i < this.m_RequiredItems.Count; i++)
			{
				XItemRequired xitemRequired = this.m_RequiredItems[i];
				XItemRequired xitemRequired2;
				bool flag = dictionary.TryGetValue(xitemRequired.itemID, out xitemRequired2);
				if (flag)
				{
					xitemRequired2.requiredCount += xitemRequired.requiredCount;
					xitemRequired.Recycle();
				}
				else
				{
					this.m_RequiredItems[dictionary.Count] = xitemRequired;
					dictionary.Add(xitemRequired.itemID, xitemRequired);
				}
			}
			bool flag2 = dictionary.Count < this.m_RequiredItems.Count;
			if (flag2)
			{
				this.m_RequiredItems.RemoveRange(dictionary.Count, this.m_RequiredItems.Count - dictionary.Count);
			}
		}

		public XItemRequired GetItem(int itemid)
		{
			for (int i = 0; i < this.m_RequiredItems.Count; i++)
			{
				bool flag = this.m_RequiredItems[i].itemID == itemid;
				if (flag)
				{
					return this.m_RequiredItems[i];
				}
			}
			return null;
		}

		public bool HasOwnedItem(int itemID)
		{
			for (int i = 0; i < this.m_OwnedItems.Count; i++)
			{
				bool flag = this.m_OwnedItems[i].itemID == itemID;
				if (flag)
				{
					return true;
				}
			}
			return false;
		}

		public void SetNewOwnedItem(int itemID, ulong count)
		{
			bool flag = this.HasOwnedItem(itemID);
			if (!flag)
			{
				ItemList.RowData itemConf = XBagDocument.GetItemConf(itemID);
				bool flag2 = itemConf == null;
				if (!flag2)
				{
					XItemRequired data = XDataPool<XItemRequired>.GetData();
					data.itemID = itemID;
					data.ownedCount = count;
					this.m_OwnedItems.Add(data);
				}
			}
		}

		public XItemRequired GetOwnedItem(int itemID)
		{
			for (int i = 0; i < this.m_OwnedItems.Count; i++)
			{
				bool flag = this.m_OwnedItems[i].itemID == itemID;
				if (flag)
				{
					return this.m_OwnedItems[i];
				}
			}
			XItemRequired data = XDataPool<XItemRequired>.GetData();
			data.itemID = itemID;
			data.ownedCount = XSingleton<XGame>.singleton.Doc.XBagDoc.GetItemCount(itemID);
			this.m_OwnedItems.Add(data);
			return data;
		}

		public bool bItemsEnough
		{
			get
			{
				for (int i = 0; i < this.m_RequiredItems.Count; i++)
				{
					bool flag = !this.m_RequiredItems[i].bEnough;
					if (flag)
					{
						return false;
					}
				}
				return true;
			}
		}

		private List<XItemRequired> m_RequiredItems = new List<XItemRequired>();

		private List<XItemRequired> m_OwnedItems = new List<XItemRequired>();
	}
}
