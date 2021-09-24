using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "TeamInvRoleState")]
	public enum TeamInvRoleState
	{

		[ProtoEnum(Name = "TIRS_IN_OTHER_TEAM", Value = 1)]
		TIRS_IN_OTHER_TEAM = 1,

		[ProtoEnum(Name = "TIRS_IN_MY_TEAM", Value = 2)]
		TIRS_IN_MY_TEAM,

		[ProtoEnum(Name = "TIRS_IN_BATTLE", Value = 3)]
		TIRS_IN_BATTLE,

		[ProtoEnum(Name = "TIRS_NORMAL", Value = 4)]
		TIRS_NORMAL,

		[ProtoEnum(Name = "TIRS_NOT_OPEN", Value = 5)]
		TIRS_NOT_OPEN,

		[ProtoEnum(Name = "TIRS_COUNT_LESS", Value = 6)]
		TIRS_COUNT_LESS,

		[ProtoEnum(Name = "TIRS_FATIGUE_LESS", Value = 7)]
		TIRS_FATIGUE_LESS
	}
}
