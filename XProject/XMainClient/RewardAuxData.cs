using System;
using System.Collections.Generic;
using XUtliPoolLib;

namespace XMainClient
{

	internal class RewardAuxData
	{

		public RewardAuxData(FirstPassReward.RowData data)
		{
			this.m_PassRewardRow = data;
		}

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

		public SeqRef<int> RankRang
		{
			get
			{
				return this.m_PassRewardRow.Rank;
			}
		}

		public bool IsInRang(int num)
		{
			return num > this.m_PassRewardRow.Rank[0] && num <= this.m_PassRewardRow.Rank[1];
		}

		private FirstPassReward.RowData m_PassRewardRow;

		private List<RewardItemAuxData> m_RewardDataList = null;
	}
}
