using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "Festival520Type")]
	public enum Festival520Type
	{

		[ProtoEnum(Name = "Festival520_NormalDonate", Value = 1)]
		Festival520_NormalDonate = 1,

		[ProtoEnum(Name = "Festival520_PreciousDonate", Value = 2)]
		Festival520_PreciousDonate,

		[ProtoEnum(Name = "Festival520_GetPrize", Value = 3)]
		Festival520_GetPrize,

		[ProtoEnum(Name = "Festival520_GetInfo", Value = 4)]
		Festival520_GetInfo
	}
}
