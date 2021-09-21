using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020007CC RID: 1996
	[ProtoContract(Name = "AntiAddictionReportType")]
	public enum AntiAddictionReportType
	{
		// Token: 0x040025D4 RID: 9684
		[ProtoEnum(Name = "ReportTypeSingle", Value = 1)]
		ReportTypeSingle = 1,
		// Token: 0x040025D5 RID: 9685
		[ProtoEnum(Name = "ReportTypeTotal", Value = 2)]
		ReportTypeTotal
	}
}
