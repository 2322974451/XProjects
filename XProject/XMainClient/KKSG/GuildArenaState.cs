using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GuildArenaState")]
	public enum GuildArenaState
	{

		[ProtoEnum(Name = "GUILD_ARENA_NOT_BEGIN", Value = 1)]
		GUILD_ARENA_NOT_BEGIN = 1,

		[ProtoEnum(Name = "GUILD_ARENA_BEGIN", Value = 2)]
		GUILD_ARENA_BEGIN,

		[ProtoEnum(Name = "GUILD_ARENA_BATTLE_ONE", Value = 3)]
		GUILD_ARENA_BATTLE_ONE,

		[ProtoEnum(Name = "GUILD_ARENA_BATTLE_TWO", Value = 4)]
		GUILD_ARENA_BATTLE_TWO,

		[ProtoEnum(Name = "GUILD_ARENA_BATTLE_FINAL", Value = 5)]
		GUILD_ARENA_BATTLE_FINAL,

		[ProtoEnum(Name = "GUILD_ARENA_END", Value = 6)]
		GUILD_ARENA_END
	}
}
