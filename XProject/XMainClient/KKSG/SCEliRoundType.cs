using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020007FD RID: 2045
	[ProtoContract(Name = "SCEliRoundType")]
	public enum SCEliRoundType
	{
		// Token: 0x040026F1 RID: 9969
		[ProtoEnum(Name = "SCEliRound_None", Value = 0)]
		SCEliRound_None,
		// Token: 0x040026F2 RID: 9970
		[ProtoEnum(Name = "SCEliRound_8to4", Value = 1)]
		SCEliRound_8to4,
		// Token: 0x040026F3 RID: 9971
		[ProtoEnum(Name = "SCEliRound_4to2", Value = 2)]
		SCEliRound_4to2,
		// Token: 0x040026F4 RID: 9972
		[ProtoEnum(Name = "SCEliRound_2to1", Value = 3)]
		SCEliRound_2to1
	}
}
