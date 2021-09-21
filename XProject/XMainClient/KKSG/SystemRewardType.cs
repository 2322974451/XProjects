using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000755 RID: 1877
	[ProtoContract(Name = "SystemRewardType")]
	public enum SystemRewardType
	{
		// Token: 0x040022B1 RID: 8881
		[ProtoEnum(Name = "RewardDinner", Value = 1)]
		RewardDinner = 1,
		// Token: 0x040022B2 RID: 8882
		[ProtoEnum(Name = "RewardSupper", Value = 2)]
		RewardSupper,
		// Token: 0x040022B3 RID: 8883
		[ProtoEnum(Name = "RewardArena", Value = 3)]
		RewardArena,
		// Token: 0x040022B4 RID: 8884
		[ProtoEnum(Name = "RewardWorldBoss", Value = 4)]
		RewardWorldBoss,
		// Token: 0x040022B5 RID: 8885
		[ProtoEnum(Name = "RewardChargeFirst", Value = 5)]
		RewardChargeFirst,
		// Token: 0x040022B6 RID: 8886
		[ProtoEnum(Name = "RewardGuildBoss", Value = 6)]
		RewardGuildBoss,
		// Token: 0x040022B7 RID: 8887
		[ProtoEnum(Name = "RewardGuildBossRole", Value = 7)]
		RewardGuildBossRole,
		// Token: 0x040022B8 RID: 8888
		[ProtoEnum(Name = "RewardPk", Value = 8)]
		RewardPk,
		// Token: 0x040022B9 RID: 8889
		[ProtoEnum(Name = "RewardVip", Value = 101)]
		RewardVip = 101,
		// Token: 0x040022BA RID: 8890
		[ProtoEnum(Name = "RewardMonthCard", Value = 102)]
		RewardMonthCard,
		// Token: 0x040022BB RID: 8891
		[ProtoEnum(Name = "RewardMakeUp", Value = 103)]
		RewardMakeUp,
		// Token: 0x040022BC RID: 8892
		[ProtoEnum(Name = "RewardArenaUp", Value = 104)]
		RewardArenaUp,
		// Token: 0x040022BD RID: 8893
		[ProtoEnum(Name = "RewardGM", Value = 105)]
		RewardGM,
		// Token: 0x040022BE RID: 8894
		[ProtoEnum(Name = "RewardDegree", Value = 106)]
		RewardDegree,
		// Token: 0x040022BF RID: 8895
		[ProtoEnum(Name = "RewardFashionPowerRank", Value = 107)]
		RewardFashionPowerRank
	}
}
