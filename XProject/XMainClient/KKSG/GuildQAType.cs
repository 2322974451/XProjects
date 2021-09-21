using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020007EC RID: 2028
	[ProtoContract(Name = "GuildQAType")]
	public enum GuildQAType
	{
		// Token: 0x04002682 RID: 9858
		[ProtoEnum(Name = "NO_GUILD", Value = 0)]
		NO_GUILD,
		// Token: 0x04002683 RID: 9859
		[ProtoEnum(Name = "BEFORE_OPEN", Value = 1)]
		BEFORE_OPEN,
		// Token: 0x04002684 RID: 9860
		[ProtoEnum(Name = "IN_TIME_NOT_OPEN", Value = 2)]
		IN_TIME_NOT_OPEN,
		// Token: 0x04002685 RID: 9861
		[ProtoEnum(Name = "IN_TIME_OPENING", Value = 3)]
		IN_TIME_OPENING,
		// Token: 0x04002686 RID: 9862
		[ProtoEnum(Name = "AFTER_OPEN", Value = 4)]
		AFTER_OPEN,
		// Token: 0x04002687 RID: 9863
		[ProtoEnum(Name = "NOT_OPEN_DAY", Value = 5)]
		NOT_OPEN_DAY
	}
}
