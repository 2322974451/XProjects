using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000792 RID: 1938
	[ProtoContract(Name = "SynsMsSubType")]
	public enum SynsMsSubType
	{
		// Token: 0x04002469 RID: 9321
		[ProtoEnum(Name = "SynsCreate", Value = 1)]
		SynsCreate = 1,
		// Token: 0x0400246A RID: 9322
		[ProtoEnum(Name = "SynsDestory", Value = 2)]
		SynsDestory,
		// Token: 0x0400246B RID: 9323
		[ProtoEnum(Name = "SynsAdd", Value = 3)]
		SynsAdd,
		// Token: 0x0400246C RID: 9324
		[ProtoEnum(Name = "SynsDel", Value = 4)]
		SynsDel,
		// Token: 0x0400246D RID: 9325
		[ProtoEnum(Name = "SynsLead", Value = 5)]
		SynsLead,
		// Token: 0x0400246E RID: 9326
		[ProtoEnum(Name = "SynsLevel", Value = 6)]
		SynsLevel,
		// Token: 0x0400246F RID: 9327
		[ProtoEnum(Name = "SynsIcon", Value = 7)]
		SynsIcon,
		// Token: 0x04002470 RID: 9328
		[ProtoEnum(Name = "SynAddExp", Value = 8)]
		SynAddExp,
		// Token: 0x04002471 RID: 9329
		[ProtoEnum(Name = "SynSetTime", Value = 9)]
		SynSetTime
	}
}
