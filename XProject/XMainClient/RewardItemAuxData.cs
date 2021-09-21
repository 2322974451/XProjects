using System;

namespace XMainClient
{
	// Token: 0x02000D01 RID: 3329
	internal class RewardItemAuxData
	{
		// Token: 0x0600BA4D RID: 47693 RVA: 0x0025F7F4 File Offset: 0x0025D9F4
		public RewardItemAuxData(int id, int count)
		{
			this.m_id = id;
			this.m_count = count;
		}

		// Token: 0x170032CF RID: 13007
		// (get) Token: 0x0600BA4E RID: 47694 RVA: 0x0025F81C File Offset: 0x0025DA1C
		public int Id
		{
			get
			{
				return this.m_id;
			}
		}

		// Token: 0x170032D0 RID: 13008
		// (get) Token: 0x0600BA4F RID: 47695 RVA: 0x0025F834 File Offset: 0x0025DA34
		public int Count
		{
			get
			{
				return this.m_count;
			}
		}

		// Token: 0x04004A86 RID: 19078
		private int m_id = 0;

		// Token: 0x04004A87 RID: 19079
		private int m_count = 0;
	}
}
