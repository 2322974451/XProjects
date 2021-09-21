using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020007FB RID: 2043
	[ProtoContract(Name = "SkyCraftMatchNtfType")]
	public enum SkyCraftMatchNtfType
	{
		// Token: 0x040026EA RID: 9962
		[ProtoEnum(Name = "SCMN_Start", Value = 1)]
		SCMN_Start = 1,
		// Token: 0x040026EB RID: 9963
		[ProtoEnum(Name = "SCMN_Stop", Value = 2)]
		SCMN_Stop,
		// Token: 0x040026EC RID: 9964
		[ProtoEnum(Name = "SCMN_Timeout", Value = 3)]
		SCMN_Timeout
	}
}
