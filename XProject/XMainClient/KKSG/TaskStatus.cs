using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "TaskStatus")]
	public enum TaskStatus
	{

		[ProtoEnum(Name = "TaskStatus_CanTake", Value = 1)]
		TaskStatus_CanTake = 1,

		[ProtoEnum(Name = "TaskStatus_Taked", Value = 2)]
		TaskStatus_Taked,

		[ProtoEnum(Name = "TaskStatus_Finish", Value = 3)]
		TaskStatus_Finish,

		[ProtoEnum(Name = "TaskStatus_Over", Value = 4)]
		TaskStatus_Over
	}
}
