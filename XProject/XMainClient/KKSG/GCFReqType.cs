using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020007D9 RID: 2009
	[ProtoContract(Name = "GCFReqType")]
	public enum GCFReqType
	{
		// Token: 0x04002620 RID: 9760
		[ProtoEnum(Name = "GCF_JOIN_READY_SCENE", Value = 1)]
		GCF_JOIN_READY_SCENE = 1,
		// Token: 0x04002621 RID: 9761
		[ProtoEnum(Name = "GCF_FIGHT_REPORT", Value = 2)]
		GCF_FIGHT_REPORT,
		// Token: 0x04002622 RID: 9762
		[ProtoEnum(Name = "GCF_FIGHT_RESULT", Value = 3)]
		GCF_FIGHT_RESULT,
		// Token: 0x04002623 RID: 9763
		[ProtoEnum(Name = "GCF_JOIN_FIGHT_SCENE", Value = 4)]
		GCF_JOIN_FIGHT_SCENE
	}
}
