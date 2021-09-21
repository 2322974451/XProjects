using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020007F3 RID: 2035
	[ProtoContract(Name = "KMatchType")]
	public enum KMatchType
	{
		// Token: 0x040026C2 RID: 9922
		[ProtoEnum(Name = "KMT_NONE", Value = 0)]
		KMT_NONE,
		// Token: 0x040026C3 RID: 9923
		[ProtoEnum(Name = "KMT_EXP", Value = 1)]
		KMT_EXP,
		// Token: 0x040026C4 RID: 9924
		[ProtoEnum(Name = "KMT_PVP", Value = 2)]
		KMT_PVP,
		// Token: 0x040026C5 RID: 9925
		[ProtoEnum(Name = "KMT_HERO", Value = 3)]
		KMT_HERO,
		// Token: 0x040026C6 RID: 9926
		[ProtoEnum(Name = "KMT_PK", Value = 4)]
		KMT_PK,
		// Token: 0x040026C7 RID: 9927
		[ProtoEnum(Name = "KMT_LEAGUE", Value = 5)]
		KMT_LEAGUE,
		// Token: 0x040026C8 RID: 9928
		[ProtoEnum(Name = "KMT_SKYCRAFT", Value = 6)]
		KMT_SKYCRAFT,
		// Token: 0x040026C9 RID: 9929
		[ProtoEnum(Name = "KMT_PKTWO", Value = 7)]
		KMT_PKTWO,
		// Token: 0x040026CA RID: 9930
		[ProtoEnum(Name = "KMT_MOBA", Value = 8)]
		KMT_MOBA,
		// Token: 0x040026CB RID: 9931
		[ProtoEnum(Name = "KMT_WEEKEND_ACT", Value = 9)]
		KMT_WEEKEND_ACT,
		// Token: 0x040026CC RID: 9932
		[ProtoEnum(Name = "KMT_CUSTOM_PKTWO", Value = 10)]
		KMT_CUSTOM_PKTWO,
		// Token: 0x040026CD RID: 9933
		[ProtoEnum(Name = "KMT_SURVIVE", Value = 11)]
		KMT_SURVIVE
	}
}
