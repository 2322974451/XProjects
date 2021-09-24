using System;
using System.Collections.Generic;
using KKSG;
using XUtliPoolLib;

namespace XMainClient
{

	public class GuildTerritoryAllianceInfo
	{

		public void Set(GuildTerrChallInfo terr)
		{
			this.GuildID = terr.guildid;
			this.GuildName = terr.guildname;
			this.AllianceGuildID = terr.allianceid;
			this.TryAllianceIDs = terr.tryallianceid;
			XSingleton<XDebug>.singleton.AddGreenLog(this.GuildName, ":TryAllianceIDs:", this.TryAllianceIDs.Count.ToString(), null, null, null);
			this.isAllicance = false;
		}

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

		public bool Contains(ulong allianceid)
		{
			bool flag = this.TryAllianceIDs == null;
			return !flag && this.TryAllianceIDs.Contains(allianceid);
		}

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

		public ulong GuildID;

		public string GuildName;

		public ulong AllianceGuildID;

		public string AllianceGuildName;

		public List<ulong> TryAllianceIDs;

		public bool isAllicance = false;
	}
}
