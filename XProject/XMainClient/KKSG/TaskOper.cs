using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "TaskOper")]
	public enum TaskOper
	{

		[ProtoEnum(Name = "TaskOper_Set", Value = 1)]
		TaskOper_Set = 1,

		[ProtoEnum(Name = "TaskOper_Add", Value = 2)]
		TaskOper_Add,

		[ProtoEnum(Name = "TaskOper_Del", Value = 3)]
		TaskOper_Del
	}
}
