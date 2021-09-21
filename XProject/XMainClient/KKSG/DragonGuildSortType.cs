using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000823 RID: 2083
	[ProtoContract(Name = "DragonGuildSortType")]
	public enum DragonGuildSortType
	{
		// Token: 0x040027B8 RID: 10168
		[ProtoEnum(Name = "DragonGuildSortByLevel", Value = 1)]
		DragonGuildSortByLevel = 1,
		// Token: 0x040027B9 RID: 10169
		[ProtoEnum(Name = "DragonGuildSortByMemberCount", Value = 2)]
		DragonGuildSortByMemberCount,
		// Token: 0x040027BA RID: 10170
		[ProtoEnum(Name = "DragongGuildSortByTotalPPT", Value = 3)]
		DragongGuildSortByTotalPPT,
		// Token: 0x040027BB RID: 10171
		[ProtoEnum(Name = "DragonGuildSortBySceneID", Value = 4)]
		DragonGuildSortBySceneID,
		// Token: 0x040027BC RID: 10172
		[ProtoEnum(Name = "DragonGuildSortByName", Value = 5)]
		DragonGuildSortByName,
		// Token: 0x040027BD RID: 10173
		[ProtoEnum(Name = "DragonGuildSortByLeaderName", Value = 6)]
		DragonGuildSortByLeaderName
	}
}
