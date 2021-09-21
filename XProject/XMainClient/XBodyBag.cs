using System;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000D3C RID: 3388
	internal class XBodyBag
	{
		// Token: 0x0600BB9D RID: 48029 RVA: 0x00269249 File Offset: 0x00267449
		public XBodyBag(int length)
		{
			this.Bag = new XItem[length];
		}

		// Token: 0x17003307 RID: 13063
		public XItem this[int key]
		{
			get
			{
				return this.Bag[key];
			}
			set
			{
				this.Bag[key] = value;
			}
		}

		// Token: 0x17003308 RID: 13064
		// (get) Token: 0x0600BBA0 RID: 48032 RVA: 0x00269288 File Offset: 0x00267488
		public int Length
		{
			get
			{
				return this.Bag.Length;
			}
		}

		// Token: 0x0600BBA1 RID: 48033 RVA: 0x002692A4 File Offset: 0x002674A4
		public void UpdateItem(XItem item)
		{
			for (int i = 0; i < this.Bag.Length; i++)
			{
				bool flag = this.Bag[i] != null && this.Bag[i].uid == item.uid;
				if (flag)
				{
					this.Bag[i].Recycle();
					this.Bag[i] = item;
					break;
				}
			}
		}

		// Token: 0x0600BBA2 RID: 48034 RVA: 0x0026930C File Offset: 0x0026750C
		public XItem GetItemByUID(ulong uid)
		{
			for (int i = 0; i < this.Bag.Length; i++)
			{
				bool flag = this.Bag[i] != null && this.Bag[i].uid == uid;
				if (flag)
				{
					return this.Bag[i];
				}
			}
			return null;
		}

		// Token: 0x0600BBA3 RID: 48035 RVA: 0x00269368 File Offset: 0x00267568
		public XItem GetItemByID(int id)
		{
			for (int i = 0; i < this.Bag.Length; i++)
			{
				bool flag = this.Bag[i] != null && this.Bag[i].itemID == id;
				if (flag)
				{
					return this.Bag[i];
				}
			}
			return null;
		}

		// Token: 0x0600BBA4 RID: 48036 RVA: 0x002693C4 File Offset: 0x002675C4
		public int GetItemCountByID(int id)
		{
			int num = 0;
			for (int i = 0; i < this.Bag.Length; i++)
			{
				bool flag = this.Bag[i] != null && this.Bag[i].itemID == id;
				if (flag)
				{
					num += this.Bag[i].itemCount;
				}
			}
			return num;
		}

		// Token: 0x0600BBA5 RID: 48037 RVA: 0x00269428 File Offset: 0x00267628
		public bool HasItem(ulong uid)
		{
			for (int i = 0; i < this.Bag.Length; i++)
			{
				bool flag = this.Bag[i] != null && this.Bag[i].uid == uid;
				if (flag)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0600BBA6 RID: 48038 RVA: 0x0026947C File Offset: 0x0026767C
		public bool GetItemPos(ulong uid, out int pos)
		{
			for (int i = 0; i < this.Bag.Length; i++)
			{
				bool flag = this.Bag[i] != null && this.Bag[i].uid == uid;
				if (flag)
				{
					pos = i;
					return true;
				}
			}
			pos = -1;
			return false;
		}

		// Token: 0x0600BBA7 RID: 48039 RVA: 0x002694D4 File Offset: 0x002676D4
		public XItem GetDefaultSelectedItem(ItemType type)
		{
			int num = 0;
			bool flag = type == ItemType.EQUIP;
			if (flag)
			{
				num = XFastEnumIntEqualityComparer<EquipPosition>.ToInt(EquipPosition.Mainweapon);
			}
			bool flag2 = num < this.Bag.Length;
			if (flag2)
			{
				bool flag3 = this.Bag[num] != null && this.Bag[num].uid > 0UL;
				if (flag3)
				{
					return this.Bag[num];
				}
			}
			for (int i = 0; i < this.Bag.Length; i++)
			{
				bool flag4 = this.Bag[i] != null && this.Bag[i].uid > 0UL;
				if (flag4)
				{
					return this.Bag[i];
				}
			}
			return null;
		}

		// Token: 0x04004C26 RID: 19494
		private XItem[] Bag;
	}
}
