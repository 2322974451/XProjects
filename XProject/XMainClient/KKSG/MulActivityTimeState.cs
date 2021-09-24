using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "MulActivityTimeState")]
	public enum MulActivityTimeState
	{

		[ProtoEnum(Name = "MULACTIVITY_BEfOREOPEN", Value = 1)]
		MULACTIVITY_BEfOREOPEN = 1,

		[ProtoEnum(Name = "MULACTIVITY_RUNNING", Value = 2)]
		MULACTIVITY_RUNNING,

		[ProtoEnum(Name = "MULACTIVITY_END", Value = 3)]
		MULACTIVITY_END,

		[ProtoEnum(Name = "MULACTIVITY_UNOPEN_TODAY", Value = 4)]
		MULACTIVITY_UNOPEN_TODAY
	}
}
