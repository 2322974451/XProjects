using System;
using KKSG;

namespace XMainClient
{

	public class XWorldBossGuildRankInfo : XBaseRankInfo
	{

		public override void ProcessData(RankData data)
		{
			this.name = data.RoleName;
			this.rank = data.Rank;
			this.damage = data.damage;
		}

		public float damage;
	}
}
