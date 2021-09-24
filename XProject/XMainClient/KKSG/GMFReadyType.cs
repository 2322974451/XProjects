using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GMFReadyType")]
	public enum GMFReadyType
	{

		[ProtoEnum(Name = "GMF_READY_UP", Value = 1)]
		GMF_READY_UP = 1,

		[ProtoEnum(Name = "GMF_READY_DOWN", Value = 2)]
		GMF_READY_DOWN,

		[ProtoEnum(Name = "GMF_READY_KICK", Value = 3)]
		GMF_READY_KICK
	}
}
