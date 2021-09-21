using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020007D4 RID: 2004
	[ProtoContract(Name = "EMentorMsgOpType")]
	public enum EMentorMsgOpType
	{
		// Token: 0x04002605 RID: 9733
		[ProtoEnum(Name = "EMentorMsgOp_Get", Value = 1)]
		EMentorMsgOp_Get = 1,
		// Token: 0x04002606 RID: 9734
		[ProtoEnum(Name = "EMentorMsgOpType_Clear", Value = 2)]
		EMentorMsgOpType_Clear,
		// Token: 0x04002607 RID: 9735
		[ProtoEnum(Name = "EMentorMsgOpType_Agree", Value = 3)]
		EMentorMsgOpType_Agree,
		// Token: 0x04002608 RID: 9736
		[ProtoEnum(Name = "EMentorMsgOpType_Reject", Value = 4)]
		EMentorMsgOpType_Reject,
		// Token: 0x04002609 RID: 9737
		[ProtoEnum(Name = "EMentorMsgOpType_Max", Value = 5)]
		EMentorMsgOpType_Max
	}
}
