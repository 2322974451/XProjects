using System;
using KKSG;

namespace XMainClient
{
	// Token: 0x02000D58 RID: 3416
	public class XPPTRankInfo : XBaseRankInfo
	{
		// Token: 0x0600BC5F RID: 48223 RVA: 0x0026D7DC File Offset: 0x0026B9DC
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
