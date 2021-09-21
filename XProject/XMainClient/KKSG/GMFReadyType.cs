using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020007B0 RID: 1968
	[ProtoContract(Name = "GMFReadyType")]
	public enum GMFReadyType
	{
		// Token: 0x04002523 RID: 9507
		[ProtoEnum(Name = "GMF_READY_UP", Value = 1)]
		GMF_READY_UP = 1,
		// Token: 0x04002524 RID: 9508
		[ProtoEnum(Name = "GMF_READY_DOWN", Value = 2)]
		GMF_READY_DOWN,
		// Token: 0x04002525 RID: 9509
		[ProtoEnum(Name = "GMF_READY_KICK", Value = 3)]
		GMF_READY_KICK
	}
}
