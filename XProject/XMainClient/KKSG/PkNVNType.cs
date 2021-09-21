using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200080F RID: 2063
	[ProtoContract(Name = "PkNVNType")]
	public enum PkNVNType
	{
		// Token: 0x04002751 RID: 10065
		[ProtoEnum(Name = "PK_1v1", Value = 1)]
		PK_1v1 = 1,
		// Token: 0x04002752 RID: 10066
		[ProtoEnum(Name = "PK_2v2", Value = 2)]
		PK_2v2
	}
}
