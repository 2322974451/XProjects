using System;

namespace XMainClient
{

	internal class EmblemSlotStatus
	{

		public EmblemSlotStatus(int slot)
		{
			this.m_slot = slot;
		}

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

		public bool IsLock
		{
			get
			{
				return !this.m_levelIsOpen | !this.m_hadSlotting;
			}
		}

		public int Slot
		{
			get
			{
				return this.m_slot;
			}
		}

		private bool m_levelIsOpen = false;

		private bool m_hadSlotting = false;

		private int m_slot = 0;
	}
}
