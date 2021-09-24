using System;
using KKSG;

namespace XMainClient
{

	public class XQualifyingRankInfo : XBaseRankInfo
	{

		public override void ProcessData(RankData data)
		{
			this.name = data.RoleName;
			this.formatname = XBaseRankInfo.GetUnderLineName(this.name);
			this.id = data.RoleId;
			this.rank = data.Rank;
			this.profession = data.profession;
			this.rankScore = data.pkpoint;
			bool flag = data.pkextradata != null;
			if (flag)
			{
				this.totalNum = data.pkextradata.joincount;
			}
		}

		public uint rankScore;

		public uint profession;

		public uint totalNum;
	}
}
