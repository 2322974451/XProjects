using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000822 RID: 2082
	[ProtoContract(Name = "DragonGuildTaskConditionType")]
	public enum DragonGuildTaskConditionType
	{
		// Token: 0x040027B3 RID: 10163
		[ProtoEnum(Name = "TASK_PASS_SCENE", Value = 1)]
		TASK_PASS_SCENE = 1,
		// Token: 0x040027B4 RID: 10164
		[ProtoEnum(Name = "TASK_PASS_NODIE", Value = 2)]
		TASK_PASS_NODIE,
		// Token: 0x040027B5 RID: 10165
		[ProtoEnum(Name = "TASK_TIME_SPAN", Value = 3)]
		TASK_TIME_SPAN,
		// Token: 0x040027B6 RID: 10166
		[ProtoEnum(Name = "TASK_PASS_PARTNER_COUNT", Value = 4)]
		TASK_PASS_PARTNER_COUNT
	}
}
