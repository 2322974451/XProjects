using System;
using System.Collections.Generic;

namespace XMainClient
{

	internal struct XSmeltingInfo
	{

		public void Init()
		{
			bool flag = this.Attrs == null;
			if (flag)
			{
				this.Attrs = new List<XItemChangeAttr>();
			}
			else
			{
				this.Attrs.Clear();
			}
			this.minQuality = uint.MaxValue;
			this.bHasSmelting = false;
			this.SlotCapacity = XSmeltingInfo.MAX_SLOT_COUNT;
			this.bCanBeSmelted = true;
		}

		public void Clone(ref XSmeltingInfo other)
		{
			this.Init();
			this.bHasSmelting = other.bHasSmelting;
			bool flag = other.Attrs != null;
			if (flag)
			{
				for (int i = 0; i < other.Attrs.Count; i++)
				{
					this.Attrs.Add(other.Attrs[i]);
				}
			}
		}

		public void SetSlotInfo(int itemid)
		{
		}

		public static readonly int MAX_SLOT_COUNT = 6;

		public List<XItemChangeAttr> Attrs;

		public bool bHasSmelting;

		public bool bCanBeSmelted;

		public uint minQuality;

		public int SlotCapacity;
	}
}
