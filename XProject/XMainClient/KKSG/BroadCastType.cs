using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020007B5 RID: 1973
	[ProtoContract(Name = "BroadCastType")]
	public enum BroadCastType
	{
		// Token: 0x04002546 RID: 9542
		[ProtoEnum(Name = "BroadCastToAll", Value = 1)]
		BroadCastToAll = 1,
		// Token: 0x04002547 RID: 9543
		[ProtoEnum(Name = "BroadCastMax", Value = 2)]
		BroadCastMax
	}
}
