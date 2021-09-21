using System;
using System.Collections.Generic;
using KKSG;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x0200093B RID: 2363
	public class GuildTerritoryAllianceInfo
	{
		// Token: 0x06008EF3 RID: 36595 RVA: 0x0013E6AC File Offset: 0x0013C8AC
		public void Set(GuildTerrChallInfo terr)
		{
			this.GuildID = terr.guildid;
			this.GuildName = terr.guildname;
			this.AllianceGuildID = terr.allianceid;
			this.TryAllianceIDs = terr.tryallianceid;
			XSingleton<XDebug>.singleton.AddGreenLog(this.GuildName, ":TryAllianceIDs:", this.TryAllianceIDs.Count.ToString(), null, null, null);
			this.isAllicance = false;
		}

		// Token: 0x06008EF4 RID: 36596 RVA: 0x0013E720 File Offset: 0x0013C920
		public void Add(GuildTerrChallInfo terr)
		{
			bool flag = this.AllianceGuildID == terr.guildid;
			if (flag)
			{
				this.AllianceGuildID = terr.guildid;
				this.AllianceGuildName = terr.guildname;
				this.isAllicance = true;
			}
		}

		// Token: 0x06008EF5 RID: 36597 RVA: 0x0013E764 File Offset: 0x0013C964
		public bool Contains(ulong allianceid)
		{
			bool flag = this.TryAllianceIDs == null;
			return !flag && this.TryAllianceIDs.Contains(allianceid);
		}

		// Token: 0x06008EF6 RID: 36598 RVA: 0x0013E794 File Offset: 0x0013C994
		public string GetAllinceString()
		{
			bool flag = this.isAllicance;
			string result;
			if (flag)
			{
				result = string.Format("{0}&{1}", this.GuildName, this.AllianceGuildName);
			}
			else
			{
				result = this.GuildName;
			}
			return result;
		}

		// Token: 0x04002EC2 RID: 11970
		public ulong GuildID;

		// Token: 0x04002EC3 RID: 11971
		public string GuildName;

		// Token: 0x04002EC4 RID: 11972
		public ulong AllianceGuildID;

		// Token: 0x04002EC5 RID: 11973
		public string AllianceGuildName;

		// Token: 0x04002EC6 RID: 11974
		public List<ulong> TryAllianceIDs;

		// Token: 0x04002EC7 RID: 11975
		public bool isAllicance = false;
	}
}
