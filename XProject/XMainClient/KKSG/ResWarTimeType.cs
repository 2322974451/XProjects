using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020007BD RID: 1981
	[ProtoContract(Name = "ResWarTimeType")]
	public enum ResWarTimeType
	{
		// Token: 0x0400257B RID: 9595
		[ProtoEnum(Name = "RealyTime", Value = 1)]
		RealyTime = 1,
		// Token: 0x0400257C RID: 9596
		[ProtoEnum(Name = "RaceTime", Value = 2)]
		RaceTime,
		// Token: 0x0400257D RID: 9597
		[ProtoEnum(Name = "EndTime", Value = 3)]
		EndTime,
		// Token: 0x0400257E RID: 9598
		[ProtoEnum(Name = "ResWarNone", Value = 4)]
		ResWarNone
	}
}
