using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "MSUseSumamryType")]
	public enum MSUseSumamryType
	{

		[ProtoEnum(Name = "MSUS_GET", Value = 1)]
		MSUS_GET = 1,

		[ProtoEnum(Name = "MSUS_FREE", Value = 2)]
		MSUS_FREE
	}
}
