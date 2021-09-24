using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "InvHReqType")]
	public enum InvHReqType
	{

		[ProtoEnum(Name = "INVH_REQ_UNF_LIST", Value = 1)]
		INVH_REQ_UNF_LIST = 1,

		[ProtoEnum(Name = "INVH_UNF_IGNORE_ALL", Value = 2)]
		INVH_UNF_IGNORE_ALL,

		[ProtoEnum(Name = "INVH_REFUSE_FORNOW", Value = 3)]
		INVH_REFUSE_FORNOW
	}
}
