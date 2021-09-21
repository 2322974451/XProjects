using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000828 RID: 2088
	[ProtoContract(Name = "PeriodTaskType")]
	public enum PeriodTaskType
	{
		// Token: 0x040027E4 RID: 10212
		[ProtoEnum(Name = "PeriodTaskType_Daily", Value = 1)]
		PeriodTaskType_Daily = 1,
		// Token: 0x040027E5 RID: 10213
		[ProtoEnum(Name = "PeriodTaskType_Weekly", Value = 2)]
		PeriodTaskType_Weekly
	}
}
