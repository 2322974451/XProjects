using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "DesignationType")]
	public enum DesignationType
	{

		[ProtoEnum(Name = "DESIGNATION_TYPE_COMMON", Value = 1)]
		DESIGNATION_TYPE_COMMON = 1,

		[ProtoEnum(Name = "DESIGNATION_TYPE_RAID", Value = 2)]
		DESIGNATION_TYPE_RAID,

		[ProtoEnum(Name = "DESIGNATION_TYPE_NEST", Value = 3)]
		DESIGNATION_TYPE_NEST,

		[ProtoEnum(Name = "DESIGNATION_TYPE_BATTLE", Value = 4)]
		DESIGNATION_TYPE_BATTLE,

		[ProtoEnum(Name = "DESIGNATION_TYPE_ACTIVITY", Value = 5)]
		DESIGNATION_TYPE_ACTIVITY
	}
}
