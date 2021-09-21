using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020007AA RID: 1962
	[ProtoContract(Name = "ItemEnum")]
	public enum ItemEnum
	{
		// Token: 0x04002509 RID: 9481
		[ProtoEnum(Name = "Virtual_Max", Value = 50)]
		Virtual_Max = 50
	}
}
