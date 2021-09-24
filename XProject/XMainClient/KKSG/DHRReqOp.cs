using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "DHRReqOp")]
	public enum DHRReqOp
	{

		[ProtoEnum(Name = "DHR_OP_LIST", Value = 1)]
		DHR_OP_LIST = 1,

		[ProtoEnum(Name = "DHR_OP_FETCH_REWARD", Value = 2)]
		DHR_OP_FETCH_REWARD,

		[ProtoEnum(Name = "DHR_OP_WANT_BE_HELP", Value = 3)]
		DHR_OP_WANT_BE_HELP,

		[ProtoEnum(Name = "DHR_OP_WANT_NOT_HELP", Value = 4)]
		DHR_OP_WANT_NOT_HELP
	}
}
