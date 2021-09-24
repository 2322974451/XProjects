using System;
using KKSG;

namespace XMainClient
{

	public class GVGCombatInfo
	{

		public void Set(GmfGuildCombat combat)
		{
			this.Score = (int)combat.score;
			bool flag = combat.gmfguild != null;
			if (flag)
			{
				this.GuildID = combat.gmfguild.guildid;
				this.GuildIcon = combat.gmfguild.guildicon;
				this.GuildName = combat.gmfguild.guildname;
			}
			bool flag2 = combat.combat != null;
			if (flag2)
			{
				this.KillCount = combat.combat.killcount;
				this.Damage = combat.combat.damage;
			}
		}

		public string DamageString
		{
			get
			{
				return ((int)this.Damage).ToString();
			}
		}

		public string KillCountString
		{
			get
			{
				return this.KillCount.ToString();
			}
		}

		public void Clear()
		{
			this.KillCount = 0U;
			this.Damage = 0.0;
			this.GuildName = string.Empty;
			this.GuildIcon = 0U;
			this.GuildID = 0UL;
		}

		public uint KillCount = 0U;

		public double Damage = 0.0;

		public string GuildName = string.Empty;

		public ulong GuildID = 0UL;

		public uint GuildIcon = 0U;

		public int Score = 0;
	}
}
