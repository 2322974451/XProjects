using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020007C4 RID: 1988
	[ProtoContract(Name = "IntegralState")]
	public enum IntegralState
	{
		// Token: 0x040025A6 RID: 9638
		[ProtoEnum(Name = "integralready", Value = 1)]
		integralready = 1,
		// Token: 0x040025A7 RID: 9639
		[ProtoEnum(Name = "integralenterscene", Value = 2)]
		integralenterscene,
		// Token: 0x040025A8 RID: 9640
		[ProtoEnum(Name = "integralwatch", Value = 3)]
		integralwatch,
		// Token: 0x040025A9 RID: 9641
		[ProtoEnum(Name = "integralend", Value = 4)]
		integralend
	}
}
