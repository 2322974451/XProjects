using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "PayParamType")]
	public enum PayParamType
	{

		[ProtoEnum(Name = "PAY_PARAM_NONE", Value = 0)]
		PAY_PARAM_NONE,

		[ProtoEnum(Name = "PAY_PARAM_LIST", Value = 1)]
		PAY_PARAM_LIST,

		[ProtoEnum(Name = "PAY_PARAM_AILEEN", Value = 2)]
		PAY_PARAM_AILEEN,

		[ProtoEnum(Name = "PAY_PARAM_CARD", Value = 3)]
		PAY_PARAM_CARD,

		[ProtoEnum(Name = "PAY_PARAM_FIRSTAWARD", Value = 4)]
		PAY_PARAM_FIRSTAWARD,

		[ProtoEnum(Name = "PAY_PARAM_GROWTH_FUND", Value = 5)]
		PAY_PARAM_GROWTH_FUND,

		[ProtoEnum(Name = "PAY_PARAM_MEMBER", Value = 6)]
		PAY_PARAM_MEMBER
	}
}
