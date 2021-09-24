using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "LBEleRoomState")]
	public enum LBEleRoomState
	{

		[ProtoEnum(Name = "LBEleRoomState_Idle", Value = 1)]
		LBEleRoomState_Idle = 1,

		[ProtoEnum(Name = "LBEleRoomState_Fighting", Value = 2)]
		LBEleRoomState_Fighting,

		[ProtoEnum(Name = "LBEleRoomState_Finish", Value = 3)]
		LBEleRoomState_Finish
	}
}
