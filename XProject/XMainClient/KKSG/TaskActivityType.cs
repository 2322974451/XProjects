using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000827 RID: 2087
	[ProtoContract(Name = "TaskActivityType")]
	public enum TaskActivityType
	{
		// Token: 0x040027D0 RID: 10192
		[ProtoEnum(Name = "TaskActType_Dragonexp", Value = 1)]
		TaskActType_Dragonexp = 1,
		// Token: 0x040027D1 RID: 10193
		[ProtoEnum(Name = "TaskActType_Tower", Value = 2)]
		TaskActType_Tower,
		// Token: 0x040027D2 RID: 10194
		[ProtoEnum(Name = "TaskActType_SuperRisk", Value = 3)]
		TaskActType_SuperRisk,
		// Token: 0x040027D3 RID: 10195
		[ProtoEnum(Name = "TaskActType_SkyCityRound", Value = 4)]
		TaskActType_SkyCityRound,
		// Token: 0x040027D4 RID: 10196
		[ProtoEnum(Name = "TaskActType_BigmeleeKill", Value = 5)]
		TaskActType_BigmeleeKill,
		// Token: 0x040027D5 RID: 10197
		[ProtoEnum(Name = "TaskActType_BigmeleeScore", Value = 6)]
		TaskActType_BigmeleeScore,
		// Token: 0x040027D6 RID: 10198
		[ProtoEnum(Name = "TaskActType_GuildBoss", Value = 7)]
		TaskActType_GuildBoss,
		// Token: 0x040027D7 RID: 10199
		[ProtoEnum(Name = "TaskActType_HeroBattleWin", Value = 8)]
		TaskActType_HeroBattleWin,
		// Token: 0x040027D8 RID: 10200
		[ProtoEnum(Name = "TaskActType_PkWin", Value = 9)]
		TaskActType_PkWin,
		// Token: 0x040027D9 RID: 10201
		[ProtoEnum(Name = "TaskActType_Help", Value = 10)]
		TaskActType_Help,
		// Token: 0x040027DA RID: 10202
		[ProtoEnum(Name = "TaskActType_DonateItem", Value = 11)]
		TaskActType_DonateItem,
		// Token: 0x040027DB RID: 10203
		[ProtoEnum(Name = "TaskActType_Fish", Value = 12)]
		TaskActType_Fish,
		// Token: 0x040027DC RID: 10204
		[ProtoEnum(Name = "TaskActType_GardenSteal", Value = 13)]
		TaskActType_GardenSteal,
		// Token: 0x040027DD RID: 10205
		[ProtoEnum(Name = "TaskActType_GardenHarvest", Value = 14)]
		TaskActType_GardenHarvest,
		// Token: 0x040027DE RID: 10206
		[ProtoEnum(Name = "TaskActType_Cooking", Value = 15)]
		TaskActType_Cooking,
		// Token: 0x040027DF RID: 10207
		[ProtoEnum(Name = "TaskActType_Banquet", Value = 16)]
		TaskActType_Banquet,
		// Token: 0x040027E0 RID: 10208
		[ProtoEnum(Name = "TaskActType_JoinBanquet", Value = 17)]
		TaskActType_JoinBanquet,
		// Token: 0x040027E1 RID: 10209
		[ProtoEnum(Name = "TaskActType_WorldBoss", Value = 18)]
		TaskActType_WorldBoss,
		// Token: 0x040027E2 RID: 10210
		[ProtoEnum(Name = "TaskActType_CampDuel", Value = 19)]
		TaskActType_CampDuel
	}
}
