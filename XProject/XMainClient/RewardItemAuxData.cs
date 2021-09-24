using System;

namespace XMainClient
{

	internal class RewardItemAuxData
	{

		public RewardItemAuxData(int id, int count)
		{
			this.m_id = id;
			this.m_count = count;
		}

		public int Id
		{
			get
			{
				return this.m_id;
			}
		}

		public int Count
		{
			get
			{
				return this.m_count;
			}
		}

		private int m_id = 0;

		private int m_count = 0;
	}
}
