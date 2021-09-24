using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "DragonGuildTaskType")]
	public enum DragonGuildTaskType
	{

		[ProtoEnum(Name = "TASK_NORMAL", Value = 1)]
		TASK_NORMAL = 1,

		[ProtoEnum(Name = "TASK_ACHIVEMENT", Value = 2)]
		TASK_ACHIVEMENT
	}
}
