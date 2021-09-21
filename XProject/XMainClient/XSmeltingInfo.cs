using System;
using System.Collections.Generic;

namespace XMainClient
{
	// Token: 0x02000DE1 RID: 3553
	internal struct XSmeltingInfo
	{
		// Token: 0x0600C0D6 RID: 49366 RVA: 0x0028D8E4 File Offset: 0x0028BAE4
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

		// Token: 0x0600C0D7 RID: 49367 RVA: 0x0028D93C File Offset: 0x0028BB3C
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

		// Token: 0x0600C0D8 RID: 49368 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public void SetSlotInfo(int itemid)
		{
		}

		// Token: 0x040050FE RID: 20734
		public static readonly int MAX_SLOT_COUNT = 6;

		// Token: 0x040050FF RID: 20735
		public List<XItemChangeAttr> Attrs;

		// Token: 0x04005100 RID: 20736
		public bool bHasSmelting;

		// Token: 0x04005101 RID: 20737
		public bool bCanBeSmelted;

		// Token: 0x04005102 RID: 20738
		public uint minQuality;

		// Token: 0x04005103 RID: 20739
		public int SlotCapacity;
	}
}
