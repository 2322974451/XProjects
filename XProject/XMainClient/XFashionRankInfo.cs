using System;
using KKSG;

namespace XMainClient
{
	// Token: 0x02000D54 RID: 3412
	public class XFashionRankInfo : XBaseRankInfo
	{
		// Token: 0x0600BC55 RID: 48213 RVA: 0x0026D5A4 File Offset: 0x0026B7A4
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
