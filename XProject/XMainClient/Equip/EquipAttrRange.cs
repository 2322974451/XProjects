using System;
using XUtliPoolLib;

namespace XMainClient
{

	internal class EquipAttrRange
	{

		public EquipAttrRange(SeqRef<uint> seq)
		{
			this.m_min = seq[0];
			this.m_max = seq[1];
		}

		public float Min
		{
			get
			{
				return this.m_min;
			}
		}

		public float Max
		{
			get
			{
				return this.m_max;
			}
		}

		public float D_value
		{
			get
			{
				return this.m_max - this.m_min;
			}
		}

		public uint Prob
		{
			get
			{
				return this.m_prob;
			}
		}

		private float m_min = 0f;

		private float m_max = 0f;

		private uint m_prob = 0U;
	}
}
