using System;
using System.Collections.Generic;
using KKSG;

namespace XMainClient
{
	// Token: 0x0200092D RID: 2349
	public class GVGDuelResult
	{
		// Token: 0x17002BC3 RID: 11203
		// (get) Token: 0x06008DC3 RID: 36291 RVA: 0x00137848 File Offset: 0x00135A48
		public bool isWinner
		{
			get
			{
				return this._winer;
			}
		}

		// Token: 0x17002BC4 RID: 11204
		// (get) Token: 0x06008DC4 RID: 36292 RVA: 0x00137860 File Offset: 0x00135A60
		public GmfGuildBrief Guild
		{
			get
			{
				return this._guild;
			}
		}

		// Token: 0x17002BC5 RID: 11205
		// (get) Token: 0x06008DC5 RID: 36293 RVA: 0x00137878 File Offset: 0x00135A78
		public uint Score
		{
			get
			{
				return this._score;
			}
		}

		// Token: 0x06008DC6 RID: 36294 RVA: 0x00137890 File Offset: 0x00135A90
		public void Setup(GmfGuildBrief guild, List<GmfRoleCombat> combats, bool winer, bool cross = false)
		{
			this._winer = winer;
			this._cross = cross;
			this._guild = guild;
			this.SetRoleCombats(combats);
		}

		// Token: 0x06008DC7 RID: 36295 RVA: 0x001378B1 File Offset: 0x00135AB1
		public void Setup(GmfGuildBrief guild, uint score, bool winer, bool cross = false)
		{
			this._winer = winer;
			this._guild = guild;
			this._score = score;
			this._cross = cross;
		}

		// Token: 0x06008DC8 RID: 36296 RVA: 0x001378D4 File Offset: 0x00135AD4
		private void SetRoleCombats(List<GmfRoleCombat> combats)
		{
			this.RoleCombats = combats;
			this.TotalKiller = 0U;
			this.TotalDamage = 0.0;
			int i = 0;
			int count = combats.Count;
			while (i < count)
			{
				this.TotalKiller += combats[i].combat.killcount;
				this.TotalDamage += combats[i].combat.damage;
				i++;
			}
		}

		// Token: 0x06008DC9 RID: 36297 RVA: 0x00137954 File Offset: 0x00135B54
		public string ToGuildNameString()
		{
			bool cross = this._cross;
			string result;
			if (cross)
			{
				result = XStringDefineProxy.GetString("CROSS_GVG_GUILDNAME", new object[]
				{
					this._guild.serverid,
					this._guild.guildname
				});
			}
			else
			{
				result = this.Guild.guildname;
			}
			return result;
		}

		// Token: 0x04002E13 RID: 11795
		public uint TotalKiller = 0U;

		// Token: 0x04002E14 RID: 11796
		public double TotalDamage = 0.0;

		// Token: 0x04002E15 RID: 11797
		public List<GmfRoleCombat> RoleCombats;

		// Token: 0x04002E16 RID: 11798
		public GuildArenaBattlePattern pattern;

		// Token: 0x04002E17 RID: 11799
		private GmfGuildBrief _guild;

		// Token: 0x04002E18 RID: 11800
		private bool _cross = false;

		// Token: 0x04002E19 RID: 11801
		private uint _score = 0U;

		// Token: 0x04002E1A RID: 11802
		private bool _winer = false;
	}
}
