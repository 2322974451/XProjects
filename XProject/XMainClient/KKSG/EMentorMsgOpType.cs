using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "EMentorMsgOpType")]
	public enum EMentorMsgOpType
	{

		[ProtoEnum(Name = "EMentorMsgOp_Get", Value = 1)]
		EMentorMsgOp_Get = 1,

		[ProtoEnum(Name = "EMentorMsgOpType_Clear", Value = 2)]
		EMentorMsgOpType_Clear,

		[ProtoEnum(Name = "EMentorMsgOpType_Agree", Value = 3)]
		EMentorMsgOpType_Agree,

		[ProtoEnum(Name = "EMentorMsgOpType_Reject", Value = 4)]
		EMentorMsgOpType_Reject,

		[ProtoEnum(Name = "EMentorMsgOpType_Max", Value = 5)]
		EMentorMsgOpType_Max
	}
}
