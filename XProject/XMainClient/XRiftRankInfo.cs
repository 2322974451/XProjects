using System;
using KKSG;

namespace XMainClient
{

	public class XRiftRankInfo : XBaseRankInfo
	{

		public override void ProcessData(RankData data)
		{
			this.formatname = XBaseRankInfo.GetUnderLineName(this.name);
			this.rank = data.Rank;
			bool flag = data.riftRankData != null;
			if (flag)
			{
				this.passtime = data.riftRankData.passTime;
				this.floor = data.riftRankData.riftFloor;
			}
		}

		public uint passtime;

		public uint floor;
	}
}
