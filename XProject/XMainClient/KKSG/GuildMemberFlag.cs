using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GuildMemberFlag")]
	public enum GuildMemberFlag
	{

		[ProtoEnum(Name = "SEND_FATIGUE", Value = 1)]
		SEND_FATIGUE = 1,

		[ProtoEnum(Name = "RECV_FATIGUE", Value = 2)]
		RECV_FATIGUE,

		[ProtoEnum(Name = "RECVED_FATIGUE", Value = 4)]
		RECVED_FATIGUE = 4,

		[ProtoEnum(Name = "ONLINE", Value = 8)]
		ONLINE = 8
	}
}
