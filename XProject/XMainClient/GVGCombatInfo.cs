using System;
using KKSG;

namespace XMainClient
{
	// Token: 0x0200092E RID: 2350
	public class GVGCombatInfo
	{
		// Token: 0x06008DCB RID: 36299 RVA: 0x001379E4 File Offset: 0x00135BE4
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

		// Token: 0x17002BC6 RID: 11206
		// (get) Token: 0x06008DCC RID: 36300 RVA: 0x00137A74 File Offset: 0x00135C74
		public string DamageString
		{
			get
			{
				return ((int)this.Damage).ToString();
			}
		}

		// Token: 0x17002BC7 RID: 11207
		// (get) Token: 0x06008DCD RID: 36301 RVA: 0x00137A98 File Offset: 0x00135C98
		public string KillCountString
		{
			get
			{
				return this.KillCount.ToString();
			}
		}

		// Token: 0x06008DCE RID: 36302 RVA: 0x00137AB5 File Offset: 0x00135CB5
		public void Clear()
		{
			this.KillCount = 0U;
			this.Damage = 0.0;
			this.GuildName = string.Empty;
			this.GuildIcon = 0U;
			this.GuildID = 0UL;
		}

		// Token: 0x04002E1B RID: 11803
		public uint KillCount = 0U;

		// Token: 0x04002E1C RID: 11804
		public double Damage = 0.0;

		// Token: 0x04002E1D RID: 11805
		public string GuildName = string.Empty;

		// Token: 0x04002E1E RID: 11806
		public ulong GuildID = 0UL;

		// Token: 0x04002E1F RID: 11807
		public uint GuildIcon = 0U;

		// Token: 0x04002E20 RID: 11808
		public int Score = 0;
	}
}
