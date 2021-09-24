using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "SyncTeamM2C")]
	public enum SyncTeamM2C
	{

		[ProtoEnum(Name = "STM2C_CREATE_TEAM", Value = 1)]
		STM2C_CREATE_TEAM = 1,

		[ProtoEnum(Name = "STM2C_ADD_MEMBER", Value = 2)]
		STM2C_ADD_MEMBER,

		[ProtoEnum(Name = "STM2C_DEL_MEMBER", Value = 3)]
		STM2C_DEL_MEMBER,

		[ProtoEnum(Name = "STM2C_ALL_DATA", Value = 4)]
		STM2C_ALL_DATA,

		[ProtoEnum(Name = "STM2C_TEAM_LIST", Value = 5)]
		STM2C_TEAM_LIST,

		[ProtoEnum(Name = "STM2C_DESTROY", Value = 6)]
		STM2C_DESTROY,

		[ProtoEnum(Name = "STM2C_GETEXTRADATA", Value = 7)]
		STM2C_GETEXTRADATA,

		[ProtoEnum(Name = "STM2C_RESETCOST", Value = 8)]
		STM2C_RESETCOST,

		[ProtoEnum(Name = "STM2C_TS_DISCONNECTED", Value = 9)]
		STM2C_TS_DISCONNECTED
	}
}
