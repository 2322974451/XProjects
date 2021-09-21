using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000800 RID: 2048
	[ProtoContract(Name = "LeagueEliType")]
	public enum LeagueEliType
	{
		// Token: 0x04002701 RID: 9985
		[ProtoEnum(Name = "LeagueEliType_None", Value = 1)]
		LeagueEliType_None = 1,
		// Token: 0x04002702 RID: 9986
		[ProtoEnum(Name = "LeagueEliType_Self", Value = 2)]
		LeagueEliType_Self,
		// Token: 0x04002703 RID: 9987
		[ProtoEnum(Name = "LeagueEliType_Cross", Value = 3)]
		LeagueEliType_Cross
	}
}
