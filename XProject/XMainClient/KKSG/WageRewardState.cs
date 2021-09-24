using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "WageRewardState")]
	public enum WageRewardState
	{

		[ProtoEnum(Name = "cannot", Value = 1)]
		cannot = 1,

		[ProtoEnum(Name = "rewarded", Value = 2)]
		rewarded,

		[ProtoEnum(Name = "notreward", Value = 3)]
		notreward
	}
}
