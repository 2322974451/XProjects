using System;
using System.Collections.Generic;

namespace XMainClient
{

	public class RankRewardData
	{

		public RankRewardData()
		{
			this.rewardID = new List<int>();
			this.rewardCount = new List<int>();
		}

		public uint id;

		public int rankMIN;

		public int rankMAX;

		public List<int> rewardID;

		public List<int> rewardCount;
	}
}
