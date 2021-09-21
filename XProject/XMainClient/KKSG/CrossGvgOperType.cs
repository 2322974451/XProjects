using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000835 RID: 2101
	[ProtoContract(Name = "CrossGvgOperType")]
	public enum CrossGvgOperType
	{
		// Token: 0x04002821 RID: 10273
		[ProtoEnum(Name = "CGOT_EnterPointRace", Value = 1)]
		CGOT_EnterPointRace = 1,
		// Token: 0x04002822 RID: 10274
		[ProtoEnum(Name = "CGOT_EnterKnockout", Value = 2)]
		CGOT_EnterKnockout,
		// Token: 0x04002823 RID: 10275
		[ProtoEnum(Name = "CGOT_SupportGuild", Value = 3)]
		CGOT_SupportGuild,
		// Token: 0x04002824 RID: 10276
		[ProtoEnum(Name = "CGOT_LeaveUI", Value = 4)]
		CGOT_LeaveUI
	}
}
