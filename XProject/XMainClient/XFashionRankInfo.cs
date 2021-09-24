using System;
using KKSG;

namespace XMainClient
{

	public class XFashionRankInfo : XBaseRankInfo
	{

		public override void ProcessData(RankData data)
		{
			this.name = data.RoleName;
			this.formatname = XTitleDocument.GetTitleWithFormat(data.titleID, XBaseRankInfo.GetUnderLineName(this.name));
			this.id = data.RoleId;
			this.rank = data.Rank;
			this.value = (ulong)data.powerpoint;
			this.guildicon = data.guildicon;
			this.guildname = data.guildname;
			this.startType = data.starttype;
		}
	}
}
