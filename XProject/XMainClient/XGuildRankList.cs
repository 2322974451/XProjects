using System;

namespace XMainClient
{
	// Token: 0x02000D76 RID: 3446
	public class XGuildRankList : XBaseRankList
	{
		// Token: 0x0600BCA0 RID: 48288 RVA: 0x0026E21E File Offset: 0x0026C41E
		public XGuildRankList()
		{
			this.type = XRankType.GuildRank;
		}

		// Token: 0x0600BCA1 RID: 48289 RVA: 0x0026E230 File Offset: 0x0026C430
		public override XBaseRankInfo CreateNewInfo()
		{
			return new XGuildRankInfo();
		}
	}
}
