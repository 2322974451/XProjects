using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "AchieveType")]
	public enum AchieveType
	{

		[ProtoEnum(Name = "ACHIEVE_TYPE_COMMON", Value = 1)]
		ACHIEVE_TYPE_COMMON = 1,

		[ProtoEnum(Name = "ACHIEVE_TYPE_RAID", Value = 2)]
		ACHIEVE_TYPE_RAID,

		[ProtoEnum(Name = "ACHIEVE_TYPE_NEST", Value = 3)]
		ACHIEVE_TYPE_NEST,

		[ProtoEnum(Name = "ACHIEVE_TYPE_BATTLE", Value = 4)]
		ACHIEVE_TYPE_BATTLE,

		[ProtoEnum(Name = "ACHIEVE_TYPE_ACTIVITY", Value = 5)]
		ACHIEVE_TYPE_ACTIVITY
	}
}
