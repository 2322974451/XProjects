using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "FishingState")]
	public enum FishingState
	{

		[ProtoEnum(Name = "LEAVE", Value = 1)]
		LEAVE = 1,

		[ProtoEnum(Name = "SITDOWN", Value = 2)]
		SITDOWN,

		[ProtoEnum(Name = "CAST", Value = 3)]
		CAST,

		[ProtoEnum(Name = "WAIT", Value = 4)]
		WAIT,

		[ProtoEnum(Name = "PULL", Value = 5)]
		PULL
	}
}
