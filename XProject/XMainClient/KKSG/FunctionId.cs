using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "FunctionId")]
	public enum FunctionId
	{

		[ProtoEnum(Name = "FunctionId_QQVip", Value = 0)]
		FunctionId_QQVip,

		[ProtoEnum(Name = "FunctionId_IOSCheck", Value = 1)]
		FunctionId_IOSCheck,

		[ProtoEnum(Name = "FunctionId_StartPrivilege", Value = 2)]
		FunctionId_StartPrivilege
	}
}
