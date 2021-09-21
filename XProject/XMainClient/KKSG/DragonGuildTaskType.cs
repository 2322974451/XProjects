using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000821 RID: 2081
	[ProtoContract(Name = "DragonGuildTaskType")]
	public enum DragonGuildTaskType
	{
		// Token: 0x040027B0 RID: 10160
		[ProtoEnum(Name = "TASK_NORMAL", Value = 1)]
		TASK_NORMAL = 1,
		// Token: 0x040027B1 RID: 10161
		[ProtoEnum(Name = "TASK_ACHIVEMENT", Value = 2)]
		TASK_ACHIVEMENT
	}
}
