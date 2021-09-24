using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "PkReqType")]
	public enum PkReqType
	{

		[ProtoEnum(Name = "PKREQ_ADDPK", Value = 1)]
		PKREQ_ADDPK = 1,

		[ProtoEnum(Name = "PKREQ_REMOVEPK", Value = 2)]
		PKREQ_REMOVEPK,

		[ProtoEnum(Name = "PKREQ_ALLINFO", Value = 3)]
		PKREQ_ALLINFO,

		[ProtoEnum(Name = "PKREQ_FETCHPOINTREWARD", Value = 4)]
		PKREQ_FETCHPOINTREWARD
	}
}
