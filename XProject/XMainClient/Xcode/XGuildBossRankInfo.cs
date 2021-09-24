using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	public class XGuildBossRankInfo : XBaseRankInfo
	{

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

		public override string GetValue()
		{
			return this.m_Time;
		}

		public string guildBossName;

		public uint guildBossIndex;

		public float damage;

		public string m_Time;

		public string guildName;

		public string strongDPSName;

		public float MaxHP;
	}
}
