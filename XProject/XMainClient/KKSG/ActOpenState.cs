using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "ActOpenState")]
	public enum ActOpenState
	{

		[ProtoEnum(Name = "ActOpenState_NotOpen", Value = 1)]
		ActOpenState_NotOpen = 1,

		[ProtoEnum(Name = "ActOpenState_Prepare", Value = 2)]
		ActOpenState_Prepare,

		[ProtoEnum(Name = "ActOpenState_Running", Value = 3)]
		ActOpenState_Running,

		[ProtoEnum(Name = "ActOpenState_Over", Value = 4)]
		ActOpenState_Over
	}
}
