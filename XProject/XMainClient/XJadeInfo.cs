using System;
using System.Collections.Generic;

namespace XMainClient
{

	internal struct XJadeInfo
	{

		public uint slotCount
		{
			get
			{
				return this._slotCount;
			}
		}

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

		public uint GetSlot(int index)
		{
			return this._slots >> (int)((long)index * (long)((ulong)XJadeInfo.slot_step)) & XJadeInfo.slot_mask;
		}

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

		public static bool SlotExists(uint slot)
		{
			return slot != XJadeInfo.SLOT_NOTEXIST;
		}

		public static bool SlotNotOpen(uint slot)
		{
			return slot == XJadeInfo.SLOT_NOTOPEN;
		}

		public static bool SlotOpened(uint slot)
		{
			return XJadeInfo.SlotExists(slot) && !XJadeInfo.SlotNotOpen(slot);
		}

		public static bool SlotEmpty(int slotIndex, XJadeInfo jadeInfo)
		{
			return XJadeInfo.SlotOpened(jadeInfo.GetSlot(slotIndex)) && jadeInfo.jades[slotIndex] == null;
		}

		public static bool SlotHasJade(int slotIndex, XJadeInfo jadeInfo)
		{
			return XJadeInfo.SlotOpened(jadeInfo.GetSlot(slotIndex)) && jadeInfo.jades[slotIndex] != null;
		}

		private static readonly uint slot_mask = 15U;

		private static readonly uint slot_step = 4U;

		private static readonly uint slot_max = 32U / XJadeInfo.slot_step;

		private uint _slots;

		private uint _slotCount;

		public XJadeItem[] jades;

		public static readonly uint SLOT_NOTEXIST = 0U;

		public static readonly uint SLOT_NOTOPEN = 15U;
	}
}
