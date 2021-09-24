using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "KMatchOp")]
	public enum KMatchOp
	{

		[ProtoEnum(Name = "KMATCH_OP_START", Value = 1)]
		KMATCH_OP_START = 1,

		[ProtoEnum(Name = "KMATCH_OP_STOP", Value = 2)]
		KMATCH_OP_STOP
	}
}
