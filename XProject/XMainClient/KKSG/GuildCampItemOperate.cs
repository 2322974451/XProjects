using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000808 RID: 2056
	[ProtoContract(Name = "GuildCampItemOperate")]
	public enum GuildCampItemOperate
	{
		// Token: 0x04002731 RID: 10033
		[ProtoEnum(Name = "SWINGUPITEM", Value = 1)]
		SWINGUPITEM = 1,
		// Token: 0x04002732 RID: 10034
		[ProtoEnum(Name = "SWINGDOWNITEM", Value = 2)]
		SWINGDOWNITEM,
		// Token: 0x04002733 RID: 10035
		[ProtoEnum(Name = "CANCEL", Value = 3)]
		CANCEL,
		// Token: 0x04002734 RID: 10036
		[ProtoEnum(Name = "CONFIRM", Value = 4)]
		CONFIRM,
		// Token: 0x04002735 RID: 10037
		[ProtoEnum(Name = "AUDIOCHAT", Value = 5)]
		AUDIOCHAT,
		// Token: 0x04002736 RID: 10038
		[ProtoEnum(Name = "TEXTCHAT", Value = 6)]
		TEXTCHAT
	}
}
