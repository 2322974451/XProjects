using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000766 RID: 1894
	[ProtoContract(Name = "FishingState")]
	public enum FishingState
	{
		// Token: 0x04002369 RID: 9065
		[ProtoEnum(Name = "LEAVE", Value = 1)]
		LEAVE = 1,
		// Token: 0x0400236A RID: 9066
		[ProtoEnum(Name = "SITDOWN", Value = 2)]
		SITDOWN,
		// Token: 0x0400236B RID: 9067
		[ProtoEnum(Name = "CAST", Value = 3)]
		CAST,
		// Token: 0x0400236C RID: 9068
		[ProtoEnum(Name = "WAIT", Value = 4)]
		WAIT,
		// Token: 0x0400236D RID: 9069
		[ProtoEnum(Name = "PULL", Value = 5)]
		PULL
	}
}
