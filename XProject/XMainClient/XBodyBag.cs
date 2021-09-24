using System;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XBodyBag
	{

		public XBodyBag(int length)
		{
			this.Bag = new XItem[length];
		}

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

		public int Length
		{
			get
			{
				return this.Bag.Length;
			}
		}

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

		private XItem[] Bag;
	}
}
