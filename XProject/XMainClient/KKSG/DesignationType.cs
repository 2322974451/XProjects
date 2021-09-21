using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000774 RID: 1908
	[ProtoContract(Name = "DesignationType")]
	public enum DesignationType
	{
		// Token: 0x040023B9 RID: 9145
		[ProtoEnum(Name = "DESIGNATION_TYPE_COMMON", Value = 1)]
		DESIGNATION_TYPE_COMMON = 1,
		// Token: 0x040023BA RID: 9146
		[ProtoEnum(Name = "DESIGNATION_TYPE_RAID", Value = 2)]
		DESIGNATION_TYPE_RAID,
		// Token: 0x040023BB RID: 9147
		[ProtoEnum(Name = "DESIGNATION_TYPE_NEST", Value = 3)]
		DESIGNATION_TYPE_NEST,
		// Token: 0x040023BC RID: 9148
		[ProtoEnum(Name = "DESIGNATION_TYPE_BATTLE", Value = 4)]
		DESIGNATION_TYPE_BATTLE,
		// Token: 0x040023BD RID: 9149
		[ProtoEnum(Name = "DESIGNATION_TYPE_ACTIVITY", Value = 5)]
		DESIGNATION_TYPE_ACTIVITY
	}
}
