using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000814 RID: 2068
	[ProtoContract(Name = "DHRReqOp")]
	public enum DHRReqOp
	{
		// Token: 0x04002762 RID: 10082
		[ProtoEnum(Name = "DHR_OP_LIST", Value = 1)]
		DHR_OP_LIST = 1,
		// Token: 0x04002763 RID: 10083
		[ProtoEnum(Name = "DHR_OP_FETCH_REWARD", Value = 2)]
		DHR_OP_FETCH_REWARD,
		// Token: 0x04002764 RID: 10084
		[ProtoEnum(Name = "DHR_OP_WANT_BE_HELP", Value = 3)]
		DHR_OP_WANT_BE_HELP,
		// Token: 0x04002765 RID: 10085
		[ProtoEnum(Name = "DHR_OP_WANT_NOT_HELP", Value = 4)]
		DHR_OP_WANT_NOT_HELP
	}
}
