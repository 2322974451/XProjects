using System;
using System.Collections.Generic;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000986 RID: 2438
	internal class XItemRequiredCollector
	{
		// Token: 0x17002CA3 RID: 11427
		// (get) Token: 0x06009295 RID: 37525 RVA: 0x00153400 File Offset: 0x00151600
		public List<XItemRequired> RequiredItems
		{
			get
			{
				return this.m_RequiredItems;
			}
		}

		// Token: 0x06009296 RID: 37526 RVA: 0x00153418 File Offset: 0x00151618
		public void Init()
		{
			this.InitRequired();
			this.InitOwned();
		}

		// Token: 0x06009297 RID: 37527 RVA: 0x0015342C File Offset: 0x0015162C
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

		// Token: 0x06009298 RID: 37528 RVA: 0x00153494 File Offset: 0x00151694
		public void InitRequired()
		{
			for (int i = 0; i < this.m_RequiredItems.Count; i++)
			{
				this.m_RequiredItems[i].Recycle();
			}
			this.m_RequiredItems.Clear();
		}

		// Token: 0x06009299 RID: 37529 RVA: 0x001534DC File Offset: 0x001516DC
		public void InitOwned()
		{
			for (int i = 0; i < this.m_OwnedItems.Count; i++)
			{
				this.m_OwnedItems[i].Recycle();
			}
			this.m_OwnedItems.Clear();
		}

		// Token: 0x0600929A RID: 37530 RVA: 0x00153524 File Offset: 0x00151724
		public void PreserveOwned(int itemID)
		{
			this.GetOwnedItem(itemID);
		}

		// Token: 0x0600929B RID: 37531 RVA: 0x00153530 File Offset: 0x00151730
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

		// Token: 0x0600929C RID: 37532 RVA: 0x001535C8 File Offset: 0x001517C8
		public void GetRequiredItems(ref SeqListRef<uint> tableData, float param = 1f)
		{
			for (int i = 0; i < tableData.Count; i++)
			{
				this.GetRequiredItem(tableData[i, 0], (ulong)tableData[i, 1], param);
			}
		}

		// Token: 0x0600929D RID: 37533 RVA: 0x00153608 File Offset: 0x00151808
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

		// Token: 0x0600929E RID: 37534 RVA: 0x001536DC File Offset: 0x001518DC
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

		// Token: 0x0600929F RID: 37535 RVA: 0x00153734 File Offset: 0x00151934
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

		// Token: 0x060092A0 RID: 37536 RVA: 0x00153780 File Offset: 0x00151980
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

		// Token: 0x060092A1 RID: 37537 RVA: 0x001537D0 File Offset: 0x001519D0
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

		// Token: 0x17002CA4 RID: 11428
		// (get) Token: 0x060092A2 RID: 37538 RVA: 0x00153860 File Offset: 0x00151A60
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

		// Token: 0x04003126 RID: 12582
		private List<XItemRequired> m_RequiredItems = new List<XItemRequired>();

		// Token: 0x04003127 RID: 12583
		private List<XItemRequired> m_OwnedItems = new List<XItemRequired>();
	}
}
