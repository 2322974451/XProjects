using System;
using System.Collections.Generic;

namespace XMainClient
{

	internal class XNewItemTipsMgr
	{

		public HashSet<ulong> NewItems
		{
			get
			{
				return this._NewItems;
			}
		}

		public XItemFilter Filter
		{
			get
			{
				return this._Filter;
			}
		}

		public bool bCanClear { get; set; }

		public void ClearItemType()
		{
			this.Clear();
			this._Filter.Clear();
			this.bCanClear = false;
		}

		public bool AddItem(XItem item, bool bDontSave = false)
		{
			bool flag = this._Filter.Contains(item.Type);
			bool result;
			if (flag)
			{
				bool flag2 = !bDontSave;
				if (flag2)
				{
					this._NewItems.Add(item.uid);
				}
				result = true;
			}
			else
			{
				result = false;
			}
			return result;
		}

		public bool AddItems(List<XItem> items, bool bDontSave = false)
		{
			bool flag = false;
			for (int i = 0; i < items.Count; i++)
			{
				flag = (this.AddItem(items[i], bDontSave) || flag);
			}
			return flag;
		}

		public bool RemoveItem(ulong uid, ItemType type, bool bConsiderFilter = false)
		{
			bool flag = this._Filter.Contains(type);
			return flag && (this._NewItems.Remove(uid) || bConsiderFilter);
		}

		public bool RemoveItems(List<ulong> items, List<ItemType> types, bool bConsiderFilter = true)
		{
			bool flag = false;
			for (int i = 0; i < items.Count; i++)
			{
				flag = (this.RemoveItem(items[i], types[i], bConsiderFilter) || flag);
			}
			return flag;
		}

		public void TryClear()
		{
			bool bCanClear = this.bCanClear;
			if (bCanClear)
			{
				this.Clear();
			}
		}

		public void Clear()
		{
			this._NewItems.Clear();
			this.bCanClear = false;
		}

		public bool IsNew(ulong uid)
		{
			return this._NewItems.Contains(uid);
		}

		public bool bHasNew
		{
			get
			{
				return this._NewItems.Count > 0;
			}
		}

		private HashSet<ulong> _NewItems = new HashSet<ulong>();

		private XItemFilter _Filter = new XItemFilter();
	}
}
