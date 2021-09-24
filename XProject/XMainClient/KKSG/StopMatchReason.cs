using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "StopMatchReason")]
	public enum StopMatchReason
	{

		[ProtoEnum(Name = "STOPMATCH_NONE", Value = 1)]
		STOPMATCH_NONE = 1,

		[ProtoEnum(Name = "STOPMATCH_LEAVESCENE", Value = 2)]
		STOPMATCH_LEAVESCENE,

		[ProtoEnum(Name = "STOPMATCH_ENTER_TIANTI", Value = 3)]
		STOPMATCH_ENTER_TIANTI,

		[ProtoEnum(Name = "STOPMATCH_ENTER_BOWEIDUIZ", Value = 4)]
		STOPMATCH_ENTER_BOWEIDUIZ
	}
}
