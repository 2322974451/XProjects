using System;
using KKSG;

namespace XMainClient
{
	// Token: 0x02000D7D RID: 3453
	public class XSpriteRankInfo : XBaseRankInfo
	{
		// Token: 0x0600BCAE RID: 48302 RVA: 0x0026E55C File Offset: 0x0026C75C
		public override void ProcessData(RankData data)
		{
			this.name = data.RoleName;
			this.formatname = XTitleDocument.GetTitleWithFormat(data.titleID, XBaseRankInfo.GetUnderLineName(this.name));
			this.id = data.RoleId;
			this.rank = data.Rank;
			this.value = (ulong)data.powerpoint;
			this.startType = data.starttype;
		}
	}
}
