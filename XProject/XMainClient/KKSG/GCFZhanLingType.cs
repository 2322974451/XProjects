using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020007DB RID: 2011
	[ProtoContract(Name = "GCFZhanLingType")]
	public enum GCFZhanLingType
	{
		// Token: 0x04002629 RID: 9769
		[ProtoEnum(Name = "GCFZL_BEGIN", Value = 1)]
		GCFZL_BEGIN = 1,
		// Token: 0x0400262A RID: 9770
		[ProtoEnum(Name = "GCFZL_BREAK", Value = 2)]
		GCFZL_BREAK,
		// Token: 0x0400262B RID: 9771
		[ProtoEnum(Name = "GCFZL_END", Value = 3)]
		GCFZL_END
	}
}
