using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000813 RID: 2067
	[ProtoContract(Name = "DHRState")]
	public enum DHRState
	{
		// Token: 0x0400275E RID: 10078
		[ProtoEnum(Name = "DHR_CANNOT", Value = 1)]
		DHR_CANNOT = 1,
		// Token: 0x0400275F RID: 10079
		[ProtoEnum(Name = "DHR_CAN_HAVEHOT", Value = 2)]
		DHR_CAN_HAVEHOT,
		// Token: 0x04002760 RID: 10080
		[ProtoEnum(Name = "DHR_CAN_HAVE", Value = 3)]
		DHR_CAN_HAVE
	}
}
