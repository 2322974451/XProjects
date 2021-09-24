using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "InvFightReqType")]
	public enum InvFightReqType
	{

		[ProtoEnum(Name = "IFRT_INV_ONE", Value = 1)]
		IFRT_INV_ONE = 1,

		[ProtoEnum(Name = "IFRT_REFUSH_ONE", Value = 2)]
		IFRT_REFUSH_ONE,

		[ProtoEnum(Name = "IFRT_IGNORE_ALL", Value = 3)]
		IFRT_IGNORE_ALL,

		[ProtoEnum(Name = "IFRT_REQ_LIST", Value = 4)]
		IFRT_REQ_LIST,

		[ProtoEnum(Name = "IFRT_ACCEPT_ONE", Value = 5)]
		IFRT_ACCEPT_ONE
	}
}
