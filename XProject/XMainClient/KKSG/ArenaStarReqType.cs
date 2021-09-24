using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "ArenaStarReqType")]
	public enum ArenaStarReqType
	{

		[ProtoEnum(Name = "ASRT_ROLEDATA", Value = 1)]
		ASRT_ROLEDATA = 1,

		[ProtoEnum(Name = "ASRT_DIANZAN", Value = 2)]
		ASRT_DIANZAN
	}
}
