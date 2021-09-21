using System;

namespace XMainClient
{
	// Token: 0x02000C46 RID: 3142
	internal class SmeltAttr
	{
		// Token: 0x17003181 RID: 12673
		// (get) Token: 0x0600B24C RID: 45644 RVA: 0x002264CC File Offset: 0x002246CC
		public bool IsForge
		{
			get
			{
				return this.isForge;
			}
		}

		// Token: 0x17003182 RID: 12674
		// (get) Token: 0x0600B24D RID: 45645 RVA: 0x002264E4 File Offset: 0x002246E4
		public uint Min
		{
			get
			{
				return this.min;
			}
		}

		// Token: 0x17003183 RID: 12675
		// (get) Token: 0x0600B24E RID: 45646 RVA: 0x002264FC File Offset: 0x002246FC
		public uint Max
		{
			get
			{
				return this.max;
			}
		}

		// Token: 0x17003184 RID: 12676
		// (get) Token: 0x0600B24F RID: 45647 RVA: 0x00226514 File Offset: 0x00224714
		public uint AttrID
		{
			get
			{
				return this.attrID;
			}
		}

		// Token: 0x17003185 RID: 12677
		// (get) Token: 0x0600B250 RID: 45648 RVA: 0x0022652C File Offset: 0x0022472C
		public uint Index
		{
			get
			{
				return this.index;
			}
		}

		// Token: 0x17003186 RID: 12678
		// (get) Token: 0x0600B251 RID: 45649 RVA: 0x00226544 File Offset: 0x00224744
		public uint Slot
		{
			get
			{
				return this.slot;
			}
		}

		// Token: 0x17003187 RID: 12679
		// (get) Token: 0x0600B252 RID: 45650 RVA: 0x0022655C File Offset: 0x0022475C
		public uint D_value
		{
			get
			{
				return this.max - this.min;
			}
		}

		// Token: 0x17003188 RID: 12680
		// (get) Token: 0x0600B253 RID: 45651 RVA: 0x0022657C File Offset: 0x0022477C
		public bool IsFull
		{
			get
			{
				return this.RealValue >= this.max;
			}
		}

		// Token: 0x0600B254 RID: 45652 RVA: 0x002265A0 File Offset: 0x002247A0
		public SmeltAttr(uint id, uint min, uint max, uint index, uint slot, bool isForge)
		{
			this.attrID = id;
			this.min = min;
			this.max = max;
			this.index = index;
			this.slot = slot;
			this.isForge = isForge;
		}

		// Token: 0x040044A8 RID: 17576
		private bool isForge;

		// Token: 0x040044A9 RID: 17577
		private uint min;

		// Token: 0x040044AA RID: 17578
		private uint max;

		// Token: 0x040044AB RID: 17579
		private uint attrID;

		// Token: 0x040044AC RID: 17580
		private uint index;

		// Token: 0x040044AD RID: 17581
		private uint slot;

		// Token: 0x040044AE RID: 17582
		public bool IsReplace;

		// Token: 0x040044AF RID: 17583
		public uint RealValue;

		// Token: 0x040044B0 RID: 17584
		public string ColorStr;

		// Token: 0x040044B1 RID: 17585
		public int LastValue = -1;

		// Token: 0x040044B2 RID: 17586
		public uint SmeltResult = 0U;

		// Token: 0x040044B3 RID: 17587
		public bool IsCanSmelt = true;
	}
}
