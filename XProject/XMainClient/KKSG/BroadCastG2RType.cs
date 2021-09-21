using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020007E1 RID: 2017
	[ProtoContract(Name = "BroadCastG2RType")]
	public enum BroadCastG2RType
	{
		// Token: 0x04002648 RID: 9800
		[ProtoEnum(Name = "BroadCastG2RType_MS", Value = 1)]
		BroadCastG2RType_MS = 1,
		// Token: 0x04002649 RID: 9801
		[ProtoEnum(Name = "BroadCastG2RType_NS", Value = 2)]
		BroadCastG2RType_NS,
		// Token: 0x0400264A RID: 9802
		[ProtoEnum(Name = "BroadCastG2RType_DB", Value = 3)]
		BroadCastG2RType_DB
	}
}
