using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200078F RID: 1935
	[ProtoContract(Name = "GMFFailReason")]
	public enum GMFFailReason
	{
		// Token: 0x0400245B RID: 9307
		[ProtoEnum(Name = "GMF_FAIL_NONE", Value = 0)]
		GMF_FAIL_NONE,
		// Token: 0x0400245C RID: 9308
		[ProtoEnum(Name = "GMF_FAIL_DIE", Value = 1)]
		GMF_FAIL_DIE,
		// Token: 0x0400245D RID: 9309
		[ProtoEnum(Name = "GMF_FAIL_TIMEOVER", Value = 2)]
		GMF_FAIL_TIMEOVER,
		// Token: 0x0400245E RID: 9310
		[ProtoEnum(Name = "GMF_FAIL_QUIT", Value = 3)]
		GMF_FAIL_QUIT,
		// Token: 0x0400245F RID: 9311
		[ProtoEnum(Name = "GMF_FAIL_REFRESE", Value = 4)]
		GMF_FAIL_REFRESE
	}
}
