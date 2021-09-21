using System;
using KKSG;

namespace XMainClient
{
	// Token: 0x020008FB RID: 2299
	internal class XGVGGuildInfo : XGuildBasicData
	{
		// Token: 0x06008AFA RID: 35578 RVA: 0x00128744 File Offset: 0x00126944
		public void Setup(CrossGvgGuildInfo guildInfo)
		{
			this.uid = guildInfo.guildid;
			this.guildName = guildInfo.guildname;
			this.serverID = guildInfo.serverid;
			this.serverName = guildInfo.servername;
			this.score = guildInfo.score;
			this.killNum = guildInfo.killnum;
			this.portraitIndex = (int)guildInfo.icon;
		}

		// Token: 0x06008AFB RID: 35579 RVA: 0x001287A8 File Offset: 0x001269A8
		public override string ToGuildNameString()
		{
			return XStringDefineProxy.GetString("CROSS_GVG_GUILDNAME", new object[]
			{
				this.serverID,
				this.guildName
			});
		}

		// Token: 0x04002C62 RID: 11362
		public uint serverID;

		// Token: 0x04002C63 RID: 11363
		public string serverName;

		// Token: 0x04002C64 RID: 11364
		public uint score;

		// Token: 0x04002C65 RID: 11365
		public uint killNum;
	}
}
