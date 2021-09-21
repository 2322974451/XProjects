using System;
using System.Collections.Generic;

namespace XMainClient
{
	// Token: 0x02000E75 RID: 3701
	internal class XNewItemTipsMgr
	{
		// Token: 0x17003496 RID: 13462
		// (get) Token: 0x0600C638 RID: 50744 RVA: 0x002BE120 File Offset: 0x002BC320
		public HashSet<ulong> NewItems
		{
			get
			{
				return this._NewItems;
			}
		}

		// Token: 0x17003497 RID: 13463
		// (get) Token: 0x0600C639 RID: 50745 RVA: 0x002BE138 File Offset: 0x002BC338
		public XItemFilter Filter
		{
			get
			{
				return this._Filter;
			}
		}

		// Token: 0x17003498 RID: 13464
		// (get) Token: 0x0600C63A RID: 50746 RVA: 0x002BE150 File Offset: 0x002BC350
		// (set) Token: 0x0600C63B RID: 50747 RVA: 0x002BE158 File Offset: 0x002BC358
		public bool bCanClear { get; set; }

		// Token: 0x0600C63C RID: 50748 RVA: 0x002BE161 File Offset: 0x002BC361
		public void ClearItemType()
		{
			this.Clear();
			this._Filter.Clear();
			this.bCanClear = false;
		}

		// Token: 0x0600C63D RID: 50749 RVA: 0x002BE180 File Offset: 0x002BC380
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

		// Token: 0x0600C63E RID: 50750 RVA: 0x002BE1C8 File Offset: 0x002BC3C8
		public bool AddItems(List<XItem> items, bool bDontSave = false)
		{
			bool flag = false;
			for (int i = 0; i < items.Count; i++)
			{
				flag = (this.AddItem(items[i], bDontSave) || flag);
			}
			return flag;
		}

		// Token: 0x0600C63F RID: 50751 RVA: 0x002BE208 File Offset: 0x002BC408
		public bool RemoveItem(ulong uid, ItemType type, bool bConsiderFilter = false)
		{
			bool flag = this._Filter.Contains(type);
			return flag && (this._NewItems.Remove(uid) || bConsiderFilter);
		}

		// Token: 0x0600C640 RID: 50752 RVA: 0x002BE240 File Offset: 0x002BC440
		public bool RemoveItems(List<ulong> items, List<ItemType> types, bool bConsiderFilter = true)
		{
			bool flag = false;
			for (int i = 0; i < items.Count; i++)
			{
				flag = (this.RemoveItem(items[i], types[i], bConsiderFilter) || flag);
			}
			return flag;
		}

		// Token: 0x0600C641 RID: 50753 RVA: 0x002BE284 File Offset: 0x002BC484
		public void TryClear()
		{
			bool bCanClear = this.bCanClear;
			if (bCanClear)
			{
				this.Clear();
			}
		}

		// Token: 0x0600C642 RID: 50754 RVA: 0x002BE2A3 File Offset: 0x002BC4A3
		public void Clear()
		{
			this._NewItems.Clear();
			this.bCanClear = false;
		}

		// Token: 0x0600C643 RID: 50755 RVA: 0x002BE2BC File Offset: 0x002BC4BC
		public bool IsNew(ulong uid)
		{
			return this._NewItems.Contains(uid);
		}

		// Token: 0x17003499 RID: 13465
		// (get) Token: 0x0600C644 RID: 50756 RVA: 0x002BE2DC File Offset: 0x002BC4DC
		public bool bHasNew
		{
			get
			{
				return this._NewItems.Count > 0;
			}
		}

		// Token: 0x040056F6 RID: 22262
		private HashSet<ulong> _NewItems = new HashSet<ulong>();

		// Token: 0x040056F7 RID: 22263
		private XItemFilter _Filter = new XItemFilter();
	}
}
