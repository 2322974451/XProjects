using System;
using System.Collections.Generic;

namespace XMainClient
{
	// Token: 0x02000DE7 RID: 3559
	internal struct XJadeInfo
	{
		// Token: 0x170033DF RID: 13279
		// (get) Token: 0x0600C0E2 RID: 49378 RVA: 0x0028DB48 File Offset: 0x0028BD48
		public uint slotCount
		{
			get
			{
				return this._slotCount;
			}
		}

		// Token: 0x170033E0 RID: 13280
		// (set) Token: 0x0600C0E3 RID: 49379 RVA: 0x0028DB60 File Offset: 0x0028BD60
		public uint slots
		{
			set
			{
				this._slots = value;
				this._slotCount = 0U;
				for (uint num = 0U; num < XJadeInfo.slot_max; num += 1U)
				{
					uint slot = this.GetSlot((int)num);
					bool flag = XJadeInfo.SlotExists(slot);
					if (flag)
					{
						this._slotCount += 1U;
					}
				}
			}
		}

		// Token: 0x0600C0E4 RID: 49380 RVA: 0x0028DBB4 File Offset: 0x0028BDB4
		public void Init()
		{
			bool flag = this.jades == null;
			if (flag)
			{
				this.jades = new XJadeItem[XJadeInfo.slot_max];
			}
			else
			{
				int num = 0;
				while ((long)num < (long)((ulong)XJadeInfo.slot_max))
				{
					bool flag2 = this.jades[num] != null;
					if (flag2)
					{
						this.jades[num].Recycle();
						this.jades[num] = null;
					}
					num++;
				}
			}
			this._slotCount = 0U;
			this._slots = 0U;
		}

		// Token: 0x0600C0E5 RID: 49381 RVA: 0x0028DC34 File Offset: 0x0028BE34
		public uint GetSlot(int index)
		{
			return this._slots >> (int)((long)index * (long)((ulong)XJadeInfo.slot_step)) & XJadeInfo.slot_mask;
		}

		// Token: 0x0600C0E6 RID: 49382 RVA: 0x0028DC60 File Offset: 0x0028BE60
		public IEnumerable<uint> AllSlots()
		{
			uint num;
			for (uint i = 0U; i < this._slotCount; i = num)
			{
				yield return this.GetSlot((int)i);
				num = i + 1U;
			}
			yield break;
		}

		// Token: 0x0600C0E7 RID: 49383 RVA: 0x0028DC78 File Offset: 0x0028BE78
		public static bool SlotExists(uint slot)
		{
			return slot != XJadeInfo.SLOT_NOTEXIST;
		}

		// Token: 0x0600C0E8 RID: 49384 RVA: 0x0028DC98 File Offset: 0x0028BE98
		public static bool SlotNotOpen(uint slot)
		{
			return slot == XJadeInfo.SLOT_NOTOPEN;
		}

		// Token: 0x0600C0E9 RID: 49385 RVA: 0x0028DCB4 File Offset: 0x0028BEB4
		public static bool SlotOpened(uint slot)
		{
			return XJadeInfo.SlotExists(slot) && !XJadeInfo.SlotNotOpen(slot);
		}

		// Token: 0x0600C0EA RID: 49386 RVA: 0x0028DCDC File Offset: 0x0028BEDC
		public static bool SlotEmpty(int slotIndex, XJadeInfo jadeInfo)
		{
			return XJadeInfo.SlotOpened(jadeInfo.GetSlot(slotIndex)) && jadeInfo.jades[slotIndex] == null;
		}

		// Token: 0x0600C0EB RID: 49387 RVA: 0x0028DD0C File Offset: 0x0028BF0C
		public static bool SlotHasJade(int slotIndex, XJadeInfo jadeInfo)
		{
			return XJadeInfo.SlotOpened(jadeInfo.GetSlot(slotIndex)) && jadeInfo.jades[slotIndex] != null;
		}

		// Token: 0x0400510F RID: 20751
		private static readonly uint slot_mask = 15U;

		// Token: 0x04005110 RID: 20752
		private static readonly uint slot_step = 4U;

		// Token: 0x04005111 RID: 20753
		private static readonly uint slot_max = 32U / XJadeInfo.slot_step;

		// Token: 0x04005112 RID: 20754
		private uint _slots;

		// Token: 0x04005113 RID: 20755
		private uint _slotCount;

		// Token: 0x04005114 RID: 20756
		public XJadeItem[] jades;

		// Token: 0x04005115 RID: 20757
		public static readonly uint SLOT_NOTEXIST = 0U;

		// Token: 0x04005116 RID: 20758
		public static readonly uint SLOT_NOTOPEN = 15U;
	}
}
