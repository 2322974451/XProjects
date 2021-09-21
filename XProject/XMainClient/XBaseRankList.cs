using System;
using System.Collections.Generic;
using KKSG;

namespace XMainClient
{
	// Token: 0x02000D82 RID: 3458
	public class XBaseRankList
	{
		// Token: 0x0600BCBC RID: 48316 RVA: 0x0026E8A8 File Offset: 0x0026CAA8
		public virtual XBaseRankInfo CreateNewInfo()
		{
			return new XBaseRankInfo();
		}

		// Token: 0x0600BCBD RID: 48317 RVA: 0x0026E8C0 File Offset: 0x0026CAC0
		public virtual XBaseRankInfo GetLatestMyRankInfo()
		{
			return this.myRankInfo;
		}

		// Token: 0x1700331A RID: 13082
		// (get) Token: 0x0600BCBE RID: 48318 RVA: 0x0026E8D8 File Offset: 0x0026CAD8
		public RankeType KKSGType
		{
			get
			{
				return XBaseRankList.GetKKSGType(this.type);
			}
		}

		// Token: 0x0600BCBF RID: 48319 RVA: 0x0026E8F8 File Offset: 0x0026CAF8
		public static RankeType GetKKSGType(XRankType type)
		{
			switch (type)
			{
			case XRankType.PPTRank:
				return RankeType.PowerPointRank;
			case XRankType.LevelRank:
				return RankeType.LevelRank;
			case XRankType.WorldBossGuildRank:
				return RankeType.WorldBossGuildRank;
			case XRankType.WorldBossGuildRoleRank:
				return RankeType.WorldBossGuildRoleRank;
			case XRankType.WorldBossDamageRank:
				return RankeType.WorldBossDamageRank;
			case XRankType.GuildBossRank:
				return RankeType.GuildBossRank;
			case XRankType.FashionRank:
				return RankeType.FashionPowerPointRank;
			case XRankType.TeamTowerRank:
				return RankeType.TowerRank;
			case XRankType.FlowerTodayRank:
				return RankeType.FlowerRank;
			case XRankType.FlowerYesterdayRank:
				return RankeType.FlowerYesterdayRank;
			case XRankType.FlowerHistoryRank:
				return RankeType.FlowerTotalRank;
			case XRankType.FlowerWeekRank:
				return RankeType.FlowerThisWeekRank;
			case XRankType.FlowerActivityRank:
				return RankeType.FlowerActivityRank;
			case XRankType.PetRank:
				return RankeType.PetPowerPointRank;
			case XRankType.BigMeleeRank:
				return RankeType.BigMeleeRank;
			case XRankType.SkyArenaRank:
				return RankeType.SkyCityRank;
			case XRankType.ChickenDinnerRank:
				return RankeType.SurviveRank;
			case XRankType.CampDuelRankLeft:
				return RankeType.CampDuelRank1;
			case XRankType.CampDuelRankRight:
				return RankeType.CampDuelRank2;
			case XRankType.SpriteRank:
				return RankeType.SpritePowerPointRank;
			case XRankType.QualifyingRank:
				return RankeType.PkRealTimeRank;
			case XRankType.LeagueTeamRank:
				return RankeType.LeagueTeamRank;
			case XRankType.LastWeek_PKRank:
				return RankeType.LastWeek_PkRank;
			case XRankType.LastWeek_NestWeekRank:
				return RankeType.LastWeek_NestWeekRank;
			case XRankType.LastWeek_HeroBattleRank:
				return RankeType.LastWeek_HeroBattleRank;
			case XRankType.LastWeek_LeagueTeamRank:
				return RankeType.LastWeek_LeagueTeamRank;
			}
			return RankeType.PowerPointRank;
		}

		// Token: 0x0600BCC0 RID: 48320 RVA: 0x0026EA08 File Offset: 0x0026CC08
		public static XRankType GetXType(RankeType type)
		{
			switch (type)
			{
			case RankeType.WorldBossGuildRank:
				return XRankType.WorldBossGuildRank;
			case RankeType.WorldBossDamageRank:
				return XRankType.WorldBossDamageRank;
			case RankeType.PowerPointRank:
				return XRankType.PPTRank;
			case RankeType.LevelRank:
				return XRankType.LevelRank;
			case RankeType.FlowerRank:
				return XRankType.FlowerTodayRank;
			case RankeType.GuildBossRank:
				return XRankType.GuildBossRank;
			case RankeType.PkRealTimeRank:
				return XRankType.QualifyingRank;
			case RankeType.FashionPowerPointRank:
				return XRankType.FashionRank;
			case RankeType.TowerRank:
				return XRankType.TeamTowerRank;
			case RankeType.FlowerYesterdayRank:
				return XRankType.FlowerYesterdayRank;
			case RankeType.FlowerTotalRank:
				return XRankType.FlowerHistoryRank;
			case RankeType.SpritePowerPointRank:
				return XRankType.SpriteRank;
			case RankeType.PetPowerPointRank:
				return XRankType.PetRank;
			case RankeType.FlowerThisWeekRank:
				return XRankType.FlowerWeekRank;
			case RankeType.LeagueTeamRank:
				return XRankType.LeagueTeamRank;
			case RankeType.LastWeek_PkRank:
				return XRankType.LastWeek_PKRank;
			case RankeType.LastWeek_NestWeekRank:
				return XRankType.LastWeek_NestWeekRank;
			case RankeType.LastWeek_HeroBattleRank:
				return XRankType.LastWeek_HeroBattleRank;
			case RankeType.LastWeek_LeagueTeamRank:
				return XRankType.LastWeek_LeagueTeamRank;
			case RankeType.FlowerActivityRank:
				return XRankType.FlowerActivityRank;
			case RankeType.BigMeleeRank:
				return XRankType.BigMeleeRank;
			case RankeType.SurviveRank:
				return XRankType.ChickenDinnerRank;
			case RankeType.SkyCityRank:
				return XRankType.SkyArenaRank;
			case RankeType.WorldBossGuildRoleRank:
				return XRankType.WorldBossGuildRoleRank;
			case RankeType.RiftRank:
				return XRankType.RiftRank;
			case RankeType.CampDuelRank1:
				return XRankType.CampDuelRankLeft;
			case RankeType.CampDuelRank2:
				return XRankType.CampDuelRankRight;
			}
			return XRankType.InValid;
		}

		// Token: 0x04004CA4 RID: 19620
		public List<XBaseRankInfo> rankList = new List<XBaseRankInfo>();

		// Token: 0x04004CA5 RID: 19621
		public XBaseRankInfo myRankInfo;

		// Token: 0x04004CA6 RID: 19622
		public uint upperBound = 1000U;

		// Token: 0x04004CA7 RID: 19623
		public uint timeStamp = 0U;

		// Token: 0x04004CA8 RID: 19624
		public XRankType type = XRankType.PPTRank;
	}
}
