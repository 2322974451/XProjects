using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "WeddingState")]
	public enum WeddingState
	{

		[ProtoEnum(Name = "WeddingState_Prepare", Value = 1)]
		WeddingState_Prepare = 1,

		[ProtoEnum(Name = "WeddingState_Running", Value = 2)]
		WeddingState_Running
	}
}
