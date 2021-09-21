using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020007C5 RID: 1989
	[ProtoContract(Name = "ResWarState")]
	public enum ResWarState
	{
		// Token: 0x040025AB RID: 9643
		[ProtoEnum(Name = "ResWarExploreState", Value = 1)]
		ResWarExploreState = 1,
		// Token: 0x040025AC RID: 9644
		[ProtoEnum(Name = "ResWarCancelState", Value = 2)]
		ResWarCancelState
	}
}
