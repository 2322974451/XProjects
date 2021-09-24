using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GuildMatchFightState")]
	public enum GuildMatchFightState
	{

		[ProtoEnum(Name = "GUILD_MF_NONE", Value = 1)]
		GUILD_MF_NONE = 1,

		[ProtoEnum(Name = "GUILD_MF_WAITING", Value = 2)]
		GUILD_MF_WAITING,

		[ProtoEnum(Name = "GUILD_MF_REFUSE", Value = 3)]
		GUILD_MF_REFUSE,

		[ProtoEnum(Name = "GUILD_MF_LEAVE", Value = 4)]
		GUILD_MF_LEAVE,

		[ProtoEnum(Name = "GUILD_MF_FIGHTING", Value = 5)]
		GUILD_MF_FIGHTING,

		[ProtoEnum(Name = "GUILD_MF_FAILED", Value = 6)]
		GUILD_MF_FAILED,

		[ProtoEnum(Name = "GUILD_MF_WIN", Value = 7)]
		GUILD_MF_WIN,

		[ProtoEnum(Name = "GUILD_MF_ERR", Value = 100)]
		GUILD_MF_ERR = 100
	}
}
