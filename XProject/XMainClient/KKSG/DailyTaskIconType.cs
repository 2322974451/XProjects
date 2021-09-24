using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "DailyTaskIconType")]
	public enum DailyTaskIconType
	{

		[ProtoEnum(Name = "DailyTaskIcon_AskHelp", Value = 1)]
		DailyTaskIcon_AskHelp = 1,

		[ProtoEnum(Name = "DailyTaskIcon_BeHelp", Value = 2)]
		DailyTaskIcon_BeHelp,

		[ProtoEnum(Name = "DailyTaskIcon_AskHelpDispear", Value = 3)]
		DailyTaskIcon_AskHelpDispear
	}
}
