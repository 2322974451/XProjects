using System;
using KKSG;

namespace XMainClient
{
	// Token: 0x02000D75 RID: 3445
	public class XGuildRankInfo : XBaseRankInfo
	{
		// Token: 0x0600BC9E RID: 48286 RVA: 0x0026E1A4 File Offset: 0x0026C3A4
		public void ProcessData(GuildInfo guildInfo)
		{
			this.id = guildInfo.id;
			this.value = (ulong)guildInfo.level;
			this.presitge = guildInfo.prestige;
			this.name = guildInfo.name;
			this.formatname = XBaseRankInfo.GetUnderLineName(this.name);
			this.name2 = guildInfo.leaderName;
			this.formatname2 = XTitleDocument.GetTitleWithFormat(0U, guildInfo.leaderName);
			this.exp = guildInfo.guildExp;
		}

		// Token: 0x04004C86 RID: 19590
		public string formatname2;

		// Token: 0x04004C87 RID: 19591
		public string name2;

		// Token: 0x04004C88 RID: 19592
		public uint exp;

		// Token: 0x04004C89 RID: 19593
		public uint presitge;
	}
}
