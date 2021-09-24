using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "KickType")]
	public enum KickType
	{

		[ProtoEnum(Name = "KICK_NORMAL", Value = 0)]
		KICK_NORMAL,

		[ProtoEnum(Name = "KICK_RELOGIN", Value = 1)]
		KICK_RELOGIN,

		[ProtoEnum(Name = "KICK_GMFORBID", Value = 2)]
		KICK_GMFORBID,

		[ProtoEnum(Name = "KICK_SERVER_SHUTDOWN", Value = 3)]
		KICK_SERVER_SHUTDOWN,

		[ProtoEnum(Name = "KICK_DEL_ROLE", Value = 4)]
		KICK_DEL_ROLE,

		[ProtoEnum(Name = "KICK_CHANGE_PROFESSION", Value = 5)]
		KICK_CHANGE_PROFESSION,

		[ProtoEnum(Name = "KICK_HG", Value = 6)]
		KICK_HG
	}
}
