using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200075D RID: 1885
	[ProtoContract(Name = "GuildSortType")]
	public enum GuildSortType
	{
		// Token: 0x04002311 RID: 8977
		[ProtoEnum(Name = "GuildSortByLevel", Value = 1)]
		GuildSortByLevel = 1,
		// Token: 0x04002312 RID: 8978
		[ProtoEnum(Name = "GuildSortByMemberCount", Value = 2)]
		GuildSortByMemberCount,
		// Token: 0x04002313 RID: 8979
		[ProtoEnum(Name = "GuildSortByName", Value = 3)]
		GuildSortByName,
		// Token: 0x04002314 RID: 8980
		[ProtoEnum(Name = "GuildSortByExp", Value = 4)]
		GuildSortByExp,
		// Token: 0x04002315 RID: 8981
		[ProtoEnum(Name = "GuildSortByPrestige", Value = 5)]
		GuildSortByPrestige
	}
}
