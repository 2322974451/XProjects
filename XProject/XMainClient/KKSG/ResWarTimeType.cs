using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "ResWarTimeType")]
	public enum ResWarTimeType
	{

		[ProtoEnum(Name = "RealyTime", Value = 1)]
		RealyTime = 1,

		[ProtoEnum(Name = "RaceTime", Value = 2)]
		RaceTime,

		[ProtoEnum(Name = "EndTime", Value = 3)]
		EndTime,

		[ProtoEnum(Name = "ResWarNone", Value = 4)]
		ResWarNone
	}
}
