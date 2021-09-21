using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020007FF RID: 2047
	[ProtoContract(Name = "WeekReportDataType")]
	public enum WeekReportDataType
	{
		// Token: 0x040026FA RID: 9978
		[ProtoEnum(Name = "WeekReportData_GuildSign", Value = 1)]
		WeekReportData_GuildSign = 1,
		// Token: 0x040026FB RID: 9979
		[ProtoEnum(Name = "WeekReportData_WorldBoss", Value = 2)]
		WeekReportData_WorldBoss,
		// Token: 0x040026FC RID: 9980
		[ProtoEnum(Name = "WeekReportData_GuildRisk", Value = 3)]
		WeekReportData_GuildRisk,
		// Token: 0x040026FD RID: 9981
		[ProtoEnum(Name = "WeekReportData_GuildArena", Value = 4)]
		WeekReportData_GuildArena,
		// Token: 0x040026FE RID: 9982
		[ProtoEnum(Name = "WeekReportData_GuildBoss", Value = 5)]
		WeekReportData_GuildBoss,
		// Token: 0x040026FF RID: 9983
		[ProtoEnum(Name = "WeekReportData_GuildTerryitory", Value = 6)]
		WeekReportData_GuildTerryitory
	}
}
