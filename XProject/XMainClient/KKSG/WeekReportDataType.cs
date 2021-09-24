using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "WeekReportDataType")]
	public enum WeekReportDataType
	{

		[ProtoEnum(Name = "WeekReportData_GuildSign", Value = 1)]
		WeekReportData_GuildSign = 1,

		[ProtoEnum(Name = "WeekReportData_WorldBoss", Value = 2)]
		WeekReportData_WorldBoss,

		[ProtoEnum(Name = "WeekReportData_GuildRisk", Value = 3)]
		WeekReportData_GuildRisk,

		[ProtoEnum(Name = "WeekReportData_GuildArena", Value = 4)]
		WeekReportData_GuildArena,

		[ProtoEnum(Name = "WeekReportData_GuildBoss", Value = 5)]
		WeekReportData_GuildBoss,

		[ProtoEnum(Name = "WeekReportData_GuildTerryitory", Value = 6)]
		WeekReportData_GuildTerryitory
	}
}
