using System;
using System.Collections.Generic;
using KKSG;

namespace XMainClient
{

	public class GVGDuelResult
	{

		public bool isWinner
		{
			get
			{
				return this._winer;
			}
		}

		public GmfGuildBrief Guild
		{
			get
			{
				return this._guild;
			}
		}

		public uint Score
		{
			get
			{
				return this._score;
			}
		}

		public void Setup(GmfGuildBrief guild, List<GmfRoleCombat> combats, bool winer, bool cross = false)
		{
			this._winer = winer;
			this._cross = cross;
			this._guild = guild;
			this.SetRoleCombats(combats);
		}

		public void Setup(GmfGuildBrief guild, uint score, bool winer, bool cross = false)
		{
			this._winer = winer;
			this._guild = guild;
			this._score = score;
			this._cross = cross;
		}

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

		public uint TotalKiller = 0U;

		public double TotalDamage = 0.0;

		public List<GmfRoleCombat> RoleCombats;

		public GuildArenaBattlePattern pattern;

		private GmfGuildBrief _guild;

		private bool _cross = false;

		private uint _score = 0U;

		private bool _winer = false;
	}
}
