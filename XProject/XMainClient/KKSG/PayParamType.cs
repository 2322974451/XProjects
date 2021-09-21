using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000798 RID: 1944
	[ProtoContract(Name = "PayParamType")]
	public enum PayParamType
	{
		// Token: 0x0400248E RID: 9358
		[ProtoEnum(Name = "PAY_PARAM_NONE", Value = 0)]
		PAY_PARAM_NONE,
		// Token: 0x0400248F RID: 9359
		[ProtoEnum(Name = "PAY_PARAM_LIST", Value = 1)]
		PAY_PARAM_LIST,
		// Token: 0x04002490 RID: 9360
		[ProtoEnum(Name = "PAY_PARAM_AILEEN", Value = 2)]
		PAY_PARAM_AILEEN,
		// Token: 0x04002491 RID: 9361
		[ProtoEnum(Name = "PAY_PARAM_CARD", Value = 3)]
		PAY_PARAM_CARD,
		// Token: 0x04002492 RID: 9362
		[ProtoEnum(Name = "PAY_PARAM_FIRSTAWARD", Value = 4)]
		PAY_PARAM_FIRSTAWARD,
		// Token: 0x04002493 RID: 9363
		[ProtoEnum(Name = "PAY_PARAM_GROWTH_FUND", Value = 5)]
		PAY_PARAM_GROWTH_FUND,
		// Token: 0x04002494 RID: 9364
		[ProtoEnum(Name = "PAY_PARAM_MEMBER", Value = 6)]
		PAY_PARAM_MEMBER
	}
}
