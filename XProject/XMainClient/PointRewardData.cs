using System;

namespace XMainClient
{

	internal struct PointRewardData
	{

		public void Init()
		{
			this.id = 0U;
			this.point = 0;
			this.rewardItem = new XBetterDictionary<int, int>(0);
		}

		public uint id;

		public int point;

		public XBetterDictionary<int, int> rewardItem;
	}
}
