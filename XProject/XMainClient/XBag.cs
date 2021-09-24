using System;
using System.Collections.Generic;

namespace XMainClient
{

	internal class XBag
	{

		public XItem this[int key]
		{
			get
			{
				return this.Items[key];
			}
			set
			{
				this.Items[key] = value;
			}
		}

		public int Count
		{
			get
			{
				return this.Items.Count;
			}
		}

		public void Clear()
		{
			this.Items.Clear();
		}

		public void AddItem(XItem item, bool bSort)
		{
			this.Items.Add(item);
			if (bSort)
			{
				this.SortItem();
			}
		}

		public void RemoveItem(ulong uid)
		{
			int index;
			bool flag = this.FindItem(uid, out index);
			if (flag)
			{
				this.Items.RemoveAt(index);
			}
		}

		public void RemoveIndex(int index)
		{
			this.Items.RemoveAt(index);
		}

		public bool FindItem(ulong uid, out int index)
		{
			for (int i = 0; i < this.Items.Count; i++)
			{
				bool flag = this.Items[i].uid == uid;
				if (flag)
				{
					index = i;
					return true;
				}
			}
			index = -1;
			return false;
		}

		public bool FindItemByID(int id, out List<int> index)
		{
			this._TempIndexList.Clear();
			index = this._TempIndexList;
			for (int i = 0; i < this.Items.Count; i++)
			{
				bool flag = this.Items[i].itemID == id;
				if (flag)
				{
					index.Add(i);
				}
			}
			bool flag2 = index.Count == 0;
			return !flag2;
		}

		public bool FindItemByID(int id, out List<XItem> lst)
		{
			this._tempItemList.Clear();
			lst = this._tempItemList;
			for (int i = 0; i < this.Items.Count; i++)
			{
				bool flag = this.Items[i].itemID == id;
				if (flag)
				{
					lst.Add(this.Items[i]);
				}
			}
			bool flag2 = lst.Count == 0;
			return !flag2;
		}

		public int GetItemCount(int id)
		{
			int num = 0;
			for (int i = 0; i < this.Items.Count; i++)
			{
				bool flag = this.Items[i].itemID == id;
				if (flag)
				{
					num += this.Items[i].itemCount;
				}
			}
			return num;
		}

		public int GetItemCountByUid(ulong uid)
		{
			int result = 0;
			for (int i = 0; i < this.Items.Count; i++)
			{
				bool flag = this.Items[i].uid == uid;
				if (flag)
				{
					result = this.Items[i].itemCount;
					break;
				}
			}
			return result;
		}

		public int GetItemCount(int id, bool isBind)
		{
			int num = 0;
			for (int i = 0; i < this.Items.Count; i++)
			{
				bool flag = this.Items[i].itemID == id && this.Items[i].bBinding == isBind;
				if (flag)
				{
					num += this.Items[i].itemCount;
				}
			}
			return num;
		}

		public void SortItem()
		{
			this.Items.Sort(new Comparison<XItem>(XBag.ItemSortCompare));
		}

		private static int ItemSortCompare(XItem item1, XItem item2)
		{
			bool flag = item1.itemConf == null;
			int result;
			if (flag)
			{
				result = 1;
			}
			else
			{
				bool flag2 = item2.itemConf == null;
				if (flag2)
				{
					result = -1;
				}
				else
				{
					bool flag3 = item1.itemConf.SortID == item2.itemConf.SortID;
					if (flag3)
					{
						result = -item1.uid.CompareTo(item2.uid);
					}
					else
					{
						result = -item1.itemConf.SortID.CompareTo(item2.itemConf.SortID);
					}
				}
			}
			return result;
		}

		private List<XItem> Items = new List<XItem>();

		private List<int> _TempIndexList = new List<int>();

		private List<XItem> _tempItemList = new List<XItem>();
	}
}
