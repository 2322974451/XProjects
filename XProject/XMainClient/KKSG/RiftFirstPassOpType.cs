using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000831 RID: 2097
	[ProtoContract(Name = "RiftFirstPassOpType")]
	public enum RiftFirstPassOpType
	{
		// Token: 0x0400280D RID: 10253
		[ProtoEnum(Name = "Rift_FirstPass_Op_GetInfo", Value = 1)]
		Rift_FirstPass_Op_GetInfo = 1,
		// Token: 0x0400280E RID: 10254
		[ProtoEnum(Name = "Rift_FirstPass_Op_GetReward", Value = 2)]
		Rift_FirstPass_Op_GetReward
	}
}
