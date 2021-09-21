using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000775 RID: 1909
	[ProtoContract(Name = "AchieveType")]
	public enum AchieveType
	{
		// Token: 0x040023BF RID: 9151
		[ProtoEnum(Name = "ACHIEVE_TYPE_COMMON", Value = 1)]
		ACHIEVE_TYPE_COMMON = 1,
		// Token: 0x040023C0 RID: 9152
		[ProtoEnum(Name = "ACHIEVE_TYPE_RAID", Value = 2)]
		ACHIEVE_TYPE_RAID,
		// Token: 0x040023C1 RID: 9153
		[ProtoEnum(Name = "ACHIEVE_TYPE_NEST", Value = 3)]
		ACHIEVE_TYPE_NEST,
		// Token: 0x040023C2 RID: 9154
		[ProtoEnum(Name = "ACHIEVE_TYPE_BATTLE", Value = 4)]
		ACHIEVE_TYPE_BATTLE,
		// Token: 0x040023C3 RID: 9155
		[ProtoEnum(Name = "ACHIEVE_TYPE_ACTIVITY", Value = 5)]
		ACHIEVE_TYPE_ACTIVITY
	}
}
