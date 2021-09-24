using System;
using KKSG;

namespace XMainClient
{

	public class XSkyArenaRankInfo : XBaseRankInfo
	{

		public override void ProcessData(RankData data)
		{
			this.rank = data.Rank;
			bool flag = data.skycity == null;
			if (!flag)
			{
				this.id = data.skycity.roleid;
				this.name = data.skycity.rolename;
				this.floor = data.skycity.floor;
				this.kill = data.skycity.killer;
				this.profession = data.skycity.job;
			}
		}

		public uint profession;

		public uint kill;

		public uint floor;
	}
}
