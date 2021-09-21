using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020007AB RID: 1963
	[ProtoContract(Name = "GuildCardOp")]
	public enum GuildCardOp
	{
		// Token: 0x0400250B RID: 9483
		[ProtoEnum(Name = "GuildCard_Query", Value = 1)]
		GuildCard_Query = 1,
		// Token: 0x0400250C RID: 9484
		[ProtoEnum(Name = "GuildCard_Start", Value = 2)]
		GuildCard_Start,
		// Token: 0x0400250D RID: 9485
		[ProtoEnum(Name = "GuildCard_Change", Value = 3)]
		GuildCard_Change,
		// Token: 0x0400250E RID: 9486
		[ProtoEnum(Name = "GuildCard_End", Value = 4)]
		GuildCard_End
	}
}
