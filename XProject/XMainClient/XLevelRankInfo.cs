using System;
using KKSG;

namespace XMainClient
{
	// Token: 0x02000D56 RID: 3414
	public class XLevelRankInfo : XBaseRankInfo
	{
		// Token: 0x0600BC5A RID: 48218 RVA: 0x0026D6BC File Offset: 0x0026B8BC
		public override void ProcessData(RankData data)
		{
			this.name = data.RoleName;
			this.formatname = XTitleDocument.GetTitleWithFormat(data.titleID, XBaseRankInfo.GetUnderLineName(this.name));
			this.id = data.RoleId;
			this.rank = data.Rank;
			this.value = (ulong)data.RoleLevel;
			this.guildicon = data.guildicon;
			this.guildname = data.guildname;
			this.startType = data.starttype;
		}
	}
}
