using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "AntiAddictionReportType")]
	public enum AntiAddictionReportType
	{

		[ProtoEnum(Name = "ReportTypeSingle", Value = 1)]
		ReportTypeSingle = 1,

		[ProtoEnum(Name = "ReportTypeTotal", Value = 2)]
		ReportTypeTotal
	}
}
