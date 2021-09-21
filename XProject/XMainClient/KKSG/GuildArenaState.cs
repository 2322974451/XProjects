using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200078E RID: 1934
	[ProtoContract(Name = "GuildArenaState")]
	public enum GuildArenaState
	{
		// Token: 0x04002454 RID: 9300
		[ProtoEnum(Name = "GUILD_ARENA_NOT_BEGIN", Value = 1)]
		GUILD_ARENA_NOT_BEGIN = 1,
		// Token: 0x04002455 RID: 9301
		[ProtoEnum(Name = "GUILD_ARENA_BEGIN", Value = 2)]
		GUILD_ARENA_BEGIN,
		// Token: 0x04002456 RID: 9302
		[ProtoEnum(Name = "GUILD_ARENA_BATTLE_ONE", Value = 3)]
		GUILD_ARENA_BATTLE_ONE,
		// Token: 0x04002457 RID: 9303
		[ProtoEnum(Name = "GUILD_ARENA_BATTLE_TWO", Value = 4)]
		GUILD_ARENA_BATTLE_TWO,
		// Token: 0x04002458 RID: 9304
		[ProtoEnum(Name = "GUILD_ARENA_BATTLE_FINAL", Value = 5)]
		GUILD_ARENA_BATTLE_FINAL,
		// Token: 0x04002459 RID: 9305
		[ProtoEnum(Name = "GUILD_ARENA_END", Value = 6)]
		GUILD_ARENA_END
	}
}
