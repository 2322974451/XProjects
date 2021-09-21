using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020007FC RID: 2044
	[ProtoContract(Name = "SkyCraftType")]
	public enum SkyCraftType
	{
		// Token: 0x040026EE RID: 9966
		[ProtoEnum(Name = "SCT_RacePoint", Value = 1)]
		SCT_RacePoint = 1,
		// Token: 0x040026EF RID: 9967
		[ProtoEnum(Name = "SCT_Eliminate", Value = 2)]
		SCT_Eliminate
	}
}
