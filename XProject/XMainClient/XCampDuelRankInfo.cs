using System;
using KKSG;

namespace XMainClient
{

	public class XCampDuelRankInfo : XBaseRankInfo
	{

		public override void ProcessData(RankData data)
		{
			this.id = data.RoleId;
			this.value = (ulong)data.powerpoint;
			this.name = data.RoleName;
			this.rank = data.Rank;
		}
	}
}
