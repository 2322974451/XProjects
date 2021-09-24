using System;
using KKSG;

namespace XMainClient
{

	internal class XGVGGuildInfo : XGuildBasicData
	{

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

		public override string ToGuildNameString()
		{
			return XStringDefineProxy.GetString("CROSS_GVG_GUILDNAME", new object[]
			{
				this.serverID,
				this.guildName
			});
		}

		public uint serverID;

		public string serverName;

		public uint score;

		public uint killNum;
	}
}
