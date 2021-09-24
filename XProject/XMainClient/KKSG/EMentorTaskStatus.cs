using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "EMentorTaskStatus")]
	public enum EMentorTaskStatus
	{

		[ProtoEnum(Name = "EMentorTask_UnComplete", Value = 1)]
		EMentorTask_UnComplete = 1,

		[ProtoEnum(Name = "EMentorTask_CanReport", Value = 2)]
		EMentorTask_CanReport,

		[ProtoEnum(Name = "EMentorTask_AlreadyReport", Value = 3)]
		EMentorTask_AlreadyReport,

		[ProtoEnum(Name = "EMentorTask_ConfirmReport", Value = 4)]
		EMentorTask_ConfirmReport,

		[ProtoEnum(Name = "EMentorTask_CompleteBefore", Value = 5)]
		EMentorTask_CompleteBefore,

		[ProtoEnum(Name = "EMentorTask_Max", Value = 6)]
		EMentorTask_Max
	}
}
