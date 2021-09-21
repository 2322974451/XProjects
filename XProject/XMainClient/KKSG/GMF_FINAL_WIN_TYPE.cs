using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020007B9 RID: 1977
	[ProtoContract(Name = "GMF_FINAL_WIN_TYPE")]
	public enum GMF_FINAL_WIN_TYPE
	{
		// Token: 0x04002561 RID: 9569
		[ProtoEnum(Name = "GMF_FWY_NORMAL", Value = 1)]
		GMF_FWY_NORMAL = 1,
		// Token: 0x04002562 RID: 9570
		[ProtoEnum(Name = "GMF_FWY_OPNONE", Value = 2)]
		GMF_FWY_OPNONE,
		// Token: 0x04002563 RID: 9571
		[ProtoEnum(Name = "GMF_FWY_RANK", Value = 3)]
		GMF_FWY_RANK
	}
}
