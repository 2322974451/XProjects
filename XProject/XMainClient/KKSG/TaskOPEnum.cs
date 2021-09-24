using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "TaskOPEnum")]
	public enum TaskOPEnum
	{

		[ProtoEnum(Name = "TAKE_TASK", Value = 1)]
		TAKE_TASK = 1,

		[ProtoEnum(Name = "FINISH_TASK", Value = 2)]
		FINISH_TASK
	}
}
