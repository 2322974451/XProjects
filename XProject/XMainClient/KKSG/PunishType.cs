using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200079E RID: 1950
	[ProtoContract(Name = "PunishType")]
	public enum PunishType
	{
		// Token: 0x040024A8 RID: 9384
		[ProtoEnum(Name = "PUNISH_NONE", Value = 0)]
		PUNISH_NONE,
		// Token: 0x040024A9 RID: 9385
		[ProtoEnum(Name = "PUNISH_USER_LOGIN", Value = 1)]
		PUNISH_USER_LOGIN,
		// Token: 0x040024AA RID: 9386
		[ProtoEnum(Name = "PUNISH_USER_CHAT", Value = 2)]
		PUNISH_USER_CHAT,
		// Token: 0x040024AB RID: 9387
		[ProtoEnum(Name = "PUNISH_USER_TEMP", Value = 3)]
		PUNISH_USER_TEMP,
		// Token: 0x040024AC RID: 9388
		[ProtoEnum(Name = "PUNISH_USER_WORLDBOSS_RANK", Value = 4)]
		PUNISH_USER_WORLDBOSS_RANK,
		// Token: 0x040024AD RID: 9389
		[ProtoEnum(Name = "PUNISH_USER_ROLE_GUILDBOSS", Value = 5)]
		PUNISH_USER_ROLE_GUILDBOSS,
		// Token: 0x040024AE RID: 9390
		[ProtoEnum(Name = "PUNISH_USER_PK_RANK", Value = 6)]
		PUNISH_USER_PK_RANK,
		// Token: 0x040024AF RID: 9391
		[ProtoEnum(Name = "PUNISH_USER_ARENA_RANK", Value = 7)]
		PUNISH_USER_ARENA_RANK,
		// Token: 0x040024B0 RID: 9392
		[ProtoEnum(Name = "PUNISH_USER_TOWER", Value = 8)]
		PUNISH_USER_TOWER,
		// Token: 0x040024B1 RID: 9393
		[ProtoEnum(Name = "PUNISH_USER_FLOWER_RANK", Value = 9)]
		PUNISH_USER_FLOWER_RANK,
		// Token: 0x040024B2 RID: 9394
		[ProtoEnum(Name = "PUNISH_USER_GUILD_RANK", Value = 10)]
		PUNISH_USER_GUILD_RANK,
		// Token: 0x040024B3 RID: 9395
		[ProtoEnum(Name = "PUNISH_USER_GUILDBOSS_RANK", Value = 11)]
		PUNISH_USER_GUILDBOSS_RANK,
		// Token: 0x040024B4 RID: 9396
		[ProtoEnum(Name = "PUNISH_USER_ZERO_PROFIT", Value = 12)]
		PUNISH_USER_ZERO_PROFIT,
		// Token: 0x040024B5 RID: 9397
		[ProtoEnum(Name = "PUNISH_USER_DAILY_PLAY", Value = 13)]
		PUNISH_USER_DAILY_PLAY,
		// Token: 0x040024B6 RID: 9398
		[ProtoEnum(Name = "PUNISH_USER_MULTI_ACTIVITY", Value = 14)]
		PUNISH_USER_MULTI_ACTIVITY,
		// Token: 0x040024B7 RID: 9399
		[ProtoEnum(Name = "PUNISH_USER_HG", Value = 15)]
		PUNISH_USER_HG
	}
}
