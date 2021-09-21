using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200082D RID: 2093
	[ProtoContract(Name = "DailyTaskIconType")]
	public enum DailyTaskIconType
	{
		// Token: 0x040027FB RID: 10235
		[ProtoEnum(Name = "DailyTaskIcon_AskHelp", Value = 1)]
		DailyTaskIcon_AskHelp = 1,
		// Token: 0x040027FC RID: 10236
		[ProtoEnum(Name = "DailyTaskIcon_BeHelp", Value = 2)]
		DailyTaskIcon_BeHelp,
		// Token: 0x040027FD RID: 10237
		[ProtoEnum(Name = "DailyTaskIcon_AskHelpDispear", Value = 3)]
		DailyTaskIcon_AskHelpDispear
	}
}
