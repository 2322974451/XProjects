using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000D50 RID: 3408
	public class XGuildBossRankInfo : XBaseRankInfo
	{
		// Token: 0x0600BC4C RID: 48204 RVA: 0x0026D3DC File Offset: 0x0026B5DC
		public override void ProcessData(RankData data)
		{
			this.rank = data.Rank;
			this.guildBossName = data.guildBossName;
			this.guildBossIndex = data.guildBossIndex;
			this.damage = data.damage;
			this.value = (ulong)data.time;
			this.guildName = data.guildname;
			this.strongDPSName = data.guildBossDpsMax;
			this.m_Time = XSingleton<UiUtility>.singleton.TimeFormatString((int)this.value, 2, 3, 4, false, true);
		}

		// Token: 0x0600BC4D RID: 48205 RVA: 0x0026D45C File Offset: 0x0026B65C
		public override string GetValue()
		{
			return this.m_Time;
		}

		// Token: 0x04004C63 RID: 19555
		public string guildBossName;

		// Token: 0x04004C64 RID: 19556
		public uint guildBossIndex;

		// Token: 0x04004C65 RID: 19557
		public float damage;

		// Token: 0x04004C66 RID: 19558
		public string m_Time;

		// Token: 0x04004C67 RID: 19559
		public string guildName;

		// Token: 0x04004C68 RID: 19560
		public string strongDPSName;

		// Token: 0x04004C69 RID: 19561
		public float MaxHP;
	}
}
