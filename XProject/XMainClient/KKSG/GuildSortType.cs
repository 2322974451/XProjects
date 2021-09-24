using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GuildSortType")]
	public enum GuildSortType
	{

		[ProtoEnum(Name = "GuildSortByLevel", Value = 1)]
		GuildSortByLevel = 1,

		[ProtoEnum(Name = "GuildSortByMemberCount", Value = 2)]
		GuildSortByMemberCount,

		[ProtoEnum(Name = "GuildSortByName", Value = 3)]
		GuildSortByName,

		[ProtoEnum(Name = "GuildSortByExp", Value = 4)]
		GuildSortByExp,

		[ProtoEnum(Name = "GuildSortByPrestige", Value = 5)]
		GuildSortByPrestige
	}
}
