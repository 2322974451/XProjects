using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "EnumServerState")]
	public enum EnumServerState
	{

		[ProtoEnum(Name = "ServerState_Maintain", Value = 0)]
		ServerState_Maintain,

		[ProtoEnum(Name = "ServerState_Smooth", Value = 1)]
		ServerState_Smooth,

		[ProtoEnum(Name = "ServerState_Hot", Value = 2)]
		ServerState_Hot,

		[ProtoEnum(Name = "ServerState_Full", Value = 3)]
		ServerState_Full,

		[ProtoEnum(Name = "ServerState_Recommend", Value = 4)]
		ServerState_Recommend,

		[ProtoEnum(Name = "ServerState_Auto", Value = 5)]
		ServerState_Auto
	}
}
