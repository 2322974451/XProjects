using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020007DD RID: 2013
	[ProtoContract(Name = "GUILDTERRTYPE")]
	public enum GUILDTERRTYPE
	{
		// Token: 0x04002634 RID: 9780
		[ProtoEnum(Name = "TERR_NOT_OPEN", Value = 1)]
		TERR_NOT_OPEN = 1,
		// Token: 0x04002635 RID: 9781
		[ProtoEnum(Name = "ALLIANCE", Value = 2)]
		ALLIANCE,
		// Token: 0x04002636 RID: 9782
		[ProtoEnum(Name = "TERR_WARING", Value = 3)]
		TERR_WARING,
		// Token: 0x04002637 RID: 9783
		[ProtoEnum(Name = "TERR_END", Value = 4)]
		TERR_END,
		// Token: 0x04002638 RID: 9784
		[ProtoEnum(Name = "WAITING", Value = 5)]
		WAITING
	}
}
