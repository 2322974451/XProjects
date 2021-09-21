using System;
using System.Collections.Generic;

namespace XMainClient
{
	// Token: 0x02000D3D RID: 3389
	internal class XBag
	{
		// Token: 0x17003309 RID: 13065
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

		// Token: 0x1700330A RID: 13066
		// (get) Token: 0x0600BBAA RID: 48042 RVA: 0x002695BC File Offset: 0x002677BC
		public int Count
		{
			get
			{
				return this.Items.Count;
			}
		}

		// Token: 0x0600BBAB RID: 48043 RVA: 0x002695D9 File Offset: 0x002677D9
		public void Clear()
		{
			this.Items.Clear();
		}

		// Token: 0x0600BBAC RID: 48044 RVA: 0x002695E8 File Offset: 0x002677E8
		public void AddItem(XItem item, bool bSort)
		{
			this.Items.Add(item);
			if (bSort)
			{
				this.SortItem();
			}
		}

		// Token: 0x0600BBAD RID: 48045 RVA: 0x00269614 File Offset: 0x00267814
		public void RemoveItem(ulong uid)
		{
			int index;
			bool flag = this.FindItem(uid, out index);
			if (flag)
			{
				this.Items.RemoveAt(index);
			}
		}

		// Token: 0x0600BBAE RID: 48046 RVA: 0x0026963E File Offset: 0x0026783E
		public void RemoveIndex(int index)
		{
			this.Items.RemoveAt(index);
		}

		// Token: 0x0600BBAF RID: 48047 RVA: 0x00269650 File Offset: 0x00267850
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

		// Token: 0x0600BBB0 RID: 48048 RVA: 0x002696A4 File Offset: 0x002678A4
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

		// Token: 0x0600BBB1 RID: 48049 RVA: 0x00269720 File Offset: 0x00267920
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

		// Token: 0x0600BBB2 RID: 48050 RVA: 0x002697A8 File Offset: 0x002679A8
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

		// Token: 0x0600BBB3 RID: 48051 RVA: 0x00269808 File Offset: 0x00267A08
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

		// Token: 0x0600BBB4 RID: 48052 RVA: 0x00269868 File Offset: 0x00267A68
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

		// Token: 0x0600BBB5 RID: 48053 RVA: 0x002698DE File Offset: 0x00267ADE
		public void SortItem()
		{
			this.Items.Sort(new Comparison<XItem>(XBag.ItemSortCompare));
		}

		// Token: 0x0600BBB6 RID: 48054 RVA: 0x002698FC File Offset: 0x00267AFC
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

		// Token: 0x04004C27 RID: 19495
		private List<XItem> Items = new List<XItem>();

		// Token: 0x04004C28 RID: 19496
		private List<int> _TempIndexList = new List<int>();

		// Token: 0x04004C29 RID: 19497
		private List<XItem> _tempItemList = new List<XItem>();
	}
}
