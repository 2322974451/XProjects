using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020007C9 RID: 1993
	[ProtoContract(Name = "FunctionId")]
	public enum FunctionId
	{
		// Token: 0x040025C6 RID: 9670
		[ProtoEnum(Name = "FunctionId_QQVip", Value = 0)]
		FunctionId_QQVip,
		// Token: 0x040025C7 RID: 9671
		[ProtoEnum(Name = "FunctionId_IOSCheck", Value = 1)]
		FunctionId_IOSCheck,
		// Token: 0x040025C8 RID: 9672
		[ProtoEnum(Name = "FunctionId_StartPrivilege", Value = 2)]
		FunctionId_StartPrivilege
	}
}
