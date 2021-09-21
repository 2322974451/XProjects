using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200080C RID: 2060
	[ProtoContract(Name = "KMatchOp")]
	public enum KMatchOp
	{
		// Token: 0x04002744 RID: 10052
		[ProtoEnum(Name = "KMATCH_OP_START", Value = 1)]
		KMATCH_OP_START = 1,
		// Token: 0x04002745 RID: 10053
		[ProtoEnum(Name = "KMATCH_OP_STOP", Value = 2)]
		KMATCH_OP_STOP
	}
}
