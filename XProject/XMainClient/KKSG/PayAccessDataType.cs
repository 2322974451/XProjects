using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "PayAccessDataType")]
	public enum PayAccessDataType
	{

		[ProtoEnum(Name = "PayAccess_SaveAmt", Value = 1)]
		PayAccess_SaveAmt = 1,

		[ProtoEnum(Name = "PayAccess_Other", Value = 2)]
		PayAccess_Other,

		[ProtoEnum(Name = "PayAccess_Send", Value = 3)]
		PayAccess_Send,

		[ProtoEnum(Name = "PayAccess_Consume", Value = 4)]
		PayAccess_Consume,

		[ProtoEnum(Name = "PayAccess_ALL", Value = 5)]
		PayAccess_ALL
	}
}
