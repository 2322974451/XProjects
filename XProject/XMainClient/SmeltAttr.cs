using System;

namespace XMainClient
{

	internal class SmeltAttr
	{

		public bool IsForge
		{
			get
			{
				return this.isForge;
			}
		}

		public uint Min
		{
			get
			{
				return this.min;
			}
		}

		public uint Max
		{
			get
			{
				return this.max;
			}
		}

		public uint AttrID
		{
			get
			{
				return this.attrID;
			}
		}

		public uint Index
		{
			get
			{
				return this.index;
			}
		}

		public uint Slot
		{
			get
			{
				return this.slot;
			}
		}

		public uint D_value
		{
			get
			{
				return this.max - this.min;
			}
		}

		public bool IsFull
		{
			get
			{
				return this.RealValue >= this.max;
			}
		}

		public SmeltAttr(uint id, uint min, uint max, uint index, uint slot, bool isForge)
		{
			this.attrID = id;
			this.min = min;
			this.max = max;
			this.index = index;
			this.slot = slot;
			this.isForge = isForge;
		}

		private bool isForge;

		private uint min;

		private uint max;

		private uint attrID;

		private uint index;

		private uint slot;

		public bool IsReplace;

		public uint RealValue;

		public string ColorStr;

		public int LastValue = -1;

		public uint SmeltResult = 0U;

		public bool IsCanSmelt = true;
	}
}
