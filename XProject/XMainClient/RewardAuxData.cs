using System;
using System.Collections.Generic;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000D00 RID: 3328
	internal class RewardAuxData
	{
		// Token: 0x0600BA49 RID: 47689 RVA: 0x0025F6DA File Offset: 0x0025D8DA
		public RewardAuxData(FirstPassReward.RowData data)
		{
			this.m_PassRewardRow = data;
		}

		// Token: 0x170032CD RID: 13005
		// (get) Token: 0x0600BA4A RID: 47690 RVA: 0x0025F6F4 File Offset: 0x0025D8F4
		public List<RewardItemAuxData> RewardDataList
		{
			get
			{
				bool flag = this.m_RewardDataList == null;
				if (flag)
				{
					this.m_RewardDataList = new List<RewardItemAuxData>();
					for (int i = 0; i < this.m_PassRewardRow.Reward.Count; i++)
					{
						RewardItemAuxData rewardItemAuxData = new RewardItemAuxData(this.m_PassRewardRow.Reward[i, 0], this.m_PassRewardRow.Reward[i, 1]);
						bool flag2 = rewardItemAuxData.Id > 0;
						if (flag2)
						{
							this.m_RewardDataList.Add(rewardItemAuxData);
						}
					}
				}
				return this.m_RewardDataList;
			}
		}

		// Token: 0x170032CE RID: 13006
		// (get) Token: 0x0600BA4B RID: 47691 RVA: 0x0025F794 File Offset: 0x0025D994
		public SeqRef<int> RankRang
		{
			get
			{
				return this.m_PassRewardRow.Rank;
			}
		}

		// Token: 0x0600BA4C RID: 47692 RVA: 0x0025F7B4 File Offset: 0x0025D9B4
		public bool IsInRang(int num)
		{
			return num > this.m_PassRewardRow.Rank[0] && num <= this.m_PassRewardRow.Rank[1];
		}

		// Token: 0x04004A84 RID: 19076
		private FirstPassReward.RowData m_PassRewardRow;

		// Token: 0x04004A85 RID: 19077
		private List<RewardItemAuxData> m_RewardDataList = null;
	}
}
