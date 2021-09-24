using System;
using KKSG;

namespace XMainClient
{

	public class XGuildRankInfo : XBaseRankInfo
	{

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

		public string formatname2;

		public string name2;

		public uint exp;

		public uint presitge;
	}
}
