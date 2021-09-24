using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "RiftFirstPassOpType")]
	public enum RiftFirstPassOpType
	{

		[ProtoEnum(Name = "Rift_FirstPass_Op_GetInfo", Value = 1)]
		Rift_FirstPass_Op_GetInfo = 1,

		[ProtoEnum(Name = "Rift_FirstPass_Op_GetReward", Value = 2)]
		Rift_FirstPass_Op_GetReward
	}
}
