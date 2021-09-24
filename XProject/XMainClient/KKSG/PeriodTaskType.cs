using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "PeriodTaskType")]
	public enum PeriodTaskType
	{

		[ProtoEnum(Name = "PeriodTaskType_Daily", Value = 1)]
		PeriodTaskType_Daily = 1,

		[ProtoEnum(Name = "PeriodTaskType_Weekly", Value = 2)]
		PeriodTaskType_Weekly
	}
}
