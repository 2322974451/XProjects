using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "DHRState")]
	public enum DHRState
	{

		[ProtoEnum(Name = "DHR_CANNOT", Value = 1)]
		DHR_CANNOT = 1,

		[ProtoEnum(Name = "DHR_CAN_HAVEHOT", Value = 2)]
		DHR_CAN_HAVEHOT,

		[ProtoEnum(Name = "DHR_CAN_HAVE", Value = 3)]
		DHR_CAN_HAVE
	}
}
