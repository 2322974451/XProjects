using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000838 RID: 2104
	[ProtoContract(Name = "Festival520Type")]
	public enum Festival520Type
	{
		// Token: 0x0400282C RID: 10284
		[ProtoEnum(Name = "Festival520_NormalDonate", Value = 1)]
		Festival520_NormalDonate = 1,
		// Token: 0x0400282D RID: 10285
		[ProtoEnum(Name = "Festival520_PreciousDonate", Value = 2)]
		Festival520_PreciousDonate,
		// Token: 0x0400282E RID: 10286
		[ProtoEnum(Name = "Festival520_GetPrize", Value = 3)]
		Festival520_GetPrize,
		// Token: 0x0400282F RID: 10287
		[ProtoEnum(Name = "Festival520_GetInfo", Value = 4)]
		Festival520_GetInfo
	}
}
