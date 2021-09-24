using System;
using KKSG;

namespace XMainClient
{

	public class XWorldBossDamageRankInfo : XBaseRankInfo
	{

		public override void ProcessData(RankData data)
		{
			this.name = data.RoleName;
			this.formatname = XTitleDocument.GetTitleWithFormat(data.titleID, data.RoleName);
			this.id = data.RoleId;
			this.rank = data.Rank;
			this.damage = data.damage;
			this.profession = data.profession;
		}

		public float damage;

		public uint profession;
	}
}
