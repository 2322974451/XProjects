using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "DragonGuildTaskConditionType")]
	public enum DragonGuildTaskConditionType
	{

		[ProtoEnum(Name = "TASK_PASS_SCENE", Value = 1)]
		TASK_PASS_SCENE = 1,

		[ProtoEnum(Name = "TASK_PASS_NODIE", Value = 2)]
		TASK_PASS_NODIE,

		[ProtoEnum(Name = "TASK_TIME_SPAN", Value = 3)]
		TASK_TIME_SPAN,

		[ProtoEnum(Name = "TASK_PASS_PARTNER_COUNT", Value = 4)]
		TASK_PASS_PARTNER_COUNT
	}
}
