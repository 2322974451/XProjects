using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "PunishType")]
	public enum PunishType
	{

		[ProtoEnum(Name = "PUNISH_NONE", Value = 0)]
		PUNISH_NONE,

		[ProtoEnum(Name = "PUNISH_USER_LOGIN", Value = 1)]
		PUNISH_USER_LOGIN,

		[ProtoEnum(Name = "PUNISH_USER_CHAT", Value = 2)]
		PUNISH_USER_CHAT,

		[ProtoEnum(Name = "PUNISH_USER_TEMP", Value = 3)]
		PUNISH_USER_TEMP,

		[ProtoEnum(Name = "PUNISH_USER_WORLDBOSS_RANK", Value = 4)]
		PUNISH_USER_WORLDBOSS_RANK,

		[ProtoEnum(Name = "PUNISH_USER_ROLE_GUILDBOSS", Value = 5)]
		PUNISH_USER_ROLE_GUILDBOSS,

		[ProtoEnum(Name = "PUNISH_USER_PK_RANK", Value = 6)]
		PUNISH_USER_PK_RANK,

		[ProtoEnum(Name = "PUNISH_USER_ARENA_RANK", Value = 7)]
		PUNISH_USER_ARENA_RANK,

		[ProtoEnum(Name = "PUNISH_USER_TOWER", Value = 8)]
		PUNISH_USER_TOWER,

		[ProtoEnum(Name = "PUNISH_USER_FLOWER_RANK", Value = 9)]
		PUNISH_USER_FLOWER_RANK,

		[ProtoEnum(Name = "PUNISH_USER_GUILD_RANK", Value = 10)]
		PUNISH_USER_GUILD_RANK,

		[ProtoEnum(Name = "PUNISH_USER_GUILDBOSS_RANK", Value = 11)]
		PUNISH_USER_GUILDBOSS_RANK,

		[ProtoEnum(Name = "PUNISH_USER_ZERO_PROFIT", Value = 12)]
		PUNISH_USER_ZERO_PROFIT,

		[ProtoEnum(Name = "PUNISH_USER_DAILY_PLAY", Value = 13)]
		PUNISH_USER_DAILY_PLAY,

		[ProtoEnum(Name = "PUNISH_USER_MULTI_ACTIVITY", Value = 14)]
		PUNISH_USER_MULTI_ACTIVITY,

		[ProtoEnum(Name = "PUNISH_USER_HG", Value = 15)]
		PUNISH_USER_HG
	}
}
