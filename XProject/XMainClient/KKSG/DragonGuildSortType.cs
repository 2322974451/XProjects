using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "DragonGuildSortType")]
	public enum DragonGuildSortType
	{

		[ProtoEnum(Name = "DragonGuildSortByLevel", Value = 1)]
		DragonGuildSortByLevel = 1,

		[ProtoEnum(Name = "DragonGuildSortByMemberCount", Value = 2)]
		DragonGuildSortByMemberCount,

		[ProtoEnum(Name = "DragongGuildSortByTotalPPT", Value = 3)]
		DragongGuildSortByTotalPPT,

		[ProtoEnum(Name = "DragonGuildSortBySceneID", Value = 4)]
		DragonGuildSortBySceneID,

		[ProtoEnum(Name = "DragonGuildSortByName", Value = 5)]
		DragonGuildSortByName,

		[ProtoEnum(Name = "DragonGuildSortByLeaderName", Value = 6)]
		DragonGuildSortByLeaderName
	}
}
