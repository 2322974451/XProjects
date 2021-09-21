using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020007DC RID: 2012
	[ProtoContract(Name = "GCFsynType")]
	public enum GCFsynType
	{
		// Token: 0x0400262D RID: 9773
		[ProtoEnum(Name = "GCF_SYN_KILL", Value = 1)]
		GCF_SYN_KILL = 1,
		// Token: 0x0400262E RID: 9774
		[ProtoEnum(Name = "GCF_SYN_LEAVE_BATTLE", Value = 2)]
		GCF_SYN_LEAVE_BATTLE,
		// Token: 0x0400262F RID: 9775
		[ProtoEnum(Name = "GCF_SYN_OCCUPY", Value = 3)]
		GCF_SYN_OCCUPY,
		// Token: 0x04002630 RID: 9776
		[ProtoEnum(Name = "GCF_SYN_MUL_POINT", Value = 4)]
		GCF_SYN_MUL_POINT,
		// Token: 0x04002631 RID: 9777
		[ProtoEnum(Name = "GCF_SYN_FIGHT_END", Value = 5)]
		GCF_SYN_FIGHT_END,
		// Token: 0x04002632 RID: 9778
		[ProtoEnum(Name = "GCF_SYN_BACK_TO_READY", Value = 6)]
		GCF_SYN_BACK_TO_READY
	}
}
