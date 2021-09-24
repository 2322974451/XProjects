using System;
using KKSG;

namespace XMainClient
{

	public class XPetRankInfo : XBaseRankInfo
	{

		public override void ProcessData(RankData data)
		{
			this.name = data.RoleName;
			this.formatname = XBaseRankInfo.GetUnderLineName(this.name);
			this.id = data.RoleId;
			this.rank = data.Rank;
			this.value = (ulong)data.powerpoint;
			this.petID = data.petid;
			this.petUID = data.petuid;
		}

		public uint petID;

		public ulong petUID;
	}
}
