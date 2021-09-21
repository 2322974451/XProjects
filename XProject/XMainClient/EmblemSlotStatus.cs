using System;

namespace XMainClient
{
	// Token: 0x020009EC RID: 2540
	internal class EmblemSlotStatus
	{
		// Token: 0x06009B5F RID: 39775 RVA: 0x0018C4EE File Offset: 0x0018A6EE
		public EmblemSlotStatus(int slot)
		{
			this.m_slot = slot;
		}

		// Token: 0x17002E33 RID: 11827
		// (get) Token: 0x06009B60 RID: 39776 RVA: 0x0018C514 File Offset: 0x0018A714
		// (set) Token: 0x06009B61 RID: 39777 RVA: 0x0018C52C File Offset: 0x0018A72C
		public bool LevelIsdOpen
		{
			get
			{
				return this.m_levelIsOpen;
			}
			set
			{
				this.m_levelIsOpen = value;
			}
		}

		// Token: 0x17002E34 RID: 11828
		// (get) Token: 0x06009B62 RID: 39778 RVA: 0x0018C538 File Offset: 0x0018A738
		// (set) Token: 0x06009B63 RID: 39779 RVA: 0x0018C550 File Offset: 0x0018A750
		public bool HadSlotting
		{
			get
			{
				return this.m_hadSlotting;
			}
			set
			{
				this.m_hadSlotting = value;
			}
		}

		// Token: 0x17002E35 RID: 11829
		// (get) Token: 0x06009B64 RID: 39780 RVA: 0x0018C55C File Offset: 0x0018A75C
		public bool IsLock
		{
			get
			{
				return !this.m_levelIsOpen | !this.m_hadSlotting;
			}
		}

		// Token: 0x17002E36 RID: 11830
		// (get) Token: 0x06009B65 RID: 39781 RVA: 0x0018C584 File Offset: 0x0018A784
		public int Slot
		{
			get
			{
				return this.m_slot;
			}
		}

		// Token: 0x040035BF RID: 13759
		private bool m_levelIsOpen = false;

		// Token: 0x040035C0 RID: 13760
		private bool m_hadSlotting = false;

		// Token: 0x040035C1 RID: 13761
		private int m_slot = 0;
	}
}
