using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "IntegralState")]
	public enum IntegralState
	{

		[ProtoEnum(Name = "integralready", Value = 1)]
		integralready = 1,

		[ProtoEnum(Name = "integralenterscene", Value = 2)]
		integralenterscene,

		[ProtoEnum(Name = "integralwatch", Value = 3)]
		integralwatch,

		[ProtoEnum(Name = "integralend", Value = 4)]
		integralend
	}
}
