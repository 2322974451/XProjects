using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200078D RID: 1933
	[ProtoContract(Name = "WorldBossState")]
	public enum WorldBossState
	{
		// Token: 0x0400244E RID: 9294
		[ProtoEnum(Name = "WorldBoss_BeginPre", Value = 0)]
		WorldBoss_BeginPre,
		// Token: 0x0400244F RID: 9295
		[ProtoEnum(Name = "WorldBoss_Begin", Value = 1)]
		WorldBoss_Begin,
		// Token: 0x04002450 RID: 9296
		[ProtoEnum(Name = "WorldBoss_Going", Value = 2)]
		WorldBoss_Going,
		// Token: 0x04002451 RID: 9297
		[ProtoEnum(Name = "WorldBoss_WaitEnd", Value = 3)]
		WorldBoss_WaitEnd,
		// Token: 0x04002452 RID: 9298
		[ProtoEnum(Name = "WorldBoss_End", Value = 4)]
		WorldBoss_End
	}
}
