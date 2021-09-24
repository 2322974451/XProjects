using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "CrossGvgRoomState")]
	public enum CrossGvgRoomState
	{

		[ProtoEnum(Name = "CGRS_Idle", Value = 1)]
		CGRS_Idle = 1,

		[ProtoEnum(Name = "CGRS_Fighting", Value = 2)]
		CGRS_Fighting,

		[ProtoEnum(Name = "CGRS_Finish", Value = 3)]
		CGRS_Finish
	}
}
