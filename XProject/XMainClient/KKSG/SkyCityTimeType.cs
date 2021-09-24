using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "SkyCityTimeType")]
	public enum SkyCityTimeType
	{

		[ProtoEnum(Name = "Waiting", Value = 1)]
		Waiting = 1,

		[ProtoEnum(Name = "Race", Value = 2)]
		Race,

		[ProtoEnum(Name = "MidleEndInRest", Value = 3)]
		MidleEndInRest,

		[ProtoEnum(Name = "FirstWaiting", Value = 4)]
		FirstWaiting,

		[ProtoEnum(Name = "SecondWaiting", Value = 5)]
		SecondWaiting,

		[ProtoEnum(Name = "SC_NONE", Value = 6)]
		SC_NONE
	}
}
