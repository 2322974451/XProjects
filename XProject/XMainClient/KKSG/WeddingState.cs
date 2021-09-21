using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000817 RID: 2071
	[ProtoContract(Name = "WeddingState")]
	public enum WeddingState
	{
		// Token: 0x0400276E RID: 10094
		[ProtoEnum(Name = "WeddingState_Prepare", Value = 1)]
		WeddingState_Prepare = 1,
		// Token: 0x0400276F RID: 10095
		[ProtoEnum(Name = "WeddingState_Running", Value = 2)]
		WeddingState_Running
	}
}
