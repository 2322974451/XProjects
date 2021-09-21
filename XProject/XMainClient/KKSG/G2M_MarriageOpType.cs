using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000837 RID: 2103
	[ProtoContract(Name = "G2M_MarriageOpType")]
	public enum G2M_MarriageOpType
	{
		// Token: 0x04002829 RID: 10281
		[ProtoEnum(Name = "G2M_MarriageOpType_ReqInfo", Value = 1)]
		G2M_MarriageOpType_ReqInfo = 1,
		// Token: 0x0400282A RID: 10282
		[ProtoEnum(Name = "G2M_MarriageOpType_AddLevelValue", Value = 2)]
		G2M_MarriageOpType_AddLevelValue
	}
}
