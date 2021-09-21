using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000818 RID: 2072
	[ProtoContract(Name = "WeddingType")]
	public enum WeddingType
	{
		// Token: 0x04002771 RID: 10097
		[ProtoEnum(Name = "WeddingType_Normal", Value = 1)]
		WeddingType_Normal = 1,
		// Token: 0x04002772 RID: 10098
		[ProtoEnum(Name = "WeddingType_Luxury", Value = 2)]
		WeddingType_Luxury
	}
}
