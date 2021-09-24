using System;
using KKSG;

namespace XMainClient
{

	public class XWorldBossGuildRoleRankInfo : XBaseRankInfo
	{

		public override void ProcessData(RankData data)
		{
			this.name = data.RoleName;
			this.rank = data.Rank;
			this.damage = data.damage;
			this.id = data.RoleId;
		}

		public float damage;
	}
}
